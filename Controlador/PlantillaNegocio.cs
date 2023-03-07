﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class PlantillaNegocio
    {
        enum actulizaciones { Remota, Precencial };

        public List<Plantilla> listar()
        {
            List<Plantilla> listaPlantillas = new List<Plantilla>();
            AccesoDatos Conexion = new AccesoDatos();
            Plantilla plantilla;
            ProveedorNegocio proveedorNegocio;
            EstadoNegocio estadoNegocio;
            SoftwareNegocio softwareNegocio;
            MedioNegocio medioNegocio;
            ActualizacionNegocio actualizacionNegocio;
            ModeloNegocio modeloNegocio;

            try
            {
                Conexion.conectar();
                Conexion.setearConsulta("SELECT [Id.], [Proveedor], [Modelo], [Plantilla], [Salto Plantilla], [Estado], [Software], [Medio], [Actualizacion], [Visa EMV], [MasterCard EMV], [Amex EMV], [Union Pay EMV], [Visa CTLS], [MasterCard CTLS], [Amex CTLS], [Union Pay CTLS], [Extra Cash CTLS], [QR Visa/Matercard], [QR Amex Puro], [QR Beneficios], [QR Cabal], [Pos Integrado QR], [Pos Integrado], [Agro], [Shell Latam], [YPF ServiClub], [ACA], [Lote IP], [Pago de Servicios], [DCC], [Tax Free], [Resume], [Conexion Persistente], [Async], [Control de brillo], [Base], [Flota], [Cobro anticipado], [Amex OPT Blue] FROM [LaposTecno].[sis].[usvt_tabla_versiones_lapostecno] AS tv WITH (NOLOCK);");
                Conexion.ejecutarLectura();

                proveedorNegocio = new ProveedorNegocio();
                estadoNegocio = new EstadoNegocio();
                softwareNegocio = new SoftwareNegocio();
                medioNegocio = new MedioNegocio();
                actualizacionNegocio = new ActualizacionNegocio();
                modeloNegocio = new ModeloNegocio();

                while (Conexion.Lector.Read())
                {
                    plantilla = new Plantilla();
                    plantilla.Id = (Int32)Conexion.Lector["Id."];
                    plantilla.Proveedor = new Proveedor();
                    plantilla.Proveedor = proveedorNegocio.buscar_con_nombre((string)Conexion.Lector["Proveedor"]);

                    plantilla.Modelo = new Modelo.Modelo();
                    plantilla.Modelo = modeloNegocio.buscar_con_denominacion((string)Conexion.Lector["Modelo"]);

                    plantilla.Denominacion = (string)Conexion.Lector["Plantilla"];

                    plantilla.Salto = (string)Conexion.Lector["Salto Plantilla"];

                    plantilla.Estado = new Estado();
                    plantilla.Estado = estadoNegocio.buscar_con_tipo((string)Conexion.Lector["Estado"]);

                    plantilla.Software = new Software();
                    plantilla.Software = softwareNegocio.buscar_con_denominacion((string)Conexion.Lector["Software"]);

                    plantilla.Medio = new Medio();
                    plantilla.Medio = medioNegocio.buscar_con_tipo((string)Conexion.Lector["Medio"]);

                    if (Conexion.Lector["Actualizacion"] is DBNull)
                    {
                        plantilla.Actualizacion = null;
                    }
                    else
                    { 
                        plantilla.Actualizacion = (string)Conexion.Lector["Actualizacion"];
                    }

                    //plantilla.Funcionalidades = new Dictionary<Funcionalidad, bool>();


                    listaPlantillas.Add(plantilla);

                }
                return listaPlantillas;
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

        public Plantilla buscar_con_denominacion(string deniminacion)
        {
            AccesoDatos conexion = new AccesoDatos();
            Plantilla plantilla;
            ProveedorNegocio proveedorNegocio;
            EstadoNegocio estadoNegocio;
            SoftwareNegocio softwareNegocio;
            MedioNegocio medioNegocio;
            ActualizacionNegocio actualizacionNegocio;
            ModeloNegocio modeloNegocio;

            try
            {
                conexion.conectar();
                conexion.setearConsulta("");
                conexion.setearParametro("@deniminacion", deniminacion);
                conexion.ejecutarLectura();

                proveedorNegocio = new ProveedorNegocio();
                estadoNegocio = new EstadoNegocio();
                softwareNegocio = new SoftwareNegocio();
                medioNegocio = new MedioNegocio();
                actualizacionNegocio = new ActualizacionNegocio();
                modeloNegocio = new ModeloNegocio();

                if (conexion.Lector.Read())
                {
                    plantilla = new Plantilla();
                    plantilla.Id = (Int32)conexion.Lector["Id."];
                    plantilla.Proveedor = new Proveedor();
                    plantilla.Proveedor = proveedorNegocio.buscar_con_nombre((string)conexion.Lector["Proveedor"]);

                    plantilla.Modelo = new Modelo.Modelo();
                    plantilla.Modelo = modeloNegocio.buscar_con_denominacion((string)conexion.Lector["Modelo"]);

                    plantilla.Denominacion = (string)conexion.Lector["Plantilla"];

                    plantilla.Salto = (string)conexion.Lector["Salto Plantilla"];

                    plantilla.Estado = new Estado();
                    plantilla.Estado = estadoNegocio.buscar_con_tipo((string)conexion.Lector["Estado"]);

                    plantilla.Software = new Software();
                    plantilla.Software = softwareNegocio.buscar_con_denominacion((string)conexion.Lector["Software"]);

                    plantilla.Medio = new Medio();
                    plantilla.Medio = medioNegocio.buscar_con_tipo((string)conexion.Lector["Medio"]);



                    //plantilla.Funcionalidades = new Dictionary<Funcionalidad, bool>();
                }
                else
                {
                    plantilla = null;
                }
                return plantilla;
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
