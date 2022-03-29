using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна справочника автомобильных шин
    public partial class TireForm : Form
    {
        public TireForm()
        {
            InitializeComponent();
            ReadTires();
        }

        // Считывание данных из таблицы Tire
        private void ReadTires()
        {
            // создание коллекции объектов
            ArrayList tireList = new ArrayList();
            TireClass tire = new TireClass();
            tireList.AddRange(tire.ReadTireData());
            // заполнение таблицы данными из базы данных
            PrintTires(listViewTire, tireList);
        }

#region ListViews
        // Процедура вывода информации об автошинах в listView
        private void PrintTires(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка автошин
            ListViewItem lvi;
            foreach (object item in list)
            {
                // создание экземпляра класса TireClass
                TireClass tire = new TireClass();
                // создание экземпляра класса VehicleClass
                VehicleClass vehicle = new VehicleClass();
                tire = (TireClass)item;
                lvi = new ListViewItem(Convert.ToString(tire.TireId));
                lvi.SubItems.Add(tire.SerialNumber);
                lvi.SubItems.Add(tire.Size);
                lvi.SubItems.Add(tire.Model);
                // вставка данных об автомобиле
                // если автошина установлена на автомобиле
                if (tire.VehicleId != null)
                {
                    vehicle.GetVehicleById((int)tire.VehicleId);
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
                if (tire.InstallationDate == tire.RemoveDate)
                    lvi.SubItems.Add(""); // отобразить пустую строку
                else
                {
                    string tmpStr = Convert.ToString(tire.InstallationDate);
                    lvi.SubItems.Add(_cutSubstringFromString(ref tmpStr, " ", 0));
                    // вычисление текущей наработки в месяцах
                    TimeSpan month = DateTime.Today - tire.InstallationDate;
                    int currentYears = month.Days / 366;
                    if (currentYears != tire.CurrentYears)
                    {
                        tire.CurrentYears = currentYears;
                        tire.EditDataInTireTable(tire);
                    }
                }
                // наработка и пробег
                lvi.SubItems.Add(Convert.ToString(tire.CurrentYears));
                lvi.SubItems.Add(Convert.ToString(tire.CurrentRun));
                // вычисление наработки в процентах
                int timeNorm = CalculatOpTimePercent(tire.WorkNorma, tire.CurrentYears, tire.RunNorma, tire.CurrentRun);
                // уровень
                string aValue = "";
                int maxCount = (listV.Columns[9].Width - 12) / 2;
                int count = timeNorm <= 100 ? maxCount * timeNorm / 100 : maxCount;
                lvi.SubItems.Add(aValue.PadRight(count, '|'));
                // проценты
                lvi.SubItems.Add(Convert.ToString(timeNorm));
                listV.Items.Add(lvi);
                // изменение цвета уровня аккумулятора
                Color textColor = listV.ForeColor;
                lvi.UseItemStyleForSubItems = false;
                for (int i = 1; i < lvi.SubItems.Count; i++)
                    lvi.SubItems[i].ForeColor = i == 9 ? Color.Green : textColor;
                // выделение аккумуляторов со 100% и более наработкой
                if (timeNorm >= 100)
                {
                    for (int i = 0; i < lvi.SubItems.Count; i++)
                        lvi.SubItems[i].BackColor = Color.Crimson;
                }
            }
        }

        // Обработчик процедуры выбора элементов в списке автомобильных шин
        private void listViewTire_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewTire.SelectedItems.Count > 0)
                SwitchingVisibility(true);
            else
                SwitchingVisibility(false);
        }
#endregion

#region Buttons
        // Обработчик кнопки "Добавить"
        private void addButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления автомобильной шины
            AddEditTireForm aeForm = new AddEditTireForm(0);
            aeForm.ShowDialog();
            if (aeForm.DialogResult == DialogResult.OK)
            {
                // добавление автомобильной шины в БД
                TireClass newTire = new TireClass(0, aeForm.vehicleId, aeForm.serialNumber,
                    aeForm.size, aeForm.model, aeForm.weight, aeForm.coast, aeForm.madename, 
                    aeForm.position, aeForm.sparewheel, aeForm.iDate, aeForm.rDate, aeForm.runNorma, 
                    aeForm.workNorma, aeForm.currentRun, aeForm.currentYears, aeForm.status);
                newTire.AddDataInTireTable(newTire);
                // обновление данных в таблице автошин
                ReadTires();
            }
        }

        // Обработчик кнопки "Дублировать"
        private void dublicateButton_Click(object sender, EventArgs e)
        {
            if (listViewTire.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id дублируемой автомобильной шины
                int editId = Convert.ToInt32(listViewTire.SelectedItems[0].Text);
                // открытие формы дублирования автомобильной шины
                AddEditTireForm aeForm = new AddEditTireForm(editId);
                aeForm.ShowDialog();
                if (aeForm.DialogResult == DialogResult.OK)
                {
                    // создание экземпляра класса BatteryClass
                    TireClass dublicateTire = new TireClass(0, aeForm.vehicleId, aeForm.serialNumber,
                    aeForm.size, aeForm.model, aeForm.weight, aeForm.coast, aeForm.madename,
                    aeForm.position, aeForm.sparewheel, aeForm.iDate, aeForm.rDate, aeForm.runNorma,
                    aeForm.workNorma, aeForm.currentRun, aeForm.currentYears, aeForm.status);
                    // добавление автомобильной шины в БД
                    dublicateTire.AddDataInTireTable(dublicateTire);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadTires();
                }
            }
        }

        // Обработчик кнопки "Редактировать"
        private void editButton_Click(object sender, EventArgs e)
        {
            if (listViewTire.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id редактируемой автомобильной шины
                int editId = Convert.ToInt32(listViewTire.SelectedItems[0].Text);
                // открытие формы редактирования автомобильной шины
                AddEditTireForm aeForm = new AddEditTireForm(editId);
                aeForm.ShowDialog();
                if (aeForm.DialogResult == DialogResult.OK)
                {
                    // создание экземпляра класса BatteryClass
                    TireClass editTire = new TireClass(editId, aeForm.vehicleId, aeForm.serialNumber,
                    aeForm.size, aeForm.model, aeForm.weight, aeForm.coast, aeForm.madename,
                    aeForm.position, aeForm.sparewheel, aeForm.iDate, aeForm.rDate, aeForm.runNorma, 
                    aeForm.workNorma, aeForm.currentRun, aeForm.currentYears, aeForm.status);
                    // обновление данных в таблице BatteryClass БД
                    editTire.EditDataInTireTable(editTire);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadTires();
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

        private void listViewTire_DoubleClick(object sender, EventArgs e)
        {
            editButton_Click(sender, e);
        }

        // Обработчик кнопки "Удалить"
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listViewTire.SelectedItems.Count == 0)
                return;
            else
            {
                // запрос на подтверждение удаления
                DialogResult confirmationResult = MessageBox.Show(
                        "Вы уверены, что хотите удалить выбранную автошину из системы?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                if (confirmationResult == DialogResult.Yes)
                {
                    TireClass delTire = new TireClass();
                    delTire.DelDataFromTireTable(Convert.ToInt32(listViewTire.SelectedItems[0].Text));
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadTires();
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

        // Метод вычисления наработки в процентах
        private int CalculatOpTimePercent(int nYears, int cYears, int nKm, int cKm)
        {
            int tmpResult1 = 0, tmpResult2 = 0;
            // вычисление процента наработки в месяцах
            if (nYears != 0)
                tmpResult1 = (cYears * 100) / nYears;
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
