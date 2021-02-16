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
    /// <summary>
    /// Clase form de notificaciones de errores
    /// </summary>
    public partial class FrmError : Form
    {
        /// <summary>
        /// Constructor, recibe mensaje para mostrar en la notificación de error
        /// </summary>
        /// <param name="message"></param>
        public FrmError(string message)
        {
            InitializeComponent();
            lblMensaje.Text = message;
            this.lblMsgFijoSuccess.Text = Language.info["lblMsgFijoSuccess"];
        }

        /// <summary>
        /// Boton aceptar, cierra el form
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Método estático para llamar al form de error
        /// </summary>
        /// <param name="_message">string</param>
        public static void ErrorForm(string _message)
        {
            FrmError form = new FrmError(_message);
            form.ShowDialog();
        }
    }
}
