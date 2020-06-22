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
    public partial class AdminIndex : System.Web.UI.Page
    {
		PagedDataSource pg = new PagedDataSource();
		static int currentPageData = 0;
		static int totalPages = 0;
		static int rowsPerPage = 5;
		private OperationsTotalDetatilsModel operationModel;
		private DataTable dtOper;

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
					if (!IsPostBack)
					{
						//pg = new PagedDataSource();
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
						if (percentOp >= 0 && percentOp <= 20)
						{
							colorProgress = System.Drawing.Color.FromArgb(217, 83, 79);
						}
						if (percentOp > 20 && percentOp <= 50)
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

		protected void BtnSearch_Click(object sender, EventArgs e)
		{
			currentPageData = 0;
			operationModel = new OperationsTotalDetatilsModel();
			dtOper = operationModel.Operations(datepicker.Text, datepicker2.Text);
			pg.DataSource = dtOper.DefaultView;
			pg.AllowPaging = true;
			pg.CurrentPageIndex = currentPageData;
			pg.PageSize = rowsPerPage;
			DataListOperations.DataSource = pg;
			DataListOperations.DataBind();
			totalPages = pg.PageCount;
		}

		protected void BtnFistPage_Click(object sender, EventArgs e)
		{
			operationModel = new OperationsTotalDetatilsModel();
			dtOper = operationModel.Operations(datepicker.Text, datepicker2.Text);
			currentPageData = 0;
			pg.DataSource = dtOper.DefaultView;
			pg.AllowPaging = true;
			pg.CurrentPageIndex = currentPageData;
			pg.PageSize = rowsPerPage;
			DataListOperations.DataSource = pg;
			DataListOperations.DataBind();
		}

		protected void BtnPreviousPage_Click(object sender, EventArgs e)
		{
			if (currentPageData > 0)
			{
				currentPageData--;
			}
			operationModel = new OperationsTotalDetatilsModel();
			dtOper = operationModel.Operations(datepicker.Text, datepicker2.Text);
			pg.DataSource = dtOper.DefaultView;
			pg.AllowPaging = true;
			pg.CurrentPageIndex = currentPageData;
			pg.PageSize = rowsPerPage;
			DataListOperations.DataSource = pg;
			DataListOperations.DataBind();
		}

		protected void BtnNextPage_Click(object sender, EventArgs e)
		{
			if (currentPageData < totalPages - 1)
			{
				currentPageData++;
			}
			operationModel = new OperationsTotalDetatilsModel();
			dtOper = operationModel.Operations(datepicker.Text, datepicker2.Text);
			pg.DataSource = dtOper.DefaultView;
			pg.AllowPaging = true;
			pg.CurrentPageIndex = currentPageData;
			pg.PageSize = rowsPerPage;
			DataListOperations.DataSource = pg;
			DataListOperations.DataBind();

		}

		protected void BtnLastPage_Click(object sender, EventArgs e)
		{
			operationModel = new OperationsTotalDetatilsModel();
			dtOper = operationModel.Operations(datepicker.Text, datepicker2.Text);
			currentPageData = totalPages - 1;
			pg.DataSource = dtOper.DefaultView;
			pg.AllowPaging = true;
			pg.CurrentPageIndex = currentPageData;
			pg.PageSize = rowsPerPage;
			DataListOperations.DataSource = pg;
			DataListOperations.DataBind();
		}
	}
}