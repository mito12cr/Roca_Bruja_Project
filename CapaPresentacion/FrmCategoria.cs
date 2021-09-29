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
    public partial class FrmCategoria : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmCategoria()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, " Ingrese el Nombre de la Categoria");
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
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdCategoria.Text = string.Empty;
        }

        //Habilitar Controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtIdCategoria.ReadOnly = !valor;
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

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.HabilitarBotones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
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
                            Rpta = NCategoria.Eliminar(Convert.ToInt32(Codigo));

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

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCategoria.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["id_categoria"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["descripcion"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void dataGridViewListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataGridViewListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.HabilitarBotones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Ingrese los Datos remarcados");

                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NCategoria.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                               this.txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        rpta = NCategoria.Editar(Convert.ToInt32(this.txtIdCategoria.Text),
                               this.txtNombre.Text.Trim().ToUpper(),
                               this.txtDescripcion.Text.Trim());
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
            if (!this.txtIdCategoria.Text.Equals(""))
            {
                this.IsEditar = true;
                this.HabilitarBotones();
                this.Habilitar(true);
                this.txtIdCategoria.Enabled = false;
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

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
