using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string CedulaIdentidad { get; set; }
        public string Clave { get; set; }
        public Guid IdPerfil { get; set; }
        public Perfil Perfil { get; set; }
        public bool Estado { get; set; }
        public bool SolicitarClave { get; set; }
    }
}
