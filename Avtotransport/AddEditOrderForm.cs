using System;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна выписки путевого листа и его редактирования
    public partial class AddEditOrderForm : Form
    {
        // переменные класса
        private int orderId;
        public int itineraryId, driverId, vehicleId, trailerId, speedometerOut, motoOut;
        public float winterCoefficient, fuelBalance, fuelCharge;
        public string number, customer, transportationKind, dopInfo;
        public DateTime date, validityDate, timeOut, timeIn;

        public AddEditOrderForm(int oId)
        {
            InitializeComponent();
            orderId = oId;
        }

        // Обработчик загрузки формы
        private void AddEditOrderForm_Load(object sender, EventArgs e)
        {
            // если открыта форма для изменения путевого листа
            if (orderId > 0)
            {
                // создание экземпляра класса TravelOrderClass
                TravelOrderClass editOrder = new TravelOrderClass();
                // получение путевого листа из БД по его Id
                editOrder.GetTravelOrderById(orderId);
                // заполнение полей формы для редактирования данных
                numberBox.Text = editOrder.Number;
                // данные об автомобиле и водителе
                if (editOrder.VehicleId != null)
                {
                    vehicleId = (int) editOrder.VehicleId;
                    VehicleClass vehicle = new VehicleClass();
                    vehicle.GetVehicleById(vehicleId);
                    vehicleNameBox.Text = vehicle.Model;
                    vehicleNumberBox.Text = vehicle.RegNumber;
                    fuelTypeLabel.Text = vehicle.GetStringFuelType(vehicle.FuelType);
                }
                if (editOrder.DriverId != null)
                {
                    driverId = (int) editOrder.DriverId;
                    DriverClass driver = new DriverClass();
                    driver.GetDriverById(driverId);
                    driverNameBox.Text = driver.DriverName;
                    driverCertificateBox.Text = driver.DriverCertificate;
                }
                // данные о прицепе
                if (editOrder.TrailerId != null)
                {
                    trailerId = (int)editOrder.TrailerId;
                    VehicleClass trailer = new VehicleClass();
                    trailer.GetVehicleById(trailerId);
                    trailerNumberBox.Text = trailer.RegNumber;
                }
                fuelBalanceBox.Text = Convert.ToString(editOrder.FuelBalance);
                customerBox.Text = editOrder.Customer;
                speedometerOutBox.Text = Convert.ToString(editOrder.SpeedometerOut);
                motoOutBox.Text = Convert.ToString(editOrder.MotoOut);
                coeffBox.Text = Convert.ToString(editOrder.WinterCoefficient);
                // данные о маршруте
                if (editOrder.ItineraryId != null)
                {
                    itineraryId = (int) editOrder.ItineraryId;
                    ItineraryClass itinerary = new ItineraryClass();
                    itinerary.GetItineraryById(itineraryId);
                    itineraryBox.Text = itinerary.ItineraryName;
                    runnormBox.Text = Convert.ToString(itinerary.Distance);
                }
                fuelConsumptionBox.Text = Convert.ToString(editOrder.FuelCharge);
                coeffBox.Text = Convert.ToString(editOrder.WinterCoefficient);
                dateOutDate.Value = editOrder.Date;
                dateInDate.Value = editOrder.ValidityDate;
                timeOutPicker.Value = editOrder.TimeOut;
                timeInPicker.Value = editOrder.TimeIn;
                transportationKindComboBox.Text = editOrder.TransportationKind;
                dopInfoBox.Text = editOrder.DopInfo;
            }
            else
            {
                fuelTypeLabel.Text = "...";
                dateOutDate.Value = DateTime.Today;
                dateInDate.Value = DateTime.Today;
                timeOutPicker.Value = DateTime.Now;
                timeInPicker.Value = DateTime.Now;
            }
        }

        // Обработчик нажатия кнопки "Очистить путевой лист"
        private void clearAllButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Panel))
                    foreach (Control d in c.Controls)
                        if (d.GetType() == typeof(TextBox))
                            d.Text = string.Empty;
            }
            itineraryId = 0;
            driverId = 0;
            vehicleId = 0;
            trailerId = 0;
            dateOutDate.Value = DateTime.Today;
            dateInDate.Value = DateTime.Today;
            timeOutPicker.Value = DateTime.Now;
            timeInPicker.Value = DateTime.Now;
            transportationKindComboBox.SelectedIndex = -1;
        }

        // Обработчик изменения значения в поле "Коэффициент зимних норм"
        private void coeffBox_TextChanged(object sender, EventArgs e)
        {
            if (coeffBox.Text.Length > 0)
            {
                float coeff = Convert.ToSingle(coeffBox.Text);
                if (coeff > 1 && coeff <= 2)
                {
                    if (runnormBox.TextLength > 0)
                    {
                        float run = Convert.ToSingle(fuelConsumptionBox.Text);
                        run = run * coeff;
                        fuelConsumptionBox.Text = Convert.ToString(run);
                    }
                }
            }
        }

        // Обработчик выбора даты путевого листа (дата с)
        private void dateOutDate_ValueChanged(object sender, EventArgs e)
        {
            timeOutPicker.Value = dateOutDate.Value;
            dateInDate.Value = dateOutDate.Value;
        }

        // Обработчик выбора даты путевого листа (дата по)
        private void dateInDate_ValueChanged(object sender, EventArgs e)
        {
            timeInPicker.Value = dateInDate.Value;
        }

