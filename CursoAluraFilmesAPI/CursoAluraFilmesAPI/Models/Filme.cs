using System.ComponentModel.DataAnnotations;

namespace CursoAluraFilmesAPI.Models;

public class Filme
{
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O genero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho máximo do gênero é 50 caracteres")]
    public string Genero { get; set; }
    [Required]
    [Range(70, 600, ErrorMessage = "Duração deve ter entre 70 e 600 min")]
    public int Duracao { get; set; }
}
