
using Banco.Models;
using Microsoft.EntityFrameworkCore;

namespace Banco
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Transferencia> transferencias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Transferencias;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        
    }

}


