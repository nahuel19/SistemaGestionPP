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

namespace UI.Usuario
{
    public partial class frmUsuarioFormulario : MetroFramework.Forms.MetroForm
    {
        private int? id;
        private int? editaElUsuario;
        private Entities.Usuario entity = null;
        private UsuarioBLL bll = new UsuarioBLL();

        public frmUsuarioFormulario(int? id = null, int? _editaElUsuario = null)
        {
            InitializeComponent();
    
            this.id = id;

            if (id != null)
            {
                CargaDatosEnForm();

                if (_editaElUsuario != null)
                {
                    editaElUsuario = _editaElUsuario;
                    TxtPassAnterior.Visible = true;
                    lblPassAnterior.Visible = true;
                    pictureBoxPassAnterior.Visible = true;
                }
            }
                



        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (id == null)
                entity = new Entities.Usuario();

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

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Usuario: " + entity.nombre, "", ""));

                        Notifications.FrmSuccess.SuccessForm(Helps.Language.info["guardadoOK"]);

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == EValidaciones.existe)
                            Notifications.FrmInformation.InformationForm(Helps.Language.info["errorExiste"]);
                        else
                        {
                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Usuario: " + entity.nombre, ex.StackTrace, ex.Message));
                            Notifications.FrmError.ErrorForm(Helps.Language.info["guardadoError"] + "\n" + ex.Message);
                        }
                    }
                }               
                else
                {
                    if (editaElUsuario == null)
                    {
                        try
                        {
                            bll.Update(entity);

                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Update, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Usuario: " + entity.nombre, "", ""));

                            Notifications.FrmSuccess.SuccessForm(Helps.Language.info["editadoOK"]);

                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message == EValidaciones.existe)
                                Notifications.FrmError.ErrorForm(Helps.Language.info["errorExiste"]);
                            else
                            {
                                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Usuario: " + entity.nombre, ex.StackTrace, ex.Message));
                                Notifications.FrmError.ErrorForm(Helps.Language.info["editadoError"] + "\n" + ex.Message);
                            }
                        } 
                    }
                    else 
                    {
                        try
                        {
                            CargarEntityVerificarUsuario(entity);

                            bool isValid = bll.Login(entity);

                            if (isValid)
                            {
                                CargarEntity(entity);
                                bll.Update(entity);

                                bll.Login(entity);
                                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Update, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Usuario: " + entity.nombre, "", ""));

                                Notifications.FrmSuccess.SuccessForm(Helps.Language.info["editadoOK"]);

                                this.Close();
                            }
                            else
                            {
                                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Usuario: " + entity.nombre, "", ""));
                                Notifications.FrmError.ErrorForm(Language.info["loginError"]);
                            }

                        }
                        catch (Exception ex)
                        {
                            if (ex.Message == EValidaciones.existe)
                                Notifications.FrmError.ErrorForm(Helps.Language.info["errorExiste"]);
                            else
                            {
                                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Usuario: " + entity.nombre, ex.StackTrace, ex.Message));
                                Notifications.FrmError.ErrorForm(Helps.Language.info["editadoError"] + "\n" + ex.Message);
                            }
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
            entity = bll.GetById(Convert.ToInt32(id));
            TxtNombre.Text = entity.nombre;
        }
        private Entities.Usuario CargarEntity(Entities.Usuario entity)
        {
            entity.nombre = TxtNombre.Text;
            entity.passSinEncriptar = txtPassNueva.Text;          
    
            return entity;
        }

        private Entities.Usuario CargarEntityVerificarUsuario(Entities.Usuario entity)
        {
            entity.nombre = TxtNombre.Text;
            entity.passSinEncriptar = TxtPassAnterior.Text;

            return entity;
        }




    }
}
