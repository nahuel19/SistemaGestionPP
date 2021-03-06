﻿using BLL;
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

namespace UI.Producto
{
    /// <summary>
    /// formulario para nuevo producto o editar
    /// </summary>
    public partial class frmProductoFormulario : MetroFramework.Forms.MetroForm
    {
        public int? id;
        Entities.Producto entity = null;
        ProductoBLL bll = new ProductoBLL();
        CategoriaBLL catBll = new CategoriaBLL();

        public frmProductoFormulario(int? id = null)
        {
            InitializeComponent();
            ChangeLanguage();
            ListCategoria();

            this.id = id;
            if (id != null)
                CargaDatosEnForm();
        }

        private void CargaDatosEnForm()
        {
            try
            {
                entity = bll.GetById(Convert.ToInt32(id));
                TxtNombre.Text = entity.nombre;
                txtDescripcion.Text = entity.descripcion;
                ddlCategoria.SelectedValue = entity.fk_id_categoria;
                txtAlto.Text = entity.alto.ToString();
                txtAncho.Text = entity.ancho.ToString();
                txtProfundidad.Text = entity.profundidad.ToString();
                txtPeso.Text = entity.peso.ToString();
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }
        private Entities.Producto CargarEntity(Entities.Producto entity)
        {
            try
            {
                entity.nombre = TxtNombre.Text;
                entity.descripcion = txtDescripcion.Text;
                entity.fk_id_categoria = (int)ddlCategoria.SelectedValue;
                entity.alto = String.IsNullOrEmpty(txtAlto.Text) ? 0 : Convert.ToDouble(txtAlto.Text);
                entity.ancho = String.IsNullOrEmpty(txtAncho.Text) ? 0 : Convert.ToDouble(txtAncho.Text);
                entity.profundidad = String.IsNullOrEmpty(txtProfundidad.Text) ? 0 : Convert.ToDouble(txtProfundidad.Text);
                entity.peso = String.IsNullOrEmpty(txtPeso.Text) ? 0 : Convert.ToDouble(txtPeso.Text);
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }

            return entity;
        }
        private void ListCategoria()
        {
            try
            {
                ddlCategoria.DataSource = new CategoriaBLL().List();
                ddlCategoria.ValueMember = "id";
                ddlCategoria.DisplayMember = "categoria";


                ddlCategoria.AutoCompleteCustomSource = AutocompleteDropDownCategoria();
                ddlCategoria.AutoCompleteMode = AutoCompleteMode.Suggest;
                ddlCategoria.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
            
        }

        private AutoCompleteStringCollection AutocompleteDropDownCategoria()
        {
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            try
            {                
                List<Entities.Categoria> listCat = new List<Entities.Categoria>();
                foreach(var cat in new CategoriaBLL().List())
                {
                    auto.Add(cat.categoria);
                }
                
            }
            catch(Exception ex)
            {
                Notifications.FrmInformation.InformationForm(ex.Message);
            }

            return auto;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (id == null)
                entity = new Entities.Producto();

            CargarEntity(entity);

            var validation = new Helps.DataValidations(entity).Validate();
            bool valid = validation.Item1;

            if (valid == true)
            {
                if (id == null)
                {
                    try
                    {
                        entity = bll.Insert(entity);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Producto: " + entity.codigo, "", ""));

                        Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("guardadoOK"));

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == EValidaciones.existe)
                            Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("errorExiste"));
                        else
                        {
                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Producto: " + entity.codigo, ex.StackTrace, ex.Message));
                            Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("guardadoError") + "\n" + ex.Message);
                        }
                    }
                }
                else
                {
                    try
                    {
                        bll.Update(entity);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Update, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Producto: " + entity.codigo, "", ""));

                        Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("editadoOK"));

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == EValidaciones.existe)
                            Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("errorExiste"));                        
                        else
                        {
                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Producto: " + entity.codigo, ex.StackTrace, ex.Message));
                            Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("editadoError") + "\n" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                string messageValid = validation.Item2;
                Notifications.FrmInformation.InformationForm(messageValid);
            }
        }

        private void ChangeLanguage()
        {
            Helps.Language.controles(this);
            this.Text = Helps.Language.SearchValue("producto");
        }

        private void frmProductoFormulario_Load(object sender, EventArgs e)
        {
            HelpUser();
        }

        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Nuevo/editar producto");
            helpProvider1.SetHelpKeyword(this, "Nuevo/editar producto");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
