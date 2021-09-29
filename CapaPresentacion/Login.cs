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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            lblhora.Text = DateTime.Now.ToString();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            DataTable Datos = NUsuario.Login(this.txtusuario.Text, this.txtcontraseña.Text);
            if(Datos.Rows.Count==0)
            {
                MessageBox.Show("El Usuario No tiene Acceso", "Sistema Roca Bruja", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                FrmMenuPrincipal frm = new FrmMenuPrincipal();
                frm.IdUsuario = Datos.Rows[0][0].ToString();
                frm.Nombre    = Datos.Rows[0][1].ToString();
                frm.Apellidos = Datos.Rows[0][2].ToString();               
                frm.Acceso    = Datos.Rows[0][3].ToString();

                frm.Show();
                this.Hide();
            }
        }
    }
}
