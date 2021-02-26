using BLL.LogBitacora;
using Entities;
using Services;
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

namespace UI.LogForm
{
    /// <summary>
    /// form que muestra detalle de un log seleccionado
    /// </summary>
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
            try
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
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }

        private void ChangeLanguage()
        {
            this.Text = Helps.Language.SearchValue("BtnDetalle");
            Helps.Language.controles(this);
        }

        private void frmDetalleLog_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
