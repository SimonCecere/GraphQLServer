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
using System.Diagnostics;

namespace GraphQLServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQLController : Controller
    {

        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;
        private readonly IDocumentWriter _writer;

        public GraphQLController(ISchema schema, IDocumentExecuter executer, IDocumentWriter writer)
        {
            _schema = schema; //referenced in start up
            _executer = executer;
            _writer = writer;
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

            //The result already comes out as an object. However IDocumentWriter pulls out what should be returned out of that object.
            //Serialize result into JSON string based on result that is produced
            var jsonString = await _writer.WriteToStringAsync(result);
            var jsonObject = JObject.Parse(jsonString);

            if (result.Errors?.Count > 0)
            {
                //Return error with data according to GRAPHQL spec
                return BadRequest(jsonObject); 
            }

            return Ok(jsonObject);
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
