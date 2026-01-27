using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MinhaApi31.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API .NET core 3.1 funcionando!");
        }
    }
}