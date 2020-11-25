using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLServer.Controllers
{
    [Route("[controller]")]
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
        public async Task<IActionResult> Post([FromBody] GraphQLQueryObject query)
        {

            var request = Request;

            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            if (result.Operation.Name == "IntrospectionQuery")
            {
                return Ok(new { Data = result.Data });
            }

            return Ok(result.Data);
        }

        public class GraphQLQueryObject
        {
            public string OperationName { get; set; }
            public string NamedQuery { get; set; }
            public string Query { get; set; }
            public string Variables { get; set; }
        }
    }
}
