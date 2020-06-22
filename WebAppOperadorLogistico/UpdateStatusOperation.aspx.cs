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
    public partial class UpdateStatusOperation : System.Web.UI.Page
    {
        private int status = 0;
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
                    LabelCode.Text = OperationCodeCache.Code;
                    status = DropDownListStatus.SelectedIndex + 1;

                    if (DropDownListStatus.Items.Count==0)
                    {
                        OperativeStatusModel opStatus = new OperativeStatusModel();
                        foreach (DataRow item in opStatus.GetData().Rows)
                        {
                            DropDownListStatus.Items.Add(item[0].ToString());
                        }
                    }
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

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateOperationStatusModel opStatus = new UpdateOperationStatusModel();
            bool res = opStatus.Update(OperationCodeCache.Code, status, "Carga");
            if (res == true)
            {
                Response.Redirect("UpdateOperations.aspx?");
            }
            else
            {
                Response.Write("<script>alert('ERROR AL ACTUALIZAR OPERACIÓN. Contacte con el programador ')</script>");
                Response.Redirect("UpdateOperations.aspx?");
            }
        }

        protected void DropDownListStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = DropDownListStatus.SelectedIndex + 1;
        }
    }
}