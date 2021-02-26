using BLL.LogBitacora;
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
    /// form bitácora
    /// </summary>
    public partial class frmLogBitacora : Form
    {


        public frmLogBitacora()
        {
            InitializeComponent();
            ChangeLanguage();
            RefrescarTabla();
        }

        private void RefrescarTabla()
        {
            try
            {
                metroGrid1.DataSource = InvokeCommand.GetLogs().Execute();

                CaracteristicasGrid();
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }

            metroGrid1.ClearSelection();
            TxtBuscar.Focus();
        }

        private void CaracteristicasGrid()
        {

            metroGrid1.Columns["id"].Visible = false;
            metroGrid1.Columns["tipo_log"].Visible = false;
            metroGrid1.Columns["usuario"].Visible = false;
            metroGrid1.Columns["stack_trace"].Visible = false;
            metroGrid1.Columns["mensaje"].Visible = false;
            metroGrid1.Columns["clase"].Visible = false;
            metroGrid1.Columns["metodo"].Visible = false;


            //metroGrid1.Columns["nombreCompleto"].DisplayIndex = 1;
            //metroGrid1.Columns["doc_identidad"].DisplayIndex = 2;
            //metroGrid1.Columns["num_documento"].DisplayIndex = 3;
            //metroGrid1.Columns["telefono"].DisplayIndex = 4;
            //metroGrid1.Columns["mail"].DisplayIndex = 5;

            //metroGrid1.Columns["nombreCompleto"].Width = 250;
            //metroGrid1.Columns["doc_identidad"].Width = 60;
            //metroGrid1.Columns["num_documento"].Width = 120;
            //metroGrid1.Columns["telefono"].Width = 170;
            //metroGrid1.Columns["mail"].Width = 200;


        }

        private int? GetId()
        {
            try
            {
                return (int)metroGrid1.CurrentRow.Cells["id"].Value;
            }
            catch
            {
                return null;
            }
        }
        private void ChangeLanguage()
        {
            Helps.Language.controles(this);
        }

        private void frmLogBitacora_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            frmDetalleLog frm = new frmDetalleLog((int)GetId());
            frm.ShowDialog();
        }
    }
}
