using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sales.Shared.Entities
{
    public class State
	{
        public int Id { get; set; }

        [Display(Name = "Departamento/Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int CountryId { get; set; }

        public Country? Country { get; set; }

        //Propiedad Virtual de Consulta
        [Display(Name = "Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

        //Relaciones en doble via
        public ICollection<City>? Cities { get; set; }
    }
}

