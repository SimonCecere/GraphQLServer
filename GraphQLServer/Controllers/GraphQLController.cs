using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> Post([FromBody] [Bind]GraphQLQueryObject payload)
        {
            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = payload.Query;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest(new { Errors = result.Errors, Data = result.Data }); //Return error with data according to GRAPHQL spec
            }

            return Ok(new { Data = result.Data }); //All data should be return in a data field
        }

        public class GraphQLQueryObject
        {
            public string OperationName { get; set; }        
            public string Query { get; set; }
            public Object Variables { get; set; }
        }
    }
}
