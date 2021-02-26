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
    /// <summary>
    /// forma familias
    /// </summary>
    public partial class frmFamilias : MetroFramework.Forms.MetroForm
    {
        public frmFamilias()
        {
            InitializeComponent();
            ChangeLanguage();
        }


        private void RefrescarTabla()
        {
            try
            {
                metroGrid1.DataSource = BLL.UFP.Familia.GetAllAdapted();

                metroGrid1.Columns[0].Visible = false;
                metroGrid1.Columns[2].Visible = false;
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }

        private void frmFamilias_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
            HelpUser();

        }

        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Perfiles");
            helpProvider1.SetHelpKeyword(this, "Perfiles");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmFormularioFamilias frmForm = new frmFormularioFamilias();
            frmForm.ShowDialog();
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                Entities.UFP.Familia familia = BLL.UFP.Familia.GetAdapted(GetId());

                string estructura = BLL.UFP.Usuario.MostrarEstructura(familia.Accesos);

                richTextBox1.Text = estructura;

            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("infoSelecDetalle"));
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {          
                Entities.UFP.Familia familia = BLL.UFP.Familia.GetAdapted(GetId());
                try
                {
                    DialogResult confirmation = new Notifications.FrmQuestion(Helps.Language.SearchValue("preguntaEliminar")).ShowDialog();

                    if (confirmation == DialogResult.OK)
                    {
                        BLL.UFP.Familia.Delete(familia);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Delete, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Familia: " + familia.Nombre, "", ""));

                        RefrescarTabla();
                        Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("eliminadoOK"));

                    }
                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.DeleteError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Familia: " + familia.Nombre, ex.StackTrace, ex.Message));
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
                frmFormularioFamilias frmForm = new frmFormularioFamilias(GetId());
                frmForm.ShowDialog();

                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("infoSelecEditar"));
            }

            
        }

        private void ChangeLanguage()
        {
            Helps.Language.controles(this);
            this.Text = Helps.Language.SearchValue("lblFamilia");
        }
    }
}
