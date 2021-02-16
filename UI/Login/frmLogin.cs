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
        BLL.UsuarioBLL bll = new BLL.UsuarioBLL();

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
            Entities.Usuario user = new Entities.Usuario();
            user.nombre = TxtNombre.Text;
            user.passSinEncriptar = TxtPass.Text;

            var validation = new Helps.DataValidations(user).Validate();
            bool valid = validation.Item1;

            if (valid == true)
            {
                try
                {
                    bool isValid = bll.Login(user);

                    if (isValid)
                    {
                        frmPrincipal frmPrincipal = new frmPrincipal();
                        frmPrincipal.Show();
                        frmPrincipal.FormClosed += Logout;
                        this.Hide();
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Login, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Inicio seción: " + user.nombre, "", ""));
                    }
                    else
                    {
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.LoginError, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Inicio seción fallido: " + user.nombre, "",""));
                        Notifications.FrmError.ErrorForm(Language.info["loginError"]);
                    }

                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.LoginError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Inicio seción fallido: " + user.nombre, ex.StackTrace, ex.Message));
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
