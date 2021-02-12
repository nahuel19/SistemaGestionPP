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
    public partial class frmIngresoFormulario : MetroFramework.Forms.MetroForm, IContractForm<Entities.Producto>, IContractForm<Entities.Proveedor>
    {
        //private static frmIngresoFormulario _instance;
        //public static frmIngresoFormulario Instance() => _instance == null ? _instance = new frmIngresoFormulario() : _instance;

        Entities.Doc_cabecera_ingreso _Cabecera_Ingreso = new Entities.Doc_cabecera_ingreso();
        
        List<Entities.Doc_detalle_ingreso> listDetalle = new List<Entities.Doc_detalle_ingreso>();
        BindingList<Entities.Doc_detalle_ingreso> bingindList = new BindingList<Entities.Doc_detalle_ingreso>();
        Entities.Proveedor proveedor = new Entities.Proveedor();
        public Entities.Producto producto;

        public frmIngresoFormulario()
        {
            InitializeComponent();
            producto = new Entities.Producto();
            
        }

        public void SetProveedor(int idProv, string prov)
        {
            proveedor.id = idProv;
            TxtProv.Text = prov;
        }
        public void SetProducto(int idProd, string prod)
        {
            producto.id = idProd;
            TxtProducto.Text = prod;
        }

        private void frmIngresoFormulario_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_instance = null;
        }

        private void btnBuscarProv_Click(object sender, EventArgs e)
        {
            Proveedor.frmSeleccionarProveedor seleccionarProveedor = new Proveedor.frmSeleccionarProveedor();
            seleccionarProveedor.ShowDialog();
        }

        private void btnSelecProducto_Click(object sender, EventArgs e)
        {
            Producto.frmSeleccionarProducto seleccionarProducto = new Producto.frmSeleccionarProducto();
            seleccionarProducto.contrato = this;
            seleccionarProducto.ShowDialog();

            //Producto.frmSeleccionarProducto seleccionarProducto = new Producto.frmSeleccionarProducto();
            //AddOwnedForm(seleccionarProducto);
            //seleccionarProducto.ShowDialog();
            //TxtProducto.Text = "";
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
                //metroGrid1.Refresh();

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


                //Entities.Doc_detalle_ingreso _Detalle_Ingreso = new Entities.Doc_detalle_ingreso();
                //_Detalle_Ingreso.fk_id_producto = GetIdProdEnGridDetalle();
                //_Detalle_Ingreso.cantidad = Convert.ToInt32(metroGrid1.CurrentRow.Cells["cantidad"].Value);
                //_Detalle_Ingreso.costo = Convert.ToDouble(metroGrid1.CurrentRow.Cells["costo"].Value);
                //_Detalle_Ingreso.precio = Convert.ToDouble(metroGrid1.CurrentRow.Cells["precio"].Value);
                //_Detalle_Ingreso.nombre_producto = metroGrid1.CurrentRow.Cells["nombre_producto"].Value.ToString(); 

                //int index = bingindList.IndexOf(_Detalle_Ingreso);

                //bingindList.RemoveAt(index);



                //listDetalle.RemoveAll(x => x.fk_id_producto == _id);
                //bingindList = (BindingList<Entities.Doc_detalle_ingreso>)bingindList.Except(bingindList.Where(a => a.fk_id_producto == _id));
                //bingindList = (BindingList<Entities.Doc_detalle_ingreso>)bingindList.Where(x=>x.fk_id_producto != _id);
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecEliminar"]);
            } 


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
    }
}
