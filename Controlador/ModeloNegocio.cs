using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class ModeloNegocio
    {

        public List<Modelo.Modelo> listar()
        {
            List<Modelo.Modelo> listaModelos;
            AccesoDatos Conexion = new AccesoDatos();
            Modelo.Modelo modelo;

            try
            {
                Conexion.conectar();
                Conexion.setearConsulta("SELECT m.[id], m.[denominacion], m.[estado] FROM [LaposTecno].[dbo].[modelos] AS m WITH (NOLOCK);");
                Conexion.ejecutarLectura();

                listaModelos = new List<Modelo.Modelo>();

                while (Conexion.Lector.Read())
                {
                    modelo = new Modelo.Modelo();
                    modelo.Id = (Int32)Conexion.Lector["id"];
                    modelo.Denominacion = (string)Conexion.Lector["denominacion"];
                    modelo.Estado = (Boolean)Conexion.Lector["estado"];

                    listaModelos.Add(modelo);
                }

                return listaModelos;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                Conexion.cerrar();
            }

        }

        public Modelo.Modelo buscar_con_denominacion(string denominacion)
        {
            AccesoDatos conexion = new AccesoDatos();
            Modelo.Modelo modelo;

            try
            {
                conexion.conectar();
                conexion.setearConsulta("SELECT m.[id], m.[denominacion], m.[estado] FROM [LaposTecno].[dbo].[modelos] AS m WITH (NOLOCK) WHERE m.[denominacion] = @denominacion;");
                conexion.setearParametro("@denominacion", denominacion);
                conexion.ejecutarLectura();

                if (conexion.Lector.Read())
                {
                    modelo = new Modelo.Modelo();
                    modelo.Id = (Int32)conexion.Lector["id"];
                    modelo.Denominacion = (string)conexion.Lector["denominacion"];
                    modelo.Estado = (Boolean)conexion.Lector["estado"];
                }
                else
                {
                    modelo = null;
                }
                return modelo;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                conexion.cerrar();
            }
        }
    }
}
