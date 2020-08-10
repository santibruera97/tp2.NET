using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using UI.App;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            UsuarioLogic usr = new UsuarioLogic();
            
            //la propiedad Text de los TextBox contiene el texto escrito en ellos
            if (usr.Login(this.txtUsuario.Text, this.txtPass.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkRegistro_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsr = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsr.ShowDialog();
        }
    }
}
