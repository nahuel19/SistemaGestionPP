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

namespace UI
{
    /// <summary>
    /// form cliente
    /// </summary>
    public partial class frmCliente : Form
    {
        ClienteBLL bll = new ClienteBLL();

        public frmCliente()
        {
            InitializeComponent();
            ChangeLanguage();
        }

        #region helpers
        /// <summary>
        /// refresca la tabla
        /// </summary>
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

        /// <summary>
        /// setea caracteristicas de la tabla
        /// </summary>
        private void CaracteristicasGrid()
        {

            metroGrid1.Columns["id"].Visible = false;
            metroGrid1.Columns["nombre"].Visible = false;
            metroGrid1.Columns["apellido"].Visible = false;
            metroGrid1.Columns["fk_id_tipo_doc_identidad"].Visible = false;
            metroGrid1.Columns["fecha_nacimiento"].Visible = false;
            metroGrid1.Columns["direccion"].Visible = false;
            metroGrid1.Columns["edad"].Visible = false;

            metroGrid1.Columns["nombreCompleto"].DisplayIndex = 1;
            metroGrid1.Columns["doc_identidad"].DisplayIndex = 2;
            metroGrid1.Columns["num_documento"].DisplayIndex = 3;
            metroGrid1.Columns["telefono"].DisplayIndex = 4;
            metroGrid1.Columns["mail"].DisplayIndex = 5;

            metroGrid1.Columns["nombreCompleto"].Width = 250;
            metroGrid1.Columns["doc_identidad"].Width = 60;
            metroGrid1.Columns["num_documento"].Width = 120;
            metroGrid1.Columns["telefono"].Width = 170;
            metroGrid1.Columns["mail"].Width = 200;


        }

        /// <summary>
        /// obtiene id del registro sleccionado
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// cambia idioma
        /// </summary>
        private void ChangeLanguage()
        {
            Helps.Language.controles(this);
        }
        #endregion

        private void frmCliente_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
            CheckPermisos();
            HelpUser();
        }

        /// <summary>
        /// abre form de nuevo cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Cliente.frmClienteFormulario frmNuevo = new Cliente.frmClienteFormulario();
            frmNuevo.ShowDialog();
            RefrescarTabla();

        }

        /// <summary>
        /// elimina cliente seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? idEntity = GetId();

                Entities.Cliente entity = bll.GetById(Convert.ToInt32(idEntity));

                try
                {
                    DialogResult confirmation = new Notifications.FrmQuestion(Helps.Language.SearchValue("preguntaEliminar")).ShowDialog();

                    if (confirmation == DialogResult.OK)
                    {
                        bll.Delete(Convert.ToInt32(idEntity));
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Delete, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Cliente: " + entity.num_documento, "", ""));

                        RefrescarTabla();
                        Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("eliminadoOK"));

                    }
                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.DeleteError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Cliente: " + entity.num_documento, ex.StackTrace, ex.Message));
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

        /// <summary>
        /// abre form de edición
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int? id = GetId();

                Cliente.frmClienteFormulario frmEditar = new Cliente.frmClienteFormulario(id);
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

                Cliente.frmClienteDetalle frmDetalle = new Cliente.frmClienteDetalle((int)id);
                frmDetalle.ShowDialog();

            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("infoSelecDetalle"));
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                bll.ExportProductosExcel();
                Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("excelOK") + "\n" + ConfigurationManager.AppSettings["FolderExcel"]);
            }
            catch (Exception ex)
            {
                Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("excelError") + "\n" + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bll.ExportProductosPDF();
                Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("pdfOK") + "\n" + ConfigurationManager.AppSettings["FolderPDF"]);
            }
            catch (Exception ex)
            {
                Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("pdfError") + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// valida permisos
        /// </summary>
        private void CheckPermisos()
        {
            try
            {
                BtnNuevo.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.ClienteInsertar);
                BtnEditar.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.ClienteEditar);
                BtnEliminar.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.ClienteEliminar);
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error validación de permisos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorPermisos") + "\n" + ex.Message);
            }         
        }


        

        /// <summary>
        /// carga manual de usuario
        /// </summary>
        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Clientes");
            helpProvider1.SetHelpKeyword(this, "Clientes");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }


    }
}
