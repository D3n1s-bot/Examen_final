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
    public partial class empleadosfrm : Form
    {
        int empleados_id;
        public empleadosfrm()
        {
            InitializeComponent();
        }

        private void empleadosfrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = empleados.obtener();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["id_empleado"].Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dni = txtdni.Text;
            string nombre = txtnombre.Text;
            string apellido = txtampellidos.Text;
            bool resultado = false;
            if (empleados_id == 0)
            {
                resultado = empleados.Crear(dni, nombre, apellido);
            }
            else
            {
                resultado = empleados.Editar(empleados_id, dni, nombre, apellido);
            }
            if (resultado)
            {
                MessageBox.Show("Operación realizada con éxito");
                dataGridView1.DataSource = empleados.obtener();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al realizar la operación");
            }
        }

        private void limpiarCampos()
        {
            txtdni.Text = "";
            txtnombre.Text = "";
            txtampellidos.Text = "";
            empleados_id = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                empleados_id = Convert.ToInt32(fila.Cells["empleados_id"].Value);
                txtdni.Text = fila.Cells["dni"].Value.ToString();
                txtnombre.Text = fila.Cells["nombres"].Value.ToString();
                txtampellidos.Text = fila.Cells["apellidos"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            bool resultado = empleados.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("empleados eliminado con éxito.");
                dataGridView1.DataSource = empleados.obtener();
            }
            else
            {
                MessageBox.Show("Error al eliminar el empleados.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
