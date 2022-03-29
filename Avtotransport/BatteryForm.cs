using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна справочника аккумуляторов
    public partial class BatteryForm : Form
    {
        public BatteryForm()
        {
            InitializeComponent();
            ReadBatteris();
        }

        // Считывание данных из таблицы Battery
        private void ReadBatteris()
        {
            // создание коллекции объектов
            ArrayList batteryList = new ArrayList();
            BatteryClass battery = new BatteryClass();
            batteryList.AddRange(battery.ReadBatteryData());
            // заполнение таблицы данными из базы данных
            PrintBatteris(listViewBattery, batteryList);
        }

#region ListViews
        // Процедура вывода информации об аккумуляторах в listView
        private void PrintBatteris(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка аккумуляторов
            ListViewItem lvi;
            foreach (object item in list)
            {
                // создание экземпляра класса BatteryClass
                BatteryClass battery = new BatteryClass();
                // создание экземпляра класса VehicleClass
                VehicleClass vehicle = new VehicleClass();
                battery = (BatteryClass)item;
                lvi = new ListViewItem(Convert.ToString(battery.BatteryId));
                lvi.SubItems.Add(battery.BatteryType);
                // вставка данных об автомобиле
                // если аккумулятор установлен на автомобиле
                if (battery.VehicleId != null)
                {
                    vehicle.GetVehicleById((int)battery.VehicleId);
                    lvi.SubItems.Add(vehicle.Model);
                    lvi.SubItems.Add(vehicle.RegNumber);
                }
                // иначе
                else
                {
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("");
                }
                // дата установки
                // если дата установки равна дате снятия
                if (battery.BatteryInstallationdate == battery.BatteryRemovedate)
                    lvi.SubItems.Add(""); // отобразить пустую строку
                else
                {
                    string tmpStr = Convert.ToString(battery.BatteryInstallationdate);
                    lvi.SubItems.Add(_cutSubstringFromString(ref tmpStr, " ", 0));
                    // вычисление текущей наработки в месяцах
                    TimeSpan month = DateTime.Today - battery.BatteryInstallationdate;
                    int currentMonth = month.Days / 30;
                    if (currentMonth != battery.BatteryCurrentmonth)
                    {
                        battery.BatteryCurrentmonth = currentMonth;
                        battery.EditDataInBatteryTable(battery);
                    }
                }
                // наработка
                lvi.SubItems.Add(CalculatOpTime(battery.BatteryCurrentmonth + battery.BatteryBeforeinstMonth));
                // если наработка в км есть
                if (battery.BatteryCurrentrun > 0 || battery.BatteryBeforeinstKm > 0)
                    lvi.SubItems.Add(Convert.ToString(battery.BatteryCurrentrun + 
                        battery.BatteryBeforeinstKm));
                // в противном случае
                else
                    lvi.SubItems.Add("");
                // вычисление наработки в процентах
                int timeNorm = battery.BatteryTimenormYears*12 + battery.BatteryTimenormMonth;
                timeNorm = CalculatOpTimePercent(timeNorm, (battery.BatteryBeforeinstMonth + 
                    battery.BatteryCurrentmonth), battery.BatteryRunnorm, (battery.BatteryBeforeinstKm + 
                    battery.BatteryCurrentrun));
                // уровень
                string aValue = "";
                int maxCount = (listV.Columns[7].Width - 12)/2;
                int count = timeNorm <= 100 ? maxCount * timeNorm / 100 : maxCount;
                lvi.SubItems.Add(aValue.PadRight(count, '|'));
                // проценты
                lvi.SubItems.Add(Convert.ToString(timeNorm));
                listV.Items.Add(lvi);
                // изменение цвета уровня аккумулятора
                Color textColor = listV.ForeColor;
                lvi.UseItemStyleForSubItems = false;
                for (int i = 1; i < lvi.SubItems.Count; i++)
                    lvi.SubItems[i].ForeColor = i == 7 ? Color.Green : textColor;
                // выделение аккумуляторов со 100% и более наработкой
                if (timeNorm >= 100)
                {
                    for (int i = 0; i < lvi.SubItems.Count; i++)
                        lvi.SubItems[i].BackColor = Color.Crimson;
                }
            }
        }

        // Обработчик процедуры выбора элементов в списке аккумуляторов
        private void listViewBattery_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewBattery.SelectedItems.Count > 0)
                SwitchingVisibility(true);
            else
                SwitchingVisibility(false);
        }
#endregion

