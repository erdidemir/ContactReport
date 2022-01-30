using ClosedXML.Excel;
using EventBus.Messages.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace RaporConsumer.Exports
{
    public static class GenerateExcel
    {
        public static string ReportExcel(Guid raporId, List<KonumModel> konumModelList)
        {
            string path = "Rapor/" + raporId.ToString() + ".xlsx";

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Users");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Konum";
                worksheet.Cell(currentRow, 2).Value = "KisiSayisi";
                worksheet.Cell(currentRow, 2).Value = "TelefonNumarasiSayisi";

                foreach (var konum in konumModelList)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = konum.Konum;
                    worksheet.Cell(currentRow, 2).Value = konum.KisiSayisi;
                    worksheet.Cell(currentRow, 3).Value = konum.TelefonNumarasiSayisi;

                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    
                    File.WriteAllBytes(path, content);
                }
            }

            return path;
        }
    }
}
