using DocumentFormat.OpenXml.Bibliography;
using OfficeOpenXml;
using System.Data;
using Thesis.Models;
using Thesis.Repository;

namespace Thesis.Services
{
    public class ExcelGenService : IExcelGenService
    {
        private readonly IExcelGenRepository _excelGenRepository;
        public ExcelGenService(IExcelGenRepository _excelGenRepository)
        {
            this._excelGenRepository =  _excelGenRepository;
        }
        public void GenSheet()
        {
            DataTable table = _excelGenRepository.getTable();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Fill the Excel sheet with data from the DataTable
                worksheet.Cells["A1"].LoadFromDataTable(table, true);

                // Save the Excel package to a file
                FileInfo excelFile = new FileInfo("C:\\Users\\Tamim\\OneDrive - Alexandria University\\Desktop\\BA-Internship'23\\.NET\\Thesis\\wwwroot\\ExcelFactory\\text2.xlsx");
                package.SaveAs(excelFile);


            }

        }
        public MemoryStream DownloadSheet()
        {
            GenSheet();
            string fileName = "text2.xlsx";
            // Ensure the fileName parameter is valid to prevent directory traversal attacks.
            if (string.IsNullOrEmpty(fileName)) return new MemoryStream();

            // Specify the path to the directory where the file is located.
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ExcelFactory", fileName);

            // Check if the file exists.
            if (!System.IO.File.Exists(filePath))
            {
                return new MemoryStream();
            }

            // Serve the file for download.
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            File.Delete(@"C:\\Users\\Tamim\\OneDrive - Alexandria University\\Desktop\\BA-Internship'23\\.NET\\Thesis\\wwwroot\\ExcelFactory\\text2.xlsx");
            return memory;
            
        }


    }
    }

