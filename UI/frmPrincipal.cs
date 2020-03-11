using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        #region metodos cerrar y abrir submenu ajustes
        //----Cerrar y abrir submenu ajustes-----
        private void cerrarSubmenu()
        {
            if (panelAjustes.Visible == true)
            {
                panelAjustes.Visible = false;
            }
        }
        private void abrirSubmenu()
        {
            if (panelAjustes.Visible == false)
            {
                panelAjustes.Visible = true;
            }
        }
        //---------------------------------------
        #endregion

        #region botones principales
        //-----Botones principales---------------
        private void btnProductos_Click(object sender, EventArgs e)
        {
            cerrarSubmenu();
            
            OpenChildForm(new frmProducto());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            cerrarSubmenu();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            cerrarSubmenu();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            cerrarSubmenu();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            cerrarSubmenu();
        }
        #endregion

        #region boton ajustes y submenu de ajustes
        //---------Ajustes-----------
        private void btnAjustes_Click(object sender, EventArgs e)
        {
            if (panelAjustes.Visible == false)
            {
                panelAjustes.Visible = true;
            }
            else
            {
                panelAjustes.Visible = false;
            }
        }
        //-----Sub menu de ajustes------
        private void btnCategoriaProd_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCategoria());
            
        }
        #endregion

        #region metodo abrir un solo form a la vez
        //---------abrir formularios----------
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelFormularios.Controls.Add(childForm);
            panelFormularios.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        #region metodo abrir mas de un formulario diferente (no mas de uno igual)
        //private void AbrirFormularios<MiFrorm>() where MiFrorm : Form, new()
        //{
        //    Form formulario;
        //    formulario = panelFormularios.Controls.OfType<MiFrorm>().FirstOrDefault();

        //    if(formulario == null)
        //    {
        //        formulario = new MiFrorm();
        //        formulario.TopLevel = false;
        //        formulario.FormBorderStyle = FormBorderStyle.None;
        //        formulario.Dock = DockStyle.Fill;
        //        panelFormularios.Controls.Add(formulario);
        //        panelFormularios.Tag = formulario;
        //        formulario.Show();
        //        formulario.BringToFront();
        //    }
        //    else
        //    {
        //        formulario.BringToFront();
        //    }

        //}
        #endregion

    }
}
