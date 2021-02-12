using BLL.LogBitacora;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Ingresos
{
    public partial class frmIngreso : Form
    {
        BLL.Doc_cabecera_ingresoBLL bllCabecera = new BLL.Doc_cabecera_ingresoBLL();
        public frmIngreso()
        {
            InitializeComponent();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Ingresos.frmIngresoFormulario frmIngreso = new Ingresos.frmIngresoFormulario()/*.Instance*/;
            frmIngreso.ShowDialog();

            RefrescarTabla();
        }



        #region helpers
        private void RefrescarTabla()
        {
            metroGrid1.DataSource = bllCabecera.List();

            //CaracteristicasGrid();

            metroGrid1.ClearSelection();
            TxtBuscar.Focus();
        }

        //private void CaracteristicasGrid()
        //{

        //    metroGrid1.Columns["id"].Visible = false;
        //    metroGrid1.Columns["fk_id_categoria"].Visible = false;
        //    metroGrid1.Columns["peso"].Visible = false;
        //    metroGrid1.Columns["alto"].Visible = false;
        //    metroGrid1.Columns["ancho"].Visible = false;
        //    metroGrid1.Columns["profundidad"].Visible = false;
        //    metroGrid1.Columns["descripcion"].Visible = false;

        //    metroGrid1.Columns["codigo"].DisplayIndex = 1;
        //    metroGrid1.Columns["nombre"].DisplayIndex = 2;
        //    metroGrid1.Columns["categoria"].DisplayIndex = 3;
        //    metroGrid1.Columns["precio"].DisplayIndex = 4;
        //    metroGrid1.Columns["cantidad"].DisplayIndex = 5;

        //    metroGrid1.Columns["codigo"].Width = 80;
        //    metroGrid1.Columns["nombre"].Width = 280;
        //    metroGrid1.Columns["categoria"].Width = 190;
        //    metroGrid1.Columns["precio"].Width = 150;
        //    metroGrid1.Columns["cantidad"].Width = 80;


        //}

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

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? idEntity = GetId();

                Entities.Doc_cabecera_ingreso entity = bllCabecera.GetById(Convert.ToInt32(idEntity));

                try
                {
                    DialogResult confirmation = new Notifications.FrmQuestion(Helps.Language.info["preguntaEliminar"]).ShowDialog();

                    if (confirmation == DialogResult.OK)
                    {
                        bllCabecera.Delete(Convert.ToInt32(idEntity));
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

        private void btnDetalle_Click(object sender, EventArgs e)
        {

        }
    }
}
