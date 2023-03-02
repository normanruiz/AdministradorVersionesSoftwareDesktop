using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Plantilla
    {
        public int Id { get; set; }
        public Proveedor Proveedor { get; set; }
        public String Denominacion { get; set; }
        public Plantilla Salto { get; set; }
        public Estado Estado { get; set; }
        public Software Software { get; set; }
        public Medio Medio { get; set; }
        public Actualizacion Actualizacion { get; set; }
        public Dictionary<Funcionalidad, Boolean> Funcionalidades { get; set; }
    }
}
