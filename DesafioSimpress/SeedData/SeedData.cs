using DesafioSimpress.Context;
using DesafioSimpress.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioSimpress.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LojaContext( serviceProvider.GetRequiredService<DbContextOptions<LojaContext>>()))
            {
                // Look for any movies.
                if (context.Categorias.Any())
                    return;   // DB has been seeded

                context.Categorias.AddRange(
                new Categoria { Nome = "Eletrônico", Descricao = "Eletrônico", Ativo = true },
                new Categoria { Nome = "Informática", Descricao = "Produtos para Informática", Ativo = true },
                new Categoria { Nome = "Celulares", Descricao = "Aparelhos e acessórios", Ativo = true },
                new Categoria { Nome = "Moda", Descricao = "Artigos para vestuário em geral", Ativo = true },
                new Categoria { Nome = "Livros", Descricao = "Livros", Ativo = true }
            );

                context.SaveChanges();
            }
        }
    }
}
