using System;
using System.ComponentModel.DataAnnotations;

namespace Rest_Bar_El_Drag_n_.Models
{
    public class Compra
    {
        public int Id { get; set; }
        [Required]
        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; }
        
        public Menu Menu { get; set; }


        public int MenuId { get; set; }

        public int UsuarioId { get; set; }
        public Compra() {
            Fecha = DateTime.Now;
        }
    }
}

