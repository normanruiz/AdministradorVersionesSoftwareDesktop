using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Plantilla
    {
        public int Id { get; set; }
        public Proveedor Proveedor { get; set; }
        public Modelo Modelo { get; set; }
        public String Denominacion { get; set; }
        public String Salto { get; set; }
        public Estado Estado { get; set; }
        public Software Software { get; set; }
        public Medio Medio { get; set; }
        public String Actualizacion { get; set; }
        public Dictionary<String, Boolean> Funcionalidades { get; set; }
    }
}
