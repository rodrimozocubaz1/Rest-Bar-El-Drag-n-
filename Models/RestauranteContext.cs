using Microsoft.EntityFrameworkCore;

namespace Rest_Bar_El_Drag_n_.Models
{
    public class RestauranteContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public RestauranteContext(DbContextOptions<RestauranteContext> o) : base (o) {
        }
    }
}