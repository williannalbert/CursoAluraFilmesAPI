using System.ComponentModel.DataAnnotations;

namespace CursoAluraFilmesAPI.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }
        //[Required]
        //retirado o required para que não haja conflito de dados na migration devido ao id 0
        public int? CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
