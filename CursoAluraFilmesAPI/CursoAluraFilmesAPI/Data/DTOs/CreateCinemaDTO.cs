using System.ComponentModel.DataAnnotations;

namespace CursoAluraFilmesAPI.Data.DTOs
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
    }
}
