using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PdfCreator
{
    public class CreatePDF
    {
        public CreatePDF() 
        { 
            
        }

        public bool SalesCheck(string PDFName, string path, string clientName, string clientFirstName, string clientLastName, string clientRFC, string quantity) 
        {
            bool res = false;

            var doc1 = new Document(PageSize.LETTER);
            PdfWriter.GetInstance(doc1, new FileStream(path + "/" + PDFName + ".pdf", FileMode.Create));
            doc1.Open();
            //doc1.Add(new Paragraph("Mi primer PDF en ASP.NET"));

            PdfPTable maintable = new PdfPTable(7);
            
            PdfPCell logo = new PdfPCell(new Phrase("LOGO        "));
            PdfPCell cellFactura = new PdfPCell(new Phrase("FACTURA"));
            

            PdfPTable infoFactura = new PdfPTable(2);
            cellFactura.Colspan = 2;
            infoFactura.AddCell(cellFactura);
            infoFactura.AddCell("No. Factura");
            infoFactura.AddCell("00000078");

            infoFactura.AddCell("Fecha. Factura");
            infoFactura.AddCell("07-05-2020");

            PdfPCell infoCellFactura = new PdfPCell(infoFactura);


            maintable.AddCell(" ");
            maintable.AddCell(" ");
            maintable.AddCell(" ");
            maintable.AddCell(" ");
            maintable.AddCell(" ");
            maintable.AddCell(" ");
            maintable.AddCell(" ");
            
            logo.Colspan = 5;
            infoCellFactura.Colspan = 2;
            maintable.AddCell(logo);
            maintable.AddCell(infoCellFactura);

            PdfPTable infoEmpresa = new PdfPTable(1);
            infoEmpresa.AddCell("EMPRESA");
            infoEmpresa.AddCell("Dirección");
            infoEmpresa.AddCell("RFC");

            PdfPCell infoCellEmpresa = new PdfPCell(infoEmpresa);
            infoCellEmpresa.Colspan = 1;

            maintable.AddCell(infoCellEmpresa);

            maintable.AddCell(" ");
            maintable.AddCell(" ");
            maintable.AddCell(" ");

            PdfPTable infoCliente = new PdfPTable(1);

            infoCliente.AddCell("CLIENTE" + clientFirstName);
            infoCliente.AddCell("Dirección");
            infoCliente.AddCell("RFC");

            PdfPCell infoCellCliente = new PdfPCell(infoCliente);
            infoCellCliente.Colspan = 3;

            maintable.AddCell(infoCellCliente);

            maintable.AddCell("Código");
            maintable.AddCell("Concepto");
            maintable.AddCell(" ");
            maintable.AddCell("Cantidad");
            maintable.AddCell("Precio unit.");
            maintable.AddCell("Descuento");
            maintable.AddCell("Total");

            doc1.Add(maintable);

            doc1.Close();

            return res;
        }
    }
}
