using BLL;
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

namespace UI.Cliente
{
    /// <summary>
    /// form para seleccionar cliente en una venta
    /// </summary>
    public partial class frmSeleccionarCliente : MetroFramework.Forms.MetroForm
    {
        ClienteBLL bll = new ClienteBLL();
        public IContractForm<Entities.Cliente> contrato { get; set; }
        public frmSeleccionarCliente()
        {
            InitializeComponent();
            ChangeLanguage();
        }

        private void RefrescarTabla()
        {
            try
            {
                metroGrid1.DataSource = bll.List();

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
            metroGrid1.Columns["nombre"].Visible = false;
            metroGrid1.Columns["apellido"].Visible = false;
            metroGrid1.Columns["fk_id_tipo_doc_identidad"].Visible = false;
            metroGrid1.Columns["fecha_nacimiento"].Visible = false;
            metroGrid1.Columns["direccion"].Visible = false;
            metroGrid1.Columns["edad"].Visible = false;

            metroGrid1.Columns["nombreCompleto"].DisplayIndex = 1;
            metroGrid1.Columns["doc_identidad"].DisplayIndex = 2;
            metroGrid1.Columns["num_documento"].DisplayIndex = 3;
            metroGrid1.Columns["telefono"].DisplayIndex = 4;
            metroGrid1.Columns["mail"].DisplayIndex = 5;

            metroGrid1.Columns["nombreCompleto"].Width = 250;
            metroGrid1.Columns["doc_identidad"].Width = 60;
            metroGrid1.Columns["num_documento"].Width = 120;
            metroGrid1.Columns["telefono"].Width = 170;
            metroGrid1.Columns["mail"].Width = 200;


        }

        private int GetId()
        {
            return (int)metroGrid1.CurrentRow.Cells["id"].Value;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                metroGrid1.DataSource = bll.FindBy(TxtBuscar.Text);
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }

        private void frmSeleccionarCliente_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void ChangeLanguage()
        {
            this.Text = Helps.Language.SearchValue("tituloSelectCliente");
            Helps.Language.controles(this);
        }
        private void metroGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Entities.Cliente cli = bll.GetById(GetId());
                contrato.Ejecutar(cli);
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
            this.Close();
        }
    }
}
