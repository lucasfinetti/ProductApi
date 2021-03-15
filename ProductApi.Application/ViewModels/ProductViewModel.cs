using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Valor é obrigatório.")]
        [DisplayName("Value")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "A Imagem é obrigatório.")]
        [DisplayName("Imagem")]
        public string Image { get; set; }
    }
}
