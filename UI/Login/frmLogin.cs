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
    public partial class frmLogin : Form
    {
        //BLL.UsuarioBLL bll = new BLL.UsuarioBLL();

        public frmLogin()
        {
            InitializeComponent();
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
                        Notifications.FrmError.ErrorForm(Language.info["loginError"]);
                    }

                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.LoginError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Inicio seción fallido: " + user.Nombre, ex.StackTrace, ex.Message));
                    Notifications.FrmError.ErrorForm(Language.info["loginError"] + "\n" + ex.Message);
                }
            }
            else
            {
                string messageValid = validation.Item2;
                Notifications.FrmInformation.InformationForm(messageValid);
            }
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            TxtNombre.Clear();
            TxtPass.Clear();
            this.Show();
        }

    }
}
