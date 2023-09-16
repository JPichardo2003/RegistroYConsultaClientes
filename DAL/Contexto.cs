using Microsoft.EntityFrameworkCore;
using ClientesApp.Models;

namespace ClientesApp.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options) { }
        public DbSet<Clientes> Clientes { get; set; }
    }
}
