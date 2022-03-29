using System;
using System.Drawing;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна добавления и редактирования данных об автомобиле
    public partial class AddEditVehicleForm : Form
    {
        // переменные класса
        // автомобиль
        private int vehicleId;
        private bool mechanicRight, adminRight;
        public int driverId, type, bodyType, motorType, releaseDate, 
            tonnage, wheel, spareWheel, passengers, fuelType, fuelTank;
        public string model, regNumber, bodySize;
        public float motorSize, tonnageCoefficient, fuelBalance;
        public bool trailer, usage;

        // нормы
        public int normaId;
        public float fuel, normaTrailer, norma100, norma100trailer, trip, 
            mehanism, oil, gorod100, gorod300, gorod1000, ostan, medl, bezdor, 
            track, boost1, boost2, boost3, cond, otopitel, generator;

        // техническое обслуживание и пробег
        public int serviceId, speedometer, counter, speedometerTo1, 
            speedometerTo2, intervalTo1, intervalTo2, counterTo1, 
            counterTo2, counterTo3, counterIntervalTo1, counterIntervalTo2, 
            counterIntervalTo3, speedometerLimit, runLimit, speedometerControl, 
            avtoState;
        public DateTime controlDate1, controlDate2;

        public AddEditVehicleForm(int vId, bool mRight, bool admin)
        {
            InitializeComponent();
            vehicleId = vId;
            mechanicRight = mRight;
            adminRight = admin;
        }

        // Обработчик загрузки формы
        private void AddEditVehicleForm_Load(object sender, EventArgs e)
        {
            // если форма открыта для редактирования данных автомобиля
            if (vehicleId > 0)
            {
                // создание экземпляров классов VehicleClass, NormaClass и ServiceMileageClass
                VehicleClass editVehicle = new VehicleClass();
                NormaClass editNorma = new NormaClass();
                ServiceMileageClass editService = new ServiceMileageClass();
                // получение данных из БД по Id
                editVehicle.GetVehicleById(vehicleId);
                editNorma.GetNormaById(vehicleId);
                normaId = editNorma.NormaId;
                editService.GetServicemileageById(vehicleId);
                serviceId = editService.ServiceId;
                // заполнение полей формы
                modelBox.Text = editVehicle.Model;
                regnumberBox.Text = editVehicle.RegNumber;
                trailerCheckBox.Checked = editVehicle.Trailer;
                usageCheckBox.Checked = editVehicle.Usage;
                // водитель
                if (editVehicle.DriverId != null)
                {
                    driverId = (int) editVehicle.DriverId;
                    // создание экземпляров классов DriverClass
                    DriverClass driver = new DriverClass();
                    driver.GetDriverById(driverId);
                    drivernameBox.Text = driver.DriverName;
                }
                else
                    driverId = 0;
                // справочные параметры
                vehicleTypeBox.SelectedIndex = editVehicle.Type - 1;
                bodyTypeBox.SelectedIndex = editVehicle.BodyType - 1;
                motorTypeBox.SelectedIndex = editVehicle.MotorType - 1;
                motorSizeBox.Text = Convert.ToString(editVehicle.MotorSize);
                releaseDateBox.Text = Convert.ToString(editVehicle.ReleaseDate);
                passengersBox.Text = Convert.ToString(editVehicle.Passengers);
                wheelBox.Text = Convert.ToString(editVehicle.Wheel);
                sparewheelBox.Text = Convert.ToString(editVehicle.SpareWheel);
                bodysizeBox.Text = Convert.ToString(editVehicle.BodySize);
                tonnageBox.Text = Convert.ToString(editVehicle.Tonnage);
                tonnageCoefficientBox.Text = Convert.ToString(editVehicle.TonnageCoefficient);
                //нормы основные
                fueltypeComboBox.SelectedIndex = editVehicle.FuelType - 1;
                fueltankBox.Text = Convert.ToString(editVehicle.FuelTank);
                fuelbalanceBox.Text = Convert.ToString(editVehicle.FuelBalance);
                fuelBox.Text = Convert.ToString(editNorma.Fuel);
                trailerBox.Text = Convert.ToString(editNorma.Trailer);
                norma100Box.Text = Convert.ToString(editNorma.Norma100);
                norma100TrailerBox.Text = Convert.ToString(editNorma.Norma100Trailer);
                tripBox.Text = Convert.ToString(editNorma.Trip);
                mehanismBox.Text = Convert.ToString(editNorma.Mehanism);
                oilBox.Text = Convert.ToString(editNorma.Oil);
                // коэффициенты
                gorod100Box.Text = Convert.ToString(editNorma.Gorod100);
                gorod300Box.Text = Convert.ToString(editNorma.Gorod300);
                gorod1000Box.Text = Convert.ToString(editNorma.Gorod1000);
                ostanBox.Text = Convert.ToString(editNorma.Ostan);
                medlBox.Text = Convert.ToString(editNorma.Medl);
                bezdorBox.Text = Convert.ToString(editNorma.Bezdor);
                trackBox.Text = Convert.ToString(editNorma.Track);
                boost1Box.Text = Convert.ToString(editNorma.Boost1);
                boost2Box.Text = Convert.ToString(editNorma.Boost2);
                boost3Box.Text = Convert.ToString(editNorma.Boost3);
                condBox.Text = Convert.ToString(editNorma.Cond);
                otopitelBox.Text = Convert.ToString(editNorma.Otopitel);
                generatorBox.Text = Convert.ToString(editNorma.Generator);
                // техобслуживание и пробеги
                speedometerBox.Text = Convert.ToString(editService.Speedometer);
                counterBox.Text = Convert.ToString(editService.Counter);
                speedometerTo1Box.Text = Convert.ToString(editService.SpeedometerTo1);
                speedometerTo2Box.Text = Convert.ToString(editService.SpeedometerTo2);
                intervalTo1Box.Text = Convert.ToString(editService.IntervalTo1);
                intervalTo2Box.Text = Convert.ToString(editService.IntervalTo2);
                counterTo1Box.Text = Convert.ToString(editService.CounterTo1);
                counterTo2Box.Text = Convert.ToString(editService.CounterTo2);
                counterTo3Box.Text = Convert.ToString(editService.CounterTo3);
                counterIntervalTo1Box.Text = Convert.ToString(editService.CounterIntervalTo1);
                counterIntervalTo2Box.Text = Convert.ToString(editService.CounterIntervalTo2);
                counterIntervalTo3Box.Text = Convert.ToString(editService.CounterIntervalTo3);
                speedometerLimitBox.Text = Convert.ToString(editService.SpeedometerLimit);
                runlimitBox.Text = Convert.ToString(editService.RunLimit);
                speedometerControlBox.Text = Convert.ToString(editService.SpeedometerControl);
                // если какая-либо контрольная дата не установлена
                if (editService.ControlDate1 == DateTime.MinValue)
                {
                    controlDate1Picker.Checked = false;
                    controlDate1Picker.Value = DateTime.Today;
                }
                else
                {
                    controlDate1Picker.Checked = true;
                    controlDate1Picker.Value = editService.ControlDate1;
                }
                if (editService.ControlDate2 == DateTime.MinValue)
                {
                    controlDate2Picker.Checked = false;
                    controlDate2Picker.Value = DateTime.Today;
                }
                else
                {
                    controlDate2Picker.Checked = true;
                    controlDate2Picker.Value = editService.ControlDate2;
                }
                avtostateComboBox.SelectedIndex = editService.AvtoState - 1;
                // подсвечивание ячеек для контроля
                // с необходимостью прохождения ТО за 100 км до очередного ТО1
                int controlNumber = editService.SpeedometerTo1 - editService.Speedometer;
                if (editService.SpeedometerTo1 != 0 && (controlNumber <= 100 || controlNumber < 0))
                    speedometerTo1Box.BackColor = Color.IndianRed;
                // с необходимостью прохождения ТО за 100 км до очередного ТО2
                controlNumber = editService.SpeedometerTo2 - editService.Speedometer;
                if (editService.SpeedometerTo2 != 0 && (controlNumber <= 100 || controlNumber < 0))
                    speedometerTo2Box.BackColor = Color.Red;
                //// за 100 км до конца ежемесячного лимитированного пробега
                //else if (service.Speedometer - service.SpeedometerLimit <= 100 ||
                //    service.Speedometer - service.SpeedometerLimit < 0)
                //    lvi.BackColor = Color.DarkRed;
                // за 100 км до конца по контрольному спидометру
                controlNumber = editService.SpeedometerControl - editService.Speedometer;
                if (editService.SpeedometerControl != 0 && controlNumber <= 100)
                    speedometerControlBox.BackColor = Color.DarkOrange;
                // при срабатывании даты контроля
                if (editService.ControlDate1 != DateTime.MinValue && editService.ControlDate1 <= DateTime.Today)
                    controlDate1Picker.BackColor = Color.LawnGreen;
                if (editService.ControlDate2 != DateTime.MinValue && editService.ControlDate2 <= DateTime.Today)
                    controlDate2Picker.ForeColor = Color.LawnGreen;
            }
            // если форма открыта пользователем без прав Механика
            if (!adminRight)
            {
                if (!mechanicRight)
                {
                    // скрытие недоступных для редактирования полей
                    usageCheckBox.Enabled = false;
                    panel5.Enabled = false;
                }
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
                drivernameBox.Text = addForm.driverName;
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
                drivernameBox.Text = "";
            }
        }

        // Снятие/установка галочки "Прицеп"
        private void trailerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            trailerStateChanged(trailerCheckBox.Checked);
        }

        // Обработчик изменения значения "Прицеп"
        private void trailerStateChanged(bool flag)
        {
            vehicleTypeBox.Enabled = !flag;
            bodyTypeBox.Enabled = !flag;
            motorTypeBox.Enabled = !flag;
            motorSizeBox.Enabled = !flag;
            fueltypeComboBox.Enabled = !flag;
            fueltankBox.Enabled = !flag;
            fuelbalanceBox.Enabled = !flag;
            fuelBox.Enabled = !flag;
            trailerBox.Enabled = !flag;
            norma100Box.Enabled = !flag;
            norma100TrailerBox.Enabled = !flag;
            tripBox.Enabled = !flag;
            mehanismBox.Enabled = !flag;
            oilBox.Enabled = !flag;
            gorod100Box.Enabled = !flag;
            gorod300Box.Enabled = !flag;
            gorod1000Box.Enabled = !flag;
            ostanBox.Enabled = !flag;
            medlBox.Enabled = !flag;
            bezdorBox.Enabled = !flag;
            trackBox.Enabled = !flag;
            boost1Box.Enabled = !flag;
            boost2Box.Enabled = !flag;
            boost3Box.Enabled = !flag;
            condBox.Enabled = !flag;
            otopitelBox.Enabled = !flag;
            generatorBox.Enabled = !flag;
        }

        // Обработчик нажатия кнопки Ок
        private void button1_Click(object sender, EventArgs e)
        {
            // проверка заполненности всех обязательных полей формы
            // если не введена модель автомобиля
            if (modelBox.TextLength == 0)
            {
                MessageBox.Show("Введите модель автомобиля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если не введен госномер автомобиля
            else if (regnumberBox.TextLength == 0)
            {
                MessageBox.Show("Введите госномер автомобиля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если введенный госномер автомобиля существует в БД
            else if (!CheckVehicleRegnumber(regnumberBox.Text))
            {
                MessageBox.Show("Автомобиль с таким госномером уже существует!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если не введен год выпуска автомобиля
            else if (releaseDateBox.TextLength == 0)
            {
                MessageBox.Show("Введите год выпуска автомобиля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если не введено количество колес автомобиля
            else if (wheelBox.TextLength == 0)
            {
                MessageBox.Show("Введите количество колес автомобиля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если транспортное средство не является прицепом
            if (!trailerCheckBox.Checked)
            {
                // если не выбран тип автомобиля
                if (vehicleTypeBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите тип автомобиля!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // если не выбран тип кузова автомобиля
                else if (bodyTypeBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите тип кузова автомобиля!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // если не выбран тип двигателя автомобиля
                else if (motorTypeBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите тип двигателя автомобиля!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // если не введен объем двигателя автомобиля
                else if (motorSizeBox.TextLength == 0)
                {
                    MessageBox.Show("Введите объем двигателя автомобиля!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // если не выбран тип топлива
                else if (fueltypeComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите тип топлива!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // если не введены текущие показатели спидометра
                else if (speedometerBox.TextLength == 0)
                {
                    MessageBox.Show("Введите текущие показатели спидометра!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
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
            // автомобиль
            model = modelBox.Text;
            regNumber = regnumberBox.Text;
            trailer = trailerCheckBox.Checked ? true : false;
            usage = usageCheckBox.Checked ? true : false;
            if (!trailer)
            {
                type = vehicleTypeBox.SelectedIndex + 1;
                bodyType = bodyTypeBox.SelectedIndex + 1;
                motorType = motorTypeBox.SelectedIndex + 1;
                motorSize = Convert.ToSingle(motorSizeBox.Text);
                fuelType = fueltypeComboBox.SelectedIndex + 1;
                fuelTank = CheckIntZero(fueltankBox);
                fuelBalance = CheckFloatZero(fuelbalanceBox);
                // норма
                fuel = CheckFloatZero(fuelBox);
                normaTrailer = CheckFloatZero(trailerBox);
                norma100 = CheckFloatZero(norma100Box);
                norma100trailer = CheckFloatZero(norma100TrailerBox);
                trip = CheckFloatZero(tripBox);
                mehanism = CheckFloatZero(mehanismBox);
                oil = CheckFloatZero(oilBox);
                gorod100 = CheckFloatZero(gorod100Box);
                gorod300 = CheckFloatZero(gorod300Box);
                gorod1000 = CheckFloatZero(gorod1000Box);
                ostan = CheckFloatZero(ostanBox);
                medl = CheckFloatZero(medlBox);
                bezdor = CheckFloatZero(bezdorBox);
                track = CheckFloatZero(trackBox);
                boost1 = CheckFloatZero(boost1Box);
                boost2 = CheckFloatZero(boost2Box);
                boost3 = CheckFloatZero(boost3Box);
                cond = CheckFloatZero(condBox);
                otopitel = CheckFloatZero(otopitelBox);
                generator = CheckFloatZero(generatorBox);
            }
            releaseDate = Convert.ToInt32(releaseDateBox.Text);
            bodySize = bodysizeBox.Text;
            passengers = CheckIntZero(passengersBox);
            tonnage = CheckIntZero(tonnageBox);
            wheel = Convert.ToInt32(wheelBox.Text);
            spareWheel = CheckIntZero(sparewheelBox);
            tonnageCoefficient = CheckFloatZero(tonnageCoefficientBox);
            // техническое обслуживание и пробег
            speedometer = CheckIntZero(speedometerBox);
            counter = CheckIntZero(counterBox);
            speedometerTo1 = CheckIntZero(speedometerTo1Box);
            speedometerTo2 = CheckIntZero(speedometerTo2Box);
            intervalTo1 = CheckIntZero(intervalTo1Box);
            intervalTo2 = CheckIntZero(intervalTo2Box);
            counterTo1 = CheckIntZero(counterTo1Box);
            counterTo2 = CheckIntZero(counterTo2Box);
            counterTo3 = CheckIntZero(counterTo3Box);
            counterIntervalTo1 = CheckIntZero(counterIntervalTo1Box);
            counterIntervalTo2 = CheckIntZero(counterIntervalTo2Box);
            counterIntervalTo3 = CheckIntZero(counterIntervalTo3Box);
            speedometerLimit = CheckIntZero(speedometerLimitBox);
            runLimit = CheckIntZero(runlimitBox);
            speedometerControl = CheckIntZero(speedometerControlBox);
            avtoState = avtostateComboBox.SelectedIndex + 1;
            if (controlDate1Picker.Checked)
                controlDate1 = controlDate1Picker.Value;
            if (controlDate2Picker.Checked)
                controlDate2 = controlDate2Picker.Value;
        }

        // Метод проверки на 0 в int
        private int CheckIntZero(TextBox box)
        {
            int result = 0;
            if (box.TextLength > 0)
                result = Convert.ToInt32(box.Text);
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

        // Функция проверки наличия в БД автомобиля с одинаковым госномером
        private bool CheckVehicleRegnumber(string vRegnumber)
        {
            // споздание экземпляра класса VehicleClass
            VehicleClass vehicle = new VehicleClass();
            // поиск в таблице Vehicle БД автомобиля по госномеру
            vehicle.GetVehicleByRegnumber(vRegnumber);
            // если такой госномер есть в БД
            if (vRegnumber == vehicle.RegNumber && vehicleId != vehicle.VehicleId)
                return false;
            else
                return true;
        }
    }
}
