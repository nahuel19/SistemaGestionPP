using BLL.LogBitacora;
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
            metroGrid1.DataSource = InvokeCommand.GetLogs().Execute();

            CaracteristicasGrid();

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
