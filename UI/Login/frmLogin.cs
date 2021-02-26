using BLL.LogBitacora;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helps;

namespace UI.Login
{
    /// <summary>
    /// Login form
    /// </summary>
    public partial class frmLogin : Form
    {
        //BLL.UsuarioBLL bll = new BLL.UsuarioBLL();

        public frmLogin()
        {
            InitializeComponent();
            UpdateLanguage();
        }


        /// <summary>
        /// buttom salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// buttom iniciar seseión, agarra user y pass, los valida y abre el form principal en caso de validación correcta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInisiarSesion_Click(object sender, EventArgs e)
        {
            Entities.UFP.Usuario user = new Entities.UFP.Usuario();
            user.Nombre = TxtNombre.Text;
            user.Pass = TxtPass.Text;

            var validation = new Helps.DataValidations(user).Validate();
            bool valid = validation.Item1;

            if (valid == true)
            {
                try
                {
                    var isValid = BLL.UFP.Usuario.Login(user);

                    if (isValid.Item1)
                    {
                        frmPrincipal frmPrincipal = new frmPrincipal();
                        frmPrincipal.Show();
                        frmPrincipal.FormClosed += Logout;
                        this.Hide();
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Login, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Inicio seción: " + user.Nombre, "", ""));
                    }
                    else
                    {
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.LoginError, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Inicio seción fallido: " + user.Nombre, "",""));
                        Notifications.FrmError.ErrorForm(Language.SearchValue("loginError"));
                    }

                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.LoginError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Inicio seción fallido: " + user.Nombre, ex.StackTrace, ex.Message));
                    Notifications.FrmError.ErrorForm(Language.SearchValue("loginError") + "\n" + ex.Message);
                }
            }
            else
            {
                string messageValid = validation.Item2;
                Notifications.FrmInformation.InformationForm(messageValid);
            }
        }

        /// <summary>
        /// método logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout(object sender, FormClosedEventArgs e)
        {
            TxtNombre.Clear();
            TxtPass.Clear();
            this.Show();
        }

        /// <summary>
        /// cambia el lenguaje
        /// </summary>
        void UpdateLanguage()
        {
            Helps.Language.controles(this);
            this.lblLogin.Text = Helps.Language.SearchValue("lblLogin");
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            HelpUser();
        }

        /// <summary>
        /// carga el manual de usuario
        /// </summary>
        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Inicio de sesión");
            helpProvider1.SetHelpKeyword(this, "Inicio de sesión");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
