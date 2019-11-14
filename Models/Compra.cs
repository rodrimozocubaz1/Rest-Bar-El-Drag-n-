using System;
using System.ComponentModel.DataAnnotations;

namespace Rest_Bar_El_Drag_n_.Models
{
    public class Compra
    {
        public int Id { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public string Direccion { get; set; }

        public DateTime Fecha { get; set; }
        [Required]
        public string TipoPago { get; set; }
        
        public Menu Menu { get; set; }

        public Usuario Usuario { get; set; }
        [Required]
        public int MenuId { get; set; }
        [Required]
        public float Total{ get; set;}
        [Required]
        public string UsuarioId { get; set; }
        public Compra() {
            Fecha = DateTime.Now;
        }
    }
}

