using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна справочника автомобилей
    public partial class VehicleForm : Form
    {
        // переменная прав пользователя Механик
        private bool mechanicRight, adminRight;
         
        public VehicleForm(bool mRight, bool admin)
        {
            InitializeComponent();
            ReadVehicles();
            mechanicRight = mRight;
            adminRight = admin;
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

#region ListViews
        // Процедура вывода информации об автомобилях в listView
        private void PrintVehicles(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка автомобилей
            ListViewItem lvi;
            foreach (object item in list)
            {
                // создание экземпляра класса VehicleClass
                VehicleClass vehicle = new VehicleClass();
                vehicle = (VehicleClass)item;
                lvi = new ListViewItem(Convert.ToString(vehicle.VehicleId));
                lvi.SubItems.Add(vehicle.Model);
                lvi.SubItems.Add(vehicle.RegNumber);
                // данные о водителе
                // если водитель закреплен за автомобилем
                if (vehicle.DriverId != null)
                {
                    DriverClass driver = new DriverClass();
                    driver.GetDriverById((int)vehicle.DriverId);
                    lvi.SubItems.Add(driver.DriverName);
                }
                // иначе
                else
                    lvi.SubItems.Add("Без водителя");
                lvi.SubItems.Add(vehicle.GetVehicleType(vehicle.Type));
                lvi.SubItems.Add(vehicle.GetVehicleBodyType(vehicle.BodyType));
                lvi.SubItems.Add(vehicle.GetVehicleMotorType(vehicle.MotorType));
                lvi.SubItems.Add(Convert.ToString(vehicle.MotorSize));
                lvi.SubItems.Add(Convert.ToString(vehicle.ReleaseDate));
                // прицеп
                string trailer = vehicle.Trailer ? "есть" : "нет";
                lvi.SubItems.Add(trailer);
                listV.Items.Add(lvi);
                // выделение автомобиля
                ServiceMileageClass service = new ServiceMileageClass();
                service.GetServicemileageById(vehicle.VehicleId);
                // с необходимостью прохождения ТО за 100 км до очередного ТО1
                if (service.SpeedometerTo1 != 0 && (service.SpeedometerTo1 - service.Speedometer <= 100 ||
                    service.SpeedometerTo1 - service.Speedometer < 0))
                    lvi.BackColor = Color.IndianRed;
                // с необходимостью прохождения ТО за 100 км до очередного ТО2
                else if (service.SpeedometerTo2 != 0 && (service.SpeedometerTo2 - service.Speedometer <= 100 ||
                    service.SpeedometerTo2 - service.Speedometer < 0))
                    lvi.BackColor = Color.Red;
                //// за 100 км до конца ежемесячного лимитированного пробега
                //else if (service.Speedometer - service.SpeedometerLimit <= 100 ||
                //    service.Speedometer - service.SpeedometerLimit < 0)
                //    lvi.BackColor = Color.DarkRed;
                // за 100 км до конца по контрольному спидометру
                else if (service.SpeedometerControl != 0 && service.SpeedometerControl - service.Speedometer <= 100)
                    lvi.BackColor = Color.DarkOrange;
                // при срабатывании даты контроля
                else if ((service.ControlDate1 != DateTime.MinValue && service.ControlDate1 <= DateTime.Today) ||
                    (service.ControlDate2 != DateTime.MinValue && service.ControlDate2 <= DateTime.Today))
                    lvi.BackColor = Color.LawnGreen;
            }
        }

        // Обработчик процедуры выбора элементов в списке автомобилей
        private void listViewBattery_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewVehicle.SelectedItems.Count > 0)
                SwitchingVisibility(true);
            else
                SwitchingVisibility(false);
        }
#endregion

