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
    public partial class OperationDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				string nombre = Session["nom"].ToString();
				OperationDetailModel detailsModel = new OperationDetailModel();
				if (detailsModel.Details())
				{
					LabelOperation.Text = "Numero de Operación: " + OperationDetailCache.idOperation;
					LabelType.Text = "Tipo: " + OperationDetailCache.Type;
					LabelStatus.Text = "Estatus: " + OperationDetailCache.Status;
					LabelDate.Text = "Fecha de Solicitud: " + OperationDetailCache.OperationDate.Date.ToShortDateString();
					if (OperationDetailCache.Status == "Facturación")
					{
						BtnDownload.Visible = true;
					}
					else
					{
						BtnDownload.Visible = false;
					}

				}
				else {
					Response.Write("<script>alert('Error al Acceder a los detalles de su operación. Contacte con su operador Logístico para mas detalles')</script>");
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

		protected void BtnDownload_Click(object sender, EventArgs e)
		{
			Response.Redirect("Billing/" + OperationDetailCache.InvoicePath);
		}
	}
}