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

namespace UI.Ingresos
{
    public partial class frmIngresoFormulario : MetroFramework.Forms.MetroForm, IContractForm<Entities.Producto>, IContractForm<Entities.Proveedor>
    {
        private static frmIngresoFormulario _instance;
        public static frmIngresoFormulario Instance() => _instance == null ? _instance = new frmIngresoFormulario() : _instance;

        Entities.Doc_cabecera_ingreso _Cabecera_Ingreso = new Entities.Doc_cabecera_ingreso();
        
        List<Entities.Doc_detalle_ingreso> listDetalle = new List<Entities.Doc_detalle_ingreso>();
        BindingList<Entities.Doc_detalle_ingreso> bingindList = new BindingList<Entities.Doc_detalle_ingreso>();

        public Entities.Proveedor proveedor;
        public Entities.Producto producto;

        BLL.Doc_cabecera_ingresoBLL bllCab = new BLL.Doc_cabecera_ingresoBLL();

        BLL.Tipo_documentoBLL bllTipoDoc = new BLL.Tipo_documentoBLL(); 

        public frmIngresoFormulario()
        {
            InitializeComponent();
            ListDocumento();
            producto = new Entities.Producto();
            proveedor = new Entities.Proveedor();
        }
             
        private void frmIngresoFormulario_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnBuscarProv_Click(object sender, EventArgs e)
        {
            Proveedor.frmSeleccionarProveedor seleccionarProveedor = new Proveedor.frmSeleccionarProveedor();
            seleccionarProveedor.contrato = this;
            seleccionarProveedor.ShowDialog();
        }

        private void btnSelecProducto_Click(object sender, EventArgs e)
        {
            Producto.frmSeleccionarProducto seleccionarProducto = new Producto.frmSeleccionarProducto();
            seleccionarProducto.contrato = this;
            seleccionarProducto.ShowDialog();          
        }

       
        private void AgregarTablaDetalle()
        {
            if (String.IsNullOrEmpty(TxtProducto.Text))
                Notifications.FrmInformation.InformationForm(Helps.Language.info["ingresarAllRegistros"]);

            try
            {
                Entities.Doc_detalle_ingreso _Detalle_Ingreso = new Entities.Doc_detalle_ingreso();
                _Detalle_Ingreso.fk_id_producto = producto.id;
                _Detalle_Ingreso.cantidad = Convert.ToInt32(txtCantidad.Text);
                _Detalle_Ingreso.costo = Convert.ToDouble(txtPrecioCompra.Text.ReplaceDot());
                _Detalle_Ingreso.precio = Convert.ToDouble(txtPrecioVenta.Text.ReplaceDot());                
                _Detalle_Ingreso.nombre_producto = TxtProducto.Text;
                

                //verifico si ya está ingresado
                foreach (var d in listDetalle)
                {
                    if (d.fk_id_producto == _Detalle_Ingreso.fk_id_producto)
                    {
                        Notifications.FrmInformation.InformationForm(Helps.Language.info["existeIngresoDetalle"]);
                        return;
                    }
                }

                bingindList.Add(_Detalle_Ingreso);
                listDetalle.Add(_Detalle_Ingreso);
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
                IReadOnlyList<Entities.Doc_detalle_ingreso> detalleToRemove = bingindList.Where(x => (x.fk_id_producto == id_prod)).ToList();

                foreach (var d in detalleToRemove)
                {
                    bingindList.Remove(d);
                    listDetalle.Remove(d);
                }               
            }
            else{ Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecEliminar"]); } 
        }

        private int GetIdProdEnGridDetalle()
        {
            return (int)metroGrid1.CurrentRow.Cells["fk_id_producto"].Value;
        }


        private void LimpiarCabecera()
        {
            TxtProv.Text = string.Empty;
            TxtLetra.Text = string.Empty;
            txtSuc.Text = string.Empty;
            txtNumero.Text = string.Empty;
           
        }

        private void LimpiarDetalle()
        {
            TxtProducto.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
        }


        private void btnAgregarProdALista_Click(object sender, EventArgs e)
        {
            AgregarTablaDetalle();
            LimpiarDetalle();
            metroGrid1.ClearSelection();
            //RefrescarTablaDetalle();
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

            metroGrid1.Columns["nombre_producto"].Width = 150;
            metroGrid1.Columns["cantidad"].Width = 50;
            metroGrid1.Columns["costo"].Width = 80;
            metroGrid1.Columns["precio"].Width = 80;
        }

        private void frmIngresoFormulario_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = bingindList;
            


        }

        private void btnQuitarProdLista_Click(object sender, EventArgs e)
        {
            QuitarTablaDetalle();
            metroGrid1.ClearSelection();
        }

        private void ListDocumento()
        {
            ddlTipoDoc.DataSource = bllTipoDoc.FindIngresos();
            ddlTipoDoc.ValueMember = "id";
            ddlTipoDoc.DisplayMember = "tipo_documento";
        }

        public void Ejecutar(Entities.Producto entity)
        {
            TxtProducto.Text = entity.nombre;
            producto.id = entity.id;                
        }

        public void Ejecutar(Entities.Proveedor entity)
        {
            TxtProv.Text = entity.nombre;
            proveedor.id = entity.id;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {   

            CargarEntity();

            var validation = new Helps.DataValidations(_Cabecera_Ingreso).Validate();
            bool valid = validation.Item1;

            if (valid == true)
            {
                try
                {
                    _Cabecera_Ingreso = bllCab.Insert(_Cabecera_Ingreso);

                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Ingreso: " + _Cabecera_Ingreso.letra+ _Cabecera_Ingreso.sucursal.ToString()+ _Cabecera_Ingreso.numero.ToString(), "", ""));

                    Notifications.FrmSuccess.SuccessForm(Helps.Language.info["guardadoOK"]);

                    this.Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message == EValidaciones.existe)
                        Notifications.FrmInformation.InformationForm(Helps.Language.info["errorExiste"]);
                    else
                    {
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Ingreso: " + _Cabecera_Ingreso.letra + _Cabecera_Ingreso.sucursal.ToString() + _Cabecera_Ingreso.numero.ToString(), ex.StackTrace, ex.Message));
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


        private void CargarEntity()
        {
            _Cabecera_Ingreso.fk_id_usuario = 0;

            _Cabecera_Ingreso.fk_id_proveedor = proveedor.id;
            _Cabecera_Ingreso.fk_id_tipo_doc = (int)ddlTipoDoc.SelectedValue;
            _Cabecera_Ingreso.fecha = dtpFecha.Value;
            _Cabecera_Ingreso.letra = TxtLetra.Text;
            _Cabecera_Ingreso.sucursal = Convert.ToInt32(txtSuc.Text);
            _Cabecera_Ingreso.numero = Convert.ToInt32(txtNumero.Text);
            _Cabecera_Ingreso.listDetalle = listDetalle;
        }

        
    }
}
