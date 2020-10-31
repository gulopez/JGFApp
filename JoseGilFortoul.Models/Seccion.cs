using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class Seccion
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public int Orden { get; set; }
    }
}
