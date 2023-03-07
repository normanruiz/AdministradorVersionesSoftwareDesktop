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
    public partial class frmPantallaDetalle : Form
    {
        public Plantilla plantilla { get; set; }
        public frmPantallaDetalle()
        {
            InitializeComponent();
        }

        public frmPantallaDetalle(Plantilla plantilla)
        {
            InitializeComponent();

            this.plantilla = plantilla;

            tbxID.Text = this.plantilla.Id.ToString();
            tbxProveedor.Text = this.plantilla.Proveedor.Nombre.ToString();
            tbxModelo.Text = this.plantilla.Modelo.Denominacion.ToString();
            tbxPlantilla.Text = this.plantilla.Denominacion.ToString();
            tbxSalto.Text = this.plantilla.Salto.ToString();
            tbxEstado.Text = this.plantilla.Estado.Tipo.ToString();
            tbxSoftware.Text = this.plantilla.Software.Denominacion.ToString();
            tbxMedio.Text = this.plantilla.Medio.Tipo.ToString();

            tbxActualizacion.Text = this.plantilla.Actualizacion is null ? "Sin espesificar" : this.plantilla.Actualizacion.ToString();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPantallaDetalle_Load(object sender, EventArgs e)
        {

        }

    }
}
