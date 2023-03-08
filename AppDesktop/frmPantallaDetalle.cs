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

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPantallaDetalle_Load(object sender, EventArgs e)
        {
            tbxID.Text = this.plantilla.Id.ToString();
            tbxProveedor.Text = this.plantilla.Proveedor.Nombre.ToString();
            tbxModelo.Text = this.plantilla.Modelo.Denominacion.ToString();
            tbxPlantilla.Text = this.plantilla.Denominacion.ToString();
            tbxSalto.Text = this.plantilla.Salto.ToString();
            tbxEstado.Text = this.plantilla.Estado.Tipo.ToString();
            tbxSoftware.Text = this.plantilla.Software.Denominacion.ToString();
            tbxMedio.Text = this.plantilla.Medio.Tipo.ToString();
            tbxActualizacion.Text = this.plantilla.Actualizacion is null ? "Sin espesificar" : this.plantilla.Actualizacion.ToString();

            tbxVisaEMV.Checked = this.plantilla.Funcionalidades["Visa EMV"];
            tbxMasterCardEMV.Checked = this.plantilla.Funcionalidades["MasterCard EMV"];
            tbxAmexEMV.Checked = this.plantilla.Funcionalidades["Amex EMV"];
            tbxUnionPayEMV.Checked = this.plantilla.Funcionalidades["Union Pay EMV"];
            tbxVisaCTLS.Checked = this.plantilla.Funcionalidades["Visa CTLS"];
            tbxMasterCardCTLS.Checked = this.plantilla.Funcionalidades["MasterCard CTLS"];
            tbxAmexCTLS.Checked = this.plantilla.Funcionalidades["Amex CTLS"];
            tbxUnionPayCTLS.Checked = this.plantilla.Funcionalidades["Union Pay CTLS"];
            tbxExtraCashCTLS.Checked = this.plantilla.Funcionalidades["Extra Cash CTLS"];
            tbxQRVisaMatercard.Checked = this.plantilla.Funcionalidades["QR Visa/Matercard"];

            tbxQRAmexPuro.Checked = this.plantilla.Funcionalidades["QR Amex Puro"];
            tbxQRBeneficios.Checked = this.plantilla.Funcionalidades["QR Beneficios"];
            tbxQRCabal.Checked = this.plantilla.Funcionalidades["QR Cabal"];
            tbxPosIntegradoQR.Checked = this.plantilla.Funcionalidades["Pos Integrado QR"];
            tbxPosIntegrado.Checked = this.plantilla.Funcionalidades["Pos Integrado"];
            tbxAgro.Checked = this.plantilla.Funcionalidades["Agro"];
            tbxShellLatam.Checked = this.plantilla.Funcionalidades["Shell Latam"];
            tbxYPFServiClub.Checked = this.plantilla.Funcionalidades["YPF ServiClub"];
            tbxACA.Checked = this.plantilla.Funcionalidades["ACA"];
            tbxLoteIP.Checked = this.plantilla.Funcionalidades["Lote IP"];
            tbxPagodeServicios.Checked = this.plantilla.Funcionalidades["Pago de Servicios"];

            tbxDCC.Checked = this.plantilla.Funcionalidades["DCC"];
            tbxTaxFree.Checked = this.plantilla.Funcionalidades["Tax Free"];
            tbxResume.Checked = this.plantilla.Funcionalidades["Resume"];
            tbxConexionPersistente.Checked = this.plantilla.Funcionalidades["Conexion Persistente"];
            tbxAsync.Checked = this.plantilla.Funcionalidades["Async"];
            tbxControldebrillo.Checked = this.plantilla.Funcionalidades["Control de brillo"];
            tbxBase.Checked = this.plantilla.Funcionalidades["Base"];
            tbxFlota.Checked = this.plantilla.Funcionalidades["Flota"];
            tbxCobroanticipado.Checked = this.plantilla.Funcionalidades["Cobro anticipado"];
            tbxAmexOPTBlue.Checked = this.plantilla.Funcionalidades["Amex OPT Blue"];
        }

    }
}
