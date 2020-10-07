using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using System.Configuration;
using Business.Entities;

namespace UI.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic usr = new UsuarioLogic();
            if (usr.Login(txtUsuario.Text, txtClave.Text))
            {
                Page.Response.Write("Ingreso Ok");
            } 
            else
            {
                Page.Response.Write("Usuario y/o contraseña incorrecto");
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Page.Response.Write("Usted olvido su clave");

        }
    }
}