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
    public partial class EditOperations : System.Web.UI.Page
    {
		private int tipoOp = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				string nombre = Session["nom"].ToString();
				if ( UserLoginCache.Rol == 1)
				{
					LabelUser.Text = "Operador Logístico: " + UserLoginCache.Name + " " + UserLoginCache.firstName;
					LabelOperador.Text = "Bienvenida " + UserLoginCache.Name + " " + UserLoginCache.firstName;
					tipoOp = ListTipoOperacion.SelectedIndex + 1;
					TxtBxCliente.Text = ClientCodeCache.Code;
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

		protected void BtnInsertar_Click(object sender, EventArgs e)
		{
			if (TxtBxCliente.Text != "")
			{
				if (tipoOp > 0)
				{
					InsertOperationModel operation = new InsertOperationModel();
					bool res = operation.Insert(TxtBxCliente.Text, tipoOp);
					if (res == true)
					{
						TxtBxCliente.Text = "";
						ListTipoOperacion.SelectedIndex = -1;
						//LabelExito.Text = "Operación creada correctamente";
						Response.Redirect("InfoOperationCreated.aspx?");
					}
					else 
					{
						TxtBxCliente.Text = "";
						ListTipoOperacion.SelectedIndex = -1;
						//LabelExito.Text = "Error al crear la operación";
						Response.Write("<script>alert('ERROR AL CREAR OPERACIÓN. Contacte con el programador ')</script>");
						Response.Redirect("SelectCreate.aspx?");
						return;
					}
				}
				else
				{
					ListTipoOperacion.Focus();
				}
			}
			else
			{
				TxtBxCliente.Focus();
			}
			
		}

		protected void ListTipoOperacion_SelectedIndexChanged1(object sender, EventArgs e)
		{
			LabelExito.Text = ListTipoOperacion.SelectedIndex.ToString();
			
		}

		protected void BtnCerrarSesion_Click(object sender, EventArgs e)
		{
			Session.Remove("nom");
			Response.Redirect("Login.aspx");
		}
	}
}