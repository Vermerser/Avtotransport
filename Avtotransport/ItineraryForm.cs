using System;
using System.Collections;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна справочника маршрутов
    public partial class ItineraryForm : Form
    {
        public ItineraryForm()
        {
            InitializeComponent();
            ReadItinerary();
        }

        // Считывание данных из таблицы Itinerary
        private void ReadItinerary()
        {
            // создание коллекции объектов
            ArrayList itineraryList = new ArrayList();
            ItineraryClass itinerary = new ItineraryClass();
            itineraryList.AddRange(itinerary.ReadItineraryData());
            // заполнение таблицы данными из базы данных
            PrintItineraries(listViewItinerary, itineraryList);
        }

#region ListViews
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
                lvi.SubItems.Add(Convert.ToString(itinerary.Distance));
                lvi.SubItems.Add(itinerary.ItineraryName);
                lvi.SubItems.Add(Convert.ToString(itinerary.City100));
                lvi.SubItems.Add(Convert.ToString(itinerary.City300));
                lvi.SubItems.Add(Convert.ToString(itinerary.City1000));
                lvi.SubItems.Add(Convert.ToString(itinerary.Track));
                lvi.SubItems.Add(Convert.ToString(itinerary.Field));
                lvi.SubItems.Add(Convert.ToString(itinerary.Medl));
                lvi.SubItems.Add(Convert.ToString(itinerary.Ostanov));
                listV.Items.Add(lvi);
            }
            // очистка таблицы от нулей
            for (int i = 0; i < listV.Items.Count; i++)
            {
                for (int j = 2; j < 10; j++)
                {
                    if (listV.Items[i].SubItems[j].Text == "0")
                        listV.Items[i].SubItems[j].Text = "";
                }
            }
        }

        // Обработчик процедуры выбора элементов в списке маршрутов
        private void listViewItinerary_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewItinerary.SelectedItems.Count > 0)
                SwitchingVisibility(true);
            else
                SwitchingVisibility(false);
        }
#endregion

#region Buttons
        // Обработчик кнопки "Добавить"
        private void addButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления маршрута
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
                ReadItinerary();
            }
        }

        // Обработчик кнопки "Редактировать"
        private void editButton_Click(object sender, EventArgs e)
        {
            if (listViewItinerary.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id редактируемого маршрута
                int editId = Convert.ToInt32(listViewItinerary.SelectedItems[0].Text);
                // открытие формы редактирования маршрута
                AddEditItineraryForm aeForm = new AddEditItineraryForm(editId);
                aeForm.ShowDialog();
                if (aeForm.DialogResult == DialogResult.OK)
                {
                    // создание экземпляра класса ItineraryClass
                    ItineraryClass editItinerary = new ItineraryClass(editId, aeForm.itineraryName, aeForm.distance,
                    aeForm.city100, aeForm.city300, aeForm.city1000, aeForm.track, aeForm.field,
                    aeForm.medl, aeForm.ostanov);
                    // обновление данных в таблице Itinerary БД
                    editItinerary.EditDataInItineraryTable(editItinerary);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadItinerary();
                }
            }
        }

        // Обработчик кнопки "Редактировать" в контекстном меню
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editButton_Click(sender, e);
        }

        private void listViewTire_DoubleClick(object sender, EventArgs e)
        {
            editButton_Click(sender, e);
        }

        // Обработчик кнопки "Удалить"
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listViewItinerary.SelectedItems.Count == 0)
                return;
            else
            {
                // запрос на подтверждение удаления
                DialogResult confirmationResult = MessageBox.Show(
                        "Вы уверены, что хотите удалить выбранный маршрут из системы?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                if (confirmationResult == DialogResult.Yes)
                {
                    ItineraryClass delItinerary = new ItineraryClass();
                    delItinerary.DelDataFromItineraryTable(Convert.ToInt32(listViewItinerary.SelectedItems[0].Text));
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadItinerary();
                }
            }
        }

        // Обработчик кнопки "Удалить" в контекстном меню
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteButton_Click(sender, e);
        }


        // Обработчик нажатия клавиши Delete на выбраной шине
        private void listViewTire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deleteButton_Click(sender, e);
        }
#endregion

        // Функция переключения видимости кнопок
        private void SwitchingVisibility(bool flag)
        {
            editButton.Enabled = flag;
            deleteButton.Enabled = flag;
            editToolStripMenuItem.Enabled = flag;
            deleteToolStripMenuItem.Enabled = flag;
        }
    }
}
