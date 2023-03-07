using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public AccesoDatos()
        {
            conexion = new SqlConnection("Data Source=WDBS-DVPM040; Initial Catalog=LaposTecno;Integrated Security=True;");
            comando = new SqlCommand();
        }

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public void conectar()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public void setearConsulta(string consulta)
        {
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                lector = comando.ExecuteReader();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public void cerrar()
        {
            try
            {
                if (lector != null)
                {
                    lector.Close();
                }
                conexion.Close();

            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public void setearParametro(string parametro, Object valor)
        {
            try
            {
                comando.Parameters.AddWithValue(parametro, valor);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }
    }
}
