using BLL;
using BLL.LogBitacora;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmCliente : Form
    {
        ClienteBLL bll = new ClienteBLL();

        public frmCliente()
        {
            InitializeComponent();
        }

        #region helpers
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

        #endregion

        private void frmCliente_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Cliente.frmClienteFormulario frmNuevo = new Cliente.frmClienteFormulario();
            frmNuevo.ShowDialog();
            RefrescarTabla();

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? idEntity = GetId();

                Entities.Cliente entity = bll.GetById(Convert.ToInt32(idEntity));

                try
                {
                    DialogResult confirmation = new Notifications.FrmQuestion(Helps.Language.info["preguntaEliminar"]).ShowDialog();

                    if (confirmation == DialogResult.OK)
                    {
                        bll.Delete(Convert.ToInt32(idEntity));
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Delete, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Cliente: " + entity.num_documento, "", ""));

                        RefrescarTabla();
                        Notifications.FrmSuccess.SuccessForm(Helps.Language.info["eliminadoOK"]);

                    }
                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.DeleteError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Cliente: " + entity.num_documento, ex.StackTrace, ex.Message));
                    RefrescarTabla();
                    Notifications.FrmError.ErrorForm(Helps.Language.info["eliminadoError"] + "\n" + ex.Message);
                }
                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecEliminar"]);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? id = GetId();

                Cliente.frmClienteFormulario frmEditar = new Cliente.frmClienteFormulario(id);
                frmEditar.ShowDialog();
                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecEditar"]);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            metroGrid1.DataSource = bll.FindBy(TxtBuscar.Text);
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? id = GetId();

                Cliente.frmClienteDetalle frmDetalle = new Cliente.frmClienteDetalle((int)id);
                frmDetalle.ShowDialog();

            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecDetalle"]);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                bll.ExportProductosExcel();
                Notifications.FrmSuccess.SuccessForm(Helps.Language.info["excelOK"] + "\n" + ConfigurationManager.AppSettings["FolderExcel"]);
            }
            catch (Exception ex)
            {
                Notifications.FrmError.ErrorForm(Helps.Language.info["excelError"] + "\n" + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bll.ExportProductosPDF();
                Notifications.FrmSuccess.SuccessForm(Helps.Language.info["pdfOK"] + "\n" + ConfigurationManager.AppSettings["FolderPDF"]);
            }
            catch (Exception ex)
            {
                Notifications.FrmError.ErrorForm(Helps.Language.info["pdfError"] + "\n" + ex.Message);
            }
        }




        //private void DataGridViewDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //Producto.frmProductoFormulario frmProducto = Owner as Producto.frmProductoFormulario;
        //    //frmProducto.TxtCatId.Text = DataGridViewDatos.CurrentRow.Cells[0].Value.ToString();
        //    //frmProducto.TxtCatNomb.Text = DataGridViewDatos.CurrentRow.Cells[1].Value.ToString();
        //    //this.Close();

        //}



    }
}
