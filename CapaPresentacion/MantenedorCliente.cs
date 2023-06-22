using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class MantenedorCliente : Form
    {
        public MantenedorCliente()
        {
            InitializeComponent();
            ListarCliente();
            dgvCliente.Rows[dgvCliente.Rows.Count - 1].Selected = true;
            chkConsulta.Enabled = false;
            btnAgregar.Enabled = false;
            grupBoxDatos.Enabled = false;
            grpBoxBusqueda.Enabled = false;
            txtidCliente.Enabled = false;
            LlenarDatosComboBoxCiudad();


        }
        private void  LlenarDatosComboBoxCiudad()
        {
            cmbCiudad.DataSource = logCiudad.Instancia.ListarCiudadCliente();
            cmbCiudad.DisplayMember = "desCiudad";
            cmbCiudad.ValueMember = "idCiudad";
        }
        public void ListarCliente()
        {
            dgvCliente.DataSource = logCliente.Instancia.ListarCliente();
            dgvCliente.Rows[dgvCliente.Rows.Count - 1].Selected = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try {
                entCliente c = new entCliente();
                
                c.razonSocial= txtRazonSocial.Text.Trim();
                c.idTipoCliente = int.Parse(txtTipoCliente.Text.Trim());
                c.fecRegCliente = dtPickerRegCliente.Value;
                c.clienteRUC = txtRUC.Text.Trim();
                c.ciudadCliente = cmbCiudad.Text;
                c.estCliente = cbkEstadoCliente.Checked;
                
                logCliente.Instancia.InsertaCliente(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
            }
            LimpiarVariables();
            grupBoxDatos.Enabled = false;
            ListarCliente();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            grupBoxDatos.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Visible = false;
            LimpiarVariables();
        }

        private void LimpiarVariables()
        {
            txtidCliente.Text = " ";
            txtTipoCliente.Text = " ";
            txtRUC.Text = "";
            txtRazonSocial.Text = " ";
            cmbCiudad.SelectedIndex = -1;
            cbkEstadoCliente.Checked = false;
            dtPickerRegCliente.Value = DateTime.Now;
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCliente.Rows.Count >0)
            {
                DataGridViewRow filaActual = dgvCliente.Rows[e.RowIndex];
                txtidCliente.Text = filaActual.Cells[0].Value.ToString();
                txtRazonSocial.Text = filaActual.Cells[1].Value.ToString();
                txtTipoCliente.Text = filaActual.Cells[2].Value.ToString();
                dtPickerRegCliente.Text = filaActual.Cells[3].Value.ToString();
                cmbCiudad.Text = filaActual.Cells[4].Value.ToString();
                cbkEstadoCliente.Checked = Convert.ToBoolean(filaActual.Cells[5].Value);
                txtRUC.Text = filaActual.Cells[6].Value.ToString();
            }
            btnAgregar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnModificar.Visible = true;
            grupBoxDatos.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //int idCliente = 0;
            entCliente c = new entCliente();
            //DataGridViewRow filaActual = dgvCliente.CurrentRow;
            //idCliente = int.Parse(filaActual.Cells[0].Value.ToString());

            c.idCliente = int.Parse(txtidCliente.Text);
            c.razonSocial = txtRazonSocial.Text.Trim();
            c.idTipoCliente = int.Parse(txtTipoCliente.Text.Trim());
            c.fecRegCliente = dtPickerRegCliente.Value;
            c.clienteRUC = txtRUC.Text.Trim();
            c.ciudadCliente = cmbCiudad.Text;
            c.estCliente = cbkEstadoCliente.Checked;
            logCliente.Instancia.EditaCliente(c);
            grupBoxDatos.Enabled = false;
            ListarCliente();
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            int idCliente = 0;
            DataGridViewRow filaActual = dgvCliente.CurrentRow;
            idCliente = int.Parse(filaActual.Cells[0].Value.ToString());
            //MessageBox.Show(idCliente.ToString());
            logCliente.Instancia.DeshabilitaCliente(idCliente);
            ListarCliente();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantenedorCiudad frm = new MantenedorCiudad();
            frm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32(textBox1.Text);

            try
            {
                entCliente cliente = logCliente.Instancia.BuscarClientePorId(idCliente);

                if (cliente != null)
                {
                    lblRazonSocial.Text = cliente.razonSocial;
                    lblTipoCliente.Text = cliente.idTipoCliente.ToString();
                    lblFecRegistro.Text = cliente.fecRegCliente.ToString();
                    lblCiudad.Text = cliente.ciudadCliente;
                    lblRUC.Text = cliente.clienteRUC;
                    chkConsulta.Checked = cliente.estCliente;
                }
                else
                {
                    // El cliente no fue encontrado, puedes mostrar un mensaje o realizar alguna acción adicional.
                    MessageBox.Show("El cliente no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            grpBoxBusqueda.Enabled = false;
        }

        private void btnActivarBusqueda_Click(object sender, EventArgs e)
        {
            grpBoxBusqueda.Enabled = true;

        }
    }
}
