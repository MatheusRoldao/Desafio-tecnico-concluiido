using WebApresentacao.Domain.Entities;
using WebApresentacao.Infra.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace WebApresentacao.Infra.Contexts
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        //Seta as Classes que devem estar no banco de dados e atribui o Get e Set
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cidade> Cidade { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            base.OnModelCreating(modelBuilder);
        }
    }
}
