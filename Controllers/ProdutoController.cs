using Microsoft.AspNetCore.Mvc;
using MinhaApi31.Models;
using System.Collections.Generic;
using System.Linq;
namespace MinhaApi31.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
    private static List<Produto> produtos = new List<Produto>();
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            produto.Id = produtos.Count +1;
            produtos.Add(produto);
            return Created("", produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            return NotFound();

            produtos.Remove(produto); 
            return NoContent();
        }
    }
}