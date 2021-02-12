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
    public partial class FrmQuestion : Form
    {
        public FrmQuestion(string message)
        {
            InitializeComponent();

            lblMensaje.Text = message;
            this.lblMsgFijoPregunta.Text  = Helps.Language.info["lblMsgFijoPregunta"];
            this.BtnCancelar.Text = Helps.Language.info["BtnCancelar"];
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }  
}
