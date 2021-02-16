﻿using BLL.DigitosVerificadores;
using Services;
using Services.Cache;
using Services.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UI.Proveedor;

namespace UI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {           
            InitializeComponent();
            //UpdateLanguage();

            try
            {
                new DigitosVerificadoresVFacade().VerificarDVV();                
            }            
            catch (SistemaCorruptoDVVException ex)
            {
                string entidades = ex.CargarEntidadesParaMostrar(ex, Helps.Language.info["sysCorruptoID"]);
                Notifications.FrmError.ErrorForm(ex.Error + "\n" + entidades);
            }

            try
            {
                new DigitosVerificadoresHFacade().VerificarDVH();
            }
            catch (SistemaCorruptoDVHException ex)
            {
                string entidades = ex.CargarEntidadesParaMostrar(ex, Helps.Language.info["sysCorruptoU"]);
                Notifications.FrmError.ErrorForm(ex.Error + "\n" + entidades);
            }

        }

        #region metodos cerrar y abrir submenu ajustes
        //----Cerrar y abrir submenu ajustes-----
        private void AbrirCerrarSubmenu()
        {

            if (panelAjustes.Visible == false)
            {
                panelAjustes.Visible = true;
            }

            if (panelAjustes.Visible == true)
            {
                panelAjustes.Visible = false;
            }
        }
        //private void abrirSubmenu()
        //{
        //    if (panelAjustes.Visible == false)
        //    {
        //        panelAjustes.Visible = true;
        //    }
        //}
        //---------------------------------------
        #endregion

        #region botones principales
        //-----Botones principales---------------
        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirCerrarSubmenu();
            
            OpenChildForm(new frmProducto());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirCerrarSubmenu();

            OpenChildForm(new frmCliente());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirCerrarSubmenu();

            OpenChildForm(new frmProveedor());
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirCerrarSubmenu();

            OpenChildForm(new Ingresos.frmIngreso());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirCerrarSubmenu();

            OpenChildForm(new Ventas.frmVentas());
        }
        #endregion

        #region boton ajustes y submenu de ajustes
        //---------Ajustes-----------
        
        //-----Sub menu de ajustes------
        //private void btnCategoriaProd_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new frmCategoria());
            
        //}

        private void BtnTipoDocIdentidad_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TipoDoc_Indentidad.frmTipoDocIdentidad());
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

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbIdioma.SelectedIndex == 0)
            {
                Helps.Language.ChangeFileLanguage(ConfigurationManager.AppSettings["fileEs"]);
                UpdateLanguage();
            }

            if (cbIdioma.SelectedIndex == 1)
            {
                Helps.Language.ChangeFileLanguage(ConfigurationManager.AppSettings["fileEn"]);
                UpdateLanguage();
            }
        }

        void UpdateLanguage()
        {
            this.btnProductos.Text = Helps.Language.info["btnProductos"];
            Helps.Language.controles(this);

            if(activeForm !=null)
                Helps.Language.controles(activeForm);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            LanguageSelected();
            HelpUser();
            loadUserData();

        }


        private void LanguageSelected()
        {
            string lang = new Properties.Settings().lang;

            if (lang == ConfigurationManager.AppSettings["fileEs"])
                cbIdioma.SelectedIndex = 0;
            if (lang == ConfigurationManager.AppSettings["fileEn"])
                cbIdioma.SelectedIndex = 1;
        }

        private void btnAjustes_Click_1(object sender, EventArgs e)
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

        private void btnPresupuesto_Click(object sender, EventArgs e)
        {
            AbrirCerrarSubmenu();

            OpenChildForm(Presupuesto.frmPresupuesto.Instance());
        }

        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/pruebaHelp.chm";
            //Help.ShowHelp(this, "pruebaHelp.chm");
            helpProvider1.SetHelpString(this, "Producto");
            helpProvider1.SetHelpKeyword(this, "Producto");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HelpUser();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                new DigitosVerificadoresHFacade().CargarDVHalCerrar();
                new DigitosVerificadoresVFacade().CargarDVV();
            }
            catch(Exception ex)
            {
                Notifications.FrmError.ErrorForm(ex.Message);
            }
            
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            
                AbrirCerrarSubmenu();

                OpenChildForm(new Usuario.frmUsuario());
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadUserData()
        {
            lblNombreUser.Text = LoginCache.nombreUser;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Usuario.frmUsuarioFormulario frmEditar = new Usuario.frmUsuarioFormulario(LoginCache.idUser,1);
            frmEditar.ShowDialog();
        }
    }
}
