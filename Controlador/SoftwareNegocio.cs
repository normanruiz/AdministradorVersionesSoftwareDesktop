using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class SoftwareNegocio
    {

        public List<Software> listar()
        {
            List<Software> listaSoftware;
            AccesoDatos Conexion = new AccesoDatos();
            Software software;

            try
            {
                Conexion.conectar();
                Conexion.setearConsulta("SELECT s.[id], s.[denominacion] FROM [LaposTecno].[dbo].[version_soft] AS s WITH (NOLOCK);");
                Conexion.ejecutarLectura();

                listaSoftware = new List<Software>();

                while (Conexion.Lector.Read())
                {
                    software = new Software();
                    software.Id = (Int32)Conexion.Lector["id"];
                    software.Denominacion = (string)Conexion.Lector["denominacion"];

                    listaSoftware.Add(software);
                }

                return listaSoftware;
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

        public Software buscar_con_denominacion(string denominacion)
        {
            AccesoDatos conexion = new AccesoDatos();
            Software software;

            try
            {
                conexion.conectar();
                conexion.setearConsulta("SELECT s.[id], s.[denominacion] FROM [LaposTecno].[dbo].[version_soft] AS s WITH (NOLOCK) WHERE s.[denominacion] = @denominacion;");
                conexion.setearParametro("@denominacion", denominacion);
                conexion.ejecutarLectura();

                if (conexion.Lector.Read())
                {
                    software = new Software();
                    software.Id = (Int32)conexion.Lector["id"];
                    software.Denominacion = (string)conexion.Lector["denominacion"];
                }
                else
                {
                    software = null;
                }
                return software;
                ;
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
