using AutoMapper;
using BibliotecaPessoal.Data.Dtos;
using BibliotecaPessoal.Models;

namespace BibliotecaPessoal.Profiles
{
    public class LivroProfile:Profile
    {
        public LivroProfile()
        {
            CreateMap<CreateLivroDto, Livro>();
            CreateMap<Livro, ReadLivroDto>();
            CreateMap<UpdateLivroDto, Livro>();
        }
    }
}
