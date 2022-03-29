using System;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна добавления и редактирования данных о маршруте
    public partial class AddEditItineraryForm : Form
    {
        // переменные класса
        private int itineraryId;
        public string itineraryName;
        public float distance, city100, city300, city1000, track, 
            field, medl, ostanov;

        public AddEditItineraryForm(int iId)
        {
            InitializeComponent();
            itineraryId = iId;
        }

        // Обработчик загрузки формы
        private void AddEditItineraryForm_Load(object sender, EventArgs e)
        {
            // если открыта форма для редактирования данных маршрута
            if (itineraryId > 0)
            {
                // создание экземпляра класса ItineraryClass
                ItineraryClass editItinerary = new ItineraryClass();
                // получение маршрута из БД по его Id
                editItinerary.GetItineraryById(itineraryId);
                // заполнение полей формы для редактирования данных маршрута
                nameBox.Text = editItinerary.ItineraryName;
                distanceBox.Text = CorrectDisplayData(editItinerary.Distance);
                city100Box.Text = CorrectDisplayData(editItinerary.City100);
                city300Box.Text = CorrectDisplayData(editItinerary.City300);
                city1000Box.Text = CorrectDisplayData(editItinerary.City1000);
                trackBox.Text = CorrectDisplayData(editItinerary.Track);
                fieldBox.Text = CorrectDisplayData(editItinerary.Field);
                medlBox.Text = CorrectDisplayData(editItinerary.Medl);
                ostanovBox.Text = CorrectDisplayData(editItinerary.Ostanov);
            }
        }

        // Обработчик нажатия кнопки Ок
        private void button1_Click(object sender, EventArgs e)
        {
            // проверка заполненности всех полей формы
            // если не введено название маршрута
            if (nameBox.TextLength == 0)
            {
                MessageBox.Show("Введите название маршрута!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
            // присвоение переменным класса соответствующих значений
            SetValue();
            // закрытие формы
            Close();
        }

        // Функция присвоения переменным класса соответствующих значений
        private void SetValue()
        {
            itineraryName = nameBox.Text;
            city100 = CheckFloatZero(city100Box);
            city300 = CheckFloatZero(city300Box);
            city1000 = CheckFloatZero(city1000Box);
            track = CheckFloatZero(trackBox);
            field = CheckFloatZero(fieldBox);
            medl = CheckFloatZero(medlBox);
            ostanov = CheckFloatZero(ostanovBox);
        }

        // Метод корректного отображения расстояний в форме
        private string CorrectDisplayData(float dist)
        {
            string result = dist > 0 ? Convert.ToString(dist) : "";
            return result;
        }

        // Метод проверки на 0 в float
        private float CheckFloatZero(TextBox box)
        {
            float result = 0;
            if (box.TextLength > 0)
                result = Convert.ToSingle(box.Text);
            return result;
        }

        // Обработчики ввода символов в соответствующих полях формы
        // Метод, позволяющий вводить в соответствующих полях только цифры и знак ","
        private void floatBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            // допуск ввода только цифр, знака "," и клавиши BackSpace
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        // Метод автоматического подсчета дистанции маршрута
        private void countBox_TextChanged(object sender, EventArgs e)
        {
            // присвоение переменным класса соответствующих значений
            SetValue();
            distance = city100 + city300 + city1000 + track + field;
            distanceBox.Text = Convert.ToString(distance);
        }
    }
}
