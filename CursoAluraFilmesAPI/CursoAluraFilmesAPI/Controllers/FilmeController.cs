using AutoMapper;
using CursoAluraFilmesAPI.Data;
using CursoAluraFilmesAPI.Data.DTOs;
using CursoAluraFilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
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
     * MICROSOFT NEWTONSOFTJSON
     * automapper adicionado em program.cs
     * newtonsoft adicionado no program.cs
     * anotações da documentação do Swagger são definidar na program.cs e  na solução do projeto(dois cliques na solução)
     */

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Adiciona filme ao banco de dados
    /// </summary>
    /// <param name="filmeDTO">Objeto com informações do filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inclusão seja realizada com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody]CreateFilmeDTO filmeDTO)
    {
        Filme filme = _mapper.Map<Filme>(filmeDTO); 
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RetornaFilme), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDTO> RetornaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10) 
    {
        return _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RetornaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null)
            return NotFound();

        var filmeDto = _mapper.Map<ReadFilmeDTO>(filme);
        return Ok(filmeDto);
    }
    [HttpPut("{id}")]
    public IActionResult AtualizarFilmePut(int id, [FromBody] UpdateFilmeDTO filmeDTO)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null) return NotFound();

        _mapper.Map(filmeDTO, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarFilmePatch(int id, JsonPatchDocument<UpdateFilmeDTO> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeAtualizar = _mapper.Map<UpdateFilmeDTO>(filme);
        patch.ApplyTo(filmeAtualizar, ModelState);

        if (!TryValidateModel(filmeAtualizar))
            return ValidationProblem(ModelState);

        _mapper.Map(filmeAtualizar, filme);
        _context.SaveChanges();
        return NoContent();

        /*CORPO DO JSON NO POSTMAN
         * [
                {
                    "op":"replace",
                    "path":"/duracao",
                    "value":250
                }
            ]
         */
    }
    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges(); 
        return NoContent();
    }
}
