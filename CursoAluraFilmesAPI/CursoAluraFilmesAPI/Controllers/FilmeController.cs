using AutoMapper;
using CursoAluraFilmesAPI.Data;
using CursoAluraFilmesAPI.Data.DTOs;
using CursoAluraFilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoAluraFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    /*INSTALAR 
     * ENTITY FRAMEWORK 
     * ENTITY FRAMEWORK TOOLS
     * POMELO ENTITY MYSQL
     * AUTOMAPPER
     * AUTOMAPPER DEPENDECYINJECTION
     * automapper adicionado em program.cs
     */

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody]CreateFilmeDTO filmeDTO)
    {
        Filme filme = _mapper.Map<Filme>(filmeDTO); 
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RetornaFilme), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RetornaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10) 
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RetornaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null)
            return NotFound();
        return Ok(filme);
    }
}
