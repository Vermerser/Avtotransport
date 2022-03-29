using System;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна добавления и редактирования данных об аккумуляторе
    public partial class AddEditBatteryForm : Form
    {
        // переменные класса
        private int batteryId;
        public int vehicleId, beforeInstKm, beforeInstMont, timenormYears, 
            timenormMonth, runNorm, currentRun, currentMonth;
        public string type, madename;
        public DateTime bDate, iDate, rDate;
        public float coast;
        public bool status;
        
        public AddEditBatteryForm(int bId)
        {
            InitializeComponent();
            batteryId = bId;
            vehicleId = 0;
        }

        // Обработчик загрузки формы
        private void AddEditBatteryForm_Load(object sender, EventArgs e)
        {
            // если открыта форма для редактирования данных аккумулятора
            if (batteryId > 0)
            {
                // создание экземпляра класса BatteryClass
                BatteryClass editBattery = new BatteryClass();
                // получение аккумулятора из БД по его Id
                editBattery.GetBatteryById(batteryId);
                // заполнение полей формы для редактирования данных аккумулятора
                typeBox.Text = editBattery.BatteryType;
                madenameBox.Text = editBattery.BatteryMadename;
                batteryDate.Value = editBattery.BatteryDate;
                coastBox.Text = Convert.ToString(editBattery.BatteryCoast);
                // данные об установленном автомобиле
                if (editBattery.VehicleId != null)
                {
                    vehicleId = (int)editBattery.VehicleId;
                    VehicleClass vehicle = new VehicleClass();
                    // получение и вставка данных автомобиля
                    vehicle.GetVehicleById(vehicleId);
                    vehicleNameBox.Text = vehicle.Model;
                    vehicleNumberBox.Text = vehicle.RegNumber;
                    beforeinstKmBox.Text = Convert.ToString(editBattery.BatteryBeforeinstKm);
                    beforeinstMonthBox.Text = Convert.ToString(editBattery.BatteryBeforeinstMonth);
                    installationDate.Value = editBattery.BatteryInstallationdate;
                    removeDate.Value = editBattery.BatteryRemovedate;
                }
                // если аккумулятор не установлен на автомобиле
                else
                {
                    // отключение доступности
                    SwitchingVisibility(false);
                    installationDate.Value = new DateTime(2006, 09, 29);
                    removeDate.Value = new DateTime(2006, 09, 29);
                }
                timenormYearsBox.Text = Convert.ToString(editBattery.BatteryTimenormYears);
                timenormMonthBox.Text = Convert.ToString(editBattery.BatteryTimenormMonth);
                runnormBox.Text = Convert.ToString(editBattery.BatteryRunnorm);
                currentrunBox.Text = Convert.ToString(editBattery.BatteryCurrentrun);
                currentmonthBox.Text = Convert.ToString(editBattery.BatteryCurrentmonth);
                // статус эксплуатации
                statusCheckBox.Checked = editBattery.BatteryStatus ? true : false;
            }
            // если форма открыта для добавления нового аккумулятора
            else
            {
                // иницилизация дат в форме
                batteryDate.Value = DateTime.Today;
                installationDate.Value = new DateTime(2006, 09, 29);
                removeDate.Value = new DateTime(2006, 09, 29);
                // отключение доступности
                SwitchingVisibility(false);
            }
        }

        // Обработчик нажатия кнопки для добавления автомобиля
        private void addAvtoButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления автомобиля
            AddVehicleForm addForm = new AddVehicleForm(vehicleId, 0);
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                // отображение добавленного автомобиля
                vehicleId = addForm.vehicleId;
                vehicleNameBox.Text = addForm.model;
                vehicleNumberBox.Text = addForm.regnumber;
                // включение доступности
                SwitchingVisibility(true);
                installationDate.Value = DateTime.Today;
                // автоматическое снятие галочки с чек-бокса Не эксплуатируется
                statusCheckBox.Checked = false;
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
                vehicleNameBox.Text = "";
                vehicleNumberBox.Text = "";
                // выключение доступности
                SwitchingVisibility(false);
            }
        }

        // Обработчик нажатия кнопки Ок
        private void button1_Click(object sender, EventArgs e)
        {
            // проверка заполненности всех полей формы
            // если не введены тип АКБ
            if (typeBox.TextLength == 0)
            {
                MessageBox.Show("Введите тип аккумулятора!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если не введен текущий пробег
            if (currentrunBox.TextLength == 0)
            {
                currentrunBox.Text = "0";
            }
            // если не введена текущая наработка
            if (currentmonthBox.TextLength == 0)
            {
                currentmonthBox.Text = "0";
            }
            // если снята галочка "Не эксплуатируется", а автомобиль не выбран
            if (statusCheckBox.Checked == false && vehicleId == 0)
            {
                statusCheckBox.Checked = true;
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
            type = typeBox.Text;
            madename = madenameBox.Text;
            bDate = batteryDate.Value;
            if (coastBox.TextLength > 0)
                coast = Convert.ToSingle(coastBox.Text);
            beforeInstKm = CheckIntZero(beforeinstKmBox);
            beforeInstMont = CheckIntZero(beforeinstMonthBox);
            timenormYears = CheckIntZero(timenormYearsBox);
            timenormMonth = CheckIntZero(timenormMonthBox);
            runNorm = CheckIntZero(runnormBox);
            iDate = installationDate.Value;
            rDate = removeDate.Value;
            currentRun = Convert.ToInt32(currentrunBox.Text);
            currentMonth = Convert.ToInt32(currentmonthBox.Text);
            status = statusCheckBox.Checked ? true : false;
        }

        // Функция переключения видимости элементов
        private void SwitchingVisibility(bool flag)
        {
            beforeinstKmBox.Enabled = flag;    // наработка до установки, км
            beforeinstMonthBox.Enabled = flag; // наработка до установки, мес.
            installationDate.Enabled = flag;   // дата установки
            removeDate.Enabled = flag;         // дата снятия
            currentrunBox.Enabled = flag;      // текущий пробег
            currentmonthBox.Enabled = flag;    // текущая наработка
        }

        // Метод проверки на 0 в int
        private int CheckIntZero(TextBox box)
        {
            int result = 0;
            if (box.TextLength > 0)
                result = Convert.ToInt32(box.Text);
            return result;
        }

#region KeyPress
        // Обработчики ввода символов в соответствующих полях формы
        // Метод, позволяющий вводить в соответствующих полях только цифры и знак ","
        private void coastBox_KeyPress(object sender, KeyPressEventArgs e)
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
#endregion
    }
}
