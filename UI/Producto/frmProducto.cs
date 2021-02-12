using BLL;
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

namespace UI
{
    public partial class frmProducto : Form
    {
        ProductoBLL bll = new ProductoBLL();

        public frmProducto()
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
            metroGrid1.Columns["fk_id_categoria"].Visible = false;
            metroGrid1.Columns["peso"].Visible = false;
            metroGrid1.Columns["alto"].Visible = false;
            metroGrid1.Columns["ancho"].Visible = false;
            metroGrid1.Columns["profundidad"].Visible = false;
            metroGrid1.Columns["descripcion"].Visible = false;

            metroGrid1.Columns["codigo"].DisplayIndex = 1;
            metroGrid1.Columns["nombre"].DisplayIndex = 2;
            metroGrid1.Columns["categoria"].DisplayIndex = 3;
            metroGrid1.Columns["precio"].DisplayIndex = 4;
            metroGrid1.Columns["cantidad"].DisplayIndex = 5;

            metroGrid1.Columns["codigo"].Width = 80;
            metroGrid1.Columns["nombre"].Width = 280;
            metroGrid1.Columns["categoria"].Width = 190;
            metroGrid1.Columns["precio"].Width = 150;
            metroGrid1.Columns["cantidad"].Width = 80;


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

        private void frmProducto_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Producto.frmProductoFormulario frm = new Producto.frmProductoFormulario();
            frm.ShowDialog();

            RefrescarTabla();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? id = GetId();

                Producto.frmProductoFormulario frmEditar = new Producto.frmProductoFormulario(id);
                frmEditar.ShowDialog();
                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecEditar"]);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? idEntity = GetId();

                Entities.Producto entity = bll.GetById(Convert.ToInt32(idEntity));

                try
                {
                    DialogResult confirmation = new Notifications.FrmQuestion(Helps.Language.info["preguntaEliminar"]).ShowDialog();

                    if (confirmation == DialogResult.OK)
                    {
                        bll.Delete(Convert.ToInt32(idEntity));
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Delete, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Producto: " + entity.codigo, "", ""));

                        RefrescarTabla();
                        Notifications.FrmSuccess.SuccessForm(Helps.Language.info["eliminadoOK"]);

                    }
                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.DeleteError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Producto: " + entity.codigo, ex.StackTrace, ex.Message));
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

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Categoria.FrmCategoria frmCatNueva = new Categoria.FrmCategoria();
            frmCatNueva.ShowDialog();
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

                Producto.frmProductoDetalle frmDetalle = new Producto.frmProductoDetalle((int)id);
                frmDetalle.ShowDialog();
                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecDetalle"]);
            }
        }

        
    }
}