#region Add&DelButtons
        // Обработчик нажатия кнопки для добавления автомобиля
        private void addAvtoButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления автомобиля
            AddVehicleForm addForm = new AddVehicleForm(vehicleId, 3);
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                // отображение добавленного автомобиля
                vehicleId = addForm.vehicleId;
                vehicleNameBox.Text = addForm.model;
                vehicleNumberBox.Text = addForm.regnumber;
                VehicleClass vehicle = new VehicleClass();
                vehicle.GetVehicleById(vehicleId);
                fuelTypeLabel.Text = vehicle.GetStringFuelType(vehicle.FuelType);
                fuelBalanceBox.Text = Convert.ToString(vehicle.FuelBalance);
                ServiceMileageClass service = new ServiceMileageClass();
                service.GetServicemileageById(vehicleId);
                speedometerOutBox.Text = Convert.ToString(service.Speedometer);
                motoOutBox.Text = Convert.ToString(service.Counter);
                // при наличии водителя, за которым закреплен автомобиль
                if (vehicle.DriverId != null)
                {
                    // вывод его в соответствующем поле
                    driverId = (int)vehicle.DriverId;
                    DriverClass driver = new DriverClass();
                    driver.GetDriverById(driverId);
                    driverNameBox.Text = driver.DriverName;
                    driverCertificateBox.Text = driver.DriverCertificate;
                }
                // если в путевом листе уже есть данные о маршруте
                if (itineraryId != 0)
                {
                    CalculateAndPrintFuelConsumption();
                }
            }
        }

        // Обработчик нажатия кнопки для удаления автомобиля
        private void delAvtoButton_Click(object sender, EventArgs e)
        {
            // если данных об автомобиле нет
            if (vehicleId == 0)
                return;
            else
            {
                vehicleId = 0;
                // очистка данных об автомобиле
                vehicleNameBox.Text = null;
                vehicleNumberBox.Text = null;
                fuelTypeLabel.Text = "...";
                fuelBalanceBox.Text = null;
                speedometerOutBox.Text = null;
                motoOutBox.Text = null;
                fuelConsumptionBox.Text = null;
            }
        }

        // Обработчик нажатия кнопки для добавления прицепа
        private void addTrailerButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления автомобиля/прицепа
            AddVehicleForm addForm = new AddVehicleForm(trailerId, 2);
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                // отображение добавленного прицепа
                trailerId = addForm.vehicleId;
                trailerNumberBox.Text = addForm.regnumber;
                // если в путевом листе уже есть данные о маршруте
                if (itineraryId != 0)
                {
                    CalculateAndPrintFuelConsumption();
                }
            }
        }

        // Обработчик нажатия кнопки для удаления прицепа
        private void delTrailerButton_Click(object sender, EventArgs e)
        {
            // если данных о прицеле нет
            if (trailerId == 0)
                return;
            else
            {
                trailerId = 0;
                // очистка данных о прицепе
                trailerNumberBox.Text = null;
                // пересчет расхода топлива при наличии данных об автомобиле и маршруте
                if (vehicleId != 0 && itineraryId != 0)
                    CalculateAndPrintFuelConsumption();
            }
        }

        // Обработчик нажатия кнопки для добавления водителя
        private void addDriverButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления водителя
            AddDriverForm addForm = new AddDriverForm(driverId);
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                // отображение добавленного водителя
                driverId = addForm.driverId;
                driverNameBox.Text = addForm.driverName;
                driverCertificateBox.Text = addForm.driverCertificate;
            }
        }

        // Обработчик нажатия кнопки для удаления водителя
        private void delDriverButton_Click(object sender, EventArgs e)
        {
            // если данных о водителе нет
            if (driverId == 0)
                return;
            else
            {
                driverId = 0;
                // очистка данных о водителе
                driverNameBox.Text = null;
                driverCertificateBox.Text = null;
            }
        }

        // Обработчик нажатия кнопки для добавления маршрута
        private void addItineraryButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления маршрута
            AddItineraryForm addForm = new AddItineraryForm(itineraryId);
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                // отображение добавленного маршрута
                itineraryId = addForm.itineraryId;
                itineraryBox.Text = addForm.itineraryName;
                runnormBox.Text = Convert.ToString(addForm.distance);
                CalculateAndPrintFuelConsumption();
            }
        }

        // Обработчик нажатия кнопки для очистки данных о маршруте
        private void clearItineraryButton_Click(object sender, EventArgs e)
        {
            // если данных о маршруте нет
            if (itineraryId == 0)
                return;
            else
            {
                itineraryId = 0;
                // очистка данных о маршруте
                itineraryBox.Text = null;
                runnormBox.Text = null;
                fuelConsumptionBox.Text = null;
            }
        }
