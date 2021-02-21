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
using UI.Helps;

namespace UI.Ventas
{
    public partial class frmFormularioVenta : MetroFramework.Forms.MetroForm, IContractForm<Entities.Cliente>, IContractForm<Entities.Producto>
    {

        private static frmFormularioVenta _instance;
        public static frmFormularioVenta Instance() => _instance == null ? _instance = new frmFormularioVenta() : _instance;

        Entities.Cliente cliente;
        Entities.Producto producto;
        Entities.Tipo_documento tipo_documento;

        BLL.Tipo_documentoBLL Tipo_DocumentoBLL = new BLL.Tipo_documentoBLL();
        BLL.Doc_cabecera_egresoBLL bllCab = new BLL.Doc_cabecera_egresoBLL();

        Entities.Doc_cabecera_egreso _Cabecera_egreso = new Entities.Doc_cabecera_egreso();

        List<Entities.Doc_detalle_egreso> listDetalle = new List<Entities.Doc_detalle_egreso>();
        BindingList<Entities.Doc_detalle_egreso> bingindList = new BindingList<Entities.Doc_detalle_egreso>();

        public frmFormularioVenta()
        {
            InitializeComponent();
            ChangeLanguage();
            cliente = new Entities.Cliente();
            producto = new Entities.Producto();
            ListDocumento();
            ddlTipoDoc.SelectedIndex = 0;
            CargarNumeroFactura();

        }

        private void ListDocumento()
        {
            ddlTipoDoc.DataSource = Tipo_DocumentoBLL.FindEgresos();
            ddlTipoDoc.ValueMember = "id";
            ddlTipoDoc.DisplayMember = "tipo_documento";
        }
        public void CargarNumeroFactura()
        {
            int _iddoc = (int)ddlTipoDoc.SelectedValue;
            tipo_documento = Tipo_DocumentoBLL.GetById(_iddoc);
            lblLetraValue.Text = tipo_documento.letra;
            lblSucValue.Text = tipo_documento.sucursal.ToString();
            lblNumeroValue.Text = (tipo_documento.numero + 1).ToString();
        }

        public void Ejecutar(Entities.Cliente entity)
        {
            TxtCliente.Text = entity.nombre;
            cliente.id = entity.id;
        }
        public void Ejecutar(Entities.Producto entity)
        {
            TxtProducto.Text = entity.nombre;
            lblPrecioValue.Text = entity.precio.ToString();
            producto.id = entity.id;
            producto.precio = entity.precio;
        }

        private void btnBuscarProv_Click(object sender, EventArgs e)
        {
            CargarNumeroFactura();
            Cliente.frmSeleccionarCliente seleccionarCli = new Cliente.frmSeleccionarCliente();
            seleccionarCli.contrato = this;
            seleccionarCli.ShowDialog();
        }

        private void btnSelecProducto_Click(object sender, EventArgs e)
        {
            Producto.frmSeleccionarProducto seleccionarProducto = new Producto.frmSeleccionarProducto();
            seleccionarProducto.contrato = this;
            seleccionarProducto.ShowDialog();
        }

        
        private void ddlTipoDoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarNumeroFactura();
        }

