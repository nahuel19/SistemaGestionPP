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

namespace UI.Notifications
{
    public partial class FrmError : Form
    {
        public FrmError(string message)
        {
            InitializeComponent();
            lblMensaje.Text = message;
            this.lblMsgFijoSuccess.Text = Language.info["lblMsgFijoSuccess"];
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void ErrorForm(string _message)
        {
            FrmError form = new FrmError(_message);
            form.ShowDialog();
        }
    }
}
