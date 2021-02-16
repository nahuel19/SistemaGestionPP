using BLL;
using BLL.LogBitacora;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using UI.Helps;
using System.Reflection;
using Services;
using Services.Encriptación;

namespace UI.Categoria
{
    /// <summary>
    /// Clase form Categoría
    /// </summary>
    public partial class FrmCategoria : MetroFramework.Forms.MetroForm
    {
        private int id;
        private bool editarse = false;
        CategoriaBLL bll = new CategoriaBLL();
        
        public FrmCategoria()
        {
            InitializeComponent();
            ChangeLanguage();
        }
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
            //TxtBuscar.Height = 40;
            //TxtNombre.Height = 22;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            metroGrid1.DataSource = bll.FindBy(TxtBuscar.Text);
        }

        #region botones

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                editarse = true;
                id = GetId();
                TxtNombre.Text = metroGrid1.Rows[metroGrid1.CurrentRow.Index].Cells[1].Value.ToString();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Language.info["infoSelecEditar"]);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int idCat = GetId();
                Entities.Categoria categoria = bll.GetById(idCat);
                
                try
                {
                    DialogResult confirmation = new Notifications.FrmQuestion(Language.info["preguntaEliminar"]).ShowDialog();
           
                    if(confirmation== DialogResult.OK)
                    {
                        bll.Delete(idCat);
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Delete, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Categoria: " + categoria.categoria, "", ""));

                        RefrescarTabla();
                        Notifications.FrmSuccess.SuccessForm(Language.info["eliminadoOK"]);
                        
                    }                    
                }
                catch(Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.DeleteError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Categoria: " + categoria.categoria, ex.StackTrace, ex.Message));

                    RefrescarTabla();
                    Notifications.FrmError.ErrorForm(Language.info["eliminadoError"] + "\n" + ex.Message);
                }
                
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Language.info["infoSelecEliminar"]);
            }
        }
        int erro=0;
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Entities.Categoria categoria = new Entities.Categoria();
            categoria.categoria = TxtNombre.Text;

            var validation = new Helps.DataValidations(categoria).Validate();
            bool valid = validation.Item1;

            if (valid == true)
            {          
                if (editarse == false)
                {
                    try
                    {
                        categoria = bll.Insert(categoria);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Insert, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Categoria: " + categoria.categoria, "", ""));
                        
                        Notifications.FrmSuccess.SuccessForm(Language.info["guardadoOK"]);
                        RefrescarTabla();
                        LimpiarTxt();
                    }
                    catch (Exception ex)
                    {
                        System.Data.SqlClient.SqlException sqlException = ex as System.Data.SqlClient.SqlException;
                        erro = sqlException.Number;
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.InsertError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Categoria: " + categoria.categoria, ex.StackTrace, ex.Message));
                        Notifications.FrmError.ErrorForm(Language.info["guardadoError"] + "\n" + ex.Message);                       

                    }
                }
                if (editarse == true)
                {
                    try
                    {
                        categoria.id = id;
                        
                        bll.Update(categoria);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Update, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Categoria: " + categoria.categoria, "", ""));

                        Notifications.FrmSuccess.SuccessForm(Language.info["editadoOK"]);
                        RefrescarTabla();
                        LimpiarTxt();
                        editarse = false;
                    }
                    catch (Exception ex)
                    {
                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Categoria: " + categoria.categoria, ex.StackTrace, ex.Message));
                        Notifications.FrmError.ErrorForm(Language.info["editadoError"] + "\n" + ex.Message);
                    }
                }
            }
            else
            {
                string messageValid = validation.Item2;
                Notifications.FrmInformation.InformationForm(messageValid);
            }




        }

        #endregion

        

        #region helpers

        /// <summary>
        /// Refresta grid
        /// </summary>
        private void RefrescarTabla()
        {
            metroGrid1.DataSource = bll.List();
            metroGrid1.Columns[0].Visible = false;
            metroGrid1.Columns[1].Width = 220;

            metroGrid1.ClearSelection();
            TxtBuscar.Focus();
            

        }

        private int GetId()
        {
            return int.Parse(metroGrid1.Rows[metroGrid1.CurrentRow.Index].Cells[0].Value.ToString());
        }

        private void LimpiarTxt()
        {
            editarse = false;
            TxtNombre.Text = "";
            TxtNombre.Focus();
            metroGrid1.ClearSelection();
        }

        private void ChangeLanguage()
        {
            this.lblTituloCat.Text = Helps.Language.info["lblTituloCat"];
            Helps.Language.controles(this);            
        }

        #endregion

        
    
    }
}
