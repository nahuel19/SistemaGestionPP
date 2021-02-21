using BLL.LogBitacora;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.LogForm
{
    public partial class frmDetalleLog : MetroFramework.Forms.MetroForm
    {
        private int id;

        public frmDetalleLog(int _id)
        {
            InitializeComponent();
            id = _id;
            ChangeLanguage();
        }

        private void CargarDatos()
        {
            Log log = InvokeCommand.GetLogById().Execute(id);
            lblTipoLogValue.Text = log.tipo_log_nombre;
            lblFechaValue.Text = log.fecha.ToString();
            lblInfoLogValue.Text = log.info_operacion;
            lblClaseValue.Text = log.clase;
            lblMetodoValue.Text = log.metodo;
            lblMensajeValue.Text = log.metodo;
            lblStackTraceValue.Text = log.stack_trace;
        }

        private void ChangeLanguage()
        {
            this.Text = Helps.Language.info["BtnDetalle"];
            Helps.Language.controles(this);
        }

        private void frmDetalleLog_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
