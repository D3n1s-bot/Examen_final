using Examen_final.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_final
{
    public partial class trasladosfrm : Form
    {
        int traslados_id=0;
        public trasladosfrm()
        {
            InitializeComponent();
        }

        private void trasladosfrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Modelos.traslados.obtener();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["id"].Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fecha_salida = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string fecha_entrega= dateTimePicker2.Value.ToString("yyyy-MM-dd");
            bool resultado = false;
            if (traslados_id == 0)
            {
                resultado = Modelos.traslados.Crear(fecha_salida, fecha_entrega);
            }
            else
            {
                resultado = Modelos.traslados.Editar(traslados_id, fecha_salida, fecha_entrega);
            }
            if (resultado)
            {
                MessageBox.Show("Operación realizada con éxito");
                dataGridView1.DataSource = Modelos.traslados.obtener();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al realizar la operación");
            }
        }
        private void limpiarCampos()
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            traslados_id = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                traslados_id = Convert.ToInt32(fila.Cells["id"].Value);
                dateTimePicker1.Text = fila.Cells["fechayhora_salida"].Value.ToString();
                dateTimePicker2.Text = fila.Cells["fechayhora_entrega"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            bool resultado = traslados.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Autor eliminado con éxito.");
                dataGridView1.DataSource = traslados.obtener();
            }
            else
            {
                MessageBox.Show("Error al eliminar el autor.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
