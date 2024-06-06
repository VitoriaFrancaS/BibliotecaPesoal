using AutoMapper;
using BibliotecaPessoal.Data;
using BibliotecaPessoal.Data.Dtos;
using BibliotecaPessoal.Models;
using Microsoft.AspNetCore.Mvc;


namespace BibliotecaPessoal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivroController:ControllerBase
{
    private readonly BibliotecaContext _context;
    private readonly IMapper _mapper;

    public LivroController(BibliotecaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //POST = api/livro
    [HttpPost]
    public IActionResult AdicionarLivro([FromBody] CreateLivroDto livroDto)
    {
        Livro livro = _mapper.Map<Livro>(livroDto);
        _context.Livros.Add(livro);
        _context.SaveChanges();
        return Ok(livro);
    }
    //GET = api/livro
    [HttpGet]
    public ActionResult<IEnumerable<ReadLivroDto>> ListarLivros()
    {
        var livro = _context.Livros.ToList();
        if (livro == null || livro.Count == 0)
        { 
            return NotFound(); 
        }
        var livroDto = _mapper.Map<List<ReadLivroDto>>(livro);
        return Ok(livroDto);
    }

    //GET = api/livro/search?titulo={titulo}
    [HttpGet("{search}")]
    public ActionResult<IEnumerable<ReadLivroDto>> BuscaTitulo([FromQuery]string titulo)
    {
        var livro = _context.Livros.Where(l => l.Titulo.Contains(titulo)).ToList();
        if(livro == null) return NotFound();
        return Ok(livro);
    }

    //PUT = api/livro/{id}
    [HttpPut("{id}")]
    public IActionResult AtualizacaoDeLivro(int id, [FromBody] UpdateLivroDto livroDto )
    {
        var livro = _context.Livros.FirstOrDefault(l => l.Id == id);
        if (livro == null) return NotFound();
        _mapper.Map(livroDto, livro);
        _context.SaveChanges();
        return NoContent();
    }

    //DELETE = api/livro/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLivroAsync(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro == null) return NotFound();
        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}
