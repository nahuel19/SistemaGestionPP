using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Proveedor
{
    public partial class frmSeleccionarProveedor : MetroFramework.Forms.MetroForm
    {
        ProveedorBLL bll = new ProveedorBLL();
        public frmSeleccionarProveedor()
        {
            InitializeComponent();
        }


        private void RefrescarTabla()
        {
            metroGrid1.DataSource = bll.List();

            CaracteristicasGrid();

            metroGrid1.ClearSelection();
            TxtBuscar.Focus();
        }

        private void CaracteristicasGrid()
        {
            metroGrid1.Columns["id"].Visible = false;
            metroGrid1.Columns["fk_id_tipo_doc_identidad"].Visible = false;
            metroGrid1.Columns["direccion"].Visible = false;
            metroGrid1.Columns["url"].Visible = false;

            metroGrid1.Columns["nombre"].DisplayIndex = 1;
            metroGrid1.Columns["doc_identidad"].DisplayIndex = 2;
            metroGrid1.Columns["num_documento"].DisplayIndex = 3;
            metroGrid1.Columns["telefono"].DisplayIndex = 4;
            metroGrid1.Columns["mail"].DisplayIndex = 5;

            metroGrid1.Columns["nombre"].Width = 250;
            metroGrid1.Columns["doc_identidad"].Width = 60;
            metroGrid1.Columns["num_documento"].Width = 120;
            metroGrid1.Columns["telefono"].Width = 170;
            metroGrid1.Columns["mail"].Width = 200;
        }


        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            metroGrid1.DataSource = bll.FindBy(TxtBuscar.Text);
        }

        private void frmSeleccionarProveedor_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void metroGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Ingresos.frmIngresoFormulario frmIngreso = new Ingresos.frmIngresoFormulario();
            
            string nombreProv = metroGrid1.CurrentRow.Cells["nombre"].Value.ToString();
            int idProv = (int)metroGrid1.CurrentRow.Cells["id"].Value; ;

            frmIngreso.SetProveedor(idProv, nombreProv);

            this.Close();
        }
    }
}
