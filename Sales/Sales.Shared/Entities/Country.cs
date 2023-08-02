using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracter")]
        [Display(Name = "Pais")]
        public string Name { get; set; } = null!;


    }
}

