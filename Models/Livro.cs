using System.ComponentModel.DataAnnotations;

namespace BibliotecaPessoal.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="O título não pode conter mais de 100 caracteres")]
        public string Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Editora { get; set; }
        [Required]
        [StringLength(5000, ErrorMessage ="A capa do livro não pode ter mais de 5000 mil caracteres")]
        public string Capa { get; set; }
        [Required]
        [StringLength(2000, ErrorMessage ="Sua resenha não pode ter mais de 2000 mil caracteres")]
        public string Resenha { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "A nota nã pode passar de 10")]
        public int Nota { get; set; }
    }
}
