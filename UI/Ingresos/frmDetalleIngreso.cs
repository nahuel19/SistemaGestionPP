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

namespace UI.Ingresos
{
    /// <summary>
    /// form detalle de ingreso
    /// </summary>
    public partial class frmDetalleIngreso : MetroFramework.Forms.MetroForm
    {
        Entities.Doc_cabecera_ingreso _Cabecera_egreso = new Entities.Doc_cabecera_ingreso();
        List<Entities.Doc_detalle_ingreso> listDetalle = new List<Entities.Doc_detalle_ingreso>();

        BLL.Doc_cabecera_ingresoBLL bllCab = new BLL.Doc_cabecera_ingresoBLL();
        BLL.Doc_detalle_ingresoBLL bllDet = new BLL.Doc_detalle_ingresoBLL();

        private int id;

        public frmDetalleIngreso(int _id)
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
                lblProveedorValue.Text = _Cabecera_egreso.nombre_proveedor;
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
            metroGrid1.Columns["id"].Visible = false;
            metroGrid1.Columns["fk_id_doc_cabecera_ingreso"].Visible = false;
            metroGrid1.Columns["fk_id_producto"].Visible = false;
            metroGrid1.Columns["fk_id_precio"].Visible = false;

            metroGrid1.Columns["nombre_producto"].DisplayIndex = 1;
            metroGrid1.Columns["cantidad"].DisplayIndex = 2;
            metroGrid1.Columns["costo"].DisplayIndex = 3;
            metroGrid1.Columns["precio"].DisplayIndex = 4;

            //metroGrid1.Columns["nombre_producto"].Width = 150;
            //metroGrid1.Columns["cantidad"].Width = 50;
            //metroGrid1.Columns["costo"].Width = 80;
            //metroGrid1.Columns["precio"].Width = 80;
        }


        private void CargarTotal()
        {
            double tot = 0;
            try
            {
                _Cabecera_egreso.listDetalle.ForEach(x => tot += x.cantidad * x.costo);
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

        private void frmDetalleIngreso_Load(object sender, EventArgs e)
        {
            HelpUser();
        }

        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Detalle compra");
            helpProvider1.SetHelpKeyword(this, "Detalle compra");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
