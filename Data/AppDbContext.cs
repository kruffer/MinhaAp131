using Microsoft.EntityFrameworkCore;
using MinhaApi31.Models;

namespace MinhaApi31.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {       
        }

        public DbSet<Produto> Produtos {get; set;}
    }
    
}