using System.ComponentModel.DataAnnotations;

namespace CursoAluraFilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="O campo nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        
        //Define a relação de 1 - 1 entre cinema e endereço
        public virtual Endereco Endereco { get; set; }
    }
}
