using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Modelo
    {
        public int Id { get; set; }
        public String Denominacion { get; set; }
        public Boolean Estado { get; set; }

        public override string ToString()
        {
            return Denominacion;
        }
    }
}
