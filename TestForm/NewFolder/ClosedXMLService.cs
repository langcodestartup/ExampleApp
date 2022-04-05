using ClosedXML.Excel;

namespace TestForm.NewFolder
{
    public class ClosedXMLService
    {
        XLWorkbook workbook;
        IXLWorksheet worksheet;

        public void Init(string path)
        {
            workbook = new XLWorkbook(path);

            worksheet = workbook.Worksheet(1); // 1부터 시작
        }

        public T GetValue<T>(int col, int row)
        {
            var data = worksheet.Cells();
            data.
        }
    }
}
