using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using SVDWPF.AppData;
using System.IO;
using System.Xml.Linq;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;



namespace SVDWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для exPDF.xaml
    /// </summary>
    public partial class exPDF : Page
    {
        public exPDF()
        {
            InitializeComponent();
        }
        private void EXBtn_Click(object sender, RoutedEventArgs e)
        {
            var acc = Connect.context.Ychetn.ToList();
            var spr = Connect.context.Spravoch.ToList();
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
            Excel.Worksheet ws = (Excel.Worksheet)app.Worksheets.get_Item(1);
            ws.Name = "Учётная  таблица";
            Excel.Range r = ws.Range["A1", "E2"];
            r.Merge();
            r.Value = "Ведомость оплаты за переговоры";
            r.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            r.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            ws.Cells.Font.Name = "Times New Roman";
            ws.Cells[3, 1].Value = "номер лицевого счета";
            ws.Cells[3, 2].Value = "ФИО";
            ws.Cells[3, 3].Value = "кол-во киловатт";
            ws.Cells[3, 4].Value = "Тариф";
            ws.Cells[3, 5].Value = "Сумма";
            var curRow = 4;
            int? sum = 0;
            foreach (var item in acc)
            {
                ws.Cells[curRow, 1].Value = item.Spravoch.nomer_licevogo_scheta;
                ws.Cells[curRow, 2].Value = item.Spravoch.FIO;
                ws.Cells[curRow, 3].Value = item.kolvo_kilovatt;
                ws.Cells[curRow, 4].Value = item.Tariff;
                curRow++;
            }

            ws.Cells[curRow, 1].Value = "Итого: ";
            ws.Cells[curRow, 5].Value = sum;
            Excel.Range range = ws.Range[ws.Cells[curRow, 1], ws.Cells[curRow, 4]];
            range.Merge();

            Excel.Range ran = ws.Range[ws.Cells[3, 1], ws.Cells[curRow, 5]];
            ran.Borders.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);


            ws.Columns.AutoFit();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "Ведомость поставки товаров");
            wb.SaveAs(filePath);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }

        private void PDFBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("Ведомость.pdf", FileMode.Create));
                doc.Open();
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                PdfPTable table = new PdfPTable(5);
                PdfPCell cell = new PdfPCell(new Phrase("Ведомость оплаты за электроэнергию", font));
                cell.Colspan = 5;
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                table.AddCell(cell);
                table.AddCell(new PdfPCell(new Phrase(new Phrase("номер лицевого счета", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("ФИО", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("кол-во киловатт", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Тариф", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Сумма", font))));
                int? sum = 0;
                foreach (var item in Connect.context.Ychetn.ToList())
                {
                    table.AddCell(new Phrase(item.Spravoch.FIO.ToString(), font));
                    table.AddCell(new Phrase(item.kolvo_kilovatt.ToString(), font));
                    table.AddCell(new Phrase(item.Tariff.ToString(), font));
                }

                table.AddCell(new PdfPCell(new Phrase("Итого: ", font)) { Colspan = 4 });
                table.AddCell(new Phrase(sum.ToString(), font));

                doc.Add(table);
                doc.Close();
                MessageBox.Show("PDF-документ сохранён");
            }
            catch
            {
                MessageBox.Show("PDF-документ не сохранён", "Ошибка");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
