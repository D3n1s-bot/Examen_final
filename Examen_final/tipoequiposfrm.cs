using Examen_final.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_final
{
    public partial class tipoequiposfrm : Form
    {
        int tipoequipos_id = 0;
        public tipoequiposfrm()
        {
            InitializeComponent();
        }

        private void tipoequiposfrm_Load(object sender, EventArgs e)
        {
              dataGridView1.DataSource = tipo_equipos.obtener();
              if (dataGridView1.Rows.Count > 0)
              {
                   dataGridView1.Columns["id"].Visible = false;
              }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nombre = txtnom.Text;
            bool resultado = false;
            if (tipoequipos_id == 0)
            {
                resultado = tipo_equipos.Crear(nombre);
            }
            else
            {
                resultado = tipo_equipos.Editar(tipoequipos_id, nombre);
            }
            if (resultado)
            {
                MessageBox.Show("Operación realizada con éxito");
                dataGridView1.DataSource = tipo_equipos.obtener();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al realizar la operación");

            }

        }
        private void limpiarCampos()
        {
            txtnom.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                tipoequipos_id = Convert.ToInt32(fila.Cells["id"].Value);
                txtnom.Text = fila.Cells["nombre"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                bool resultado = tipo_equipos.Eliminar(id);
                if (resultado)
                {
                    MessageBox.Show("equipos eliminado con éxito");
                    dataGridView1.DataSource = tipo_equipos.obtener();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el pro");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
