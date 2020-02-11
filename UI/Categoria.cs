using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }

        CategoriaBLL catBLL = new CategoriaBLL();

        private void DGVcategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DGVcategoria.DataSource = catBLL.List();
        }
    }
}
