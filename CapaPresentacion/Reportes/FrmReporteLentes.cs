using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReporteLentes : Form
    {
        public FrmReporteLentes()
        {
            InitializeComponent();
        }

        private void FrmReporteLentes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.Lentes' Puede moverla o quitarla según sea necesario.
            this.LentesTableAdapter.Fill(this.dsPrincipal.Lentes);

            this.reportViewer1.RefreshReport();
        }
    }
}
