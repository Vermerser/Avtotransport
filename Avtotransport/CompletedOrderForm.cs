using System;
using System.Drawing;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна принятия путевых листов
    public partial class CompletedOrderForm : Form
    {
        // переменные класса
        private int vehicleId, trailerId;
        private bool calculateFlag = false;
        public int completedId, orderId, speedometerIn, motoIn, gorod100, gorod300, gorod1000, track, 
            bezdor, ostan, medl, withCargo, withoutCargo, cargo, withTrailer, 
            onTrailer, cond, fuelTank;
        public float fuelBalance, refuel, otopitel, generator, dopCoefficient, oilNorma, oilFact;
        public DateTime timeOut, timeIn;
        public string transportationKind;
        // переменные класса для TravelOrderClass
        public int speedometerOut, motoOut;
        public float fuelBalanceOut, winterCoefficient;
        public bool completedFlag;

        public CompletedOrderForm(int oId)
        {
            InitializeComponent();
            orderId = oId;
        }

        // Обработчик загрузки формы
        private void CompletedOrderForm_Load(object sender, EventArgs e)
        {
            // создание экземпляра класса CompletedTravelOrderClass
            CompletedTravelOrderClass complOrder = new CompletedTravelOrderClass();
            complOrder.GetCompletedTravelOrderById(orderId);
            completedId = complOrder.CompletedId;
            // создание экземпляра класса TravelOrderClass
            TravelOrderClass order = new TravelOrderClass();
            // получение путевого листа из БД по его Id
            order.GetTravelOrderById(orderId);
            // заполнение соответствующих полей формы
            // данные об автомобиле и водителе
            VehicleClass vehicle = new VehicleClass();
            vehicleId = (int) order.VehicleId;
            vehicle.GetVehicleById(vehicleId);
            fuelTank = vehicle.FuelTank;
            vehicleNameBox.Text = vehicle.Model;
            vehicleNumberBox.Text = vehicle.RegNumber;
            fuelTypeLabel.Text = vehicle.GetStringFuelType(vehicle.FuelType);
            fuelBalanceOutBox.Text = Convert.ToString(order.FuelBalance);
            NormaClass norma = new NormaClass();
            norma.GetNormaById(vehicleId);
            DriverClass driver = new DriverClass();
            driver.GetDriverById((int)order.DriverId);
            driverNameBox.Text = driver.DriverName;
            trailerId = order.TrailerId != null ? (int) order.TrailerId : 0;
            string tmpStr = Convert.ToString(order.Date);
            dateOrderBox.Text = _cutSubstringFromString(ref tmpStr, " ", 0);
            numberBox.Text = order.Number;
            speedometerOutBox.Text = Convert.ToString(order.SpeedometerOut);
            motoOutBox.Text = Convert.ToString(order.MotoOut);
            transportationKindComboBox.Text = order.TransportationKind;
            fuelConsumptionNormaBox.Text = Convert.ToString(order.FuelCharge);
            coeffBox.Text = Convert.ToString(order.WinterCoefficient);

            // если открыта форма для редактирования данных в заполненном путевом листе
            if (completedId > 0)
            {
                speedometerInBox.Text = Convert.ToString(complOrder.SpeedometerIn);
                motoInBox.Text = Convert.ToString(complOrder.MotoIn);
                timeOutDate.Value = complOrder.TimeOut;
                timeInDate.Value = complOrder.TimeIn;
                fuelBalanceInBox.Text = Convert.ToString(complOrder.FuelBalance);
                refuelBox.Text = Convert.ToString(complOrder.Refuel);
                CalculateFuelCharge();

                gorod100Box.Text = Convert.ToString(complOrder.Gorod100);
                gorod300Box.Text = Convert.ToString(complOrder.Gorod300);
                gorod1000Box.Text = Convert.ToString(complOrder.Gorod1000);
                trackBox.Text = Convert.ToString(complOrder.Track);
                bezdorBox.Text = Convert.ToString(complOrder.Bezdor);
                ostanBox.Text = Convert.ToString(complOrder.Ostan);
                medlBox.Text = Convert.ToString(complOrder.Medl);
                withCargoBox.Text = Convert.ToString(complOrder.WithCargo);
                withoutCargoBox.Text = Convert.ToString(complOrder.WithoutCargo);
                cargoBox.Text = Convert.ToString(complOrder.Cargo);
                tonnoKmBox.Text = Convert.ToString(complOrder.WithCargo * complOrder.Cargo);
                withTrailerBox.Text = Convert.ToString(complOrder.WithTrailer);
                onTrailerBox.Text = Convert.ToString(complOrder.OnTrailer);
                otopitelBox.Text = Convert.ToString(complOrder.Otopitel);
                generatorBox.Text = Convert.ToString(complOrder.Generator);
                condBox.Text = Convert.ToString(complOrder.Cond);
                dopCoefficientBox.Text = Convert.ToString(complOrder.DopCoefficient);
                oilNormaBox.Text = Convert.ToString(complOrder.OilNorma);
                oilFactBox.Text = Convert.ToString(complOrder.OilFact);

                // стирание "пустых" нулей в полях формы
                CleanZeroBox();
                // вычисление расхода топлива по норме
                fuelConsumptionNormaBox.Text = Convert.ToString(Math.Round(CalculatePlanFuelConsumption(norma), 2));
                CalculateSavings();
                calculateFlag = true;
            }
            else
            {
                timeOutDate.Value = order.TimeOut;
                timeInDate.Value = order.TimeIn;
            }
        }

        // Обработчик нажатия кнопки "Расчет по норме"
        private void calculateButton_Click(object sender, EventArgs e)
        {
            NormaClass norma = new NormaClass();
            norma.GetNormaById(vehicleId);
            fuelConsumptionNormaBox.Text = Convert.ToString(Math.Round(CalculatePlanFuelConsumption(norma), 2));
            CalculateSavings();
            oilNormaBox.Text = Convert.ToString(Math.Round(CalculateNormaOilConsumption(norma), 2));
            calculateFlag = true;
        }

        // Обработчик нажатия кнопки Ок
        private void button1_Click(object sender, EventArgs e)
        {
            if (!calculateFlag)
            {
                MessageBox.Show("Произведите расчет расхода топлива по норме!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                // проверка заполненности всех полей формы
                // если не введены показания спидометра по возвращении
                if (speedometerInBox.TextLength == 0)
                {
                    MessageBox.Show("Введите показания спидометра по возвращении!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // если введены показания спидометра по возвращении меньше, чем при выезде
                else if (Convert.ToInt32(speedometerInBox.Text) < Convert.ToInt32(speedometerOutBox.Text))
                {
                    MessageBox.Show("Введите корректные показания спидометра по возвращении!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (fuelBalanceInBox.TextLength == 0)
                    fuelBalance = 0;
                if (motoInBox.TextLength == 0)
                    motoIn = 0;
                DialogResult = DialogResult.OK;
                // присвоение переменным класса соответствующих значений
                SetValue();
                // закрытие формы
                Close();
            }
        }

        // Функция присвоения переменным класса соответствующих значений
        private void SetValue()
        {
            speedometerIn = GetIntValueFromBox(speedometerInBox);
            motoIn = GetIntValueFromBox(motoInBox);
            timeOut = timeOutDate.Value;
            timeIn = timeInDate.Value;
            fuelBalance = GetFloatValueFromBox(fuelBalanceInBox);
            refuel = GetFloatValueFromBox(refuelBox);
            withCargo = GetIntValueFromBox(withCargoBox);
            withoutCargo = GetIntValueFromBox(withoutCargoBox);
            cargo = GetIntValueFromBox(cargoBox);
            withTrailer = GetIntValueFromBox(withTrailerBox);
            onTrailer = GetIntValueFromBox(onTrailerBox);
            otopitel = GetFloatValueFromBox(otopitelBox);
            generator = GetFloatValueFromBox(generatorBox);
            dopCoefficient = GetFloatValueFromBox(dopCoefficientBox);
            transportationKind = transportationKindComboBox.Text;
            oilNorma = GetFloatValueFromBox(oilNormaBox);
            oilFact = GetFloatValueFromBox(oilFactBox);

            speedometerOut = GetIntValueFromBox(speedometerOutBox);
            motoOut = GetIntValueFromBox(motoOutBox);
            fuelBalanceOut = GetFloatValueFromBox(fuelBalanceOutBox);
            winterCoefficient = GetFloatValueFromBox(coeffBox);
            completedFlag = true;
    }

#region Methods
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

        // Метод отсечения части строки и образование новой строки
        private string _cutSubstringFromString(ref string s, string c, int startIndex)
        {
            int pos1 = s.IndexOf(c, startIndex);
            string retString = s.Substring(0, pos1);
            s = (s.Substring(pos1 + c.Length)).Trim();
            return retString;
        }

        // Метод перерасчета пробега при внесении изменений в соответствующих полях
        private void runBox_TextChanged(object sender, EventArgs e)
        {
            int spedometr = 0, moto = 0;
            if (speedometerInBox.TextLength > 0 && speedometerOutBox.TextLength > 0)
                spedometr = Convert.ToInt32(speedometerInBox.Text) - 
                    Convert.ToInt32(speedometerOutBox.Text);
            if (motoInBox.TextLength > 0 && motoOutBox.TextLength > 0)
                moto = Convert.ToInt32(motoInBox.Text) - Convert.ToInt32(motoOutBox.Text);
            runKmBox.Text = Convert.ToString(spedometr);
            runMotoBox.Text = Convert.ToString(moto);
        }

        // Метод расчета фактического расхода топлива по осаткам
        private void CalculateFuelCharge()
        {
            float fuelBalance = Convert.ToSingle(fuelBalanceOutBox.Text);
            // при наличии положительного числа заправки
            if (refuelBox.TextLength > 0)
                fuelBalance += Convert.ToSingle(refuelBox.Text);
            // при наличии положительного числа остатка топлива по возвращению
            if (fuelBalanceInBox.TextLength > 0)
                fuelBalance -= Convert.ToSingle(fuelBalanceInBox.Text);
            fuelConsumptionFaktBox.Text = Convert.ToString(fuelBalance);
        }

        // Метод перерасчета фактического расхода топлива
        // при внесении изменений в соответствующих полях
        private void fuel_TextChanged(object sender, EventArgs e)
        {
            CalculateFuelCharge();
            // при наличии остатка топлива большего чем его вместимость
            if (fuelBalanceInBox.TextLength > 0)
            {
                float fuelBalance = Convert.ToSingle(fuelBalanceInBox.Text);
                if (fuelBalance > fuelTank)
                    fuelBalanceInBox.BackColor = Color.Red;
                else
                    fuelBalanceInBox.BackColor = Color.LightGreen;
            }
        }

        // Выделение отрицательного расхода топлива, возможная ошибка при заполнении формы
        private void fuelAlarm_TextChanged(object sender, EventArgs e)
        {
            if (fuelConsumptionFaktBox.TextLength > 0)
            {
                float fuelBalance = Convert.ToSingle(fuelConsumptionFaktBox.Text);
                if (fuelBalance < 0)
                    fuelConsumptionFaktBox.BackColor = Color.Red;
                else
                    fuelConsumptionFaktBox.BackColor = Color.LightGreen;
                CalculateSavings();
            }
        }
        
        // Метод расчета экономии/пережога топлива
        private void CalculateSavings()
        {
            if (fuelConsumptionNormaBox.TextLength > 0 && 
                fuelConsumptionFaktBox.TextLength > 0)
            {
                float savings = Convert.ToSingle(fuelConsumptionFaktBox.Text) -
                                Convert.ToSingle(fuelConsumptionNormaBox.Text);
                // пережог
                if (savings >= 0.005)
                    economyBox.Text = "П: " + Convert.ToString(Math.Round(savings, 2));
                // экономия
                else if (savings < -0.005)
                    economyBox.Text = "Э: " + Convert.ToString(Math.Round(-savings, 2));
                // нет ни экономии ни пережога
                else
                    economyBox.Text = "Э/П: нет";
            }
        }

        // Метод расчета Тонно-км при добавлении данных о грузе и движении с грузом
        private void tonnoKm_TextChanged(object sender, EventArgs e)
        {
            int tmp1, tmp2;
            if (withCargoBox.TextLength > 0 && cargoBox.TextLength > 0)
            {
                tmp1 = Convert.ToInt32(withCargoBox.Text);
                tmp2 = Convert.ToInt32(cargoBox.Text);
                tonnoKmBox.Text = Convert.ToString(tmp1 * tmp2);
            }
            if (withCargoBox.TextLength > 0 && runKmBox.TextLength > 0)
            {
                tmp1 = Convert.ToInt32(runKmBox.Text);
                tmp2 = Convert.ToInt32(withCargoBox.Text);
                withoutCargoBox.Text = Convert.ToString(tmp1 - tmp2);
            }
        }

        // Метод изменения флага необходимости проведения перерасчета расхода топлива по норме
        private void norma_TextChanged(object sender, EventArgs e)
        {
            calculateFlag = false;
        }

        // Метод вычисления планируемого расхода топлива по маршруту
        private float CalculatePlanFuelConsumption(NormaClass norma)
        {
            float result = 0;
            // расчет расхода топлива по линейной норме или по норме с прицепом
            result = trailerId == 0 ? Convert.ToSingle(runKmBox.Text) / 100 * norma.Fuel :
                Convert.ToSingle(runKmBox.Text) / 100 * norma.Trailer;
            // присвоение переменным класса соответствующих значений, необходимых для проведения расчетов
            gorod100 = GetIntValueFromBox(gorod100Box);
            gorod300 = GetIntValueFromBox(gorod300Box);
            gorod1000 = GetIntValueFromBox(gorod1000Box);
            track  = GetIntValueFromBox(trackBox);
            bezdor = GetIntValueFromBox(bezdorBox);
            ostan = GetIntValueFromBox(ostanBox);
            medl = GetIntValueFromBox(medlBox);
            cond = GetIntValueFromBox(condBox);
            // прибавление повышающих коэффициентов
            result += gorod100 / 100 * norma.Fuel * (norma.Gorod100 / 100);
            result += gorod300 / 100 * norma.Fuel * (norma.Gorod300 / 100);
            result += gorod1000 / 100 * norma.Fuel * (norma.Gorod1000 / 100);
            result += bezdor / 100 * norma.Fuel * (norma.Bezdor / 100);
            result += medl / 100 * norma.Fuel * (norma.Medl / 100);
            result += ostan / 100 * norma.Fuel * (norma.Ostan / 100);
            result += cond / 100 * norma.Fuel * (norma.Cond / 100);
            // прибавление дополнительных коэффициентов
            result = norma.Boost1 > 1 ? result * norma.Boost1 : result;
            result = norma.Boost2 > 1 ? result * norma.Boost2 : result;
            result = norma.Boost3 > 1 ? result * norma.Boost3 : result;
            // прибавление топлива на отопитель и генератор
            if (otopitelBox.TextLength > 0 && norma.Otopitel > 0)
                result += Convert.ToSingle(otopitelBox.Text) * norma.Otopitel;
            if (generatorBox.TextLength > 0 && norma.Generator > 0)
                result += Convert.ToSingle(generatorBox.Text) * norma.Generator;
            // вычитание понижающих коэффициентов
            result -= track / 100 * norma.Fuel * (norma.Track / 100);
            // при наличии коэффициента зимних норм
            if (coeffBox.TextLength > 0)
                result = result * Convert.ToSingle(coeffBox.Text);
            // применение дополнительного коэффициента при его наличии
            if (dopCoefficientBox.TextLength > 0)
                result = result * Convert.ToSingle(dopCoefficientBox.Text);
            return result;
        }

        // Метод вычисления расхода масла по норме
        private float CalculateNormaOilConsumption(NormaClass norma)
        {
            float result = 0;
            // если есть данные о фактическом расходе топлива
            if (fuelConsumptionFaktBox.TextLength > 0)
                result = Convert.ToSingle(fuelConsumptionFaktBox.Text)/100*norma.Oil;
            return result;
        }

        private int GetIntValueFromBox(TextBox box)
        {
            int result = box.TextLength > 0 ? Convert.ToInt32(box.Text) : 0;
            return result;
        }
        private float GetFloatValueFromBox(TextBox box)
        {
            float result = box.TextLength > 0 ? Convert.ToSingle(box.Text) : 0;
            return result;
        }

        // Метод стирания "пустых" нулей в полях формы
        private void CleanZeroBox()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Panel))
                    foreach (Control d in c.Controls)
                        if (d.GetType() == typeof(TextBox) && d.Text == "0")
                            d.Text = string.Empty;
            }
        }
#endregion
    }
}
