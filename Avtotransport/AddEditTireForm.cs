using System;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна добавления и редактирования данных об автомобильных шинах
    public partial class AddEditTireForm : Form
    {
        // переменные класса
        private int tireId, wheelCount, sparewheelCount;
        public int vehicleId, position, runNorma, workNorma, 
            currentRun, currentYears;
        public string serialNumber, size, model, madename;
        public DateTime iDate, rDate;
        public float weight, coast;
        public bool sparewheel, status;
        
        public AddEditTireForm(int tId)
        {
            InitializeComponent();
            tireId = tId;
            vehicleId = 0;
        }

        // Обработчик загрузки формы
        private void AddEditTireForm_Load(object sender, EventArgs e)
        {
            // если открыта форма для редактирования данных автошины
            if (tireId > 0)
            {
                // создание экземпляра класса TireClass
                TireClass editTire = new TireClass();
                // получение автошины из БД по его Id
                editTire.GetTireById(tireId);
                // заполнение полей формы для редактирования данных автошины
                serialBox.Text = editTire.SerialNumber;
                sizeBox.Text = editTire.Size;
                modelBox.Text = editTire.Model;
                madenameBox.Text = editTire.MadeName;
                weightBox.Text = Convert.ToString(editTire.Weight);
                coastBox.Text = Convert.ToString(editTire.Coast);
                // данные об установленном автомобиле
                if (editTire.VehicleId != null)
                {
                    vehicleId = (int)editTire.VehicleId;
                    VehicleClass vehicle = new VehicleClass();
                    vehicle.GetVehicleById(vehicleId);
                    vehicleNameBox.Text = vehicle.Model;
                    vehicleNumberBox.Text = vehicle.RegNumber;
                    positionComboBox.SelectedIndex = editTire.Position - 1;
                    GetCorrectPosition(vehicle.Wheel, positionComboBox.Items.Count);
                    sparewheelCheckBox.Checked = editTire.Sparewheel;
                    if (sparewheelCheckBox.Checked)
                        positionComboBox.Enabled = false;
                    installationDate.Value = editTire.InstallationDate;
                    removeDate.Value = editTire.RemoveDate;
                }
                // если автошина не установлена на автомобиле
                else
                {
                    // отключение доступновти
                    SwitchingVisibility(false);
                    installationDate.Value = new DateTime(2006, 09, 29);
                    removeDate.Value = new DateTime(2006, 09, 29);
                }
                runnormBox.Text = Convert.ToString(editTire.RunNorma);
                timenormYearsBox.Text = Convert.ToString(editTire.WorkNorma);
                currentrunBox.Text = Convert.ToString(editTire.CurrentRun);
                currentyearsBox.Text = Convert.ToString(editTire.CurrentYears);
                // статус эксплуатации
                statusCheckBox.Checked = editTire.ExpluataionStatus ? true : false;
            }
            // если форма открыта для добавления нового аккумулятора
            else
            {
                // иницилизация дат в форме
                installationDate.Value = new DateTime(2006, 09, 29);
                removeDate.Value = new DateTime(2006, 09, 29);
                // отключение доступновти
                SwitchingVisibility(false);
            }
        }

        // Обработчик нажатия кнопки для добавления автомобиля
        private void addAvtoButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления автомобиля
            AddVehicleForm addForm = new AddVehicleForm(vehicleId, 1);
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                // проверка возможности добавления автомобиля
                if (CheckInstallTire(addForm.vehicleId))
                {
                    // отображение добавленного автомобиля
                    vehicleId = addForm.vehicleId;
                    vehicleNameBox.Text = addForm.model;
                    vehicleNumberBox.Text = addForm.regnumber;
                    // включение доступности
                    SwitchingVisibility(true);
                    // автоматическое снятие галочки с чек-бокса Запасное колесо
                    sparewheelCheckBox.Checked = false;
                    installationDate.Value = DateTime.Today;
                    // автоматическое снятие галочки с чек-бокса Не эксплуатируется
                    statusCheckBox.Checked = false;
                    // корректное отображение возможных позиций колес автоомбиля
                    GetCorrectPosition(wheelCount, positionComboBox.Items.Count);
                }
                else
                {
                    MessageBox.Show("На выбранном автомобиле установлено максимально возможное число автошин! " +
                                    "Выберите другой автомобиль.", "Ошибка", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                vehicleNameBox.Text = "";
                vehicleNumberBox.Text = "";
                positionComboBox.SelectedIndex = -1;
                sparewheelCheckBox.Checked = false;
                sparewheelCount = 0;
                wheelCount = 0;
                // выключение доступности
                SwitchingVisibility(false);
            }
        }

        // Обработчик изменения состояния флажка Запасное колесо
        private void sparewheelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sparewheelCheckBox.Checked)
            {
                positionComboBox.SelectedIndex = -1;
                positionComboBox.Enabled = false;
            }
            else
                positionComboBox.Enabled = true;

        }

        // Обработчик нажатия кнопки Ок
        private void button1_Click(object sender, EventArgs e)
        {
            // проверка заполненности всех полей формы
            // если не введен размер автошины
            if (sizeBox.TextLength == 0)
            {
                MessageBox.Show("Введите размер автомобильной шины!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если не введена модель автошины
            else if (modelBox.TextLength == 0)
            {
                MessageBox.Show("Введите модель автомобильной шины!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
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
            weight = CheckFloatZero(weightBox);
            position = positionComboBox.SelectedIndex + 1;
            sparewheel = sparewheelCheckBox.Checked ? true : false;
            runNorma = CheckIntZero(runnormBox);
            workNorma = CheckIntZero(timenormYearsBox);
            currentRun = CheckIntZero(currentrunBox);
            currentYears = CheckIntZero(currentyearsBox);
            if (serialBox.TextLength == 0)
                serialNumber = "б/н";
            else
                serialNumber = serialBox.Text;
            size = sizeBox.Text;
            model = modelBox.Text;
            madename = madenameBox.Text;
            iDate = installationDate.Value;
            rDate = removeDate.Value;
            coast = CheckFloatZero(coastBox);
            status = statusCheckBox.Checked ? true : false;
        }

        // Функция переключения видимости элементов
        private void SwitchingVisibility(bool flag)
        {
            installationDate.Enabled = flag;    // дата установки
            removeDate.Enabled = flag;          // дата снятия
            currentrunBox.Enabled = flag;       // текущий пробег
            currentyearsBox.Enabled = flag;     // текущая наработка
            positionComboBox.Enabled = flag;    // позиция
            sparewheelCheckBox.Enabled = flag;  // запасное колесо
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

        // Метод проверки возможности установки автошины на автомобиль
        private bool CheckInstallTire(int vId)
        {
            // подсчет количества автошин на данном автомобиле
            TireClass countTire = new TireClass();
            int count = countTire.SelCountFromTireTable(vId);
            // создание экземпляра класса VehicleClass 
            // и получение количества колес и запасок на искомом автомобиле
            VehicleClass addVehicle = new VehicleClass();
            addVehicle.GetVehicleById(vId);
            // если на данном автомобиле установлено меньше шин, чем может там быть
            if (count < (addVehicle.Wheel + addVehicle.SpareWheel))
            {
                wheelCount = addVehicle.Wheel;
                sparewheelCount = addVehicle.SpareWheel;
                return true;
            }
            else
                return false;
        }

        // Метод отображения возможных позиций колес автоомбиля
        private void GetCorrectPosition(int count, int pos)
        {
            if (count < positionComboBox.Items.Count)
            {
                for (int i = count; i < pos; i++)
                {
                    positionComboBox.Items.RemoveAt(count);
                }
            }
        }
    }
}
