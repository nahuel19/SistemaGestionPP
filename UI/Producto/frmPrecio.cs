using BLL;
using BLL.LogBitacora;
using Services;
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

namespace UI.Producto
{
    public partial class frmPrecio : MetroFramework.Forms.MetroForm
    {
        private Entities.Producto producto = null;
        private Entities.Precio precio = new Entities.Precio();
        private Entities.Movimiento_producto movProd = new Entities.Movimiento_producto();

        private ProductoBLL bllProd = new ProductoBLL();
        private PrecioBLL bllPrecio = new PrecioBLL();
        private Movimiento_productoBLL bllMov = new Movimiento_productoBLL();

        private int id;

        public frmPrecio(int _id)
        {
            InitializeComponent();
            ChangeLanguage();
            CargaDatosEnForm(_id);
            id = _id;
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPorcentaje.Text))
            {
                CargarEntidades(Convert.ToInt32(ConfigurationManager.AppSettings["ajusteInflacion"]));
                GuardarDatos();
                CargaDatosEnForm(id);
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["ingresarPorcentaje"]);
            }
            
        }


        private void GuardarDatos()
        {
            var validation = new Helps.DataValidations(precio).Validate();
            bool valid = validation.Item1;

            if (valid == true)
            {
                try
                {
                    bllPrecio.Insert(precio);
                    bllMov.Insert(movProd);

                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Precio Producto: " + producto.codigo + ' ' + precio.precio, "", ""));
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Movimiento Producto: " + producto.codigo + ' ' + movProd.movimiento, "", ""));
                    Notifications.FrmSuccess.SuccessForm(Helps.Language.info["guardadoOK"]);

                    this.Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message == EValidaciones.existe)
                        Notifications.FrmInformation.InformationForm(Helps.Language.info["errorExiste"]);
                    else
                    {
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Precio Producto: " + producto.codigo + ' ' + precio.precio, ex.StackTrace, ex.Message));
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Movimiento Producto: " + producto.codigo + ' ' + movProd.movimiento, ex.StackTrace, ex.Message));
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

        private void CargaDatosEnForm(int id)
        {
            producto = bllProd.GetById(id);

            lblCodValue.Text = producto.codigo;
            lblNombreValue.Text = producto.nombre;
            lblPrecioValue.Text = producto.precio.ToString();
        
        }

        private void CargarEntidades(int tipo_mov)
        {           
            
            precio.fk_id_producto = producto.id;
            precio.costo = 0;

            double porcentaje;

            try
            {
                porcentaje = (Convert.ToDouble(txtPorcentaje.Text)/100) +1;
            }
            catch (Exception ex)
            {
                Notifications.FrmInformation.InformationForm(ex.Message);
                return;
            }

            double nuevoPrecio= Convert.ToDouble(producto.precio) * porcentaje; 

            movProd.fk_id_producto = producto.id;
            movProd.fk_id_tipo_mov_prod = tipo_mov;
            movProd.antes = producto.precio;
            movProd.movimiento = Convert.ToDouble(txtPorcentaje.Text);
            movProd.despues = nuevoPrecio;
            movProd.extra = txtMotivo.Text;

            precio.precio = nuevoPrecio;

        }

        private void txtNuevoPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPorcentaje.Text))
            {
                double precioFuturo = 0.0;
                try
                {
                    double porcentaje = (Convert.ToDouble(txtPorcentaje.Text) / 100) + 1;
                    precioFuturo = producto.precio * porcentaje;
                }
                catch {}

                if (txtPorcentaje.Text.Contains("."))
                {
                    //string p = txtPorcentaje.Text;                    
                    txtPorcentaje.Text= txtPorcentaje.Text.Replace(".", ",");                 
                }

                lblPrecioFuturo.Text = precioFuturo.ToString();
            }
            else
            {
                lblPrecioFuturo.Text = "";
            }

            
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if (Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar) ) //permitir teclas de control como retroceso y signos de puntuación
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }


        private void ChangeLanguage()
        {
            Helps.Language.controles(this);
            this.Text = Helps.Language.info["lblPrecio"];            
        }
    }
}
