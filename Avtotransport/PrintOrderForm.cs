using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Avtotransport
{
    public partial class PrintOrderForm : Form
    {
        // переменные класса
        private int orderId;
        private int counter;        // сквозной номер строки в массиве строк, которые выводятся
        private string orgNumber;   // номер воинской части для печати на путевом листе

        public PrintOrderForm(int oId, string number)
        {
            InitializeComponent();
            orderId = oId;
            orgNumber = number;
        }

        // Обработчик загрузки формы
        private void PrintOrderForm_Load(object sender, EventArgs e)
        {
            TravelOrderClass printOrder = new TravelOrderClass();
            printOrder.GetTravelOrderById(orderId);
            DriverClass driver = new DriverClass();
            driver.GetDriverById((int)printOrder.DriverId);
            VehicleClass vehicle = new VehicleClass();
            vehicle.GetVehicleById((int)printOrder.VehicleId);
            VehicleClass trailer = new VehicleClass();
            // если есть прицеп в путевом листе
            if (printOrder.TrailerId != null)
                trailer.GetVehicleById((int)printOrder.TrailerId);
            ItineraryClass itinerary = new ItineraryClass();
            itinerary.GetItineraryById((int)printOrder.ItineraryId);
            // вывод в RichTextBox данных для печати путевого листа
            // серия и номер
            pageRichTextBox.Text += printOrder.Number.PadLeft(150) + "\r\n";
            pageRichTextBox.Text += "\r\n" + "\r\n";
            // действителен по
            pageRichTextBox.Text += printOrder.ValidityDate.ToLongDateString().PadLeft(140) + "\r\n";
            // водитель
            pageRichTextBox.Text += driver.DriverName.PadLeft(30) + "\r\n";
            // организация
            pageRichTextBox.Text += orgNumber.PadLeft(140) + "\r\n";
            pageRichTextBox.Text += "\r\n";
            // марка машины
            pageRichTextBox.Text += vehicle.Model.PadLeft(135) + "\r\n";
            pageRichTextBox.Text += "\r\n";
            // номерной знак машины
            pageRichTextBox.Text += vehicle.RegNumber.PadLeft(145) + "\r\n";
            pageRichTextBox.Text += "\r\n";
            // номерной знак прицепа
            pageRichTextBox.Text += trailer.RegNumber.PadLeft(145) + "\r\n";
            pageRichTextBox.Text += "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n";
            // старший машины
            string customer = printOrder.Customer.PadRight(22);
            pageRichTextBox.Text += customer.PadLeft(90);
            // маршрут
            pageRichTextBox.Text += itinerary.ItineraryName.PadRight(52);
            // расстояние
            pageRichTextBox.Text += Convert.ToString(itinerary.Distance).PadRight(20);
            // дополнительная информация
            pageRichTextBox.Text += printOrder.DopInfo.PadRight(65);
            // время подачи и возвращения
            pageRichTextBox.Text += printOrder.TimeOut.ToShortTimeString().PadRight(20);
            pageRichTextBox.Text += printOrder.TimeIn.ToShortTimeString() + "\r\n";
            pageRichTextBox.Text += "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n";
            // тип топлива
            pageRichTextBox.Text += GetStringFuelType(vehicle.FuelType).PadLeft(100, ' ');

            printButton_Click(sender, e);
        }

        // Обработчик нажатия кнопки "Печать"
        private void printButton_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.DefaultPageSettings.Landscape = true;
                printDocument.DefaultPageSettings.Margins = new Margins(50, 50, 38, 50);
                printDocument.Print();
                Close();
            }   
        }

        // Начало печати
        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter = 0;
        }

        // Обработчик события PrintPage - программирование печати
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Создать шрифт myFont
            Font myFont = new Font("Arial", 13, FontStyle.Regular, GraphicsUnit.Pixel);

            string curLine; // текущая выводимая строка

            // Отступы внутри страницы
            float leftMargin = e.PageBounds.Left; // отступы слева в документе
            float topMargin = e.PageBounds.Top; // отступы сверху в документе
            float yPos = 0; // текущая позиция Y для вывода строки

            int nLines; // максимально-возможное количество строк на странице
            int i; // номер текущей строки для вывода на странице

            // Вычислить максимально возможное количество строк на странице
            nLines = (int)(e.PageBounds.Height / myFont.GetHeight(e.Graphics));

            // Цикл печати/вывода одной страницы
            i = 0;
            while ((i < nLines) && (counter < pageRichTextBox.Lines.Length))
            {
                // Взять строку для вывода из richTextBox1
                curLine = pageRichTextBox.Lines[counter];

                // Вычислить текущую позицию по оси Y
                yPos = topMargin + i * myFont.GetHeight(e.Graphics);

                // Вывести строку в документ
                e.Graphics.DrawString(curLine, myFont, Brushes.Black,
                  leftMargin, yPos, new StringFormat());

                counter++;
                i++;
            }
        }

        // Метод получения типа топлива для отображения
        private string GetStringFuelType(int typeIndex)
        {
            string result = "";
            switch (typeIndex)
            {
                case 1:
                    result = "Дизель";
                    break;
                case 2:
                    result = "Н80";
                    break;
                case 3:
                    result = "А92";
                    break;
                case 4:
                    result = "А95";
                    break;
                case 5:
                    result = "А98";
                    break;
                case 6:
                    result = "КПГ";
                    break;
                case 7:
                    result = "СУГ";
                    break;
                case 8:
                    result = "Керосин";
                    break;
                case 9:
                    result = "Биодизель";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
