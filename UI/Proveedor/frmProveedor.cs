using BLL;
using BLL.LogBitacora;
using Services;
using Services.Cache;
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

namespace UI.Proveedor
{
    /// <summary>
    /// form gestión de proveedores
    /// </summary>
    public partial class frmProveedor : Form
    {
        ProveedorBLL bll = new ProveedorBLL();

        public frmProveedor()
        {
            InitializeComponent();
            ChangeLanguage();
        }

        #region helpers
        private void RefrescarTabla()
        {
            try
            {
                metroGrid1.DataSource = bll.List();

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

        private void CaracteristicasGrid()
        {
            metroGrid1.Columns["id"].Visible = false;     
            metroGrid1.Columns["fk_id_tipo_doc_identidad"].Visible = false;
            metroGrid1.Columns["direccion"].Visible = false;
            metroGrid1.Columns["url"].Visible = false;

            metroGrid1.Columns["nombre"].DisplayIndex = 1;
            metroGrid1.Columns["doc_identidad"].DisplayIndex = 2;
            metroGrid1.Columns["num_documento"].DisplayIndex = 3;
            metroGrid1.Columns["telefono"].DisplayIndex = 4;
            metroGrid1.Columns["mail"].DisplayIndex = 5;

            metroGrid1.Columns["nombre"].Width = 250;
            metroGrid1.Columns["doc_identidad"].Width = 60;
            metroGrid1.Columns["num_documento"].Width = 120;
            metroGrid1.Columns["telefono"].Width = 170;
            metroGrid1.Columns["mail"].Width = 200;
        }


        #endregion

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
            CheckPermisos();
            HelpUser();
        }

        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Proveedores");
            helpProvider1.SetHelpKeyword(this, "Proveedores");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Proveedor.frmProveedorFormulario frmNuevo = new Proveedor.frmProveedorFormulario();
            frmNuevo.ShowDialog();
            RefrescarTabla();
        }

        private void ChangeLanguage()
        {
            Helps.Language.controles(this);
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? idEntity = GetId();

                Entities.Proveedor entity = bll.GetById(Convert.ToInt32(idEntity));

                try
                {
                    DialogResult confirmation = new Notifications.FrmQuestion(Helps.Language.SearchValue("preguntaEliminar")).ShowDialog();

                    if (confirmation == DialogResult.OK)
                    {
                        bll.Delete(Convert.ToInt32(idEntity));
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Delete, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Proveedor: " + entity.nombre, "", ""));

                        RefrescarTabla();
                        Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("eliminadoOK"));

                    }
                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.DeleteError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Proveedor: " + entity.nombre, ex.StackTrace, ex.Message));
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

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? id = GetId();

                Proveedor.frmProveedorFormulario frmEditar = new Proveedor.frmProveedorFormulario(id);
                frmEditar.ShowDialog();
                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("infoSelecEditar"));
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                metroGrid1.DataSource = bll.FindBy(TxtBuscar.Text);
            }
            catch (Exception ex)
            {

                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? id = GetId();

                Proveedor.frmProveedorDetalle frmDetalle = new Proveedor.frmProveedorDetalle((int)id);
                frmDetalle.ShowDialog();

            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("infoSelecDetalle"));
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try {
                bll.ExportProveedoresExcel();
                Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("excelOK") + "\n" + ConfigurationManager.AppSettings["FolderExcel"]);
            }
            catch(Exception ex)
            {
                Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("excelError") + "\n" + ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bll.ExportProveedoresPDF();
                Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("pdfOK") + "\n" + ConfigurationManager.AppSettings["FolderPDF"]);
            }
            catch (Exception ex)
            {
                Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("pdfError") + "\n" + ex.Message);
            }
        }


        private void CheckPermisos()
        {
            try
            {
                BtnNuevo.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.ProveedorInsertar);
                BtnEditar.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.ProveedorEditar);
                BtnEliminar.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.ProveedorEliminar);
            }
            catch (Exception ex)
            {

                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error validación de permisos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorPermisos") + "\n" + ex.Message);
            }
         
        }
    }
}