#endregion

        // Обработчик нажатия кнопки Ок
        private void button1_Click(object sender, EventArgs e)
        {
            // проверка заполненности всех полей формы
            // если не введен номер путевого листа
            if (numberBox.TextLength == 0)
            {
                MessageBox.Show("Введите номер путевого листа!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если не выбран автомобиль
            else if (vehicleId == 0)
            {
                MessageBox.Show("Выберите автомобиль для которого выписывается путевой лист!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если не выбран водитель
            else if (driverId == 0)
            {
                MessageBox.Show("Выберите водителя для добавления в путевой лист!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если не выбран маршрут
            else if (itineraryId == 0)
            {
                MessageBox.Show("Обязательно выберите маршрут! При остутствии нужного маршрута, " +
                                "добавьте его в соответствующий справочник", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
            // присвоение переменным класса соответствующих значений
            SetValue();
            // закрытие формы
            Close();
        }

#region Methods
        // Функция присвоения переменным класса соответствующих значений
        private void SetValue()
        {
            number = numberBox.Text;
            date = dateOutDate.Value;
            validityDate = dateInDate.Value;
            speedometerOut = Convert.ToInt32(speedometerOutBox.Text);
            motoOut = Convert.ToInt32(motoOutBox.Text);
            if (coeffBox.Text.Length > 0)
                winterCoefficient = Convert.ToSingle(coeffBox.Text);
            else
                winterCoefficient = 1;
            fuelBalance = Convert.ToSingle(fuelBalanceBox.Text);
            fuelCharge = Convert.ToSingle(fuelConsumptionBox.Text);
            customer = customerBox.Text;
            timeOut = timeOutPicker.Value;
            timeIn = timeInPicker.Value;
            transportationKind = transportationKindComboBox.Text;
            dopInfo = dopInfoBox.Text;
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

        // Метод, позволяющий вводить в соответствующих полях только целые числа
        private void integerBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            // допуск ввода только цифр и клавиши BackSpace
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        // Метод вычисления планируемого расхода топлива по маршруту
        private float CalculatePlanFuelConsumption(ItineraryClass itinerary, NormaClass norma)
        {
            float result = 0;
            // расчет расхода топлива по линейной норме или по норме с прицепом
            result = trailerId == 0 ? itinerary.Distance / 100 * norma.Fuel : 
                itinerary.Distance / 100 * norma.Trailer;
            // прибавление повышающих коэффициентов
            result += itinerary.City100 / 100 * norma.Fuel * (norma.Gorod100 / 100);
            result += itinerary.City300 / 100 * norma.Fuel * (norma.Gorod300 / 100);
            result += itinerary.City1000 / 100 * norma.Fuel * (norma.Gorod1000 / 100);
            result += itinerary.Field / 100 * norma.Fuel * (norma.Bezdor / 100);
            result += itinerary.Medl / 100 * norma.Fuel * (norma.Medl / 100);
            result += itinerary.Ostanov / 100 * norma.Fuel * (norma.Ostan / 100); 
            // вычитание понижающих коэффициентов
            result -= itinerary.Track / 100 * norma.Fuel * (norma.Track / 100);
            // прибавление дополнительных коэффициентов
            result = norma.Boost1 > 1 ? result * norma.Boost1 : result;
            result = norma.Boost2 > 1 ? result * norma.Boost2 : result;
            result = norma.Boost3 > 1 ? result * norma.Boost3 : result;
            // при наличии коэффициента зимних норм
            if (coeffBox.TextLength > 0)
                result = result * Convert.ToSingle(coeffBox.Text);
            return result;
        }

        // Метод расчета и вывода планируемого расхода топлива
        private void CalculateAndPrintFuelConsumption()
        {
            ItineraryClass itinerary = new ItineraryClass();
            NormaClass norma = new NormaClass();
            itinerary.GetItineraryById(itineraryId);
            norma.GetNormaById(vehicleId);
            fuelConsumptionBox.Text = Convert.ToString(Math.Round(CalculatePlanFuelConsumption(itinerary, norma), 2));
        }
#endregion
    }
}
