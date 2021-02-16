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
    public partial class frmFormularioVenta : MetroFramework.Forms.MetroForm, IContractForm<Entities.Cliente>, IContractForm<Entities.Producto>
    {

        private static frmFormularioVenta _instance;
        public static frmFormularioVenta Instance() => _instance == null ? _instance = new frmFormularioVenta() : _instance;

        Entities.Cliente cliente;
        Entities.Producto producto;
        Entities.Tipo_documento tipo_documento;

        BLL.Tipo_documentoBLL Tipo_DocumentoBLL = new BLL.Tipo_documentoBLL();

        public frmFormularioVenta()
        {
            InitializeComponent();
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
            producto.id = entity.id;
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
    }
}
