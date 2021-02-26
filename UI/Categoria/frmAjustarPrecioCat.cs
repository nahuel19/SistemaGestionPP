using BLL;
using BLL.LogBitacora;
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
using UI.Helps;

namespace UI.Categoria
{
    /// <summary>
    /// form ajuste precio por categoría
    /// </summary>
    public partial class frmAjustarPrecioCat : MetroFramework.Forms.MetroForm
    {
        private int id;
        CategoriaBLL bllCat = new CategoriaBLL();
        PrecioBLL bllPrecio = new PrecioBLL();
        Entities.Categoria categoria;

        /// <summary>
        /// contructor, recibe id categoría para cargar el nombre en el form
        /// </summary>
        /// <param name="_id">int</param>
        public frmAjustarPrecioCat(int _id)
        {
            InitializeComponent();
            id = _id;
            ChangeLanguage();
            CargarDatosEnForm();
        }

        /// <summary>
        /// carga el nombre de la categoría en el form
        /// </summary>
        private void CargarDatosEnForm()
        {
            try
            {
                categoria = bllCat.GetById(id);
                lblNombreValue.Text = categoria.categoria;
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }

        }

        /// <summary>
        /// carga el idioma
        /// </summary>
        private void ChangeLanguage()
        {
            try
            {
                Helps.Language.controles(this);
                this.Text = Helps.Language.SearchValue("lblPrecio");
            }
            catch (Exception ex)
            {
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorIdioma") + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// filtra caracteres permitidos en el textbow de porcentaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// guarda los cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("ingresarPorcentaje"));
            }
        }

        /// <summary>
        /// carga manual de usuario para el form
        /// </summary>
        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuariox.chm";
            helpProvider1.SetHelpString(this, "Ajuste precio por categoría");
            helpProvider1.SetHelpKeyword(this, "Ajuste precio por categoría");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }

      
        private void frmAjustarPrecioCat_Load(object sender, EventArgs e)
        {
            HelpUser();
        }
    }
}
