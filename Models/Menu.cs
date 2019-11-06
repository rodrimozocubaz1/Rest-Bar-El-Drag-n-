using System.ComponentModel.DataAnnotations;

namespace Rest_Bar_El_Drag_n_.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Foto { get; set; }
        [Required]
        public string Descripcion { get; set; }
        
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}