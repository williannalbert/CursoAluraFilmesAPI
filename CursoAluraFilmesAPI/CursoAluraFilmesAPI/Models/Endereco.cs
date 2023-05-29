using System.ComponentModel.DataAnnotations;

namespace CursoAluraFilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        //Define a relação de 1 - 1 entre cinema e endereço. inclusão feita nas duas classes
        public virtual Cinema Cinema { get; set; }
    }
}
