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


namespace UI.App
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        } 

        public EspecialidadDesktop(ModoForm modo)
        {
            InitializeComponent();
            this.Modo = modo;
        }

        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            EspecialidadLogic esp = new EspecialidadLogic();
            this.EspecialidadActual = esp.GetOne(ID);
            MapearDeDatos();
        }

        public Especialidad EspecialidadActual
        {
            get;
            set;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDesc.Text = this.EspecialidadActual.Descripcion;
           

            switch (this.Modo)
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

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                Especialidad esp = new Especialidad();
                this.EspecialidadActual = esp;
            }

            if (this.Modo == ModoForm.Modificacion || this.Modo == ModoForm.Baja)
            {
                this.txtID.Text = this.EspecialidadActual.ID.ToString();
            }

            this.EspecialidadActual.Descripcion = this.txtDesc.Text;
            



            switch (Modo)
            {
                case ModoForm.Alta:
                    this.EspecialidadActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja:
                    this.EspecialidadActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    this.EspecialidadActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    this.EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic usr = new EspecialidadLogic();
            usr.Save(EspecialidadActual);

        }

        public override bool Validar()
        {
            string msg = "";
            if (this.txtDesc.TextLength == 0)
            {
                string name = this.txtDesc.Name;
                msg += "- El parametro " + name + " no debe estar vacio\n";
            }

            if (msg != "")
            {
                Notificar("Verifique los errores", msg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }

            else return true;


        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
