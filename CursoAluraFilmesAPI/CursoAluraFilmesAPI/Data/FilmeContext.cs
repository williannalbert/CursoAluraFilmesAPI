using CursoAluraFilmesAPI.Controllers;
using CursoAluraFilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoAluraFilmesAPI.Data;

public class FilmeContext : DbContext
{
    //Carregamento da database é feita na program.cs
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) 
    {
        
    }

    public DbSet<Filme> Filmes { get; set; }    
    public DbSet<Cinema> Cinemas{ get; set; }    
    public DbSet<Endereco> Enderecos{ get; set; }

    public DbSet<Sessao> Sessoes { get; set; }
}
