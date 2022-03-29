using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна справочника водителей
    public partial class DriversForm : Form
    {
        public DriversForm()
        {
            InitializeComponent();
            ReadDrivers();
        }

        // Считывание данных из таблицы Drivers
        private void ReadDrivers()
        {
            // создание коллекции объектов
            ArrayList driverList = new ArrayList();
            DriverClass driver = new DriverClass();
            driverList.AddRange(driver.ReadDriverData());
            // заполнение таблицы данными из базы данных
            PrintDrivers(listViewDrivers, driverList);
        }

#region ListViews
        // Процедура вывода информации о водителях в listView
        private void PrintDrivers(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка водителей
            ListViewItem lvi;
            foreach (object item in list)
            {
                // создание экземпляра класса DriverClass
                DriverClass driver = new DriverClass();
                driver = (DriverClass)item;
                lvi = new ListViewItem(Convert.ToString(driver.DriverId));
                lvi.SubItems.Add(driver.DriverName);
                lvi.SubItems.Add(driver.DriverCertificate);
                lvi.SubItems.Add(driver.DriverAdres);
                string tmpStr = Convert.ToString(driver.DriverMeddate);
                lvi.SubItems.Add(_cutSubstringFromString(ref tmpStr, " ", 0));
                // если дата контроля установлена
                if (driver.DriverControldate != DateTime.MinValue)
                {
                    tmpStr = Convert.ToString(driver.DriverControldate);
                    lvi.SubItems.Add(_cutSubstringFromString(ref tmpStr, " ", 0));
                }
                listV.Items.Add(lvi);
                // выделение водителей с просроченной медицинской справкой
                if (driver.DriverMeddate < DateTime.Today)
                {
                    lvi.BackColor = Color.Tomato;
                    lvi.UseItemStyleForSubItems = false;
                    for (int i = 1; i < lvi.SubItems.Count; i++)
                        lvi.SubItems[i].BackColor = i == 4 ? Color.Crimson : Color.Tomato;
                }
                // или датой контроля
                if (driver.DriverControldate < DateTime.Today && driver.DriverControldate != DateTime.MinValue)
                {
                    lvi.BackColor = Color.Tomato;
                    lvi.UseItemStyleForSubItems = false;
                    for (int i = 1; i < lvi.SubItems.Count; i++)
                        lvi.SubItems[i].BackColor = i == 5 ? Color.Crimson : Color.Tomato;
                }
                // выделение водителей с просроченной медицинской справкой и датой контроля
                if (driver.DriverMeddate < DateTime.Today && driver.DriverControldate < DateTime.Today 
                    && driver.DriverControldate != DateTime.MinValue)
                {
                    lvi.BackColor = Color.Tomato;
                    lvi.UseItemStyleForSubItems = false;
                    for (int i = 1; i < lvi.SubItems.Count; i++)
                    {
                        if (i == 4 || i == 5)
                            lvi.SubItems[i].BackColor = Color.Crimson;
                        else
                            lvi.SubItems[i].BackColor = Color.Tomato;
                    }
                }
            }
        }

        // обработчик процедуры выбора элементов в списке водителей
        private void listViewDrivers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewDrivers.SelectedItems.Count > 0)
                SwitchingVisibility(true);
            else
                SwitchingVisibility(false);
        }

#endregion
#region Buttons
        // Обработчик кнопки "Добавить" водителя
        private void addButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления водителя
            AddEditDriverForm aeForm = new AddEditDriverForm(0);
            aeForm.ShowDialog();
            if (aeForm.DialogResult == DialogResult.OK)
            {
                // добавление водителя в БД
                DriverClass newDriver = new DriverClass(0, aeForm.name, aeForm.certificate,
                    aeForm.adres, aeForm.meddate, aeForm.controldate);
                newDriver.AddDataInDriverTable(newDriver);
                // обновление данных в таблице водителей
                ReadDrivers();
            }
        }

        // Обработчик кнопки "Редактировать" водителя
        private void editButton_Click(object sender, EventArgs e)
        {
            if (listViewDrivers.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id редактируемого водителя
                int editId = Convert.ToInt32(listViewDrivers.SelectedItems[0].Text);
                // открытие формы редактирования водителя
                AddEditDriverForm aeForm = new AddEditDriverForm(editId);
                aeForm.ShowDialog();
                if (aeForm.DialogResult == DialogResult.OK)
                {
                    // создание экземпляра класса DriverClass
                    DriverClass editDriver = new DriverClass(editId, aeForm.name, aeForm.certificate,
                        aeForm.adres, aeForm.meddate, aeForm.controldate);
                    // обновление данных в таблице DriverClass БД
                    editDriver.EditDataInDriverTable(editDriver);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadDrivers();
                }
            }
        }

        // Обработчик кнопки "Редактировать" водителя в контекстном меню
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editButton_Click(sender, e);
        }

        private void listViewDrivers_DoubleClick(object sender, EventArgs e)
        {
            editButton_Click(sender, e);
        }

        // Обработчик кнопки "Удалить" водителя
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listViewDrivers.SelectedItems.Count == 0)
                return;
            else
            {
                // запрос на подтверждение удаления
                DialogResult confirmationResult = MessageBox.Show(
                        "Вы уверены, что хотите удалить водителя из системы?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                if (confirmationResult == DialogResult.Yes)
                {
                    DriverClass delDriver = new DriverClass();
                    delDriver.DelDataFromDriverTable(Convert.ToInt32(listViewDrivers.SelectedItems[0].Text));
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadDrivers();
                }
            }
        }

        // Обработчик кнопки "Удалить" водителя в контекстном меню
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteButton_Click(sender, e);
        }

        // Обработчик нажатия клавиши Delete на выбраном водителе
        private void listViewDrivers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deleteButton_Click(sender, e);
        }
        #endregion

        // Метод отсечения части строки и образование новой строки
        private string _cutSubstringFromString(ref string s, string c, int startIndex)
        {
            int pos1 = s.IndexOf(c, startIndex);
            string retString = s.Substring(0, pos1);
            s = (s.Substring(pos1 + c.Length)).Trim();
            return retString;
        }

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
