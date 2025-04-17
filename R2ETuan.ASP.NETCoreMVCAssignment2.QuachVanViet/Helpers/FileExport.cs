using ClosedXML.Excel;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;

namespace ASP.NETCoreMVCAssignment1.QuachVanViet.Helpers
{
    public class FileExport
    {
        public static byte[] ExportToExcel(List<Person> data)
        {
            var people = data; // Lấy danh sách từ repository
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("People");

                // Tiêu đề cột
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "First Name";
                worksheet.Cell(1, 3).Value = "Last Name";
                worksheet.Cell(1, 4).Value = "Gender";
                worksheet.Cell(1, 5).Value = "Date of Birth";
                worksheet.Cell(1, 6).Value = "Phone Number";
                worksheet.Cell(1, 7).Value = "Birth Place";
                worksheet.Cell(1, 8).Value = "Is Graduated";

                // Điền dữ liệu
                int row = 2;
                foreach (var person in people)
                {
                    worksheet.Cell(row, 1).Value = person.Id.ToString();
                    worksheet.Cell(row, 2).Value = person.FirstName;
                    worksheet.Cell(row, 3).Value = person.LastName;
                    worksheet.Cell(row, 4).Value = person.Gender.ToString();
                    worksheet.Cell(row, 5).Value = person.DateOfBirth;
                    worksheet.Cell(row, 6).Value = person.PhoneNumber;
                    worksheet.Cell(row, 7).Value = person.BirthPlace;
                    worksheet.Cell(row, 8).Value = person.IsGraduated;
                    row++;
                }

                // Định dạng cột Date of Birth
                worksheet.Column(5).Style.DateFormat.Format = "yyyy-MM-dd";
                worksheet.Columns().AdjustToContents();

                // Xuất file thành byte[]
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
