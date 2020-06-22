using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Cache;
using Domain;

namespace WebAppOperadorLogistico
{
    public partial class SearchClient : System.Web.UI.Page
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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchClientModel client = new SearchClientModel();
            DataTable dtClient = client.Search(TxtBxCriterion.Text);
            DataListClients.DataSource = dtClient;
            DataListClients.DataBind();
        }

        protected void BtnItem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string operationCode = btn.CommandArgument;
            ClientCodeCache.Code = operationCode;
            Response.Redirect("CreateOperations.aspx");
        }
    }
}