        private void ChangeLanguage()
        {
            this.Text = Helps.Language.info["btnVentas"];
            this.lblTipoDoc.Text = Helps.Language.info["lblTipoDoc"];
            this.lblPrecioVenta.Text = Helps.Language.info["lblPrecioVenta"];
            this.lblCant.Text = Helps.Language.info["lblCant"];
            this.lblLetra.Text = Helps.Language.info["lblLetra"];
            this.lblSucursal.Text = Helps.Language.info["lblSucursal"];
            this.lblNumero.Text = Helps.Language.info["lblNumero"];
            this.lblCliente.Text = Helps.Language.info["lblCliente"];
            this.lblTotal.Text = Helps.Language.info["lblTotal"];
            Helps.Language.controles(this);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            CargarEntity();

            var validation = new Helps.DataValidations(_Cabecera_egreso).Validate();
            bool valid = validation.Item1;

            if (valid == true)
            {
                try
                {
                    _Cabecera_egreso = bllCab.Insert(_Cabecera_egreso);

                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Egreso: " + _Cabecera_egreso.letra + _Cabecera_egreso.sucursal.ToString() + _Cabecera_egreso.numero.ToString(), "", ""));

                    Notifications.FrmSuccess.SuccessForm(Helps.Language.info["guardadoOK"]);

                    this.Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message == EValidaciones.existe)
                        Notifications.FrmInformation.InformationForm(Helps.Language.info["errorExiste"]);
                    else
                    {
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Egreso: " + _Cabecera_egreso.letra + _Cabecera_egreso.sucursal.ToString() + _Cabecera_egreso.numero.ToString(), ex.StackTrace, ex.Message));
                        Notifications.FrmError.ErrorForm(Helps.Language.info["guardadoError"] + "\n" + ex.Message);
                    }
                }

            }
            else
            {
                string messageValid = validation.Item2;
                Notifications.FrmInformation.InformationForm(messageValid);
            }
        }

        private void frmFormularioVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }


        private void AgregarTablaDetalle()
        {
            if (String.IsNullOrEmpty(TxtProducto.Text))
                Notifications.FrmInformation.InformationForm(Helps.Language.info["ingresarAllRegistros"]);

            try
            {
                Entities.Doc_detalle_egreso _Detalle_egreso = new Entities.Doc_detalle_egreso();
                _Detalle_egreso.fk_id_producto = producto.id;
                _Detalle_egreso.cantidad = Convert.ToInt32(txtCantidad.Text);
                _Detalle_egreso.precio = Convert.ToDouble(producto.precio);
                _Detalle_egreso.nombre_producto = TxtProducto.Text;


                //verifico si ya está ingresado
                foreach (var d in listDetalle)
                {
                    if (d.fk_id_producto == _Detalle_egreso.fk_id_producto)
                    {
                        Notifications.FrmInformation.InformationForm(Helps.Language.info["existeIngresoDetalle"]);
                        return;
                    }
                }

                bingindList.Add(_Detalle_egreso);
                listDetalle.Add(_Detalle_egreso);
                CaracteristicasGrid();
            }
            catch
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["ingresarAllRegistros"]);
            }

        }

        private void QuitarTablaDetalle()
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int id_prod = GetIdProdEnGridDetalle();
                IReadOnlyList<Entities.Doc_detalle_egreso> detalleToRemove = bingindList.Where(x => (x.fk_id_producto == id_prod)).ToList();

                foreach (var d in detalleToRemove)
                {
                    bingindList.Remove(d);
                    listDetalle.Remove(d);
                }
            }
            else { Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecEliminar"]); }
        }

        private int GetIdProdEnGridDetalle()
        {
            return (int)metroGrid1.CurrentRow.Cells["fk_id_producto"].Value;
        }

        private void LimpiarDetalle()
        {
            TxtProducto.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            lblPrecioValue.Text = string.Empty;
        }

        private void CaracteristicasGrid()
        {
            metroGrid1.Columns["id"].Visible = false;
            metroGrid1.Columns["fk_id_doc_cabecera_egreso"].Visible = false;
            metroGrid1.Columns["fk_id_producto"].Visible = false;
          
            metroGrid1.Columns["nombre_producto"].DisplayIndex = 1;
            metroGrid1.Columns["cantidad"].DisplayIndex = 2;
            metroGrid1.Columns["precio"].DisplayIndex = 3;

            metroGrid1.Columns["nombre_producto"].Width = 150;
            metroGrid1.Columns["cantidad"].Width = 50;
            metroGrid1.Columns["precio"].Width = 80;
        }

        private void CargarEntity()
        {
            _Cabecera_egreso.fk_id_usuario = 0;
            _Cabecera_egreso.fk_id_cliente = cliente.id;
            _Cabecera_egreso.fk_id_tipo_doc = (int)ddlTipoDoc.SelectedValue;           
            _Cabecera_egreso.listDetalle = listDetalle;
            _Cabecera_egreso.letra = lblLetraValue.Text;
            _Cabecera_egreso.sucursal = Convert.ToInt32(lblSucValue.Text);
            _Cabecera_egreso.numero = Convert.ToInt32(lblNumeroValue.Text);
        }

        private void frmFormularioVenta_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = bingindList;
        }

        private void btnAgregarProdALista_Click(object sender, EventArgs e)
        {
            AgregarTablaDetalle();
            LimpiarDetalle();            
            metroGrid1.ClearSelection();
            CargarTotal();
        }

        private void btnQuitarProdLista_Click(object sender, EventArgs e)
        {
            QuitarTablaDetalle();
            CargarTotal();
            metroGrid1.ClearSelection();
            CargarTotal();
        }


        private void CargarTotal()
        {
            double tot = 0;
            listDetalle.ForEach(x => tot += x.precio * x.cantidad);
            lblTotalValue.Text = tot.ToString();           
        }
    }
}
