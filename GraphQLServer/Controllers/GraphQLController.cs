using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace GraphQLServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQLController : Controller
    {

        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;

        public GraphQLController(ISchema schema, IDocumentExecuter executer)
        {
            _schema = schema; //referenced in start up
            _executer = executer;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQueryObject payload)
        {
            var inputs = payload.Variables?.ToString().ToInputs();

            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = payload.Query;
                _.OperationName = payload.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest(new { Errors = result.Errors, Data = result.Data }); //Return error with data according to GRAPHQL spec
            }

            return Ok(new { Data = result.Data }); //All data should be returned in a data field
        }

        public class GraphQLQueryObject
        {
            [DisplayName("operationName")]
            public string OperationName { get; set; }      
            
            [Required] //I think this is safe. Will test with further adventures.
            [DisplayName("query")]
            public string Query { get; set; }

            [DisplayName("variables")]
            public JObject Variables { get; set; }
        }
    }
}
