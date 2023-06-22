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

        //"virtual" - Define a relação de 1 - 1 entre cinema e endereço e recupera a instancia do endereço
        //para recuperar endereço é necessário instalar Microsoft.EntityFrameworkCore.Proxies - versão 6.0.10 da solução
        //instanciar UseLazyLoadingProxies no program.cs
        public virtual Endereco Endereco { get; set; }
    }
}
