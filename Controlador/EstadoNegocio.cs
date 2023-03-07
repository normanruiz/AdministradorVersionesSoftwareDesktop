using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class EstadoNegocio
    {
        public List<Estado> listar()
        {
            List<Estado> listaEstados = new List<Estado>();
            AccesoDatos Conexion = new AccesoDatos();
            Estado estado;

            try
            {
                Conexion.conectar();
                Conexion.setearConsulta("SELECT e.[id], e.[tipo] FROM [LaposTecno].[dbo].[estados] AS e WITH (NOLOCK); ");
                Conexion.ejecutarLectura();

                while (Conexion.Lector.Read())
                {
                    estado = new Estado();
                    estado.Id = (Int32)Conexion.Lector["id"];
                    estado.Tipo = (string)Conexion.Lector["tipo"];

                    listaEstados.Add(estado);
                }

                return listaEstados;
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

        public Estado buscar_con_tipo(string tipo)
        {
            AccesoDatos conexion = new AccesoDatos();
            Estado estado;

            try
            {
                conexion.conectar();
                conexion.setearConsulta("SELECT e.[id], e.[tipo] FROM [LaposTecno].[dbo].[estados] AS e WITH (NOLOCK) WHERE e.[tipo] = @tipo;");
                conexion.setearParametro("@tipo", tipo);
                conexion.ejecutarLectura();

                if (conexion.Lector.Read())
                {
                    estado = new Estado();
                    estado.Id = (Int32)conexion.Lector["id"];
                    estado.Tipo = (string)conexion.Lector["tipo"];
                }
                else
                {
                    estado = null;
                }
                return estado;
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
