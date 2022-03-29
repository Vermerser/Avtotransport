using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс, реализующий функционал отчетов о расходе топлива
    class ReportClass
    {
        // переменные класса
        private int _vehacleId;              // Id автомобиля
        private string _vehicleType;         // тип автомобиля
        private string _vehicleModel;        // модель автомобиля
        private string _vehicleRegnumber;    // регистрационный номер автомобиля
        private int _speedometrStart;        // спидометр начало
        private int _speedometrFinish;       // спидометр конец
        private int _speedometrLimit;        // лимитированный пробег
        private int _resultRun;              // пробег
        private int _withCargo;              // пробег с грузом
        private int _cargo;                  // перевезено груза
        private int _onTrailer;              // перевезено на прицепе
        private int _resultCounter;          // машиночасы
        private string _fuelType;            // тип топлива
        private float _fuelBalanceStart;     // остаток топлива на начало периода
        private float _fuelBalanceFinish;    // остаток топлива на конец периода
        private float _fuelConsumptionNorma; // расход топлива по норме
        private float _fuelConsumptionFact;  // расход топлива фактически
        private float _fuelEconomy;          // экономия
        private float _fuelUneconomy;        // пережог
        private int _periodDays;             // выбранный период дней
        private int _workingDays;            // наработка дней
        private float _oilNorma;             // расход масла по норме
        private float _oilFact;              // расход масла фактически
        // расход топлива по типам
        private float _disel;
        private float _n80;
        private float _a92;
        private float _a95;
        private float _a98;
        private float _kpg;
        private float _sug;
        private float _kerosin;
        private float _biodisel;
        // итоговая экономия и перерасход топлива по видам
        private float _benzinEconomy;        // бензин экономия
        private float _benzinUneconomy;      // бензин перерасход
        private float _diselEconomy;         // дизель экономия
        private float _diselUneconomy;       // дизель перерасход
        // расход масла
        private float _oilRes;

        // конструкторы
        public ReportClass()
        {
        }

        // конструктор для отчета по интенсивности использования автотранспорта
        // и сводной ведомости учета работы машин
        public ReportClass(int vehacleId, string vehicleType, string vehicleModel, 
            string vehicleRegnumber, int speedometrStart, int speedometrFinish, 
            int speedometrLimit, int resultRun, int withCargo, int cargo, int onTrailer, 
            int resultCounter, string fuelType, float fuelBalanceStart, float fuelBalanceFinish, 
            float fuelConsumptionNorma, float fuelConsumptionFact, float fuelEconomy, 
            float fuelUneconomy, int periodDays, int workingDays, float oilNorma, float oilFact)
        {
            this._vehacleId = vehacleId;
            this._vehicleType = vehicleType;
            this._vehicleModel = vehicleModel;
            this._vehicleRegnumber = vehicleRegnumber;
            this._speedometrStart = speedometrStart;
            this._speedometrFinish = speedometrFinish;
            this._speedometrLimit = speedometrLimit;
            this._resultRun = resultRun;
            this._withCargo = withCargo;
            this._cargo = cargo;
            this._onTrailer = onTrailer;
            this._resultCounter = resultCounter;
            this._fuelType = fuelType;
            this._fuelBalanceStart = fuelBalanceStart;
            this._fuelBalanceFinish = fuelBalanceFinish;
            this._fuelConsumptionNorma = fuelConsumptionNorma;
            this._fuelConsumptionFact = fuelConsumptionFact;
            this._fuelEconomy = fuelEconomy;
            this._fuelUneconomy = fuelUneconomy;
            this._periodDays = periodDays;
            this._workingDays = workingDays;
            this._oilNorma = oilNorma;
            this._oilFact = oilFact;
        }

        // конструктор для прицепов
        public ReportClass(int vehacleId, string vehicleRegnumber, 
            int resultRun, int periodDays, int workingDays)
        {
            this._vehacleId = vehacleId;
            this._vehicleRegnumber = vehicleRegnumber;
            this._resultRun = resultRun;
            this._periodDays = periodDays;
            this._workingDays = workingDays;
        }

        // конструктор по расходу топлива
        public ReportClass(float disel, float n80, float a92, float a95, float a98, 
            float kpg, float sug, float kerosin, float biodisel, float oilRes)
        {
            this._disel = disel;
            this._n80 = n80;
            this._a92 = a92;
            this._a95 = a95;
            this._a98 = a98;
            this._kpg = kpg;
            this._sug = sug;
            this._kerosin = kerosin;
            this._biodisel = biodisel;
            this._oilRes = oilRes;
        }

#region Getters&Setters

        public int VehacleId
        {
            get { return _vehacleId; }
            set { _vehacleId = value; }
        }

        public string VehicleType
        {
            get { return _vehicleType; }
            set { _vehicleType = value; }
        }

        public string VehicleModel
        {
            get { return _vehicleModel; }
            set { _vehicleModel = value; }
        }

        public string VehicleRegnumber
        {
            get { return _vehicleRegnumber; }
            set { _vehicleRegnumber = value; }
        }

        public int SpeedometrStart
        {
            get { return _speedometrStart; }
            set { _speedometrStart = value; }
        }

        public int SpeedometrFinish
        {
            get { return _speedometrFinish; }
            set { _speedometrFinish = value; }
        }

        public int SpeedometrLimit
        {
            get { return _speedometrLimit; }
            set { _speedometrLimit = value; }
        }

        public int ResultRun
        {
            get { return _resultRun; }
            set { _resultRun = value; }
        }

        public int WithCargo
        {
            get { return _withCargo; }
            set { _withCargo = value; }
        }

        public int Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        public int OnTrailer
        {
            get { return _onTrailer; }
            set { _onTrailer = value; }
        }

        public int ResultCounter
        {
            get { return _resultCounter; }
            set { _resultCounter = value; }
        }

        public string FuelType
        {
            get { return _fuelType; }
            set { _fuelType = value; }
        }

        public float FuelBalanceStart
        {
            get { return _fuelBalanceStart; }
            set { _fuelBalanceStart = value; }
        }

        public float FuelBalanceFinish
        {
            get { return _fuelBalanceFinish; }
            set { _fuelBalanceFinish = value; }
        }

        public float FuelConsumptionNorma
        {
            get { return _fuelConsumptionNorma; }
            set { _fuelConsumptionNorma = value; }
        }

        public float FuelConsumptionFact
        {
            get { return _fuelConsumptionFact; }
            set { _fuelConsumptionFact = value; }
        }

        public float FuelEconomy
        {
            get { return _fuelEconomy; }
            set { _fuelEconomy = value; }
        }

        public float FuelUneconomy
        {
            get { return _fuelUneconomy; }
            set { _fuelUneconomy = value; }
        }

        public int PeriodDays
        {
            get { return _periodDays; }
            set { _periodDays = value; }
        }

        public int WorkingDays
        {
            get { return _workingDays; }
            set { _workingDays = value; }
        }

        public float OilNorma
        {
            get { return _oilNorma; }
            set { _oilNorma = value; }
        }

        public float OilFact
        {
            get { return _oilFact; }
            set { _oilFact = value; }
        }

        public float Disel
        {
            get { return _disel; }
            set { _disel = value; }
        }

        public float N80
        {
            get { return _n80; }
            set { _n80 = value; }
        }

        public float A92
        {
            get { return _a92; }
            set { _a92 = value; }
        }

        public float A95
        {
            get { return _a95; }
            set { _a95 = value; }
        }

        public float A98
        {
            get { return _a98; }
            set { _a98 = value; }
        }

        public float Kpg
        {
            get { return _kpg; }
            set { _kpg = value; }
        }

        public float Sug
        {
            get { return _sug; }
            set { _sug = value; }
        }

        public float Kerosin
        {
            get { return _kerosin; }
            set { _kerosin = value; }
        }

        public float Biodisel
        {
            get { return _biodisel; }
            set { _biodisel = value; }
        }

        public float BenzinEconomy
        {
            get { return _benzinEconomy; }
            set { _benzinEconomy = value; }
        }

        public float BenzinUneconomy
        {
            get { return _benzinUneconomy; }
            set { _benzinUneconomy = value; }
        }

        public float DiselEconomy
        {
            get { return _diselEconomy; }
            set { _diselEconomy = value; }
        }

        public float DiselUneconomy
        {
            get { return _diselUneconomy; }
            set { _diselUneconomy = value; }
        }

        public float OilRes
        {
            get { return _oilRes; }
            set { _oilRes = value; }
        }
#endregion

#region Methods
        // Метод получения флага формирования отчета
        public bool GetStatisticFlag(DateTime startDate, DateTime endDate, 
            ref ReportClass fuelReport, ref ArrayList reportList, ref ArrayList reportTrailerList, 
            ref List<int> typeList)
        {
            bool result = false;
            // обнуление показателей экономии
            BenzinEconomy = 0f;
            BenzinUneconomy = 0f;
            DiselEconomy = 0f;
            DiselUneconomy = 0f;
            // создание коллекций объектов
            ArrayList vehicleList = new ArrayList();
            ArrayList orderList = new ArrayList();
            // создание экземпляра класса VehicleClass
            VehicleClass vehicle = new VehicleClass();
            // создание экземпляров классов TravelOrderClass и CompletedTravelOrderClass
            TravelOrderClass order = new TravelOrderClass();
            CompletedTravelOrderClass cOrder = new CompletedTravelOrderClass();
            // коллекция объектов автомобилей и принятых путевых листов
            vehicleList.AddRange(vehicle.ReadVehicleData());
            orderList.AddRange(cOrder.ReadCompletedTravelOrderData());
            // перебор коллекции автоомбилей и создание статистики
            foreach (VehicleClass avto in vehicleList)
            {
                // перебор коллекции принятых путевых листов
                foreach (CompletedTravelOrderClass item in orderList)
                {
                    // если путевой лист попадает в выбранный период
                    if (item.TimeOut >= startDate && item.TimeIn <= endDate)
                    {
                        // получение выписанного путевого листа по его Id
                        order.GetTravelOrderById((int)item.OrderId);
                        // если путевой лист выписан на текущий автомобиль
                        if (order.VehicleId == avto.VehicleId)
                        {
                            bool update = false;
                            // фактический расход топлива
                            float tmpFuelFact = order.FuelBalance + item.Refuel - item.FuelBalance;
                            // если reportList содержит данные
                            if (reportList.Count > 0)
                            {
                                // проверить список на наличие автомобиля в нем
                                foreach (ReportClass rItem in reportList)
                                {
                                    // если автомобиль есть в списке
                                    if (avto.VehicleId == rItem.VehacleId)
                                    {
                                        // обновить данные о нем
                                        update = true;
                                        // спидометр начало
                                        rItem.SpeedometrStart = order.SpeedometerOut < rItem.SpeedometrStart
                                            ? order.SpeedometerOut : rItem.SpeedometrStart;
                                        // спидометр конец
                                        rItem.SpeedometrFinish = item.SpeedometerIn > rItem.SpeedometrFinish
                                            ? item.SpeedometerIn : rItem.SpeedometrFinish;
                                        // пробег
                                        rItem.ResultRun = rItem.SpeedometrFinish - rItem.SpeedometrStart;
                                        // пробег с грузом
                                        rItem.WithCargo += item.WithCargo;
                                        // перевезено груза
                                        rItem.Cargo += item.Cargo;
                                        // перевезено груза на прицепе
                                        rItem.OnTrailer += item.OnTrailer;
                                        // машиночасы
                                        rItem.ResultCounter = item.MotoIn - order.MotoOut;
                                        // обновление последнего остатка топлива
                                        rItem.FuelBalanceFinish = item.FuelBalance;
                                        // расход топлива по норме
                                        NormaClass norma = new NormaClass();
                                        norma.GetNormaById(rItem.VehacleId);
                                        rItem.FuelConsumptionNorma += CalculatePlanFuelConsumption((item.SpeedometerIn -
                                            order.SpeedometerOut), norma, item);
                                        // расход топлива фактически
                                        rItem.FuelConsumptionFact += tmpFuelFact;
                                        // экономия и пережог
                                        float tmp = rItem.FuelConsumptionNorma - rItem.FuelConsumptionFact;
                                        if (tmp > 0)
                                        {
                                            // экономия
                                            rItem.FuelEconomy = tmp;
                                            rItem.FuelUneconomy = 0;
                                        }
                                        else
                                        {
                                            // пережог
                                            rItem.FuelEconomy = 0;
                                            rItem.FuelUneconomy = (-tmp);
                                        }
                                        // наработка дней
                                        rItem.WorkingDays += item.TimeIn.Subtract(item.TimeOut).Days + 1;
                                        // расход масла по норме и фактически
                                        rItem.OilNorma += item.OilNorma;
                                        rItem.OilFact += item.OilFact;
                                    }
                                }
                            }
                            // если автомобиля в списке еще нет
                            if (reportList.Count == 0 || !update)
                            {
                                // добавить автомобиль в список
                                NormaClass norma = new NormaClass();
                                ServiceMileageClass service = new ServiceMileageClass();
                                norma.GetNormaById(avto.VehicleId);
                                service.GetServicemileageById(avto.VehicleId);
                                float tmpFuelNorma = CalculatePlanFuelConsumption((item.SpeedometerIn -
                                    order.SpeedometerOut), norma, item);
                                float eTmp = 0, uTmp = 0;
                                float economy = tmpFuelNorma - tmpFuelFact;
                                if (economy > 0)
                                    eTmp = economy;
                                else
                                    uTmp = (-economy);
                                reportList.Add(new ReportClass(avto.VehicleId, avto.GetVehicleType(avto.Type), avto.Model,
                                    avto.RegNumber, order.SpeedometerOut, item.SpeedometerIn, service.RunLimit,
                                    (item.SpeedometerIn - order.SpeedometerOut), item.WithCargo, item.Cargo,
                                    item.OnTrailer, (item.MotoIn - order.MotoOut), avto.GetStringFuelType(avto.FuelType),
                                    order.FuelBalance, item.FuelBalance, tmpFuelNorma, tmpFuelFact, eTmp, uTmp,
                                    (endDate.Subtract(startDate).Days + 1),
                                    (cOrder.TimeIn.Subtract(cOrder.TimeOut).Days + 1), item.OilNorma, item.OilFact));
                                // подсчет эконмии и пережога по видам топлива (бензин/дизель)
                                GetEconomyUneconomyFuelSumm(avto.FuelType, eTmp, uTmp, ref fuelReport);
                                bool typeFlag = false;
                                if (typeList.Count != 0) // если список содержит уже данные
                                {
                                    foreach (object type in typeList)
                                    {
                                        if (avto.Type == (int)type)
                                        {
                                            typeFlag = true;
                                            break;
                                        }
                                    }
                                }
                                // в случае отсутствия в списке типов типа добавленного автомобиля
                                // добавить его в список
                                if (typeList.Count == 0 || !typeFlag)
                                    typeList.Add(avto.Type);
                            }
                            // суммирование топлива по видам
                            GetFuelSumm(avto.FuelType, tmpFuelFact, ref fuelReport);
                            // расход масла
                            fuelReport.OilRes += item.OilFact;
                            fuelReport.OilNorma += item.OilNorma;
                        }
                        // если в путевом листе присутствует прицеп
                        else if (avto.VehicleId == order.TrailerId)
                        {
                            bool update = false;
                            // если reportTrailerList содержит данные
                            if (reportTrailerList.Count > 0)
                            {
                                // проверить список на наличие прицепа в нем
                                foreach (ReportClass rtItem in reportTrailerList)
                                {
                                    // если прицеп есть в списке
                                    if (avto.VehicleId == rtItem.VehacleId)
                                    {
                                        // обновить данные о нем
                                        update = true;
                                        // пробег
                                        rtItem.ResultRun += item.WithTrailer;
                                    }
                                }
                            }
                            // если прицепа в списке еще нет
                            if (reportTrailerList.Count == 0 || !update)
                            {
                                // добавить прицеп в список
                                ServiceMileageClass service = new ServiceMileageClass();
                                service.GetServicemileageById(avto.VehicleId);
                                reportTrailerList.Add(new ReportClass(avto.VehicleId, avto.RegNumber, item.WithTrailer, 
                                    (endDate.Subtract(startDate).Days + 1), (cOrder.TimeIn.Subtract(cOrder.TimeOut).Days + 1)));
                            }
                        }
                        result = true;
                    }
                }
            }
            return result;
        }

        // Метод суммирование топлива по видам
        private void GetFuelSumm(int fuelType, float fuelFact, ref ReportClass fuelReport)
        {
            switch (fuelType)
            {
                case 1:
                    fuelReport.Disel += fuelFact;
                    break;
                case 2:
                    fuelReport.N80 += fuelFact;
                    break;
                case 3:
                    fuelReport.A92 += fuelFact;
                    break;
                case 4:
                    fuelReport.A95 += fuelFact;
                    break;
                case 5:
                    fuelReport.A98 += fuelFact;
                    break;
                case 6:
                    fuelReport.Kpg += fuelFact;
                    break;
                case 7:
                    fuelReport.Sug += fuelFact;
                    break;
                case 8:
                    fuelReport.Kerosin += fuelFact;
                    break;
                case 9:
                    fuelReport.Biodisel += fuelFact;
                    break;
                default:
                    break;
            }
        }

        // Метод подсчета эконмии и пережога по видам топлива (бензин/дизель)
        private void GetEconomyUneconomyFuelSumm(int fuelType, float fuelEconomy, float fuelUneconomy, 
            ref ReportClass fuelReport)
        {
            if (fuelType >= 2 && fuelType <= 5)
            {
                fuelReport.BenzinEconomy += fuelEconomy;
                fuelReport.BenzinUneconomy += fuelUneconomy;
            }
            else
            {
                fuelReport.DiselEconomy += fuelEconomy;
                fuelReport.DiselUneconomy += fuelUneconomy;
            }
        }
        // Метод вывода отчета о расходе топлива
        public void PrintResultFuel(RichTextBox resultRichTextBox, ref ReportClass fuelReport)
        {
            resultRichTextBox.Text = "";
            resultRichTextBox.Text += "Дизель".PadRight(78, '.') + fuelReport.Disel + "\r\n" + "\r\n";
            resultRichTextBox.Text += "Бензин Н80".PadRight(75, '.') + fuelReport.N80 + "\r\n" + "\r\n";
            resultRichTextBox.Text += "Бензин А92".PadRight(75, '.') + fuelReport.A92 + "\r\n" + "\r\n";
            resultRichTextBox.Text += "Бензин А95".PadRight(75, '.') + fuelReport.A95 + "\r\n" + "\r\n";
            resultRichTextBox.Text += "Бензин А98".PadRight(75, '.') + fuelReport.A98 + "\r\n" + "\r\n";
            resultRichTextBox.Text += "КПГ".PadRight(81, '.') + fuelReport.Kpg + "\r\n" + "\r\n";
            resultRichTextBox.Text += "СУГ".PadRight(81, '.') + fuelReport.Sug + "\r\n" + "\r\n";
            resultRichTextBox.Text += "Керосин".PadRight(78, '.') + fuelReport.Kerosin + "\r\n" + "\r\n";
            resultRichTextBox.Text += "Биодизель".PadRight(76, '.') + fuelReport.Biodisel + "\r\n" + "\r\n";
            resultRichTextBox.Text += "Масло".PadRight(79, '.') + fuelReport.OilRes + "\r\n";
        }

        // Метод вывода отчетов об интенсивности использования автотранспорта
        // и сводной ведомости учета работы машин
        public void PrintReports(ListView avtoRateList, ListView vedomostList, 
            ArrayList reportList, ArrayList reportTrailerList, List<int> typeList)
        {
            // создание экземпляра класса VehicleClass
            VehicleClass vehicle = new VehicleClass();
            // очистка списка отчетов об использовании автотранспорта
            avtoRateList.Items.Clear();
            // очистка сводной ведомости учета работы машин
            vedomostList.Items.Clear();
            ListViewItem lvi;
            // заполнение таблицы отчета использования автотранспорта данными
            foreach (ReportClass item in reportList)
            {
                lvi = new ListViewItem(item.VehicleModel);
                lvi.SubItems.Add(item.VehicleRegnumber);
                lvi.SubItems.Add(Convert.ToString(item.SpeedometrStart));
                lvi.SubItems.Add(Convert.ToString(item.SpeedometrFinish));
                lvi.SubItems.Add(Convert.ToString(item.ResultRun));
                lvi.SubItems.Add(Convert.ToString(item.FuelConsumptionNorma));
                lvi.SubItems.Add(Convert.ToString(item.FuelConsumptionFact));
                lvi.SubItems.Add(Convert.ToString(Math.Round(item.FuelEconomy, 2)));
                lvi.SubItems.Add(Convert.ToString(Math.Round(item.FuelUneconomy, 2)));
                lvi.SubItems.Add(Convert.ToString(item.WorkingDays));
                lvi.SubItems.Add(Convert.ToString(item.OilNorma));
                lvi.SubItems.Add(Convert.ToString(item.OilFact));
                avtoRateList.Items.Add(lvi);
            }
            // заполнение таблицы сводной ведомости учета работы машин данными
            int i = 1;
            // промежуточные значения
            float norma = 0f, fact = 0f, economy = 0f, uneconomy = 0f, oil = 0f;
            // итоговые значения
            float _norma = 0f, _fact = 0f, _economy = 0f, _uneconomy = 0f, _oil = 0f;
            // сортировка автомобилей по типам
            foreach (int rItem in typeList)
            {
                // проверка всех автомобилей в reportList
                foreach (ReportClass item in reportList)
                {
                    if (vehicle.GetVehicleType(rItem) == item.VehicleType)
                    {
                        lvi = new ListViewItem(Convert.ToString(i++));
                        lvi.SubItems.Add(item.VehicleType);
                        lvi.SubItems.Add(item.VehicleModel);
                        lvi.SubItems.Add(item.VehicleRegnumber);
                        lvi.SubItems.Add(Convert.ToString(item.PeriodDays));
                        lvi.SubItems.Add(Convert.ToString(item.WorkingDays));
                        lvi.SubItems.Add(Convert.ToString(item.SpeedometrLimit));
                        lvi.SubItems.Add(Convert.ToString(item.ResultRun));
                        lvi.SubItems.Add(Convert.ToString(item.WithCargo));
                        lvi.SubItems.Add(Convert.ToString(item.Cargo));
                        lvi.SubItems.Add(Convert.ToString(item.OnTrailer));
                        lvi.SubItems.Add(item.FuelType);
                        lvi.SubItems.Add(Convert.ToString(item.FuelConsumptionNorma));
                        lvi.SubItems.Add(Convert.ToString(item.FuelConsumptionFact));
                        lvi.SubItems.Add(Convert.ToString(Math.Round(item.FuelEconomy, 2)));
                        lvi.SubItems.Add(Convert.ToString(Math.Round(item.FuelUneconomy, 2)));
                        lvi.SubItems.Add(Convert.ToString(item.OilFact));

                        vedomostList.Items.Add(lvi);
                        // подсчет итоговых значений
                        norma += item.FuelConsumptionNorma;
                        fact += item.FuelConsumptionFact;
                        economy += item.FuelEconomy;
                        uneconomy += item.FuelUneconomy;
                        oil += item.OilFact;
                    }
                }
                // добавление итого после каждого типа
                string[] subItems = new string[] {"Итого:", "", "", "", "", "", "", "", "", "", "",
                        Convert.ToString(Math.Round(norma, 2)), Convert.ToString(Math.Round(fact, 2)),
                        Convert.ToString(Math.Round(economy, 2)), Convert.ToString(Math.Round(uneconomy, 2)),
                        Convert.ToString(oil)};
                lvi = new ListViewItem();
                lvi.SubItems.AddRange(subItems);
                lvi.BackColor = Color.Gainsboro;
                vedomostList.Items.Add(lvi);
                // подсчет итоговых значений
                _norma += norma;
                _fact += fact;
                _economy += economy;
                _uneconomy += uneconomy;
                _oil += oil;
                // обнуление итоговых значений
                norma = 0f;
                fact = 0f;
                economy = 0f;
                uneconomy = 0f;
                oil = 0f;
            }
            // вывод данных о прицепах
            // проверка всех прицепов в reportTrailerList
            foreach (ReportClass item in reportTrailerList)
            {
                lvi = new ListViewItem(Convert.ToString(i++));
                lvi.SubItems.Add("Прицеп");
                lvi.SubItems.Add(item.VehicleModel);
                lvi.SubItems.Add(item.VehicleRegnumber);
                lvi.SubItems.Add(Convert.ToString(item.PeriodDays));
                lvi.SubItems.Add(Convert.ToString(item.WorkingDays));
                lvi.SubItems.Add("");
                lvi.SubItems.Add(Convert.ToString(item.ResultRun));
                
                vedomostList.Items.Add(lvi);
            }
            // ВСЕГО ЗА ЧАСТЬ
            string[] _subItems = new string[] {"ВСЕГО:", "", "", "", "", "", "", "", "", "", "",
                    Convert.ToString(Math.Round(_norma, 2)), Convert.ToString(Math.Round(_fact, 2)),
                    Convert.ToString(Math.Round(_economy, 2)), Convert.ToString(Math.Round(_uneconomy, 2)),
                    Convert.ToString(_oil)};
            lvi = new ListViewItem();
            lvi.SubItems.AddRange(_subItems);
            lvi.BackColor = Color.DarkGray;
            vedomostList.Items.Add(lvi);
        }

        // Метод вычисления расхода топлива по норме
        private float CalculatePlanFuelConsumption(int runResult, NormaClass norma, 
            CompletedTravelOrderClass order)
        {
            float result = 0;
            // расчет расхода топлива по линейной норме
            result = (float)runResult / 100 * norma.Fuel;
            // прибавление повышающих коэффициентов
            result += order.Gorod100 / 100 * norma.Fuel * (norma.Gorod100 / 100);
            result += order.Gorod300 / 100 * norma.Fuel * (norma.Gorod300 / 100);
            result += order.Gorod1000 / 100 * norma.Fuel * (norma.Gorod1000 / 100);
            result += order.Bezdor / 100 * norma.Fuel * (norma.Bezdor / 100);
            result += order.Medl / 100 * norma.Fuel * (norma.Medl / 100);
            result += order.Ostan / 100 * norma.Fuel * (norma.Ostan / 100);
            result += order.Cond / 100 * norma.Fuel * (norma.Cond / 100);
            // прибавление дополнительных коэффициентов
            result = norma.Boost1 > 1 ? result * norma.Boost1 : result;
            result = norma.Boost2 > 1 ? result * norma.Boost2 : result;
            result = norma.Boost3 > 1 ? result * norma.Boost3 : result;
            // прибавление топлива на отопитель и генератор
            if (order.Otopitel > 0 && norma.Otopitel > 0)
                result += order.Otopitel * norma.Otopitel;
            if (order.Generator > 0 && norma.Generator > 0)
                result += order.Generator * norma.Generator;
            // вычитание понижающих коэффициентов
            result -= order.Track / 100 * norma.Fuel * (norma.Track / 100);
            // при наличии коэффициента зимних норм
            TravelOrderClass tOrder = new TravelOrderClass();
            tOrder.GetTravelOrderById((int)order.OrderId);
            if (tOrder.WinterCoefficient > 0)
                result = result * tOrder.WinterCoefficient;
            // применение дополнительного коэффициента при его наличии
            if (order.DopCoefficient > 0)
                result = result * order.DopCoefficient;
            return result;
        }

#endregion
    }

    // Класс реализации изображения диграммы расхода топлива
    class DiagramPaintClass
    {
        // Основные объекты для рисования       
        private Bitmap bmp = null;
        private Graphics graph = null;
        private Font objFont = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
        private Brush objBrush = Brushes.Black;
        private Pen objPenLine = new Pen(Color.Black, 1);

        // Размеры холста
        private int viX = 200;
        private int viY = 100;

        // Параметры для рисования круговой диаграммы
        private float vfDiamX = 100;
        private float vfDiamY = 100;
        private float vfXcirc = 100;
        private float vfYcirc = 100;

        // Массив предопределенных цветов для отображения легенды
        private Color[] color = {Color.LightGreen,Color.Chartreuse,Color.LimeGreen,
                          Color.Green,Color.DarkGreen,Color.DarkOliveGreen,
                          Color.LightPink,Color.LightSeaGreen,Color.LightCoral,
                          Color.DarkCyan,Color.Crimson,Color.CornflowerBlue,
                          Color.Chocolate,Color.CadetBlue,Color.BlueViolet,
                          Color.Maroon,Color.Blue,Color.Brown,Color.DarkBlue,
                          Color.Red,Color.Coral,Color.DarkRed, Color.DarkMagenta,
                          Color.DarkOrange,Color.DarkOrchid};

        // Массив предопределенных цветов для отображения круговой диаграммы
        private Brush[] br = {Brushes.LightGreen,Brushes.Chartreuse,Brushes.LimeGreen,
                          Brushes.Green,Brushes.DarkGreen,Brushes.DarkOliveGreen,
                          Brushes.LightPink,Brushes.LightSeaGreen,Brushes.LightCoral,
                          Brushes.DarkCyan,Brushes.Crimson,Brushes.CornflowerBlue,
                          Brushes.Chocolate,Brushes.CadetBlue,Brushes.BlueViolet,
                          Brushes.Maroon, Brushes.Blue,Brushes.Brown,Brushes.DarkBlue,
                          Brushes.Red,Brushes.Coral,Brushes.DarkRed,
                          Brushes.DarkMagenta, Brushes.DarkOrange,Brushes.DarkOrchid};

        // Массив значений для рисования графика
        private string[,] rgsValues = null;
        // Размер массива
        private int viMaxRg = 9;


        // Отступы от краев холста
        private int viDeltaaxisL = 50;
        private int viDeltaaxisR = 50;
        private int viDeltaaxisH = 20;

        // Конструктор
        public DiagramPaintClass(int a, int b)
        {
            bmp = new Bitmap(a, b);
            graph = Graphics.FromImage(bmp);
            viX = a;
            viY = b;
        }

        // Установка цвета фона диаграммы
        public void vSetBackground(Color bcl)
        {
            graph.Clear(bcl);
        }

#region Getters&Setters
        public Bitmap Bmp
        {
            get { return bmp; }
        }
        public int MaxRg
        {
            set { viMaxRg = value; }
        }
        public string[,] RgValue
        {
            set { rgsValues = value; }
        }
        public Font font
        {
            set { objFont = value; }
        }
        public Brush brush
        {
            set { objBrush = value; }
        }
        #endregion

#region Pen, Font, Brush
        // Цвет карандаша
        public void vSetPenColorLine(Color pcl)
        {
            if (objPenLine == null)
            {
                objPenLine = new Pen(Color.Black, 1);
            }
            objPenLine.Color = pcl;
        }
        // Установка толщины карандаша        
        public void vSetPenWidthLine(int penwidth)
        {
            if (objPenLine == null)
            {
                objPenLine = new Pen(Color.Black, 1);
            }
            objPenLine.Width = penwidth;
        }
#endregion

#region  vDravCircle3D
        // Параметры - Отступ от краев по X слева deltaaxisL, от краев по Y справа,
        // deltaaxisH - отступа сверху и снизу, толщина диаграммы viH, сдвиг сектора viDx, viDy
        public void vDravCircle3D(int deltaaxisL, int deltaaxisR, int deltaaxisH, int viH, int viDx, int viDy)
        {
            // отступы            
            viDeltaaxisL = deltaaxisL;
            viDeltaaxisR = deltaaxisR;
            viDeltaaxisH = deltaaxisH;
            float a = viX - (deltaaxisL + deltaaxisR);
            // нужен ли выброс сектора
            int viMov = 1;
            if (viDx == 0 && viDy == 0)
            {
                viMov = 0;
            }
            // диаметр
            vfDiamX = a;
            vfDiamY = viY - 2 * viDeltaaxisH;
            // центр элипса
            vfXcirc = deltaaxisL + a / 2;
            vfYcirc = viY / 2;
            graph.SmoothingMode = SmoothingMode.AntiAlias;
            float fSum = 0;
            string s = string.Empty;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                fSum += float.Parse(s);
            }
            float f = 0;
            float fBSum = 0;
            float fDeltaGrad = (fSum / (float)360);
            SolidBrush objBrush = new SolidBrush(Color.Aqua);
            float[] frgZn = new float[viMaxRg];
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                frgZn[i] = float.Parse(s);
            }
            // рисование диаграммы против часовой стрелки со штриховкой до 90 градусав по часовой
            // штриховка убирается каждым следующим сектором от сектора предыдущего
            // в первом нарисованном секторе она сохраняетсяна случай сдвига первого по часовой стрелке
            for (int i = viMaxRg - 1; i >= 0; i--)
            {
                if (i != viMaxRg - 1 && fBSum < 90) break;
                // f в градусах  fBSum в градусах
                f = frgZn[i] / fDeltaGrad;
                if (i == viMaxRg - 1)
                    fBSum = 360 - f;
                else
                    fBSum -= f;
                // для цвета
                int j = i % br.Length;
                float k = f;
                if (f < 1)
                    k = 1;
                if (i != 0)
                {
                    if ((fBSum > 90 && fBSum < 180) || i == viMaxRg - 1)
                    {
                        for (int d = 0; d < viH; d++)
                        {
                            graph.FillPie(new HatchBrush(HatchStyle.Percent25, color[j]),
                                  vfXcirc - a / 2, vfYcirc - vfDiamY / 2 + d,
                                         vfDiamX, vfDiamY, fBSum, k);
                        }
                    }
                    objBrush.Color = color[j];
                    graph.FillPie(objBrush, vfXcirc - a / 2, vfYcirc - vfDiamY / 2,
                           vfDiamX, vfDiamY, fBSum, k);
                }
            }
            // рисование до 90 градусов без первого сегмента в случае необходимости 
            // сдвига первого по часовой стрелке
            fBSum = 0;
            for (int i = viMov; i < viMaxRg; i++)
            {
                // f в градусах  fBSum в градусах
                f = frgZn[i] / fDeltaGrad;
                if (i == 1)
                    fBSum = frgZn[0] / fDeltaGrad;
                // для цвета
                int j = i % br.Length;
                float k = f;
                if (f < 1)
                    k = 1;
                if (fBSum < 90)
                {
                    for (int d = 0; d < viH; d++)
                    {
                        graph.FillPie(new HatchBrush(HatchStyle.Percent25, color[j]), vfXcirc - a / 2,
                            vfYcirc - vfDiamY / 2 + d,
                              vfDiamX, vfDiamY, fBSum, k);
                    }
                    objBrush.Color = color[j];
                    graph.FillPie(objBrush, vfXcirc - a / 2, vfYcirc - vfDiamY / 2,
                    vfDiamX, vfDiamY, fBSum, k);
                }
                else
                    break;
                fBSum += f;
            }
            // прорисовка сдвинутого сектора при необходимости
            if (viMov == 1)
            {
                f = frgZn[0] / fDeltaGrad;
                fBSum = 0;
                float k1 = f;
                if (f < 1) k1 = 1;
                for (int d = 0; d < viH; d++)
                {
                    graph.FillPie(new HatchBrush(HatchStyle.Percent25, color[0]),
                     vfXcirc - a / 2 + viDx, vfYcirc - vfDiamY / 2 + d - viDy,
                        vfDiamX, vfDiamY, fBSum, k1);
                }
                objBrush.Color = color[0];
                graph.FillPie(objBrush, vfXcirc - a / 2 + viDx, vfYcirc - vfDiamY / 2 - viDy,
                vfDiamX, vfDiamY, fBSum, k1);
            }
        }
        #endregion
        
        // Метод смены шрифта
        private void vSetFont(string name, float size, bool bold)
        {
            if (objFont != null)
                objFont = null;
            if (bold)
                objFont = new Font(name, size, FontStyle.Bold);
            else
                objFont = new Font(name, size);
        }

        // Метод написания текста легенды
        public void vDravTextKeyCircle(bool vfGde)
        {
            float fSum = 0;
            float f = 0;
            string s = string.Empty;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                fSum += float.Parse(s);
            }
            // сдвиг от круговой диаграммы
            float vfSdvig = vfXcirc + vfDiamX / 2;
            vfSdvig += (viX - vfSdvig) / 5;
            // высота места для легенды
            // на одну строку по высоте отводится - + 1 на заголовок
            float vfHg = viY / (viMaxRg + 2);
            vSetFont("Microsoft Sans Serif", 12, true);
            if (viMaxRg > 100)
            {
                graph.DrawString("Легенда не может быть размещена",
                 objFont, Brushes.DarkBlue, vfSdvig + (viX - vfSdvig) / 10, objFont.Size);
            }
            else
            {
                // шрифт в 2 раза меньше места на строку надписи
                if (viMaxRg > 15)
                    vSetFont("Microsoft Sans Serif", (vfHg / 2), true);
                
                else
                {
                    if (viMaxRg > 10)
                        vSetFont("Microsoft Sans Serif", (vfHg / 3), true);
                    else
                        vSetFont("Microsoft Sans Serif", (vfHg / 3) - 1, true);
                }
                if (vfGde)
                {
                    graph.DrawString("Пояснения к графику", objFont,
                        Brushes.DarkBlue, vfSdvig, objFont.Size);
                }
                else
                {
                    graph.DrawString("Пояснения к графику", objFont,
                        objBrush, vfSdvig, objFont.Size);
                }
                if (viMaxRg > 15)
                    vSetFont("Microsoft Sans Serif", (vfHg / 2) + 1, true);
                else
                {
                    if (viMaxRg > 10)
                        vSetFont("Microsoft Sans Serif", (vfHg / 4) + 1, true);
                    else
                        vSetFont("Microsoft Sans Serif", (vfHg / 5) + 1, true);
                }
                for (int i = 0; i < rgsValues.Length / 2; i++)
                {
                    Brush brTxt = null;
                    int j = i % br.Length;
                    if (vfGde) brTxt = br[j];
                    else brTxt = objBrush;
                    vSetPenColorLine(color[j]);
                    vSetPenWidthLine((int)objFont.Size);
                    graph.DrawEllipse(objPenLine, vfSdvig, vfHg * (i + 2), objFont.Size, objFont.Size);
                    f = float.Parse(rgsValues[i, 0]);
                    f = (f * 100) / fSum;
                    graph.DrawString(rgsValues[i, 1], objFont,
                        brTxt, vfSdvig + 1 * (viX - vfSdvig) / 5, vfHg * (i + 2));
                    graph.DrawString(f.ToString("0.0") + "%", objFont,
                         brTxt, vfSdvig + 3 * (viX - vfSdvig) / 5, vfHg * (i + 2));
                }
            }
        }
    }
}
