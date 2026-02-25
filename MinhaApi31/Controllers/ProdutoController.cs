using Microsoft.AspNetCore.Mvc;
using MinhaApi31.Models;
using System.Collections.Generic;
using System.Linq;
using MinhaApi31.Data;

namespace MinhaApi31.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Produtos.ToList());
    }

    [HttpPost]
    public IActionResult Post(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Produto produtoAtualizado)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null) return NotFound();

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        produto.Estoque = produtoAtualizado.Estoque;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null) return NotFound();

        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        return NoContent();
    }
}
}