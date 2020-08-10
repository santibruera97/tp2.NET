using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.App
{
    public partial class UsuarioDesktop : ApplicationForm
    {

       
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public override void MapearDeDatos() {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave; 

            switch(this.Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }

        }
        public override void MapearADatos() { 
            if(this.Modo == ModoForm.Alta)
            {
                Usuario usr = new Usuario();
                this.UsuarioActual = usr;
            } 
           
                if(this.Modo == ModoForm.Modificacion || this.Modo == ModoForm.Baja) { 
                    this.txtID.Text = this.UsuarioActual.ID.ToString();
                }
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.EMail= this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario= this.txtUsuario.Text;
                this.UsuarioActual.Clave= this.txtClave.Text; 
                
            

            switch (Modo)
            {
                case ModoForm.Alta:
                    this.UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja:
                    this.UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    this.UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    this.UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
            }

        }
        public override void GuardarCambios() {
            MapearADatos();
            UsuarioLogic usr = new UsuarioLogic(); 
            usr.Save(UsuarioActual);
            
        }
        public override bool Validar() {
            string msg = "";
            if (this.txtApellido.TextLength == 0) {
                string name = this.txtApellido.Name;
                msg += "- El parametro "+ name + " no debe estar vacio\n";
            }
            
            if (this.txtClave.TextLength == 0)
            {
                string name = this.txtClave.Name;
                msg += "- El parametro " + name + " no debe estar vacio\n";
            }

            if (this.txtEmail.TextLength == 0)
            {
                string name = this.txtEmail.Name;
                msg += "- El parametro " + name + " no debe estar vacio\n";
            }

            if (this.txtNombre.TextLength == 0)
            {
                string name = this.txtNombre.Name;
                msg += "- El parametro " + name + " no debe estar vacio\n";
            }

            if (this.txtUsuario.TextLength == 0)
            {
                string name = this.txtUsuario.Name;
                msg += "- El parametro " + name + " no debe estar vacio\n";
            } 

            if(this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                msg += "- Las claves no coinciden\n";
            }

            if (!Util.Validaciones.EsMailValido(this.txtEmail.Text))
            {
                msg += "- El Email no es valido\n";
                
            }
            if (this.txtClave.TextLength < 8)
            {
                msg += "- La clave debe tener al menos 8 caracteres";
            }

            if (msg != "")
            {
                Notificar("Verifique los errores",msg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }

            else return true;




            }

        public Usuario UsuarioActual { get; set; }

        public UsuarioDesktop(ModoForm modo) : this() {
            modo = ModoForm.Alta;
            this.Modo =modo;
           

         } 

        public UsuarioDesktop (int ID,ModoForm modo) :this()
        {
            this.Modo = modo;
            UsuarioLogic usr = new UsuarioLogic();
            this.UsuarioActual = usr.GetOne(ID);
            MapearDeDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                GuardarCambios();
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
