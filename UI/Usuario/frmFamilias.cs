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

namespace UI.Usuario
{
    public partial class frmFamilias : MetroFramework.Forms.MetroForm
    {
        public frmFamilias()
        {
            InitializeComponent();

        }


        private void RefrescarTabla()
        {
            metroGrid1.DataSource = BLL.UFP.Familia.GetAllAdapted();

            metroGrid1.Columns[0].Visible = false;
            metroGrid1.Columns[2].Visible = false;
        }

        private void frmFamilias_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
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
                Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecDetalle"]);
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
                    DialogResult confirmation = new Notifications.FrmQuestion(Helps.Language.info["preguntaEliminar"]).ShowDialog();

                    if (confirmation == DialogResult.OK)
                    {
                        BLL.UFP.Familia.Delete(familia);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Delete, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Familia: " + familia.Nombre, "", ""));

                        RefrescarTabla();
                        Notifications.FrmSuccess.SuccessForm(Helps.Language.info["eliminadoOK"]);

                    }
                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.DeleteError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Familia: " + familia.Nombre, ex.StackTrace, ex.Message));
                    RefrescarTabla();
                    Notifications.FrmError.ErrorForm(Helps.Language.info["eliminadoError"] + "\n" + ex.Message);
                }
                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecEliminar"]);
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
                Notifications.FrmInformation.InformationForm(Helps.Language.info["infoSelecEditar"]);
            }

            
        }
    }
}
