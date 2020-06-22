using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Cache;
using Domain;

namespace WebAppOperadorLogistico
{
    public partial class CreateClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string nombre = Session["nom"].ToString();
                if (UserLoginCache.Rol == 0)
                {
                    Response.Write("<script>alert('OPERACIÓN DENEGADA. Debe tener privilegios de Administrador ')</script>");
                    Response.Redirect("Default.aspx?men=1");
                }
                else if (UserLoginCache.Rol == 1)
                {
                    LabelUser.Text = "Bienvenida " + UserLoginCache.Name + " " + UserLoginCache.firstName;
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("Default.aspx?men=1");
            }
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("nom");
            Response.Redirect("Login.aspx");
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            InsertClientModel client = new InsertClientModel();
            if (TxtNombre.Text == "")
            {
                TxtNombre.Focus();
                TxtNombre.Attributes["placeholder"] = "Escriba su nombre";
                return;
            }

            if (TxtApellidoPaterno.Text == "")
            {
                TxtApellidoPaterno.Focus();
                TxtApellidoPaterno.Attributes["placeholder"] = "Escriba primer apellido";
                return;
            }

            if (TxtApellidoMaterno.Text == "")
            {
                TxtApellidoMaterno.Focus();
                TxtApellidoMaterno.Attributes["placeholder"] = "Escriba segundo apellido";
                return;
            }

            if (TxtEmail.Text == "")
            {
                TxtEmail.Focus();
                TxtEmail.Attributes["placeholder"] = "Escriba correo Electrónico";
                return;
            }

            if (TxtTelefono.Text == "")
            {
                TxtTelefono.Focus();
                TxtTelefono.Attributes["placeholder"] = "Escriba su Teléfono";
                return;
            }

            if (TxtCURP.Text == "")
            {
                TxtCURP.Focus();
                TxtCURP.Attributes["placeholder"] = "Escriba el CURP";
                return;
            }

            if (TxtUserName.Text == "")
            {
                TxtUserName.Focus();
                TxtUserName.Attributes["placeholder"] = "Escriba el Usuario";
                return;
            }

            if (TxtPassword.Text == "")
            {
                TxtPassword.Focus();
                TxtPassword.Attributes["placeholder"] = "Escriba el Password";
                return;
            }

            bool res = client.Insert(TxtCURP.Text, TxtUserName.Text, TxtPassword.Text, TxtApellidoPaterno.Text, TxtApellidoMaterno.Text, TxtNombre.Text, TxtEmail.Text, Int64.Parse(TxtTelefono.Text));
            if (res == true)
            {
                ClientCodeCache.Code = TxtCURP.Text;
                Response.Redirect("CreateOperations.aspx");
            }
            else
            {
                Response.Write("<script>alert('ERROR AL CREAR CLIENTE. Contacte con el Programador')</script>");
                Response.Redirect("SelectCreate.aspx");
            }
        }
    }
}