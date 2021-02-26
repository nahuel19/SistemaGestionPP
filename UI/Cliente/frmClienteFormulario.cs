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
using UI.Helps;

namespace UI.Cliente
{
    /// <summary>
    /// form cliente formulario
    /// </summary>
    public partial class frmClienteFormulario : MetroFramework.Forms.MetroForm
    {

        private int? id;
        private Entities.Cliente entity = null;
        private ClienteBLL bll = new ClienteBLL();

        public frmClienteFormulario(int? id = null)
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
                entity = new Entities.Cliente();
            
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

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Cliente: " + entity.num_documento, "", ""));

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
                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Cliente: " + entity.num_documento, ex.StackTrace, ex.Message));
                            Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("guardadoError") + "\n" + ex.Message);
                        }
                    }
                }
                else
                {
                    try
                    {
                        bll.Update(entity);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Update, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Cliente: " + entity.num_documento, "", ""));

                        Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("editadoOK"));

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == EValidaciones.existe)
                            Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("errorExiste"));
                        if (ex.Message == EValidaciones.menor)
                            Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("errorMenor"));
                        else
                        {
                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Cliente: " + entity.num_documento, ex.StackTrace, ex.Message));
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


        private void CargaDatosEnForm()
        {
            try
            {
                entity = bll.GetById(Convert.ToInt32(id));
                TxtNombre.Text = entity.nombre;
                TxtApellido.Text = entity.apellido;
                ddlTipoDoc.SelectedValue = entity.fk_id_tipo_doc_identidad;
                TxtDocumento.Text = entity.num_documento;
                dtpNacimiento.Text = entity.fecha_nacimiento.ToString();
                txtDireccion.Text = entity.direccion;
                txtTel.Text = entity.telefono;
                txtMail.Text = entity.mail;
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }
        private Entities.Cliente CargarEntity(Entities.Cliente entity)
        {
            entity.nombre = TxtNombre.Text;
            entity.apellido = TxtApellido.Text;
            entity.fk_id_tipo_doc_identidad = (int)ddlTipoDoc.SelectedValue;
            entity.num_documento = TxtDocumento.Text;
            entity.fecha_nacimiento = dtpNacimiento.Value;
            entity.direccion = txtDireccion.Text;
            entity.telefono = txtTel.Text;
            entity.mail = txtMail.Text;

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


        private void ChangeLanguage()
        {
            this.Text = Helps.Language.info["btnClientes"];
            Helps.Language.controles(this);
        }

        private void TxtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (Char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //if (Char.IsControl(e.KeyChar) ) 
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private void frmClienteFormulario_Load(object sender, EventArgs e)
        {
            HelpUser();
        }
        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Nuevo/editar cliente");
            helpProvider1.SetHelpKeyword(this, "Nuevo/editar cliente");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
