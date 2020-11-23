using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLServer.Controllers
{
    public class GraphQLController : Controller
    {
        public GraphQLController()
        {

        }


        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }
    }
}
