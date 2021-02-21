﻿using BLL.LogBitacora;
using Entities.UFP;
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

namespace UI.Usuario
{
    public partial class frmFormularioFamilias : MetroFramework.Forms.MetroForm
    {
        Entities.UFP.Familia familia = new Entities.UFP.Familia();
        BindingList<FamiliaElement> bind = new BindingList<FamiliaElement>();
        private string id;

        public frmFormularioFamilias(string _id = null)
        {
            InitializeComponent();
            ListPatentes();
            ChangeLanguage();
            id = _id;

            if (_id != null)
                CargarDatos();
        }

        private void ListPatentes()
        {
            ddlPatentes.DataSource = BLL.UFP.Patente.GetAllAdapted();
            ddlPatentes.ValueMember = "IdFamiliaElement";
            ddlPatentes.DisplayMember = "Nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Patente patente = BLL.UFP.Patente.GetAdapted(ddlPatentes.SelectedValue.ToString());
            familia.Add(patente);
            bind.Add(patente);
        }

        private void Tabla()
        {
            metroGrid1.DataSource = bind;
            metroGrid1.Columns[0].Visible = false;
            metroGrid1.Columns[2].Visible = false;
        }

       

        private void frmFamilias_Load(object sender, EventArgs e)
        {
            Tabla();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                Patente patente = BLL.UFP.Patente.GetAdapted(GetId());                
                familia.Remove(patente);

                IReadOnlyList<FamiliaElement> ToRemove = bind.Where(x => (x.IdFamiliaElement == patente.IdFamiliaElement)).ToList();

                foreach (var d in ToRemove)
                {
                    bind.Remove(d);
                }

            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecEditar"]);
            }
            
        }


        private string GetId()
        {
            try
            {
                return metroGrid1.CurrentRow.Cells["IdFamiliaElement"].Value.ToString();
            }
            catch
            {
                return null;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //if (id == null)
            //    entity = new Entities.Producto();



            //var validation = new Helps.DataValidations(entity).Validate();
            //bool valid = validation.Item1;

            //if (valid == true)
            //{
            if ((!String.IsNullOrEmpty(txtNuevaFamilis.Text)) && familia.ChildrenCount > 0)
            {
                if (id == null)
                {
                    try
                    {
                        familia.Nombre = txtNuevaFamilis.Text;
                        BLL.UFP.Familia.Insert(familia);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Familia: " + familia.Nombre, "", ""));

                        Notifications.FrmSuccess.SuccessForm(Helps.Language.info["guardadoOK"]);

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == EValidaciones.existe)
                            Notifications.FrmInformation.InformationForm(Helps.Language.info["errorExiste"]);
                        else
                        {
                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Familia: " + familia.Nombre, ex.StackTrace, ex.Message));
                            Notifications.FrmError.ErrorForm(Helps.Language.info["guardadoError"] + "\n" + ex.Message);
                        }
                    }
                }
                else
                {
                    try
                    {
                        BLL.UFP.Familia.Update(familia);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Update, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Familia: " + familia.Nombre, "", ""));

                        Notifications.FrmSuccess.SuccessForm(Helps.Language.info["editadoOK"]);

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == EValidaciones.existe)
                            Notifications.FrmError.ErrorForm(Helps.Language.info["errorExiste"]);
                        else
                        {
                            InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Familia: " + familia.Nombre, ex.StackTrace, ex.Message));
                            Notifications.FrmError.ErrorForm(Helps.Language.info["editadoError"] + "\n" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["ingresarAllRegistros"]);
            }
            //}
            //else
            //{
            //    string messageValid = validation.Item2;
            //    Notifications.FrmInformation.InformationForm(messageValid);
            //}
        }

        private void ChangeLanguage()
        {
            //this.lblTituloUsuarios.Text = Helps.Language.info["lblTituloUsuarios"];
            Helps.Language.controles(this);
        }

        private void CargarDatos()
        {
            familia = BLL.UFP.Familia.GetAdapted(id);
            
            foreach(var p in familia.Accesos)
            {
                bind.Add(p);
            }

            txtNuevaFamilis.Text = familia.Nombre;

        }
    }
}
