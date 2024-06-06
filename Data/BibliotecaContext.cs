using BibliotecaPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaPessoal.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {

        }
        public DbSet<Livro> Livros { get; set; }
    }


}
