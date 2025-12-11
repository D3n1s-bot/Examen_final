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
    public partial class mantenimientos : Form
    {
        int mantenimientos_id=0;
        public mantenimientos()
        {
            InitializeComponent();
        }

        private void mantenimientos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Modelos.mantenimiento.obtener();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["id"].Visible = false;
            }
            comboBox2.DataSource = equipos.obtener();
            comboBox2.DisplayMember = "numero_serie";
            comboBox2.ValueMember = "id";
            comboBox1.DataSource = empleados.obtener();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipo = textBox1.Text;
            string detalles = textBox2.Text;
            string costo = textBox3.Text;
            string fechayhora_recepcion = dateTimePicker1.Text;
            string fechayhora_devolucion = dateTimePicker2.Text;
            int id_equipo = Convert.ToInt32(comboBox2.SelectedValue);
            int id_empleado = Convert.ToInt32(comboBox1.SelectedValue);
            bool resultado = false;
            
            if (mantenimientos_id == 0)
            {
                resultado = mantenimiento.Crear( tipo, detalles, costo, fechayhora_recepcion, fechayhora_devolucion,id_equipo,id_empleado);
            }
            else
            {
                resultado = mantenimiento.Editar(mantenimientos_id, tipo, detalles, costo, fechayhora_recepcion, fechayhora_devolucion,id_equipo,id_empleado);
            }
            if (resultado)
            {
                MessageBox.Show("Operación realizada con éxito");
                dataGridView1.DataSource = mantenimiento.obtener();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al realizar la operación");
            }
        }
        private void limpiarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            mantenimientos_id = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                mantenimientos_id = Convert.ToInt32(fila.Cells["id"].Value);
                textBox1.Text = fila.Cells["tipo"].Value.ToString();
                textBox2.Text = fila.Cells["detalles"].Value.ToString();
                textBox3.Text = fila.Cells["costo"].Value.ToString();
                dateTimePicker1.Text = fila.Cells["fechayhora_recepcion"].Value.ToString();
                dateTimePicker2.Text = fila.Cells["fechayhora_devolucion"].Value.ToString();
                comboBox2.SelectedItem = dataGridView1.SelectedRows[0].Cells["id_equipo"].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells["id_empleado"].Value.ToString();

            }

            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            bool resultado = mantenimiento.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Mantenimiento eliminado con éxito");
                dataGridView1.DataSource = mantenimiento.obtener();
            }
            else
            {
                MessageBox.Show("Error al eliminar el mantenimiento");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
