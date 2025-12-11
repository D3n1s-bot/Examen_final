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
    public partial class equiposfrm : Form
    {
        int equipos_id = 0;
        public equiposfrm()
        {
            InitializeComponent();
        }

        private void equiposfrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource =equipos.obtener();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["id"].Visible = false;

            }
            comboBox1.DataSource = proveedores.obtener();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";
            comboBox2.DataSource = tipo_equipos.obtener();
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no_serie = txtserie.Text;
            string nombre = txtnombre.Text;
            string marca = txtmarca.Text;
            string modelo = txtmodelo.Text;
            string fecha_adquirida = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string valor = txtvalor.Text;
            int id_proveedor= Convert.ToInt32(comboBox1.SelectedValue);
            int id_tipo_equipo = Convert.ToInt32(comboBox2.SelectedValue);

            bool resultado = false;
            if (equipos_id == 0)
            {
                MessageBox.Show(Convert.ToString(id_tipo_equipo));

                resultado = equipos.Crear(no_serie, nombre, marca, modelo, fecha_adquirida, valor,id_proveedor,id_tipo_equipo);
            }
            else
            {
                resultado = equipos.Editar(equipos_id, no_serie, nombre, marca, modelo, fecha_adquirida, valor,id_tipo_equipo,id_proveedor);
            }
            if (resultado)
            {
             MessageBox.Show("Operación realizada con éxito");
                dataGridView1.DataSource = equipos.obtener();
                limpiarCampos();

            }
            else
            {
                MessageBox.Show("Error al realizar la operación");
            }

        }
        private void limpiarCampos()
        {
            txtserie.Text = "";
            txtnombre.Text = "";
            txtmarca.Text = "";
            txtmodelo.Text = "";
            dateTimePicker1 = new DateTimePicker();
            txtvalor.Text = "";
            txtserie.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                equipos_id = Convert.ToInt32(fila.Cells["id"].Value);
                txtserie.Text = fila.Cells["numero_serie"].Value.ToString();
                txtnombre.Text = fila.Cells["nombre"].Value.ToString();
                txtmarca.Text = fila.Cells["marca"].Value.ToString();
                txtmodelo.Text = fila.Cells["modelo"].Value.ToString();
                dateTimePicker1.Text = fila.Cells["fecha_adquierida"].Value.ToString();  
                txtvalor.Text = fila.Cells["valor"].Value.ToString();
                comboBox2.SelectedItem = dataGridView1.SelectedRows[0].Cells["id_tipo_equipo"].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells["id_proveedor"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            bool resultado = equipos.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("equipo eliminado con éxito.");
                dataGridView1.DataSource = equipos.obtener();
            }
            else
            {
                MessageBox.Show("Error al eliminar el equipos.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}

