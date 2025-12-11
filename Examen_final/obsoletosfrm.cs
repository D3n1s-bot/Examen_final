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
    public partial class obsoletosfrm : Form
    {
        int obsoletos_id=0;
        public obsoletosfrm()
        {
            InitializeComponent();
        }

        private void obsoletos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = obsoleto.obtener();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["id"].Visible = false;
            }
            comboBox1.DataSource = equipos.obtener();
            comboBox1.DisplayMember = "numero_serie";
            comboBox1.ValueMember = "id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string informe = txtinforme.Text;
            string motivo = txtmotivo.Text;
            string disposicion = txtdescripcion.Text;
            int id_equipo = Convert.ToInt32( comboBox1.SelectedValue);
            bool resultado = false;
            if (obsoletos_id == 0)
            {
                resultado = obsoleto.Crear(informe, motivo, disposicion,id_equipo);
            }
            else
            {
                resultado = obsoleto.Editar(obsoletos_id, informe, motivo, disposicion, id_equipo);
            }
            if (resultado)
            {
                MessageBox.Show("Operación realizada con éxito");
                dataGridView1.DataSource = obsoleto.obtener();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al realizar la operación");
            }
        }
        private void limpiarCampos()
        {
            txtinforme.Text = "";
            txtmotivo.Text = "";
            txtdescripcion.Text = "";
            obsoletos_id = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                obsoletos_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                txtinforme.Text = dataGridView1.SelectedRows[0].Cells["informe"].Value.ToString();
                txtmotivo.Text = dataGridView1.SelectedRows[0].Cells["motivo"].Value.ToString();
                txtdescripcion.Text = dataGridView1.SelectedRows[0].Cells["disposicion"].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells["id_equipo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            bool resultado = obsoleto.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Obsoleto eliminado con éxito");
                dataGridView1.DataSource = obsoleto.obtener();
            }
            else
            {
                MessageBox.Show("Error al eliminar el obsoleto");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
