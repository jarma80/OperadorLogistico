using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Cache;

namespace WebAppOperadorLogistico
{
    public partial class InfoOperationCreated : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				string nombre = Session["nom"].ToString();
				if (UserLoginCache.Rol == 1)
				{
					LabelUser.Text = "Bienvenida " + UserLoginCache.Name + " " + UserLoginCache.firstName;
					Codigo.Text = OperationDetailCache.idOperation;
					Cliente.Text = ClientCodeCache.Code;
					Tipo.Text = OperationDetailCache.Type;
					Estatus.Text = OperationDetailCache.Status;

                    string percentOp = OperationDetailCache.Progress;

                    double perc = double.Parse( OperationDetailCache.Progress );
                    System.Drawing.Color colorProgress = System.Drawing.Color.FromArgb(92, 184, 92);
                    if (perc >= 0 && perc <= 20)
                    {
                        colorProgress = System.Drawing.Color.FromArgb(217, 83, 79);
                    }
                    if (perc > 20 && perc <= 50)
                    {
                        colorProgress = System.Drawing.Color.FromArgb(240, 173, 78);
                    }
                    if (perc > 50 && perc < 90)
                    {
                        colorProgress = System.Drawing.Color.FromArgb(2, 117, 216);
                    }
                    if (perc >= 90 && perc <= 100)
                    {
                        colorProgress = System.Drawing.Color.FromArgb(92, 184, 92);
                    }
                    progressPanel.Attributes["aria-valuemin"] = "0";
                    progressPanel.Attributes["aria-valuemax"] = "100";
                    progressPanel.BackColor = colorProgress;
                    progressPanel.Attributes["aria-valuenow"] = percentOp;
                    progressPanel.Style["width"] = String.Format("{0}%;", percentOp);
                    progressPanel.Controls.Add(new LiteralControl(String.Format("{0}%", percentOp)));

                    //LabelOperador.Text = "Bienvenida " + UserLoginCache.Name + " " + UserLoginCache.firstName;
                    //tipoOp = ListTipoOperacion.SelectedIndex + 1;
                    //TxtBxCliente.Text = ClientCodeCache.Code;
                }
				else
				{
					Response.Write("<script>alert('OPERACIÓN DENEGADA. Debe tener privilegios de Administrador ')</script>");
					Response.Redirect("Default.aspx?men=1");
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
    }
}