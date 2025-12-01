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
        int equipos_id;
        public equiposfrm()
        {
            InitializeComponent();
        }

        private void equiposfrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource =equipos.obtener();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["id_equipo"].Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no_serie = txtserie.Text;
            string nombre = txtnombre.Text;
            string marca = txtmarca.Text;
            string modelo = txtmodelo.Text;
            string fecha_adquirida = dateTimePicker1.Text;   
            string valor = txtvalor.Text;
            bool resultado = false;
            if (equipos_id == 0)
            {
                resultado = equipos.Crear(no_serie, nombre, marca, modelo, fecha_adquirida, valor);
            }
            else
            {
                resultado = equipos.Editar(equipos_id, no_serie, nombre, marca, modelo, fecha_adquirida, valor);
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                equipos_id = Convert.ToInt32(fila.Cells["equipos_id"].Value);
                txtserie.Text = fila.Cells["no_serie"].Value.ToString();
                txtnombre.Text = fila.Cells["nombres"].Value.ToString();
                txtmarca.Text = fila.Cells["marca"].Value.ToString();
                txtmodelo.Text = fila.Cells["modelo"].Value.ToString();
                dateTimePicker1.Text = fila.Cells["fecha_adquirida"].Value.ToString();  
                txtvalor.Text = fila.Cells["valor"].Value.ToString();


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
    }
}

