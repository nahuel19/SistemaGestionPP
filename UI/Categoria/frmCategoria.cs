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
using Entities.UFP;

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
            pruebaPermisos();
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

        private void btnAjustaPrecioCat_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                frmAjustarPrecioCat frm = new frmAjustarPrecioCat((int)GetId());
                frm.ShowDialog();
                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Language.info["infoSelecEditar"]);
            }
        }




        private void pruebaPermisos()
        {
            //Patente pat1 = new Patente();
            //pat1.Nombre = "Bitácora";
            //BLL.UFP.Patente.Insert(pat1);

            //Patente pat2 = new Patente();
            //pat2.Nombre = "Ventas Insertar";
            //BLL.UFP.Patente.Insert(pat2);

            //Patente pat3 = new Patente();
            //pat3.Nombre = "Ventas Ver";
            //BLL.UFP.Patente.Insert(pat3);

            //Patente pat4 = new Patente();
            //pat4.Nombre = "Ventas Anular";
            //BLL.UFP.Patente.Insert(pat4);



            //Familia familiaConsulta = new Familia();
            //familiaConsulta.Nombre = "Rol de Consulta de Ventas";
            //familiaConsulta.Add(patenteConsulta);
            //BLL.UFP.Familia.Insert(familiaConsulta);

            //Patente patenteVentas = new Patente();
            //patenteVentas.Nombre = "Pantalla de Ventas";
            //BLL.UFP.Patente.Insert(patenteVentas);

            //Familia familiaVentas = new Familia();
            //familiaVentas.Nombre = "Rol Ventas";
            //familiaVentas.Add(patenteVentas);
            //familiaVentas.Add(familiaConsulta);

            //BLL.UFP.Familia.Insert(familiaVentas);

            //Patente patentePantallaUsuario = new Patente();
            //patentePantallaUsuario.Nombre = "Pantalla de Administración de Perfil del Usuario";
            //BLL.UFP.Patente.Insert(patentePantallaUsuario);

            //Entities.UFP.Usuario user = new Entities.UFP.Usuario();
            //user.Nombre = "Pedro Rodriguez";
            //user.Permisos.Add(familiaVentas);
            //user.Permisos.Add(patentePantallaUsuario);

            //BLL.UFP.Usuario.Insert(user);

            //Familia familia = BLL.Familia.GetAdapted(familiaVentas.IdFamiliaElement);
            //List<Entities.UFP.Patente> patentes = BLL.UFP.Patente.GetAllAdapted();
            //===============

            //string contraseña = "abc1234";
            //Entities.UFP.Usuario usuario = BLL.UFP.Usuario.GetAdapted("ae3fdddb-997b-4f1d-b3d1-049e0ac8ed50");
            //usuario.Pass = Convert.ToBase64String(new CryptoSeguridad().Encrypt(contraseña));


            //BLL.UFP.Usuario.Update(usuario);



           // Entities.UFP.Usuario user = BLL.UFP.Usuario.GetAdapted("ae3fdddb-997b-4f1d-b3d1-049e0ac8ed50");
            //string contra = new CryptoSeguridad().Decrypt(Convert.FromBase64String(user.Pass));



        }
    }
}
