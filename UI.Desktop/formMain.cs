using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop;

namespace UI.App
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
                this.Dispose();
            
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListUsuarios usersABM = new formListUsuarios();
            usersABM.ShowDialog();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListEspecialidades espABM = new formListEspecialidades();
            espABM.ShowDialog();
        }
    }
}
