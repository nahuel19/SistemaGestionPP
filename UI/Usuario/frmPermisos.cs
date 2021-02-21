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
    public partial class frmPermisos : MetroFramework.Forms.MetroForm
    {
        private string id;
        Entities.UFP.Usuario usuario = new Entities.UFP.Usuario();
               
        BindingList<Entities.UFP.FamiliaElement> bind = new BindingList<Entities.UFP.FamiliaElement>();

        public frmPermisos(string _id)
        {
            InitializeComponent();
            id = _id;
            CargarDatos();

            MostrarPermisosEstructura();
            ListPatentes();
            ListFamilias();
        }

        private void MostrarPermisosEstructura()
        {
            string estructura = BLL.UFP.Usuario.MostrarEstructura(usuario.Permisos);
            richTextBox1.Text = estructura;            
        }

        private void ListPatentes()
        {
            ddlPatentes.DataSource = BLL.UFP.Patente.GetAllAdapted();
            ddlPatentes.ValueMember = "IdFamiliaElement";
            ddlPatentes.DisplayMember = "Nombre";
        }

        private void ListFamilias()
        {
            ddlFamilias.DataSource = BLL.UFP.Familia.GetAllAdapted();
            ddlFamilias.ValueMember = "IdFamiliaElement";
            ddlFamilias.DisplayMember = "Nombre";
        }

        private void CargarDatos()
        {
            usuario = BLL.UFP.Usuario.GetAdapted(id);

            foreach (var p in usuario.Permisos)
            {
                bind.Add(p);
            }
            lblUsuarioValue.Text = usuario.Nombre;
        }

        private void Tabla()
        {
            metroGrid1.DataSource = bind;
            metroGrid1.Columns[0].Visible = false;
            metroGrid1.Columns[2].Visible = false;
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            Tabla();
        }

        private void btnAgregarPatente_Click(object sender, EventArgs e)
        {
            Entities.UFP.Patente patente = BLL.UFP.Patente.GetAdapted(ddlPatentes.SelectedValue.ToString());
            usuario.Permisos.Add(patente);
            bind.Add(patente);
            MostrarPermisosEstructura();
        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e)
        {
            Entities.UFP.Familia familia = BLL.UFP.Familia.GetAdapted(ddlFamilias.SelectedValue.ToString());
            usuario.Permisos.Add(familia);
            bind.Add(familia);
            MostrarPermisosEstructura();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                string idARemover = GetId();
                usuario.Permisos.RemoveAll( x => x.IdFamiliaElement == idARemover);

                IReadOnlyList<Entities.UFP.FamiliaElement> ToRemove = bind.Where(x => (x.IdFamiliaElement == idARemover)).ToList();

                foreach (var d in ToRemove)
                {
                    bind.Remove(d);
                }
                MostrarPermisosEstructura();
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
            try
            {
                BLL.UFP.Usuario.Update(usuario);

                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Update, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Usuario: " + usuario.Nombre, "", ""));

                Notifications.FrmSuccess.SuccessForm(Helps.Language.info["editadoOK"]);

                MostrarPermisosEstructura();
            }
            catch (Exception ex)
            {
                if (ex.Message == EValidaciones.existe)
                    Notifications.FrmError.ErrorForm(Helps.Language.info["errorExiste"]);
                else
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.UpdateError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Usuario: " + usuario.Nombre, ex.StackTrace, ex.Message));
                    Notifications.FrmError.ErrorForm(Helps.Language.info["editadoError"] + "\n" + ex.Message);
                }
            }
        }
    }
}
