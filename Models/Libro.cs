using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoCRUD.Models
{
    public class Libro
    {
        [Key] // Llave primaria
        public int Id { get; set; }

        [Display(Name="Título")] //Permit visualizar el acento
        public string Titulo { get; set; }

        public string Descripcion { get; set; }
        [DataType(DataType.Date)] //Formato fecha corta
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage ="El nombre del autor es requerido")]
        public string Autor { get; set; }

        [Required(ErrorMessage ="El precio del libro es rquerido")]
        public int PrecioLibro { get; set; }

    }
}
