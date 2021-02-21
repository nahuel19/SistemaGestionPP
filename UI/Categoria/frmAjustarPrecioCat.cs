using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Categoria
{
    public partial class frmAjustarPrecioCat : MetroFramework.Forms.MetroForm
    {
        private int id;
        CategoriaBLL bllCat = new CategoriaBLL();
        PrecioBLL bllPrecio = new PrecioBLL();
        Entities.Categoria categoria;

        public frmAjustarPrecioCat(int _id)
        {
            InitializeComponent();
            id = _id;
            ChangeLanguage();
            CargarDatosEnForm();
        }

        private void CargarDatosEnForm()
        {
            categoria = bllCat.GetById(id);
            lblNombreValue.Text = categoria.categoria;

        }


        private void ChangeLanguage()
        {
            Helps.Language.controles(this);
            this.Text = Helps.Language.info["lblPrecio"];
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if (Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar)) //permitir teclas de control como retroceso y signos de puntuación
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPorcentaje.Text))
            {
                try
                {                    
                    double porcentaje = (Convert.ToDouble(Convert.ToDouble(txtPorcentaje.Text.ReplaceDot())) / 100) + 1;
                    bllPrecio.UpdatePrecioCategoria(categoria.id, porcentaje, txtMotivo.Text);
                }
                catch (Exception ex)
                {
                    Notifications.FrmInformation.InformationForm(ex.Message);
                }
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["ingresarPorcentaje"]);
            }
        }
    }
}
