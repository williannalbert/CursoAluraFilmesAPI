using CursoAluraFilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoAluraFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 1;

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody]Filme filme)
    {
        filme.Id = id++; 
        filmes.Add(filme);
        return CreatedAtAction(nameof(RetornaFilme), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RetornaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10) 
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RetornaFilme(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null)
            return NotFound();
        return Ok(filme);
    }
}
