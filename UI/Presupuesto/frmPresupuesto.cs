using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helps;

namespace UI.Presupuesto
{
    public partial class frmPresupuesto : Form, IContractForm<Entities.Producto>
    {
        private static frmPresupuesto _instance;
        public static frmPresupuesto Instance() => _instance == null ? _instance = new frmPresupuesto() : _instance;

        BLL.ProductoBLL bll = new BLL.ProductoBLL();
        public Entities.Producto producto = new Entities.Producto();
        BindingList<Entities.Producto> bingindList = new BindingList<Entities.Producto>();

        List<Entities.Producto> listProd = new List<Entities.Producto>();

        double total = 0;

        public frmPresupuesto()
        {
            InitializeComponent();
            ChangeLanguage();
        }

        private void frmPresupuesto_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnSelecProducto_Click(object sender, EventArgs e)
        {
            Producto.frmSeleccionarProducto seleccionarProducto = new Producto.frmSeleccionarProducto();
            seleccionarProducto.contrato = this;
            seleccionarProducto.ShowDialog();
        }

        private int GetIdProdEnGridDetalle()
        {
            return (int)metroGrid1.CurrentRow.Cells["id"].Value;
        }

        private void LimpiarDetalle()
        {
            TxtProducto.Text = string.Empty;
            txtCantidad.Text = string.Empty;           
        }

        public void Ejecutar(Entities.Producto entity)
        {
            TxtProducto.Text = entity.nombre;
            producto = entity;
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
            metroGrid1.Columns["categoria"].Visible = false;

            metroGrid1.Columns["codigo"].DisplayIndex = 1;
            metroGrid1.Columns["nombre"].DisplayIndex = 2;
            metroGrid1.Columns["precio"].DisplayIndex = 4;
            metroGrid1.Columns["cantidad"].DisplayIndex = 5;

            metroGrid1.Columns["codigo"].Width = 80;
            metroGrid1.Columns["nombre"].Width = 280;
            metroGrid1.Columns["precio"].Width = 150;
            metroGrid1.Columns["cantidad"].Width = 80;
        }

        private void AgregarTablaDetalle()
        {
            if (String.IsNullOrEmpty(TxtProducto.Text))
                Notifications.FrmInformation.InformationForm(Helps.Language.info["ingresarAllRegistros"]);

            try
            {
                producto.cantidad = Convert.ToInt32(txtCantidad.Text);  

                foreach (var d in listProd)
                {
                    if (d.id == producto.id)
                    {
                        Notifications.FrmInformation.InformationForm(Helps.Language.info["existeIngresoDetalle"]);
                        return;
                    }
                }
                total += producto.precio * producto.cantidad;
                bingindList.Add(producto);
                listProd.Add(producto);
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
                IReadOnlyList<Entities.Producto> detalleToRemove = bingindList.Where(x => (x.id == id_prod)).ToList();

                foreach (var d in detalleToRemove)
                {
                    total -= d.precio * d.cantidad;
                    bingindList.Remove(d);
                    listProd.Remove(d);                                        
                }
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecEliminar"]);
            }


        }

        private void btnAgregarProdALista_Click(object sender, EventArgs e)
        {
            AgregarTablaDetalle();
            LimpiarDetalle();
            metroGrid1.ClearSelection();

            
            lblTotValue.Text = total.ToString();

        }

        private void btnQuitarProdLista_Click(object sender, EventArgs e)
        {
            QuitarTablaDetalle();
            metroGrid1.ClearSelection();

            lblTotValue.Text = total.ToString();
        }

        private void frmPresupuesto_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = bingindList;
            lblTotValue.Text = total.ToString() ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bll.ExportPresupuestoExcel(listProd);
                Notifications.FrmSuccess.SuccessForm(Helps.Language.info["excelOK"] + "\n" + ConfigurationManager.AppSettings["FolderExcel"]);
                LimpiarDetalle();
            }
            catch (Exception ex)
            {
                Notifications.FrmError.ErrorForm(Helps.Language.info["excelError"] + "\n" + ex.Message);
            }
            LimpiarDetalle();
            bingindList = new BindingList<Entities.Producto>();
            listProd = new List<Entities.Producto>();
            
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                bll.ExportPresupuestoPDF(listProd);
                Notifications.FrmSuccess.SuccessForm(Helps.Language.info["pdfOK"] + "\n" + ConfigurationManager.AppSettings["FolderPDF"]);
                LimpiarDetalle();
            }
            catch (Exception ex)
            {
                Notifications.FrmError.ErrorForm(Helps.Language.info["pdfError"] + "\n" + ex.Message);
            }
            LimpiarDetalle();
            bingindList = new BindingList<Entities.Producto>();
            listProd = new List<Entities.Producto>();

        }

        private void ChangeLanguage()
        {            
            this.lblTituloPresupuesto.Text = Helps.Language.info["lblTituloPresupuesto"];
            Helps.Language.controles(this);
        }
    }
}
