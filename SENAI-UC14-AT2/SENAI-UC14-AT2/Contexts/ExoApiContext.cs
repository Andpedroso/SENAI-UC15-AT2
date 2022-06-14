using Microsoft.EntityFrameworkCore;
using SENAI_UC14_AT2.Models;

namespace SENAI_UC14_AT2.Contexts
{
    public class ExoApiContext : DbContext
    {
        public ExoApiContext() { }

        public ExoApiContext(DbContextOptions<ExoApiContext> options) : base(options) { }

        protected override void
            OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=DESKTOP-Q4INLOT\\SQLEXPRESS;" +
                    "Initial Catalog=ExoApi;" +
                    "Integrated Security=False;" +
                    "User Id=sa;" +
                    "Password=server");
            }
        }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
