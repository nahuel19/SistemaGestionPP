﻿using BLL;
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
using UI.Helps;

namespace UI.Producto
{
    /// <summary>
    /// form ajuste stock productos
    /// </summary>
    public partial class frmAddStock : MetroFramework.Forms.MetroForm
    {
        private Entities.Producto producto = null;
        private Entities.Stock stock = new Entities.Stock();
        private Entities.Movimiento_producto movProd = new Entities.Movimiento_producto();

        private ProductoBLL bllProd = new ProductoBLL();
        private StockBLL bllStock = new StockBLL();
        private Movimiento_productoBLL bllMov = new Movimiento_productoBLL();

        private int id;
        public frmAddStock(int _id)
        {
            InitializeComponent();
            ChangeLanguage();
            CargaDatosEnForm(_id);
            id = _id;
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtStock.Text))
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("stockVacio"));
            }
            else
            {
                if (Convert.ToInt32(txtStock.Text) == producto.cantidad)                
                    Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("mismoStock"));
                                
                if (Convert.ToInt32(txtStock.Text) > producto.cantidad)
                {
                    CargarEntidades(Convert.ToInt32(ConfigurationManager.AppSettings["ingresoStock"]));
                    GuardarDatos();
                }

                if (Convert.ToInt32(txtStock.Text) < producto.cantidad)
                {
                    CargarEntidades(Convert.ToInt32(ConfigurationManager.AppSettings["egresoStock"]));
                    GuardarDatos();
                }                
            }

            CargaDatosEnForm(id);

        }


        private void GuardarDatos()
        {
            var validation = new Helps.DataValidations(stock).Validate();
            bool valid = validation.Item1;

            if (valid == true)
            {
                try
                {
                    bllStock.Update(stock);
                    bllMov.Insert(movProd);

                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Stock Producto: " + producto.codigo + ' ' + stock.cantidad, "", ""));
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Movimiento Producto: " + producto.codigo + ' ' + movProd.movimiento, "", ""));

                    Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("guardadoOK"));

                    this.Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message == EValidaciones.existe)
                        Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("errorExiste"));
                    else
                    {
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Stock Producto: " + producto.codigo + ' ' + stock.cantidad, ex.StackTrace, ex.Message));
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Movimiento Producto: " + producto.codigo + ' ' + movProd.movimiento, ex.StackTrace, ex.Message));
                        Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("guardadoError") + "\n" + ex.Message);
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
            try
            {
                producto = bllProd.GetById(Convert.ToInt32(id));

                lblCodValue.Text = producto.codigo;
                lblNombreValue.Text = producto.nombre;
                txtStock.Text = producto.cantidad.ToString();
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }

        private void CargarEntidades(int tipo_mov)
        {
            try
            {
                stock.fk_id_producto = producto.id;
                stock.cantidad = Convert.ToInt32(txtStock.Text);

                movProd.fk_id_producto = producto.id;
                movProd.fk_id_tipo_mov_prod = tipo_mov;
                movProd.antes = producto.cantidad;
                movProd.movimiento = Convert.ToInt32(txtStock.Text) - producto.cantidad;
                movProd.despues = Convert.ToInt32(txtStock.Text);
                movProd.extra = txtMotivo.Text;
                movProd.fecha = DateTime.Now;
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
            this.Text = Helps.Language.SearchValue("lblPrecio");
        }

        private void frmAddStock_Load(object sender, EventArgs e)
        {
            HelpUser();
        }
        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Stock");
            helpProvider1.SetHelpKeyword(this, "Stock");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
