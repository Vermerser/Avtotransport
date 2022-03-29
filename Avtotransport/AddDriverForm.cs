using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна добавления водителя при закреплении автомобиля и при выписке путевого листа
    public partial class AddDriverForm : Form
    {
        // переменные класса
        public int driverId;
        public string driverName, driverCertificate;

        public AddDriverForm(int Id)
        {
            InitializeComponent();
            driverId = Id;
        }

        // Обработчик загрузки формы
        private void AddDriverForm_Load(object sender, EventArgs e)
        {
            ReadDrivers();
        }

        // Считывание данных из таблицы Driver
        private void ReadDrivers()
        {
            // создание коллекции объектов
            ArrayList driverList = new ArrayList();
            DriverClass driver = new DriverClass();
            driverList.AddRange(driver.ReadDriverData());
            // заполнение таблицы данными из базы данных
            PrintDrivers(listViewDriver, driverList);
        }

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
                listV.Items.Add(lvi);
                // выделение водителя с истекшим медосмотром
                if (driver.DriverMeddate < DateTime.Today)
                    lvi.BackColor = Color.Tomato;
                // выделение ранее выбранного водителя
                if (driver.DriverId == driverId)
                    lvi.Selected = true;
            }
        }

        // Обработчик нажатия кнопки Ок
        private void button1_Click(object sender, EventArgs e)
        {
            if (listViewDriver.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id выбранного водителя
                int selectedId = Convert.ToInt32(listViewDriver.SelectedItems[0].Text);
                // если выбран ранее выбранный водитель
                if (driverId == selectedId)
                    Close();
                // иначе присвоить переменным класса соответствующие значения
                else
                {
                    DialogResult = DialogResult.OK;
                    // присвоение переменным класса соответствующих значений
                    driverId = selectedId;
                    driverName = listViewDriver.SelectedItems[0].SubItems[1].Text;
                    driverCertificate = listViewDriver.SelectedItems[0].SubItems[2].Text;
                    // закрытие формы
                    Close();
                }
            }
        }
    }
}
