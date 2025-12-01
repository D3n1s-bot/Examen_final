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
    public partial class oficinasfrm : Form
    {
        int oficina_id=0;
        public oficinasfrm()
        {
            InitializeComponent();
        }

        private void oficinasfrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = oficinas.obtener();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["id_empleado"].Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipo = txttipo.Text;
            bool resultado = false;
            if (oficina_id == 0)
            {
                resultado = oficinas.Crear(tipo);
            }
            else
            {
                resultado = oficinas.Editar(oficina_id, tipo);
            }
            if (resultado)
            {
                MessageBox.Show("Operación realizada con éxito");
                dataGridView1.DataSource = oficinas.obtener();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al realizar la operación");
            }
        }
        private void limpiarCampos()
        {
            txttipo.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                oficina_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_oficina"].Value);
                txttipo.Text = dataGridView1.SelectedRows[0].Cells["tipo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_oficina"].Value);
            bool resultado = oficinas.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Oficina eliminada con éxito");
                dataGridView1.DataSource = oficinas.obtener();
            }
            else
            {
                MessageBox.Show("Error al eliminar la oficina");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
