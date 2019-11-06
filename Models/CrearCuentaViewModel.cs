using System;
using System.ComponentModel.DataAnnotations;

namespace Rest_Bar_El_Drag_n_.Models
{
    public class CrearCuentaViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public DateTime FechaNac { get; set; }

        [Required]

        public string Sexo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name="Correo electrónico")]
        public string Correo { get; set; }

        [Required]
        [Display(Name="Contraseña")]
        [DataType(DataType.Password)]
        public string Password1 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirmar Contraseña")]
        [Compare("Password1", ErrorMessage = "Las contraseñas no coinciden")]
        public string Password2 { get; set; }
        
        public int puntos { get; set; }
    }
}