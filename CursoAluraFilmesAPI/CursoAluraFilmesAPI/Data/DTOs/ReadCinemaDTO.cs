using System.ComponentModel.DataAnnotations;

namespace CursoAluraFilmesAPI.Data.DTOs
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ReadEnderecoDTO Endereco { get; set; }
    }
}