#region Buttons
        // Обработчик кнопки "Добавить"
        private void addButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления автомобиля
            AddEditVehicleForm aeForm = new AddEditVehicleForm(0, mechanicRight, adminRight);
            aeForm.ShowDialog();
            if (aeForm.DialogResult == DialogResult.OK)
            {
                // добавление автомобиля в БД
                VehicleClass newVihacle = new VehicleClass(0, aeForm.driverId, aeForm.model,
                    aeForm.type, aeForm.bodyType, aeForm.motorType, aeForm.motorSize,
                    aeForm.regNumber, aeForm.releaseDate, aeForm.trailer,
                    aeForm.usage, aeForm.bodySize, aeForm.tonnage, aeForm.wheel,
                    aeForm.spareWheel, aeForm.passengers, aeForm.tonnageCoefficient, 
                    aeForm.fuelType, aeForm.fuelTank, aeForm.fuelBalance);
                newVihacle.AddDataInVehicleTable(newVihacle);
                // получение Id добавленного автомобиля по его госномеру
                newVihacle.GetVehicleByRegnumber(aeForm.regNumber);
                // добавление норм, ТО и пробегов добавленного автомобиля
                NormaClass newNorma = new NormaClass(0, newVihacle.VehicleId, aeForm.fuel, aeForm.normaTrailer, 
                    aeForm.norma100, aeForm.norma100trailer, aeForm.trip, aeForm.mehanism, aeForm.oil, aeForm.gorod100, 
                    aeForm.gorod300, aeForm.gorod1000, aeForm.ostan, aeForm.medl, aeForm.bezdor, aeForm.track, 
                    aeForm.boost1, aeForm.boost2, aeForm.boost3, aeForm.cond, aeForm.otopitel, aeForm.generator);
                ServiceMileageClass newService = new ServiceMileageClass(0, newVihacle.VehicleId, aeForm.speedometer, 
                    aeForm.counter, aeForm.speedometerTo1, aeForm.speedometerTo2, aeForm.intervalTo1, aeForm.intervalTo2, 
                    aeForm.counterTo1, aeForm.counterTo2, aeForm.counterTo3, aeForm.counterIntervalTo1, 
                    aeForm.counterIntervalTo2, aeForm.counterIntervalTo3, aeForm.speedometerLimit, aeForm.runLimit, 
                    aeForm.speedometerControl, aeForm.controlDate1, aeForm.controlDate2, aeForm.avtoState);
                newNorma.AddDataInNormaTable(newNorma);
                newService.AddDataInServicemileageTable(newService);
                // обновление данных в таблице автомобилей
                ReadVehicles();
            }
        }

        // Обработчик кнопки "Редактировать"
        private void editButton_Click(object sender, EventArgs e)
        {
            if (listViewVehicle.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id редактируемого автомобиля
                int editId = Convert.ToInt32(listViewVehicle.SelectedItems[0].Text);
                // открытие формы редактирования автомобиля
                AddEditVehicleForm aeForm = new AddEditVehicleForm(editId, mechanicRight, adminRight);
                aeForm.ShowDialog();
                if (aeForm.DialogResult == DialogResult.OK)
                {
                    // создание экземпляров классов VehicleClass, NormaClass и ServiceMileageClass
                    VehicleClass editVehicle = new VehicleClass(editId, aeForm.driverId, aeForm.model, 
                        aeForm.type, aeForm.bodyType, aeForm.motorType, aeForm.motorSize, aeForm.regNumber, 
                        aeForm.releaseDate, aeForm.trailer, aeForm.usage, aeForm.bodySize, aeForm.tonnage, 
                        aeForm.wheel, aeForm.spareWheel, aeForm.passengers, aeForm.tonnageCoefficient, 
                        aeForm.fuelType, aeForm.fuelTank, aeForm.fuelBalance);
                    NormaClass editNorma = new NormaClass(aeForm.normaId, editId, aeForm.fuel, aeForm.normaTrailer, 
                        aeForm.norma100, aeForm.norma100trailer, aeForm.trip, aeForm.mehanism, aeForm.oil, aeForm.gorod100,
                        aeForm.gorod300, aeForm.gorod1000, aeForm.ostan, aeForm.medl, aeForm.bezdor, aeForm.track,
                        aeForm.boost1, aeForm.boost2, aeForm.boost3, aeForm.cond, aeForm.otopitel, aeForm.generator);
                    ServiceMileageClass editService = new ServiceMileageClass(aeForm.serviceId, editId, aeForm.speedometer,
                        aeForm.counter, aeForm.speedometerTo1, aeForm.speedometerTo2, aeForm.intervalTo1, aeForm.intervalTo2,
                        aeForm.counterTo1, aeForm.counterTo2, aeForm.counterTo3, aeForm.counterIntervalTo1,
                        aeForm.counterIntervalTo2, aeForm.counterIntervalTo3, aeForm.speedometerLimit, aeForm.runLimit,
                        aeForm.speedometerControl, aeForm.controlDate1, aeForm.controlDate2, aeForm.avtoState);
                    // обновление данных в таблицах Vehicle, Norma и ServiceMileage БД
                    editVehicle.EditDataInVehicleTable(editVehicle);
                    editNorma.EditDataInNormaTable(editNorma);
                    editService.EditDataInServicemileageTable(editService);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadVehicles();
                }
            }
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
            if (listViewVehicle.SelectedItems.Count == 0)
                return;
            else
            {
                // запрос на подтверждение удаления
                DialogResult confirmationResult = MessageBox.Show(
                        "Вы уверены, что хотите удалить выбранный автомобиль из системы?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                if (confirmationResult == DialogResult.Yes)
                {
                    VehicleClass delVehicle = new VehicleClass();
                    delVehicle.DelDataFromVehicleTable(Convert.ToInt32(listViewVehicle.SelectedItems[0].Text));
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadVehicles();
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
