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
    public partial class FrmLentes : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static FrmLentes _Instancia;

        public static FrmLentes GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmLentes();
            }
            return _Instancia;
        } 

        //Metodo que envia los valores recividos a la caja de texto IdCategoria
        public void SetCategoria(string idcategoria, string nombre)
        {
            this.txtidcategoria.Text = idcategoria;
            this.txtcategoria.Text = nombre;
        }

        public FrmLentes()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, " Ingrese el Nombre del Articulo");
            this.ttMensaje.SetToolTip(this.txtDescripcion, " Ingrese la Descripcion del Articulo");
            this.ttMensaje.SetToolTip(this.txtidcategoria, " Elija la Categoría del Articulo");
            this.ttMensaje.SetToolTip(this.txtexistencias, " Ingrese las Existencias del Articulo");

            this.txtidlentes.ReadOnly = true;
            this.txtidcategoria.Visible = true;
            this.txtcategoria.ReadOnly = true;
        }

        //Mensaje de Confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Mensaje de Error

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //
        private void Limpiar()
        {
            this.txtidlentes.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtexistencias.Text = string.Empty;
            this.cmbestado.Text = string.Empty;
            this.txtcategoria.Text = string.Empty;
            this.txtidcategoria.Text = string.Empty;
            this.pximagen.Image = global::CapaPresentacion.Properties.Resources.file;

        }

        //Habilitar Controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtidlentes.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnbuscarcategoria.Enabled = valor;
            this.cmbestado.Enabled = valor;
            this.btncargar.Enabled = valor;
            this.btnlimpiar.Enabled = valor;  
            this.txtexistencias.ReadOnly = !valor;

        }

        // Habilita botones
        private void HabilitarBotones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }


        ////Ocultar Columnas
        private void OcultarColumnas()
        {
            this.dataGridViewListado.Columns[0].Visible = false;
            this.dataGridViewListado.Columns[1].Visible = false;
            this.dataGridViewListado.Columns[7].Visible = false;
        }

        //Mostrar
        private void Mostrar()
        {
            this.dataGridViewListado.DataSource = NLentes.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dataGridViewListado.Rows.Count);

        }

        //Buscar por nombre de categoria
        private void BuscarNombre()
        {
            this.dataGridViewListado.DataSource = NLentes.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dataGridViewListado.Rows.Count);

        }       

        private void FrmLentes_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.HabilitarBotones();
            this.txtidcategoria.ReadOnly = true;
        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
                this.pximagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pximagen.Image = Image.FromFile(dialog.FileName);
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            this.pximagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pximagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.HabilitarBotones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
            this.txtidcategoria.ReadOnly = true;
            this.txtcategoria.ReadOnly = true;
            this.txtidlentes.ReadOnly = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtNombre.Text == string.Empty || this.txtidcategoria.Text == string.Empty || this.txtexistencias.Text == string.Empty)
                {
                    MensajeError("Ingrese los Datos remarcados");

                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtDescripcion, "Ingrese un Valor");
                    errorIcono.SetError(txtexistencias, "Ingrese un Valor");
                    errorIcono.SetError(txtidcategoria, "Ingrese un Valor");
                }
                else
                {
                    //instancia para almacenar en el bufer 
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    //guarda y almacena en el bufer lo que tenemos en el picturebox
                    this.pximagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();

                    if (this.IsNuevo)
                    {
                        rpta = NLentes.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim().ToUpper(),
                               Convert.ToInt32(this.txtexistencias.Text),
                               this.cmbestado.Text,
                               imagen,
                               Convert.ToInt32(this.txtidcategoria.Text));
                    }
                    else
                    {
                        rpta = NLentes.Editar(Convert.ToInt32(this.txtidlentes.Text),
                               this.txtNombre.Text.Trim().ToUpper(),
                               this.txtDescripcion.Text.Trim().ToUpper(),
                               Convert.ToInt32(this.txtexistencias.Text),
                               this.cmbestado.Text,
                               imagen,
                               Convert.ToInt32(this.txtidcategoria.Text));
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("El Registro se Insertó de forma Correcta");
                        }
                        else
                        {
                            this.MensajeOk("El Registro se Actualizó de forma Correcta");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.HabilitarBotones();
                    this.Limpiar();
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtidlentes.Text.Equals(""))
            {
                this.IsEditar = true;
                this.HabilitarBotones();
                this.Habilitar(true);
                this.txtidlentes.ReadOnly = true;
            }
            else
            {
                this.MensajeError("Debe de Seleccionar el registro para Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.HabilitarBotones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataGridViewListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataGridViewListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtidlentes.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["id_lentes"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["descripcion"].Value);
            this.txtexistencias.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["existencias"].Value);
            this.cmbestado.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["estado"].Value);

            byte[] imagenBuffer = (byte[])this.dataGridViewListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            this.pximagen.Image = Image.FromStream(ms);
            this.pximagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtidcategoria.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["id_categoria"].Value);
            this.txtcategoria.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["Categoria"].Value);
            this.btnCancelar.Enabled = true;

            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataGridViewListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataGridViewListado.Columns[0].Visible = false;
            }
        }

        private void btnbuscarcategoria_Click(object sender, EventArgs e)
        {
            FrmVistaCategoria_Articulo form = new FrmVistaCategoria_Articulo();
            form.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Eliminar los Registros ?", "+ Chic Store", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataGridViewListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NLentes.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminaron Correctamente los Registros");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }

                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteLentes frm = new FrmReporteLentes();
            frm.Show();
        }
    }
}
