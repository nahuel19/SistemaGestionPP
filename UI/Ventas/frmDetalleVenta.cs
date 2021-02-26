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

namespace UI.Ventas
{
    /// <summary>
    /// form detalle de una venta
    /// </summary>
    public partial class frmDetalleVenta : MetroFramework.Forms.MetroForm
    {
        Entities.Doc_cabecera_egreso _Cabecera_egreso = new Entities.Doc_cabecera_egreso();
        List<Entities.Doc_detalle_egreso> listDetalle = new List<Entities.Doc_detalle_egreso>();

        BLL.Doc_cabecera_egresoBLL bllCab = new BLL.Doc_cabecera_egresoBLL();
        BLL.Doc_detalle_egresoBLL bllDet = new BLL.Doc_detalle_egresoBLL();

        private int id;

        public frmDetalleVenta(int _id)
        {
            id = _id;
            InitializeComponent();
            ChangeLanguage();
            CargarDatos();
            CaracteristicasGrid();
            CargarTotal();
        }

        private void CargarDatos()
        {
            try
            {
                _Cabecera_egreso = bllCab.GetById(id);
                _Cabecera_egreso.listDetalle = bllDet.ListDetallesByCabecera(id);

                lblFacturaValue.Text = _Cabecera_egreso.factura;
                lblClienteValue.Text = _Cabecera_egreso.nombre_cliente;
                lblTipoDocValue.Text = _Cabecera_egreso.tipo_documento;

                metroGrid1.DataSource = _Cabecera_egreso.listDetalle;

            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }
        private void CaracteristicasGrid()
        {
            try
            {
                metroGrid1.Columns["id"].Visible = false;
                metroGrid1.Columns["fk_id_doc_cabecera_egreso"].Visible = false;
                metroGrid1.Columns["fk_id_producto"].Visible = false;

                metroGrid1.Columns["nombre_producto"].DisplayIndex = 1;
                metroGrid1.Columns["cantidad"].DisplayIndex = 2;
                metroGrid1.Columns["precio"].DisplayIndex = 3;
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }

            //metroGrid1.Columns["nombre_producto"].Width = 150;
            //metroGrid1.Columns["cantidad"].Width = 50;
            //metroGrid1.Columns["precio"].Width = 80;
        }


        private void CargarTotal()
        {
            try
            {
                double tot = 0;
                _Cabecera_egreso.listDetalle.ForEach(x => tot += x.precio * x.cantidad);
                lblTotalValue.Text = tot.ToString();
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }

        private void ChangeLanguage()
        {
            Helps.Language.controles(this);
            this.Text = Helps.Language.SearchValue("BtnDetalle");            
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            HelpUser();
        }
        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Detalle Venta");
            helpProvider1.SetHelpKeyword(this, "Detalle Venta");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
