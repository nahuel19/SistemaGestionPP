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
    /// Clase form de notificaciones de infromación
    /// </summary>
    public partial class FrmInformation : Form
    {
        /// <summary>
        /// Constructor, recibe mensaje para mostrar en la notificación de información
        /// </summary>
        /// <param name="message"></param>
        public FrmInformation(string message)
        {
            InitializeComponent();
            lblMensaje.Text = message;
            this.lblMsgFijoSuccess.Text = Helps.Language.info["lblMsgFijoSuccess"];
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
        /// Método estático para llamar al form de información
        /// </summary>
        /// <param name="_message">string</param>
        public static void InformationForm(string _message)
        {
            FrmInformation form = new FrmInformation(_message);
            form.ShowDialog();
        }
    }
}
