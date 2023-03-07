using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class MedioNegocio
    {

        public List<Medio> listar()
        {
            List<Medio> listaMedios;
            AccesoDatos Conexion = new AccesoDatos();
            Medio medio;

            try
            {
                Conexion.conectar();
                Conexion.setearConsulta("SELECT c.[id], c.[tipo], c.[estado] FROM [LaposTecno].[dbo].[conectividades] AS c WITH (NOLOCK);");
                Conexion.ejecutarLectura();

                listaMedios = new List<Medio>();

                while (Conexion.Lector.Read())
                {
                    medio = new Medio();
                    medio.Id = (Int32)Conexion.Lector["id"];
                    medio.Tipo = (string)Conexion.Lector["tipo"];
                    medio.Estado = (Boolean)Conexion.Lector["estado"];

                    listaMedios.Add(medio);
                }

                return listaMedios;
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

        public Medio buscar_con_tipo(string tipo)
        {
            AccesoDatos conexion = new AccesoDatos();
            Medio medio;

            try
            {
                conexion.conectar();
                conexion.setearConsulta("SELECT c.[id], c.[tipo], c.[estado] FROM [LaposTecno].[dbo].[conectividades] AS c WITH (NOLOCK) WHERE c.[tipo] = @tipo;");
                conexion.setearParametro("@tipo", tipo);
                conexion.ejecutarLectura();

                if (conexion.Lector.Read())
                {
                    medio = new Medio();
                    medio.Id = (Int32)conexion.Lector["id"];
                    medio.Tipo = (string)conexion.Lector["tipo"];
                    medio.Estado = (Boolean)conexion.Lector["estado"];
                }
                else
                {
                    medio = null;
                }
                return medio;
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
