using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmVistaCategoria_Articulo : Form
    {
        public FrmVistaCategoria_Articulo()
        {
            InitializeComponent();
        }

        ////Ocultar Columnas
        private void OcultarColumnas()
        {
            this.dataGridViewListado.Columns[0].Visible = false;
            this.dataGridViewListado.Columns[1].Visible = false;
        }

        //Mostrar
        private void Mostrar()
        {
            this.dataGridViewListado.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dataGridViewListado.Rows.Count);

        }

        //Buscar por nombre de categoria
        private void BuscarNombre()
        {
            this.dataGridViewListado.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dataGridViewListado.Rows.Count);

        }

        private void FrmVistaCategoria_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            FrmLentes form = FrmLentes.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["id_categoria"].Value);
            par2 = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["nombre"].Value);
            form.SetCategoria(par1, par2);
            this.Hide();
        }
    }
}
