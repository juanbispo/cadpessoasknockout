using CadPessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace CadPessoas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
