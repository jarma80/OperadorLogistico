using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Cache;
using Domain;
using PdfCreator;

namespace WebAppOperadorLogistico
{
    public partial class UpdateOperations : System.Web.UI.Page
    {
        private bool postBySearchButton = true;
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
                    postBySearchButton = false;
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

        private void SearchOperation() 
        {
            if (TxtBxCriterion.Text != "")
            {
                SearchOperationModel operation = new SearchOperationModel();
                DataTable dtOperation = operation.Search(TxtBxCriterion.Text);

                if (dtOperation != null)
                {
                    if (dtOperation.Rows.Count > 0)
                    {
                        Codigo.Text = dtOperation.Rows[0].ItemArray[0].ToString();
                        Cliente.Text = dtOperation.Rows[0].ItemArray[1].ToString();
                        Estatus.Text = dtOperation.Rows[0].ItemArray[2].ToString();
                        string percentOp = dtOperation.Rows[0].ItemArray[3].ToString();
                        OperationCodeCache.Type = int.Parse(dtOperation.Rows[0].ItemArray[4].ToString());
                        OperationCodeCache.Code = dtOperation.Rows[0].ItemArray[0].ToString();
                        ClientCodeCache.Code = Cliente.Text;
                        ClientCodeCache.FirstName = dtOperation.Rows[0].ItemArray[5].ToString();
                        ClientCodeCache.LastName = dtOperation.Rows[0].ItemArray[6].ToString();
                        ClientCodeCache.Name = dtOperation.Rows[0].ItemArray[7].ToString();

                        double perc = double.Parse(percentOp);
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

                        DropDownEstatusOperativo.Items.Clear();

                        OperativeStatusModel operativeStatus = new OperativeStatusModel();
                        List<string> itemsString = new List<string>();
                        if (OperationCodeCache.Type == 1) // Aduana-Logística
                        {
                            foreach (DataRow item in operativeStatus.GetData().Rows)
                            {
                                itemsString.Add(item[0].ToString());
                            }
                            for (int i = 3; i < 8; i++)
                            {
                                DropDownEstatusOperativo.Items.Add(itemsString.ElementAt(i));
                            }
                            DropDownEstatusOperativo.Items.Add(itemsString.ElementAt(1));
                            DropDownEstatusOperativo.Items.Add(itemsString.ElementAt(2));
                            DropDownEstatusOperativo.Items.Add(itemsString.ElementAt(8));
                        }
                        else if (OperationCodeCache.Type == 2) // Solo Logística
                        {
                            foreach (DataRow item in operativeStatus.GetData().Rows)
                            {
                                itemsString.Add(item[0].ToString());
                            }
                            for (int i = 0; i < 3; i++)
                            {
                                DropDownEstatusOperativo.Items.Add(itemsString.ElementAt(i));
                            }
                            DropDownEstatusOperativo.Items.Add(itemsString.ElementAt(8));
                        }
                        int index = 0;
                        foreach (System.Web.UI.WebControls.ListItem item in DropDownEstatusOperativo.Items)
                        {
                            if (item.Text == Estatus.Text)
                            {
                                DropDownEstatusOperativo.SelectedIndex = index;
                            }
                            index++;
                        }
                        postBySearchButton = true;
                    }
                    else
                    {
                        Codigo.Text = "";
                        Cliente.Text = "";
                        Estatus.Text = "";
                        progressPanel.Style["width"] = String.Format("0%;");
                        progressPanel.Attributes["aria-valuenow"] = "0";
                        DropDownEstatusOperativo.Items.Clear();
                    }
                }
            }     
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchOperation();
        }

        protected void BtnItem_Click(object sender, EventArgs e)
        {
            /*
            Button btn = (Button)sender;
            string operationCode = btn.CommandArgument;
            OperationCodeCache.Code = operationCode;
            Response.Redirect("UpdateStatusOperation.aspx");
            */
        }

        protected void BtnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (Codigo.Text != "" && Cliente.Text != "" && Estatus.Text != "" && DropDownEstatusOperativo.Items.Count > 0 )
            {
                UpdateOperationStatusModel opstatus = new UpdateOperationStatusModel();
                bool res = opstatus.Update(OperationCodeCache.Code, DropDownEstatusOperativo.SelectedIndex, DropDownEstatusOperativo.SelectedItem.Text);
                if (res == true)
                {
                    string fact = DropDownEstatusOperativo.SelectedItem.Text;
                    SearchOperation();
                    if (fact == "Facturación")
                    {
                        //Response.Write("<script>alert('CREANDO FACTURA PDF .')</script>");

                        string path = Server.MapPath("PDFs");
                        FileUploader.Visible = true;
                        BtnUploader.Visible = true;

                        CreatePDF PDF = new CreatePDF();

                        PDF.SalesCheck(OperationCodeCache.Code, path, ClientCodeCache.Name, ClientCodeCache.FirstName, ClientCodeCache.LastName, "RFCCLIENT", "500");

                        /*
                        var doc1 = new Document(PageSize.LETTER);
                        //use a variable to let my code fit across the page...

                        string path = Server.MapPath("PDFs");
                        PdfWriter.GetInstance(doc1, new FileStream(path + "/"+ OperationCodeCache.Code + ".pdf", FileMode.Create));
                        doc1.Open();
                        doc1.Add(new Paragraph("Mi primer PDF en ASP.NET"));
                        doc1.Close();
                        */

                    }
                    else
                    {
                        FileUploader.Visible = false;
                        BtnUploader.Visible = false;
                    }
                }
                else
                {
                    Response.Write("<script>alert('ERROR EN LA ACTUALIZACIÓN. Contacte al programador.')</script>");
                }
            }
        }

        protected void BtnUploader_Click(object sender, EventArgs e)
        {
            if (FileUploader.HasFile)
            {
                string pathFact = Server.MapPath("Billing");
                FileUploader.SaveAs(pathFact + "/" + OperationCodeCache.Code + "-" + FileUploader.FileName);
                FileUploader.Visible = false;
                BtnUploader.Visible = false;
                InsertInvoiceModel invoice = new InsertInvoiceModel();
                bool res = invoice.Insert(OperationCodeCache.Code, (OperationCodeCache.Code + "-" + FileUploader.FileName));
                if (res == true)
                {

                }
                else
                {
                    Response.Write("<script>alert('ERROR EN LA FACTURACIÓN. Contacte al programador.')</script>");
                }
                
            }
        }
    }
}