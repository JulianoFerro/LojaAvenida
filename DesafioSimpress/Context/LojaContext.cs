using DesafioSimpress.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioSimpress.Context
{
    public class LojaContext : DbContext
    {

        public LojaContext(DbContextOptions<LojaContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("tblProduto");
            modelBuilder.Entity<Categoria>().ToTable("tblCategoria");
        }
    }
}
