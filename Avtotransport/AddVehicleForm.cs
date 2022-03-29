using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна добавления автомобиля при закреплении аккумулятора, автомобильных шин и 
    // при выписке путевого листа
    public partial class AddVehicleForm : Form
    {
        // переменные класса
        private int[] vehicleNumbers;
        public int vehicleId;
        public string model, regnumber;
        private int wFlag;  // флаг причины открытия окна
        
        public AddVehicleForm(int vId, int oFlag)
        {
            InitializeComponent();
            vehicleId = vId;
            wFlag = oFlag;
        }

        // Обработчик загрузки формы
        private void AddVehicleForm_Load(object sender, EventArgs e)
        {
            ReadVehicles();
        }

        // Считывание данных из таблицы Vehicle
        private void ReadVehicles()
        {
            // создание коллекции объектов
            ArrayList vehicleList = new ArrayList();
            VehicleClass vehicle = new VehicleClass();
            vehicleList.AddRange(vehicle.ReadVehicleData());
            // заполнение таблицы данными из базы данных
            PrintVehicles(listViewVehicle, vehicleList);
        }

        // Процедура вывода информации об автомобилях в listView
        private void PrintVehicles(ListView listV, ArrayList list)
        {
            vehicleNumbers = new int[list.Count];
            ServiceMileageClass service = new ServiceMileageClass();
            listV.Items.Clear();    // очистка списка автомобилей
            ListViewItem lvi;
            string tmp;
            int count = 0;
            foreach (VehicleClass item in list)
            {
                // если не стоит метка, что автомобиль Не эксплуатируется
                if (!item.Usage)
                {
                    lvi = new ListViewItem(Convert.ToString(item.VehicleId));
                    tmp = item.Trailer ? "Прицеп" : item.Model;
                    lvi.SubItems.Add(tmp);
                    lvi.SubItems.Add(item.RegNumber);
                    // если форма открыта для добавления автомобиля при закреплении аккумулятора
                    if (!item.Trailer && wFlag == 0)
                        listV.Items.Add(lvi);   // прицепы не выводить
                    // если форма открыта для добавления автомобиля при закреплении автомобильных шин
                    else if (wFlag == 1)
                        listV.Items.Add(lvi);   // выводятся и автомобили и прицепы
                    // если форма открыта для добавления прицепа в путевой лист
                    else if (wFlag == 2 && item.Trailer)
                        listV.Items.Add(lvi);   // выводятся только прицепы
                    // если форма открыта для добавления автомобиля в путевой лист
                    else if (wFlag == 3 && !item.Trailer)
                        listV.Items.Add(lvi);   // выводятся только автомобили
                    // выделение автомобиля с необходимостью прохождения ТО
                    service.GetServicemileageById(item.VehicleId);
                    if ((service.SpeedometerTo1 != 0 && service.SpeedometerTo1 - service.Speedometer <= 0) ||
                        (service.SpeedometerTo2 != 0 && service.SpeedometerTo2 - service.Speedometer <= 0))
                    {
                        lvi.BackColor = Color.Red;
                        vehicleNumbers[count++] = item.VehicleId + 1;
                    }
                    // выделение ранее выбранного автомобиля
                    if (item.VehicleId == vehicleId)
                        lvi.Selected = true;
                }
            }
        }

        // Обработчик нажатия кнопки Ок
        private void button1_Click(object sender, EventArgs e)
        {
            if (listViewVehicle.SelectedItems.Count == 0)
                return;
            else
            {
                bool alert = false; // флаг получения автомобиля с непройденным ТО
                // получение Id выбранного автомобиля
                int selectedId = Convert.ToInt32(listViewVehicle.SelectedItems[0].Text);
                foreach (int item in vehicleNumbers)
                {
                    if (item == selectedId + 1)
                        alert = true;
                }
                // если выбран ранее выбранный автомобиль
                if (selectedId == vehicleId)
                    Close();
                // если выбран автомобиль с непройденным ТО
                else if (alert)
                {
                    MessageBox.Show("Использование автомобиля с непройденным ТО не возможно!", "Запрещено",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                // иначе присвоить переменным класса соответствующие значения
                else
                {
                    DialogResult = DialogResult.OK;
                    // присвоение переменным класса соответствующих значений
                    vehicleId = selectedId;
                    model = listViewVehicle.SelectedItems[0].SubItems[1].Text;
                    regnumber = listViewVehicle.SelectedItems[0].SubItems[2].Text;
                    // закрытие формы
                    Close();
                }
            }
        }
    }
}
