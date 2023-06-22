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
    public partial class MantenedorCiudad : Form
    {
        public MantenedorCiudad()
        {
            InitializeComponent();
            ListarCiudad();
            dgvCiudad.Rows[dgvCiudad.Rows.Count - 1].Selected = true;
            
            btnAgregar.Enabled = false;
            grupBoxDatos.Enabled = false;

        }
       
        public void ListarCiudad()
        {
            dgvCiudad.DataSource = logCiudad.Instancia.ListarCiudad();
            dgvCiudad.Rows[dgvCiudad.Rows.Count - 1].Selected = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try {
                entCiudad c = new entCiudad();
                
                c.desCiudad= txtdesCiudad.Text.Trim();
                c.estCiudad = cbkEstadoCiudad.Checked;
                logCiudad.Instancia.InsertaCiudad(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
            }
            LimpiarVariables();
            grupBoxDatos.Enabled = false;
            ListarCiudad();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;
            txtId.Enabled = false;
            grupBoxDatos.Enabled = true;
            btnModificar.Enabled = false;
            LimpiarVariables();
        }

        private void LimpiarVariables()
        {
            txtdesCiudad.Text = " ";
            cbkEstadoCiudad.Checked = false;
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCiudad.Rows.Count > 0)
            {
                DataGridViewRow filaActual = dgvCiudad.Rows[e.RowIndex];
                //txtidCliente.Text = filaActual.Cells[0].Value.ToString();
                txtId.Text = filaActual.Cells[0].Value.ToString();
                txtdesCiudad.Text = filaActual.Cells[1].Value.ToString();
                cbkEstadoCiudad.Checked = Convert.ToBoolean(filaActual.Cells[2].Value);
            }
            btnAgregar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            btnAgregar.Enabled=false;
            btnModificar.Enabled = true;
            grupBoxDatos.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //int idCliente = 0;
            entCiudad c = new entCiudad();
            //DataGridViewRow filaActual = dgvCliente.CurrentRow;
            //idCliente = int.Parse(filaActual.Cells[0].Value.ToString());
            c.idCiudad = int.Parse(txtId.Text);
            c.desCiudad = txtdesCiudad.Text.Trim();
            c.estCiudad = cbkEstadoCiudad.Checked;                  
            logCiudad.Instancia.EditaCiudad(c);
            grupBoxDatos.Enabled = false;
            ListarCiudad();
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            int idCiudad = 0;
            DataGridViewRow filaActual = dgvCiudad.CurrentRow;
            idCiudad = int.Parse(filaActual.Cells[0].Value.ToString());
            //MessageBox.Show(idCliente.ToString());
            logCiudad.Instancia.DeshabilitaCiudad(idCiudad);
            ListarCiudad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantenedorCliente frm = new MantenedorCliente();
            frm.Show();
        }
    }
}
