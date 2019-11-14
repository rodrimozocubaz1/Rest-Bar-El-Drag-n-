using System;
using Microsoft.AspNetCore.Identity;

namespace Rest_Bar_El_Drag_n_.Models
{
    public class Usuario : IdentityUser
    {
        

        public string  Nombre { get; set; }

        public string Apellidos { get; set; }

        public int Puntos { get; set;}

        public string Telefono{ get; set;}

        public DateTime Fecha{ get;set;}


        public Usuario(){
            this.Fecha= DateTime.Now;
        }
        

    }
}