﻿using BLL.LogBitacora;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helps;

namespace UI.Producto
{
    /// <summary>
    /// form para seleccionar un producto
    /// </summary>
    public partial class frmSeleccionarProducto : MetroFramework.Forms.MetroForm
    {
        BLL.ProductoBLL bll = new BLL.ProductoBLL();
        public IContractForm<Entities.Producto> contrato { get; set; }
        public frmSeleccionarProducto()
        {
            InitializeComponent();
            ChangeLanguage();
        }

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

        private void CaracteristicasGrid()
        {

            metroGrid1.Columns["id"].Visible = false;
            metroGrid1.Columns["fk_id_categoria"].Visible = false;
            metroGrid1.Columns["peso"].Visible = false;
            metroGrid1.Columns["alto"].Visible = false;
            metroGrid1.Columns["ancho"].Visible = false;
            metroGrid1.Columns["profundidad"].Visible = false;
            metroGrid1.Columns["descripcion"].Visible = false;

            metroGrid1.Columns["codigo"].DisplayIndex = 1;
            metroGrid1.Columns["nombre"].DisplayIndex = 2;
            metroGrid1.Columns["categoria"].DisplayIndex = 3;
            metroGrid1.Columns["precio"].DisplayIndex = 4;
            metroGrid1.Columns["cantidad"].DisplayIndex = 5;

            metroGrid1.Columns["codigo"].Width = 80;
            metroGrid1.Columns["nombre"].Width = 280;
            metroGrid1.Columns["categoria"].Width = 190;
            metroGrid1.Columns["precio"].Width = 150;
            metroGrid1.Columns["cantidad"].Width = 80;


        }

        private int GetId()
        {
            return (int)metroGrid1.CurrentRow.Cells["id"].Value;            
        }

        private void frmSeleccionarProducto_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
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

        private void metroGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Entities.Producto prod = bll.GetById(GetId());
            contrato.Ejecutar(prod);
            this.Close();            
        }
        private void ChangeLanguage()
        {
            this.Text = Helps.Language.SearchValue("tituloSelectProd");
            Helps.Language.controles(this);
        }
    }
}
