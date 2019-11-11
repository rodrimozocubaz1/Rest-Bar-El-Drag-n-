using System.ComponentModel.DataAnnotations;

namespace Rest_Bar_El_Drag_n_.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        [Required]
        public int CantidadP { get; set; }
        [Required]
        public string Fecha { get; set; }
        [Required]
        public int Hora { get; set; }
        [Required]
        public int DNI { get; set; }
    }
}