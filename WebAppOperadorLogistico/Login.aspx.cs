using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;

namespace WebAppOperadorLogistico
{
    public partial class Login : System.Web.UI.Page
    {
        private int loginRol = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            loginRol = DropDownListRol.SelectedIndex;
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (TextUsuario.Text != "" && TextPassword.Text != "" && DropDownListRol.SelectedItem != null )
            {
                UserModel user = new UserModel();
                bool validLogin = user.userLogin(TextUsuario.Text, TextPassword.Text, loginRol);
                if (validLogin == true)
                {
                    if (loginRol == 0)
                    {
                        Session["nom"] = TextUsuario.Text;
                        Response.Redirect("Index.aspx");
                    }
                    else if (loginRol == 1)
                    {
                        Session["nom"] = TextUsuario.Text;
                        Response.Redirect("AdminIndex.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Acceso DENEGADO. Revise sus credenciales')</script>");
                }
                TextUsuario.Text = "";
                TextPassword.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Los campos usuario y contraseña no pueden estar vacíos. Revise')</script>");
            }            
        }

        protected void DropDownListRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            loginRol = DropDownListRol.SelectedIndex;
        }
    }
}