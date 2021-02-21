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
using BLL.LogBitacora;
using Services;
using Services.Excepciones;

namespace UI.Ventas
{
    public partial class frmVentas : Form
    {
        BLL.Doc_cabecera_egresoBLL bllCabecera = new BLL.Doc_cabecera_egresoBLL();
        BLL.Doc_detalle_egresoBLL bllDetalle = new BLL.Doc_detalle_egresoBLL();

        public frmVentas()
        {
            InitializeComponent();
            ChangeLanguage();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Ventas.frmFormularioVenta frmVenta = Ventas.frmFormularioVenta.Instance();
            frmVenta.ShowDialog();

            RefrescarTabla();
        }

        #region helpers
        private void RefrescarTabla()
        {
            metroGrid1.DataSource = bllCabecera.List();

            CaracteristicasGrid();

            metroGrid1.ClearSelection();
            TxtBuscar.Focus();
        }

        private void CaracteristicasGrid()
        {

            metroGrid1.Columns["id"].Visible = false;
            metroGrid1.Columns["fk_id_tipo_doc"].Visible = false;
            metroGrid1.Columns["fk_id_cliente"].Visible = false;
            metroGrid1.Columns["letra"].Visible = false;
            metroGrid1.Columns["sucursal"].Visible = false;
            metroGrid1.Columns["numero"].Visible = false;
            metroGrid1.Columns["fk_id_usuario"].Visible = false;
            //metroGrid1.Columns["nombre_usuario"].Visible = false;



            metroGrid1.Columns["tipo_documento"].DisplayIndex = 1;
            metroGrid1.Columns["factura"].DisplayIndex = 2;
            metroGrid1.Columns["nombre_cliente"].DisplayIndex = 3;
            metroGrid1.Columns["fecha"].DisplayIndex = 4;
            metroGrid1.Columns["cancelada"].DisplayIndex = 5;


            metroGrid1.Columns["tipo_documento"].Width = 150;
            metroGrid1.Columns["factura"].Width = 150;
            metroGrid1.Columns["nombre_cliente"].Width = 220;
            metroGrid1.Columns["fecha"].Width = 150;
            metroGrid1.Columns["cancelada"].Width = 150;


            foreach (DataGridViewRow row in metroGrid1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["cancelada"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.DarkOrange;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }


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

        #endregion

        private void frmVentas_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? idEntity = GetId();

                Entities.Doc_cabecera_egreso entity = bllCabecera.GetById(Convert.ToInt32(idEntity));
                entity.listDetalle = bllDetalle.ListDetallesByCabecera(entity.id);

                try
                {
                    DialogResult confirmation = new Notifications.FrmQuestion(Helps.Language.info["preguntaEliminar"]).ShowDialog();

                    if (confirmation == DialogResult.OK)
                    {
                        bllCabecera.Anular(entity);
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Delete, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Ingreso anulado: " + entity.factura, "", ""));

                        RefrescarTabla();
                        Notifications.FrmSuccess.SuccessForm(Helps.Language.info["eliminadoOK"]);
                    }
                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.DeleteError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Ingreso anulado: " + entity.factura, ex.StackTrace, ex.Message));
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

        private void metroGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.metroGrid1.Columns[e.ColumnIndex].Name == "cancelada")
            {
                try
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        if (Convert.ToBoolean(e.Value) == true)
                        {
                            e.CellStyle.BackColor = Color.Red;
                        }
                    }
                }
                catch (NullReferenceException ex)
                {

                }
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Ventas.frmDetalleVenta frmDetalle = new Ventas.frmDetalleVenta((int)GetId());
            frmDetalle.ShowDialog();

            RefrescarTabla();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                bllCabecera.GetFacturaPDF((int)GetId());
                Notifications.FrmSuccess.SuccessForm(Helps.Language.info["pdfOK"] + "\n" + ConfigurationManager.AppSettings["FolderFacturas"]);
            }
            catch(FacturaAnuladaException ex)
            {
                Notifications.FrmError.ErrorForm(Helps.Language.info["pdfError"] + "\n" + ex.Error + "\n" + ex.Factura);
            }
            catch (Exception ex)
            {
                Notifications.FrmError.ErrorForm(Helps.Language.info["pdfError"] + "\n" + ex.Message);
            }
        }
    }
}
