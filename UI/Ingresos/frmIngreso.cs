﻿using BLL.LogBitacora;
using Services;
using Services.Cache;
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

namespace UI.Ingresos
{
    /// <summary>
    /// form ingreso
    /// </summary>
    public partial class frmIngreso : Form
    {
        BLL.Doc_cabecera_ingresoBLL bllCabecera = new BLL.Doc_cabecera_ingresoBLL();
        BLL.Doc_detalle_ingresoBLL bllDetalle = new BLL.Doc_detalle_ingresoBLL();
        public frmIngreso()
        {
            InitializeComponent();
            ChangeLanguage();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Ingresos.frmIngresoFormulario frmIngreso = Ingresos.frmIngresoFormulario.Instance();
            frmIngreso.ShowDialog();

            RefrescarTabla();
        }



        #region helpers
        private void RefrescarTabla()
        {
            try
            {
                metroGrid1.DataSource = bllCabecera.List();

                CaracteristicasGrid();
            }
            catch (Exception ex)
            {

                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }

            metroGrid1.ClearSelection();
            TxtBuscar.Focus();
        }

        private void CaracteristicasGrid()
        {

            metroGrid1.Columns["id"].Visible = false;
            metroGrid1.Columns["fk_id_tipo_doc"].Visible = false;
            metroGrid1.Columns["fk_id_proveedor"].Visible = false;
            metroGrid1.Columns["letra"].Visible = false;
            metroGrid1.Columns["sucursal"].Visible = false;
            metroGrid1.Columns["numero"].Visible = false;
            metroGrid1.Columns["fk_id_usuario"].Visible = false;
            //metroGrid1.Columns["nombre_usuario"].Visible = false;
            


            metroGrid1.Columns["tipo_documento"].DisplayIndex = 1;
            metroGrid1.Columns["factura"].DisplayIndex = 2;
            metroGrid1.Columns["nombre_proveedor"].DisplayIndex = 3;
            metroGrid1.Columns["fecha"].DisplayIndex = 4;
            metroGrid1.Columns["cancelada"].DisplayIndex = 10;


            metroGrid1.Columns["tipo_documento"].Width = 150;
            metroGrid1.Columns["factura"].Width = 150;
            metroGrid1.Columns["nombre_proveedor"].Width = 220;
            metroGrid1.Columns["fecha"].Width = 150;
            metroGrid1.Columns["cancelada"].Width = 100;


            foreach (DataGridViewRow row in metroGrid1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["cancelada"].Value) ==true) 
                {
                    row.DefaultCellStyle.BackColor = Color.DarkOrange;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
            

        }

        private int? GetId()
        {
            try
            {
                return (int)metroGrid1.CurrentRow.Cells["id"].Value;
            }
            catch
            {
                return null;
            }
        }

        private void ChangeLanguage()
        {
            Helps.Language.controles(this);
        }


        #endregion

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
            CheckPermisos();
            HelpUser();
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? idEntity = GetId();

                Entities.Doc_cabecera_ingreso entity = bllCabecera.GetById(Convert.ToInt32(idEntity));
                entity.listDetalle = bllDetalle.ListDetallesByCabecera(entity.id);

                try
                {
                    DialogResult confirmation = new Notifications.FrmQuestion(Helps.Language.info["preguntaEliminar"]).ShowDialog();

                    if (confirmation == DialogResult.OK)
                    {
                        bllCabecera.Anular(entity);
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Delete, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Ingreso anulado: " + entity.factura, "", ""));

                        RefrescarTabla();
                        Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("eliminadoOK"));
                    }
                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.DeleteError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Ingreso anulado: " + entity.factura, ex.StackTrace, ex.Message));
                    RefrescarTabla();
                    Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("eliminadoError") + "\n" + ex.Message);
                }
                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("infoSelecEliminar"));
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Ingresos.frmDetalleIngreso frmDetalle = new Ingresos.frmDetalleIngreso((int)GetId());
            frmDetalle.ShowDialog();

            RefrescarTabla();
        }

        private void metroGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.metroGrid1.Columns[e.ColumnIndex].Name == "cancelada")
            {
                try
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        if (Convert.ToBoolean(e.Value) == true)
                        {
                            e.CellStyle.BackColor = Color.Red;
                        }
                    }
                }
                catch (NullReferenceException ex)
                {

                }
            }
        }


        private void CheckPermisos()
        {
            try
            {
                BtnNuevo.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.ComprasInsertar);
                BtnAnular.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.ComprasAnular);
            }
            catch (Exception ex)
            {

                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error validación de permisos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorPermisos") + "\n" + ex.Message);
            }
           
        }

        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Compras");
            helpProvider1.SetHelpKeyword(this, "Compras");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
