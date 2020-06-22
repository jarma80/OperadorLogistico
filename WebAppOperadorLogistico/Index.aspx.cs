using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Common.Cache;
using Domain;

namespace WebAppOperadorLogistico
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				string nombre = Session["nom"].ToString();
				OperationsModel operationsModel = new OperationsModel();
				DataTable dtOper = operationsModel.Operations(UserLoginCache.IDUser);
				
				//GridViewTable.DataSource = dtOper;
				//GridViewTable.DataBind();

				DataListOperations.DataSource = dtOper;
				DataListOperations.DataBind();
				LabelUser.Text = "Bienvenido " + UserLoginCache.Name + " " + UserLoginCache.firstName;
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

		protected void GridViewTable_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		protected void DataListOperations_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		protected void BtnItem_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			string operationCode = btn.CommandArgument;
			OperationCodeCache.Code = operationCode;
			Response.Redirect("OperationDetail.aspx");
		}

		protected void DataListOperations_ItemCreated(object sender, DataListItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
			{
				Object ob = e.Item.FindControl("PercentagePanel");
				if (ob != null)
				{
					Double percentOp = 25;
					Panel progressPanel = (Panel)ob;
					DataRowView dataRow = (DataRowView)e.Item.DataItem;
					if (dataRow != null)
					{
						percentOp = Convert.ToDouble(dataRow.Row.ItemArray[3].ToString());
						System.Drawing.Color colorProgress = System.Drawing.Color.FromArgb(92, 184, 92);
						if (percentOp >= 0 && percentOp <= 20 )
						{
							colorProgress = System.Drawing.Color.FromArgb(217, 83, 79);
						}
						if (percentOp > 20 && percentOp <=50)
						{
							colorProgress = System.Drawing.Color.FromArgb(240, 173, 78);
						}
						if (percentOp > 50 && percentOp < 90)
						{
							colorProgress = System.Drawing.Color.FromArgb(2, 117, 216);
						}
						if (percentOp >= 90 && percentOp <= 100)
						{
							colorProgress = System.Drawing.Color.FromArgb(92, 184, 92);
						}
						progressPanel.Attributes["aria-valuemin"] = "0";
						progressPanel.Attributes["aria-valuemax"] = "100";
						progressPanel.BackColor = colorProgress;
						progressPanel.Attributes["aria-valuenow"] = percentOp.ToString();
						progressPanel.Style["width"] = String.Format("{0}%;", percentOp);
						progressPanel.Controls.Add(new LiteralControl(String.Format("{0}%", percentOp)));
					}
				}
			}
		}

	}
}