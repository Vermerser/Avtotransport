using System;
using System.Collections;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна добавления маршрута при выписке путевого листа
    public partial class AddItineraryForm : Form
    {
        // переменные класса
        public int itineraryId;
        public string itineraryName;
        public float distance;

        public AddItineraryForm(int iId)
        {
            InitializeComponent();
            itineraryId = iId;
        }

        // Обработчик загрузки формы
        private void AddItineraryForm_Load(object sender, EventArgs e)
        {
            ReadItineraries();
        }

        // Считывание данных из таблицы Itinerary
        private void ReadItineraries()
        {
            // создание коллекции объектов
            ArrayList itineraryList = new ArrayList();
            ItineraryClass itinerary = new ItineraryClass();
            itineraryList.AddRange(itinerary.ReadItineraryData());
            // заполнение таблицы данными из базы данных
            PrintItineraries(listViewItinerary, itineraryList);
        }

        // Процедура вывода информации о маршрутах в listView
        private void PrintItineraries(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка маршрутов
            ListViewItem lvi;
            foreach (object item in list)
            {
                // создание экземпляра класса ItineraryClass
                ItineraryClass itinerary = new ItineraryClass();
                itinerary = (ItineraryClass)item;
                lvi = new ListViewItem(Convert.ToString(itinerary.ItineraryId));
                lvi.SubItems.Add(itinerary.ItineraryName);
                lvi.SubItems.Add(Convert.ToString(itinerary.Distance));
                listV.Items.Add(lvi);
                // выделение ранее выбранного маршрута
                if (itinerary.ItineraryId == itineraryId)
                    lvi.Selected = true;
            }
        }

        // Обработчик нажатия кнопки Ок
        private void button1_Click(object sender, EventArgs e)
        {
            if (listViewItinerary.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id выбранного маршрута
                int selectedId = Convert.ToInt32(listViewItinerary.SelectedItems[0].Text);
                // если выбран ранее выбранный маршрут
                if (itineraryId == selectedId)
                    Close();
                // иначе присвоить переменным класса соответствующие значения
                else
                {
                    DialogResult = DialogResult.OK;
                    // присвоение переменным класса соответствующих значений
                    itineraryId = selectedId;
                    itineraryName = listViewItinerary.SelectedItems[0].SubItems[1].Text;
                    distance = Convert.ToInt32(listViewItinerary.SelectedItems[0].SubItems[2].Text);
                    // закрытие формы
                    Close();
                }
            }
        }

        // Обработчик нажатия кнопки Новый маршрут
        private void button3_Click(object sender, EventArgs e)
        {
            // открытие формы для добавления маршрута  в БД
            AddEditItineraryForm aeForm = new AddEditItineraryForm(0);
            aeForm.ShowDialog();
            if (aeForm.DialogResult == DialogResult.OK)
            {
                // добавление маршрута в БД
                ItineraryClass newItinerary = new ItineraryClass(0, aeForm.itineraryName, aeForm.distance,
                    aeForm.city100, aeForm.city300, aeForm.city1000, aeForm.track, aeForm.field,
                    aeForm.medl, aeForm.ostanov);
                newItinerary.AddDataInItineraryTable(newItinerary);
                // обновление данных в таблице маршрутов
                ReadItineraries();
            }
        }
    }
}
