using System.ComponentModel.DataAnnotations;

namespace ASP.NET.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="El Nombre es obligatorio")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El Apellido es obligatorio")]
        public string Apellidos { get; set; }
        [Required (ErrorMessage = "La Edad es obligatoria")]
        public int Edad { get; set; }
        [Required (ErrorMessage = "El Sexo es obligatorio")]
        public string Sexo { get; set; }
        public System.DateTime FechaRegistro { get; set; }


    }
}
