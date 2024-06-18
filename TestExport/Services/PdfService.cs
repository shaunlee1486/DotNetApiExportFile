using iText.Html2pdf;
using iText.Kernel.Pdf;
using TestExport.Models;

namespace TestExport.Services
{
    public class PdfService : IPdfService
    {
        public byte[] GeneratePdfFromHtmlFile(string htmlFilePath, object model)
        {
            var htmlContent = System.IO.File.ReadAllText(htmlFilePath);

            // Replace placeholders in the HTML content with model values (simplified example)
            foreach (var prop in model.GetType().GetProperties())
            {
                var placeholder = $"{{{{{prop.Name}}}}}";
                htmlContent = htmlContent.Replace(placeholder, prop.GetValue(model)?.ToString());
            }

            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new PdfWriter(memoryStream))
                using (var pdfDocument = new PdfDocument(writer))
                {
                    ConverterProperties converterProperties = new ConverterProperties();
                    HtmlConverter.ConvertToPdf(htmlContent, pdfDocument, converterProperties);
                }
                return memoryStream.ToArray();
            }
        }

        public byte[] GeneratePdfFromTableHtmlFile(string htmlFilePath, object model)
        {
            var htmlContent = File.ReadAllText(htmlFilePath);

            // Replace placeholders in the HTML content with model values (simplified example)
            foreach (var prop in model.GetType().GetProperties())
            {
                var placeholder = $"{{{{{prop.Name}}}}}";
                htmlContent = htmlContent.Replace(placeholder, prop.GetValue(model)?.ToString());
            }

            // Handle the table data
            if (model is ReportModel report)
            {
                var itemsHtml = "";
                foreach (var item in report.Items)
                {
                    itemsHtml += $"<tr><td>{item.Item}</td><td>{item.Quantity}</td><td>{item.Price}</td></tr>";
                }
                htmlContent = htmlContent.Replace("{{#each Items}}", itemsHtml);
            }

            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new PdfWriter(memoryStream))
                {
                    var pdfDocument = new PdfDocument(writer);
                    ConverterProperties converterProperties = new ConverterProperties();
                    HtmlConverter.ConvertToPdf(htmlContent, pdfDocument, converterProperties);
                }
                return memoryStream.ToArray();
            }
        }
    }
}
