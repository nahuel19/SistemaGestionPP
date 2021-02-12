using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Notifications
{
    public partial class FrmSuccess : Form
    {
        public FrmSuccess(string message)
        {
            InitializeComponent();

            lblMensaje.Text = message;
            this.lblMsgFijoSuccess.Text = Helps.Language.info["lblMsgFijoSuccess"];

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        public static void SuccessForm(string _message)
        {
            FrmSuccess form = new FrmSuccess(_message);
            form.ShowDialog();
        } 
    }
}
