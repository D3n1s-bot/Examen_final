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
    public partial class provedoresfrm : Form
    {
        int provedores_id = 0;
        public provedoresfrm()
        {
            InitializeComponent();
        }

        private void provedoresfrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = proveedores.obtener();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["provedores_id"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtnomb.Text;
            bool resultado = false;
            if (provedores_id == 0)
            {
                resultado = proveedores.Crear(nombre);
            }
            else
            {
                resultado = proveedores.Editar(provedores_id, nombre);
            }
            if (resultado)
            {
                MessageBox.Show("Operación realizada con éxito");
                dataGridView1.DataSource = proveedores.obtener();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al realizar la operación");

            }
        }
        private void limpiarCampos()
        {
            txtnomb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["provedores_id"].Value);
                bool resultado = proveedores.Eliminar(id);
                if (resultado)
                {
                    MessageBox.Show("Proveedor eliminado con éxito");
                    dataGridView1.DataSource = proveedores.obtener();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el proveedor");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar");
            }

        }

        private void button2_Click(object sender, EventArgs e)
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
