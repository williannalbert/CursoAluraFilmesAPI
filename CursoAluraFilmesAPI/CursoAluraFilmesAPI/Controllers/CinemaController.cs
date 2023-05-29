using AutoMapper;
using CursoAluraFilmesAPI.Data;
using CursoAluraFilmesAPI.Data.DTOs;
using CursoAluraFilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoAluraFilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;
    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDTO cinemaDTO)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RetornaCinemasPorId), new { Id = cinema.Id }, cinemaDTO);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> RetornaCinemas()
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RetornaCinemasPorId(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if(cinema == null)
            return NotFound();

        ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDTO cinemaDto)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaCinema(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}
