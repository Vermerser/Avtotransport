using System;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна поиска путевых листов
    public partial class SearchOrderForm : Form
    {
        // поисковое значение
        public int orderId;
        public SearchOrderForm()
        {
            InitializeComponent();
        }

        // Метод, позволяющий вводить в поле для номера только целые числа
        private void searchNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            // допуск ввода только цифр и клавиши BackSpace
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        // Обработчик нажатия кнопки "Поиск"
        private void searchButton_Click(object sender, EventArgs e)
        {
            // проверка заполненности всех полей формы
            // если не введен номер путевого листа
            if (searchNumberBox.TextLength == 0)
            {
                MessageBox.Show("Введите номер путевого листа!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // поиск путевого листа по введенным параметрам
            TravelOrderClass searchOrder = new TravelOrderClass();
            searchOrder.GetTravelOrderByNumber(Convert.ToInt32(searchNumberBox.Text));
            // если поиск дал положительный результат
            if (searchOrder.OrderId != 0)
            {
                DialogResult = DialogResult.OK;
                orderId = searchOrder.OrderId;
                // закрытие формы
                Close();
            }
            else
            {
                MessageBox.Show("Поиск результатов не дал!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
