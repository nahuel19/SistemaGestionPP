﻿using BLL;
using BLL.LogBitacora;
using Services;
using Services.Encriptación;
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
        private string id;
        private int? editaElUsuario;
        private Entities.UFP.Usuario entity = null;

        public frmUsuarioFormulario(string id = null, int? _editaElUsuario = null)
        {
            InitializeComponent();
            ChangeLanguage();


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
                entity = new Entities.UFP.Usuario();

            CargarEntity(entity);

            var validation = new Helps.DataValidations(entity).Validate();
            bool valid = validation.Item1;

            if (valid == true)
            {
                if (id == null)
                {
                    try
                    {
                        BLL.UFP.Usuario.Insert(entity);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Usuario: " + entity.Nombre, "", ""));

                        Notifications.FrmSuccess.SuccessForm(Helps.Language.info["guardadoOK"]);

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == EValidaciones.existe)
                            Notifications.FrmInformation.InformationForm(Helps.Language.info["errorExiste"]);
                        else
                        {
                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Usuario: " + entity.Nombre, ex.StackTrace, ex.Message));
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
                            entity.Pass = Convert.ToBase64String(new CryptoSeguridad().Encrypt(entity.Pass));
                            BLL.UFP.Usuario.Update(entity);

                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Update, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Usuario: " + entity.Nombre, "", ""));

                            Notifications.FrmSuccess.SuccessForm(Helps.Language.info["editadoOK"]);

                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message == EValidaciones.existe)
                                Notifications.FrmError.ErrorForm(Helps.Language.info["errorExiste"]);
                            else
                            {
                                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Usuario: " + entity.Nombre, ex.StackTrace, ex.Message));
                                Notifications.FrmError.ErrorForm(Helps.Language.info["editadoError"] + "\n" + ex.Message);
                            }
                        } 
                    }
                    else 
                    {
                        try
                        {

                            var isValid = CargarEntityVerificarUsuario(entity);
                                                        
                            if (isValid.Item1)
                            {
                                if (!String.IsNullOrEmpty(txtPassNueva.Text))
                                    entity.Pass = txtPassNueva.Text;


                                entity.Pass = Convert.ToBase64String(new CryptoSeguridad().Encrypt(entity.Pass));
                                BLL.UFP.Usuario.Update(entity);

                                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Update, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Usuario: " + entity.Nombre, "", ""));

                                Notifications.FrmSuccess.SuccessForm(Helps.Language.info["editadoOK"]);

                                this.Close();
                            }
                            else
                            {
                                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Usuario: " + entity.Nombre, "", ""));
                                Notifications.FrmError.ErrorForm(Language.info["loginError"]);
                            }

                        }
                        catch (Exception ex)
                        {
                            if (ex.Message == EValidaciones.existe)
                                Notifications.FrmError.ErrorForm(Helps.Language.info["errorExiste"]);
                            else
                            {
                                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Usuario: " + entity.Nombre, ex.StackTrace, ex.Message));
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
            entity = BLL.UFP.Usuario.GetAdapted(id);
            TxtNombre.Text = entity.Nombre;
        }
        private Entities.UFP.Usuario CargarEntity(Entities.UFP.Usuario entity)
        {
            entity.Nombre = TxtNombre.Text;
            entity.Pass = txtPassNueva.Text;          
    
            return entity;
        }

        private (bool,string) CargarEntityVerificarUsuario(Entities.UFP.Usuario entity)
        {
            entity.Nombre = TxtNombre.Text;
            entity.Pass = TxtPassAnterior.Text;
            
            return BLL.UFP.Usuario.Login(entity);
        }


        private void ChangeLanguage()
        {
            this.Text = Helps.Language.info["usuario"];
            Helps.Language.controles(this);
        }


    }
}
