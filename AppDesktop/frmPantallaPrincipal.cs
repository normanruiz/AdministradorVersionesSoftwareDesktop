using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using Controlador;

namespace AppDesktop
{
    public partial class frmPantallaPrincipal : Form
    {
        public List<Estado> listadoEstados { get; set; }
        public List<Plantilla> listadoPlantillas { get; set; }

        public frmPantallaPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmPantallaPrincipal_Load(object sender, EventArgs e)
        {
            try
            {

                actualizarListadoPlantillas();

                this.dgvPlantillas.Columns["Id"].Visible = false;
                this.dgvPlantillas.Columns["Funcionalidades"].Visible = false;
                this.dgvPlantillas.AutoResizeColumns();
                this.dgvPlantillas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //actualizarListadoFiltroEstados();

            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.ToString(), "Cargando listado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void actualizarListadoFiltroEstados()
        {
             EstadoNegocio estadoNegocio  = new EstadoNegocio();
            try
            {
                listadoEstados = estadoNegocio.listar();
                cbxEstados.DataSource = listadoEstados;
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.ToString(), "Actualizando listado de estados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void actualizarListadoPlantillas()
        {
            PlantillaNegocio plantillaNegocio = new PlantillaNegocio();
            try
            {
                listadoPlantillas = plantillaNegocio.listar();
                dgvPlantillas.DataSource = listadoPlantillas;
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.ToString(), "Actualizando listado de estados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvPlantillas.CurrentRow != null)
                {
                    Plantilla plantilla = (Plantilla)dgvPlantillas.CurrentRow.DataBoundItem;
                    foreach (var item in Application.OpenForms)
                    {
                        if (item.GetType() == typeof(frmPantallaDetalle)) return;
                    }
                    frmPantallaDetalle ventanaDetalle = new frmPantallaDetalle(plantilla);
                    ventanaDetalle.Show();
                    actualizarListadoPlantillas();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una plantilla primero.", "Visualizando articulo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.ToString(), "Visualizando articulo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PlantillaNegocio plantillanegocio = new PlantillaNegocio();
            Plantilla plantilla;
            try
            {
                DialogResult respuesta = MessageBox.Show("Estas seguro de eliminar la Plantilla?", "Eliminando Plantilla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (dgvPlantillas.CurrentRow != null)
                    {
                        plantilla = (Plantilla)dgvPlantillas.CurrentRow.DataBoundItem;
                        if (plantillanegocio.Eliminar(plantilla.Id))
                        {
                            MessageBox.Show("La plantilla se elimino correctamente.", "Eliminando Plantilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        actualizarListadoPlantillas();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un elemento primero.", "Eliminar articulo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (NullReferenceException excepcion)
            {
                MessageBox.Show("Debe seleccionar un elemento primero.", "Eliminando articulo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.ToString(), "Eliminando articulo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
