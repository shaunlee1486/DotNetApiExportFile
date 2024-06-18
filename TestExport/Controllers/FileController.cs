using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection;
using TestExport.Models;
using TestExport.Services;

namespace TestExport.Controllers
{
    [ApiController]
    [Route("export/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IPdfService _pdfService;

        public FileController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpGet("csv")]
        public IActionResult ExportFileCsv()
        {
            var people = new List<Person>
            {
                new Person { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new Person { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" }
            };

            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(people);
                streamWriter.Flush();
                var result = memoryStream.ToArray();
                return File(result, "text/csv", "people.csv");
            }
        }

        [HttpGet("pdf")]
        public IActionResult ExportFilePdfFromHtml()
        {
            var model = new
            {
                Name = "shaun",
                Email = "shaun1486@gmail.com"
            };
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var htmlFilePath = @"Templates/Pdf/ReportTemplate.html";
            if (!System.IO.File.Exists(htmlFilePath))
            {
                return Ok();
            }
            var pdfBytes = _pdfService.GeneratePdfFromHtmlFile(htmlFilePath, model);
            return File(pdfBytes, "application/pdf", "report.pdf");
        }

        [HttpGet("pdf/table")]
        public IActionResult ExportFilePdfFromTableHtml()
        {
            var model = new ReportModel
            {
                Name = "shaun",
                Email = "shaun1486@gmail.com",
                Items = new List<ItemModel>
                {
                    new ItemModel { Item = "Item 1", Quantity = 2, Price = 10.50m },
                    new ItemModel { Item = "Item 2", Quantity = 1, Price = 20.00m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                    new ItemModel { Item = "Item 3", Quantity = 5, Price = 5.75m },
                }
            };

            var htmlFilePath = "Templates/Pdf/TableReportTemplate.html";
            var pdfBytes = _pdfService.GeneratePdfFromTableHtmlFile(htmlFilePath, model);
            return File(pdfBytes, "application/pdf", "report.pdf");
        }
    }
}
