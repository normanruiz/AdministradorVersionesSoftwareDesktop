using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    class ProveedorNegocio
    {

        public List<Proveedor> listar()
        {
            List<Proveedor> listaProveedores;
            AccesoDatos Conexion = new AccesoDatos();
            Proveedor proveedor;

            try
            {
                Conexion.conectar();
                Conexion.setearConsulta("SELECT p.[id], p.[nombre], p.[estado] FROM [LaposTecno].[dbo].[proveedores] AS p WITH (NOLOCK);");
                Conexion.ejecutarLectura();

                listaProveedores = new List<Proveedor>();

                while (Conexion.Lector.Read())
                {
                    proveedor = new Proveedor();
                    proveedor.Id = (Int32)Conexion.Lector["id"];
                    proveedor.Nombre = (string)Conexion.Lector["nombre"];
                    proveedor.Estado = (Boolean)Conexion.Lector["estado"];

                    listaProveedores.Add(proveedor);
                }

                return listaProveedores;
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

        public Proveedor buscar_con_nombre(string nombre)
        {
            AccesoDatos conexion = new AccesoDatos();
            Proveedor proveedor;

            try
            {
                conexion.conectar();
                conexion.setearConsulta("SELECT p.[id], p.[nombre], p.[estado] FROM [LaposTecno].[dbo].[proveedores] AS p WITH (NOLOCK) WHERE p.nombre = @nombre;");
                conexion.setearParametro("@nombre", nombre);
                conexion.ejecutarLectura();

                if (conexion.Lector.Read())
                {
                    proveedor = new Proveedor();
                    proveedor.Id = (Int32)conexion.Lector["id"];
                    proveedor.Nombre = (string)conexion.Lector["nombre"];
                    proveedor.Estado = (Boolean)conexion.Lector["estado"];
                }
                else
                {
                    proveedor = null;
                }
                return proveedor;
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
