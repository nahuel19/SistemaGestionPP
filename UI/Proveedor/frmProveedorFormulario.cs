using BLL;
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

namespace UI.Proveedor
{
    /// <summary>
    /// formulario para nuevo proveedor o editar
    /// </summary>
    public partial class frmProveedorFormulario : MetroFramework.Forms.MetroForm
    {
        private int? id;
        private Entities.Proveedor entity = null;
        private ProveedorBLL bll = new ProveedorBLL();

        public frmProveedorFormulario(int? id = null)
        {
            InitializeComponent();
            ListTipoDoc();
            ChangeLanguage();

            this.id = id;
            if (id != null)
                CargaDatosEnForm();            
        }

       

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (id == null)
                entity = new Entities.Proveedor();

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

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Proveedor: " + entity.nombre, "", ""));

                        Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("guardadoOK"));

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == EValidaciones.existe)
                            Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("errorExiste"));
                        else if (ex.Message == EValidaciones.menor)
                            Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("errorMenor"));
                        else
                        {
                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Proveedor: " + entity.nombre, ex.StackTrace, ex.Message));
                            Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("guardadoError") + "\n" + ex.Message);
                        }
                    }
                }
                else
                {
                    try
                    {
                        bll.Update(entity);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Update, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Proveedor: " + entity.nombre, "", ""));

                        Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("editadoOK"));

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == EValidaciones.existe)
                            Notifications.FrmError.ErrorForm(Helps.Language.info["errorExiste"]);
                        if (ex.Message == EValidaciones.menor)
                            Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("errorMenor"));
                        else
                        {
                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Proveedor: " + entity.nombre, ex.StackTrace, ex.Message));
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
            this.Text = Helps.Language.SearchValue("btnProveedores");
            Helps.Language.controles(this);
        }
        private void CargaDatosEnForm()
        {
            try
            {
                entity = bll.GetById(Convert.ToInt32(id));
                TxtNombre.Text = entity.nombre;
                ddlTipoDoc.SelectedValue = entity.fk_id_tipo_doc_identidad;
                TxtDocumento.Text = entity.num_documento;
                txtDireccion.Text = entity.direccion;
                txtTel.Text = entity.telefono;
                txtMail.Text = entity.mail;
                txtUrl.Text = entity.url;
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }
        private Entities.Proveedor CargarEntity(Entities.Proveedor entity)
        {
            try
            {
                entity.nombre = TxtNombre.Text;
                entity.fk_id_tipo_doc_identidad = (int)ddlTipoDoc.SelectedValue;
                entity.num_documento = TxtDocumento.Text;
                entity.direccion = txtDireccion.Text;
                entity.telefono = txtTel.Text;
                entity.mail = txtMail.Text;
                entity.url = txtUrl.Text;
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }

            return entity;
        }
        private void ListTipoDoc()
        {
            try
            {
                ddlTipoDoc.DataSource = new TipoDoc_identidadBLL().List();
                ddlTipoDoc.ValueMember = "id";
                ddlTipoDoc.DisplayMember = "doc_identidad";
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }

        private void TxtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void frmProveedorFormulario_Load(object sender, EventArgs e)
        {
            HelpUser();
        }
        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Nuevo/editar proveedor");
            helpProvider1.SetHelpKeyword(this, "Nuevo/editar proveedor");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
