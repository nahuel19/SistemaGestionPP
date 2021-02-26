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
    /// <summary>
    /// Clase form de notificaciones de pregunta
    /// </summary>
    public partial class FrmQuestion : Form
    {
        /// <summary>
        /// Constructor, recibe mensaje para mostrar en la notificación de pregunta
        /// </summary>
        /// <param name="message"></param>
        public FrmQuestion(string message)
        {
            InitializeComponent();

            lblMensaje.Text = message;
            this.lblMsgFijoPregunta.Text  = Helps.Language.SearchValue("lblMsgFijoPregunta");
            this.BtnCancelar.Text = Helps.Language.SearchValue("BtnCancelar");
        }

        /// <summary>
        /// Boton aceptar, carga el dialog result con un OK
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Boton cancelar, carga el dialog result con un Cancel
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }  
}
