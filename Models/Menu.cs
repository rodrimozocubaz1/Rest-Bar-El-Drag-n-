using System.ComponentModel.DataAnnotations;

namespace Rest_Bar_El_Drag_n_.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Foto { get; set; }
        public string Descripcion { get; set; }
    }
}