#region Buttons
        // Обработчик кнопки "Добавить"
        private void addButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления аккумулятора
            AddEditBatteryForm aeForm = new AddEditBatteryForm(0);
            aeForm.ShowDialog();
            if (aeForm.DialogResult == DialogResult.OK)
            {
                // добавление аккумулятора в БД
                BatteryClass newBattery = new BatteryClass(0, aeForm.vehicleId, aeForm.type,
                    aeForm.madename, aeForm.bDate, aeForm.coast, aeForm.beforeInstKm,
                    aeForm.beforeInstMont, aeForm.timenormYears, aeForm.timenormMonth,
                    aeForm.runNorm, aeForm.iDate, aeForm.rDate, aeForm.currentRun,
                    aeForm.currentMonth, aeForm.status);
                newBattery.AddDataInBatteryTable(newBattery);
                // обновление данных в таблице аккумуляторов
                ReadBatteris();
            }
        }

        // Обработчик кнопки "Дублировать"
        private void dublicateButton_Click(object sender, EventArgs e)
        {
            if (listViewBattery.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id аккумулятора для дублирования
                int editId = Convert.ToInt32(listViewBattery.SelectedItems[0].Text);
                // открытие формы дублирования аккумулятора
                AddEditBatteryForm aeForm = new AddEditBatteryForm(editId);
                aeForm.ShowDialog();
                if (aeForm.DialogResult == DialogResult.OK)
                {
                    // создание экземпляра класса Battery
                    BatteryClass dublicateBattery = new BatteryClass(0, aeForm.vehicleId, aeForm.type, aeForm.madename,
                        aeForm.bDate, aeForm.coast, aeForm.beforeInstKm, aeForm.beforeInstMont, aeForm.timenormYears,
                        aeForm.timenormMonth, aeForm.runNorm, aeForm.iDate, aeForm.rDate, aeForm.currentRun,
                        aeForm.currentMonth, aeForm.status);
                    // добавление аккумулятора в БД
                    dublicateBattery.AddDataInBatteryTable(dublicateBattery);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadBatteris();
                }
            }
        }

        // Обработчик кнопки "Редактировать"
        private void editButton_Click(object sender, EventArgs e)
        {
            if (listViewBattery.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id редактируемого аккумулятора
                int editId = Convert.ToInt32(listViewBattery.SelectedItems[0].Text);
                // открытие формы редактирования аккумулятора
                AddEditBatteryForm aeForm = new AddEditBatteryForm(editId);
                aeForm.ShowDialog();
                if (aeForm.DialogResult == DialogResult.OK)
                {
                    // создание экземпляра класса Battery
                    BatteryClass editBattery = new BatteryClass(editId, aeForm.vehicleId, aeForm.type, aeForm.madename, 
                        aeForm.bDate, aeForm.coast, aeForm.beforeInstKm, aeForm.beforeInstMont, aeForm.timenormYears, 
                        aeForm.timenormMonth, aeForm.runNorm, aeForm.iDate, aeForm.rDate, aeForm.currentRun, 
                        aeForm.currentMonth, aeForm.status);
                    // обновление данных в таблице Battery БД
                    editBattery.EditDataInBatteryTable(editBattery);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadBatteris();
                }
            }
        }

        // Обработчик кнопки "Дублировать" в контекстном меню
        private void dublicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dublicateButton_Click(sender, e);
        }

        // Обработчик кнопки "Редактировать" в контекстном меню
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editButton_Click(sender, e);
        }

        private void listViewBattery_DoubleClick(object sender, EventArgs e)
        {
            editButton_Click(sender, e);
        }

        // Обработчик кнопки "Удалить"
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listViewBattery.SelectedItems.Count == 0)
                return;
            else
            {
                // запрос на подтверждение удаления
                DialogResult confirmationResult = MessageBox.Show(
                        "Вы уверены, что хотите удалить выбранный аккумулятор из системы?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                if (confirmationResult == DialogResult.Yes)
                {
                    BatteryClass delBattery = new BatteryClass();
                    delBattery.DelDataFromBatteryTable(Convert.ToInt32(listViewBattery.SelectedItems[0].Text));
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadBatteris();
                }
            }
        }

        // Обработчик кнопки "Удалить" в контекстном меню
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteButton_Click(sender, e);
        }


        // Обработчик нажатия клавиши Delete на выбраном аккумуляторе
        private void listViewBattery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deleteButton_Click(sender, e);
        }
#endregion

        // Метод вычисления наработки аккумуляора в годах и месяцах
        private string CalculatOpTime(int uMonth)
        {
            string result = "";  // результат работы функции
            int years, month;
            if (uMonth != 0)
            {
                years = uMonth/12; // количество полных лет
                month = uMonth%12; // количество месяцев
                // вывод количества лет
                if (years%20 == 1) // если результат равен 1 году
                    result = Convert.ToString(years) + " год";
                else if (years%20 > 1 && years % 20 < 5)    // если результат от 2 до 4 лет
                    result = Convert.ToString(years) + " года";
                else if (years % 20 >= 5)    // если результат больше 5 лет
                    result = Convert.ToString(years) + " лет";
                if (years > 0)
                    result += " ";
                // вывод количества месяцев
                if (month == 1)
                    result += Convert.ToString(month) + " месяц";
                else if (month > 1 && month < 5)
                    result += Convert.ToString(month) + " месяца";
                else if (month >= 5)
                    result += Convert.ToString(month) + " месяцев";
            }
            return result;
        }

        // Метод вычисления наработки в процентах
        private int CalculatOpTimePercent(int nMonth, int cMonth, int nKm, int cKm)
        {
            int tmpResult1 = 0, tmpResult2 = 0;
            // вычисление процента наработки в месяцах
            if (nMonth != 0)
                tmpResult1 = (cMonth * 100) / nMonth;
            // вычисление процента наработки в км
            if (nKm != 0)
                tmpResult2 = (cKm * 100) / nKm;
            // сравнение результатов и вывод наибольшего процента наработки
            if (tmpResult1 > tmpResult2)
                return tmpResult1;
            else if (tmpResult1 < tmpResult2)
                return tmpResult2;
            else
                return 0;
        }

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
            dublicateButton.Enabled = flag;
            editButton.Enabled = flag;
            deleteButton.Enabled = flag;
            dublicateToolStripMenuItem.Enabled = flag;
            editToolStripMenuItem.Enabled = flag;
            deleteToolStripMenuItem.Enabled = flag;
        }
    }
}
