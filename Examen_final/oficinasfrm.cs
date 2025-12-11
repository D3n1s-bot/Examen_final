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
        int id=0;
        public oficinasfrm()
        {
            InitializeComponent();
        }

        private void oficinasfrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = oficinas.obtener();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["id_edificio"].Visible = false;
            }
            comboBox1.DataSource = edificio.obtener();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string oficina = comboBox1
            string tipo = txttipo.Text;
            int id_edificio = Convert.ToInt32(comboBox1.SelectedValue);
            //MessageBox.Show(Convert.ToString(id_edificio));
            bool resultado = false;
            if (id == 0)
            {
                resultado = oficinas.Crear(tipo,id_edificio);
            }
            else
            {
                resultado = oficinas.Editar(id, id_edificio, tipo);
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
                id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                txttipo.Text = dataGridView1.SelectedRows[0].Cells["tipo"].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells["id_edificio"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
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

        private void txttipo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
