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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            oficinasfrm oficinas = new oficinasfrm();
            oficinas.MdiParent = this;
            oficinas.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            equiposfrm equipos = new equiposfrm();
            equipos.MdiParent = this;
            equipos.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            provedoresfrm provedores = new provedoresfrm();
            provedores.MdiParent = this;
            provedores.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            obsoletos obs = new obsoletos();
            obs.MdiParent = this;
            obs.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            mantenimientos mant= new mantenimientos();
            mant.MdiParent = this;
            mant.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            trasladosfrm traslados = new trasladosfrm();
            traslados.MdiParent = this;
            traslados.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            empleadosfrm empleados = new empleadosfrm();
            empleados.MdiParent = this;
            empleados.Show();

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            tipoequiposfrm tipoequipos = new tipoequiposfrm();
            tipoequipos.MdiParent = this;
            tipoequipos.Show();
        }
    }
}
