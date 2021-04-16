using iTextSharp.text;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout_web_local_api.Printer
{
    public static class Generate
    {
        // Exemplo:
        // https://www.c-sharpcorner.com/UploadFile/f4f047/generating-pdf-file-using-C-Sharp/
        // https://www.devmedia.com.br/criando-e-manipulando-arquivos-pdf-com-a-biblioteca-itextsharp-em-csharp/33392
        // https://pdfium.patagames.com/
        // Dentro da pasta debug/x86 retirar a dll pdfium.dll e adicionar onde fica o .exe

        public static void createPDF()
        {
            string pathFile = @"C:\teste.pdf";
            using (FileStream fileStream = new FileStream(pathFile, FileMode.Create))
            {
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fileStream);
                document.Open();

                Chunk chunk = new Chunk("This is from chunk. ");
                document.Add(chunk);

                Phrase phrase = new Phrase("This is from Phrase.");
                document.Add(phrase);

                Paragraph para = new Paragraph("This is from paragraph.");
                document.Add(para);

                string text = @"you are successfully created PDF file.";
                Paragraph paragraph = new Paragraph();
                paragraph.SpacingBefore = 10;
                paragraph.SpacingAfter = 10;
                paragraph.Alignment = Element.ALIGN_LEFT;
                paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
                paragraph.Add(text);
                document.Add(paragraph);

                document.Close();
                //byte[] bytes = memoryStream.ToArray();

                //var reader = new StreamReader(memoryStream);

               // PrintPDF2("Microsoft Print to PDF", "teste", 1, memoryStream);
                try
                {
                    // Create the printer settings for our printer
                    var printerSettings = new PrinterSettings
                    {
                        PrinterName = "Microsoft Print to PDF",//printer,
                        Copies = 1,//(short)copies,
                    };

                    // Create our page settings for the paper size selected
                    var pageSettings = new PageSettings(printerSettings)
                    {
                        Margins = new Margins(0, 0, 0, 0),
                    };
                    foreach (PaperSize paperSize in printerSettings.PaperSizes)
                    {
                        if (paperSize.PaperName == "Teste")//paperName)
                        {
                            pageSettings.PaperSize = paperSize;
                            break;
                        }
                    }

                    // Now print the PDF document
                    using (var documento = PdfiumViewer.PdfDocument.Load(pathFile))
                    {
                        using (var printDocument = documento.CreatePrintDocument())
                        {
                            printDocument.PrinterSettings = printerSettings;
                            printDocument.DefaultPageSettings = pageSettings;
                            printDocument.PrintController = new StandardPrintController();
                            printDocument.Print();
                        }
                    }
                }
                catch (System.Exception e)
                {

                }
                //memoryStream.Close();
                //string filename = textBox1.Text.ToString();
                ////Create a StreamReader object
                //var reader = new StreamReader(writer.);
                //// Create a Verdana font with size 10
                //verdana10Font = new Font("Verdana", 10);
                //// Create a PrintDocument object
                //PrintDocument pd = new PrintDocument();
                //// Add PrintPage event handler
                //pd.PrintPage += new PrintPageEventHandler(this.PrintTextFileHandler);
                ////Call Print Method
                ////pd.PrinterSettings.PrinterName

                //pd.Print();
                ////Close the reader  
                //if (reader != null)
                //    reader.Close();

                //Response.Clear();
                //Response.ContentType = "application/pdf";

                //string pdfName = "User";
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
                //Response.ContentType = "application/pdf";
                //Response.Buffer = true;
                //Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
                //Response.BinaryWrite(bytes);
                //Response.End();
                //Response.Close();
            }
        }
    }
}
