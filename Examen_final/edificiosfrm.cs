using Examen_final.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_final
{
    public partial class edificiosfrm : Form
    {
        int edificios_id;
        public edificiosfrm()
        {
            InitializeComponent();
        }

        private void edificiosfrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = edificio.obtener();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["id"].Visible = false;
            }

        }
  

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                edificios_id = Convert.ToInt32(fila.Cells["id"].Value);
                txtnom_e.Text = fila.Cells["nombre"].Value.ToString();
                txtdire.Text = fila.Cells["direccion"].Value.ToString();
               
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string nombre = txtnom_e.Text;
                string direccion = txtdire.Text;
                bool resultado = false;
                if (edificios_id == 0)
                {
                    resultado = edificio.Crear(nombre, direccion);
                }
                else
                {
                    resultado = edificio.Editar(edificios_id, nombre, direccion);
                }
                if (resultado)
                {
                    MessageBox.Show("Operación exitosa");
                    dataGridView1.DataSource = edificio.obtener();
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error en la operación");
                }

            }
        }
        private void limpiar()
        {
            txtnom_e.Text = "";
            txtdire.Text = "";
            edificios_id = 0;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            bool resultado = edificio.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Autor eliminado con éxito.");
                dataGridView1.DataSource = edificio.obtener();
            }
            else
            {
                MessageBox.Show("Error al eliminar el autor.");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}   