using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // Класс, реализующий функционал карточки учета работы машины
    class CardMachineWorkClass
    {
        // переменные класса
        //private string _orgNumber;          // номер воинской части
        //private string _chiefPost;          // должность подписывающего сводную ведомость
        //private string _chiefRank;          // воинское звание подписывающего сводную ведомость
        //private string _chiefName;          // фамилия подписывающего сводную ведомость
        //private string _makePost;           // должность составившего сводную ведомость
        //private string _makeRank;           // воинское звание составившего сводную ведомость
        //private string _makeName;           // фамилия составившего сводную ведомость
        private int _vehicleId;             // Id автомобиля
        private int[] _vehicleIds;          // массив с Id автомобилей
        private string _vehicleModel;       // марка автомобиля
        private int _vehicleType;           // тип автомобиля
        private string _vehicleRegNumber;   // госномер автомобиля
        private int _month;                 // месяц составления карточки
        private int _year;                  // год составления карточки
        private int _days;                  // количество дней в отчетном месяце
        private int _speedometerStart;      // показания спидометра на начало месяца
        private int _speedometerEnd;        // показания спидометра на конец месяца
        private int _resultOdometr;         // общий пробег за отчетный период
        private int _planOdometr;           // пробег по плану за отчетный период
        //**  ДАННЫЕ ДЛЯ ТАБЛИЦЫ  **//
        private DateTime _orderDate;        // дата закрытия путевого листа
        private string _orderNumber;        // массив с номерами путевых листов
        private int _resultOrderOdometr;    // общий пробег по путевому листу
        private int _speedometerOut;        // спидометр при выезде
        private int _speedometerIn;         // спидометр возвращение
        private int _withCargo;             // пробег с грузом
        private int _withTrailer;           // общий пробег с прицепом
        private int _cargoOnMachine;        // перевезено груза на машине
        private int _cargoOnTrailer;        // перевезено груза на прицепе
        private float _refuel;              // получено горючего по путевому листу
        //**  ДАННЫЕ ПОСЛЕ ТАБЛИЦЫ  **//
        private float _fuelBalanceStart;    // остаток топлива на 1-е число месяца
        private float _resultRefuel;        // получено горючего за месяц
        private float _fuelBalanceEnd;      // остаток топлива по окончании месяца
        private float _fuelConsumption;     // расход топлива за месяц
        private float _fuelNorma;           // расход топлива по норме
        private float _fuelEconomy;         // экномия топлива за отчетный период
        //private float _fuelUneconomy;       // перерасход топлива за отчетный период
        private int _workingDays;           // машино-дни в работе
        //** ДАННЫЕ ДЛЯ РАСЧЕТА РАСХОДА ТОПЛИВА ПО НОРМЕ **//
        private int? _trailerId;            // Id прицепа
        private int _gorod100;              // город с населением 100 тыс.
        private int _gorod300;              // город с населением 300 тыс.
        private int _gorod1000;             // город с населением 1 млн
        private int _track;                 // по трассе
        private int _bezdor;                // бездорожье
        private int _ostan;                 // с остановками
        private int _medl;                  // медленно
        private float _otopitel;            // отопитель
        private float _generator;           // генератор
        private int _cond;                  // кондиционер
        private float _dopCoefficient;      // дополнительный коэффициент
        private float _winterCoefficient;   // коэффициент зимних норм

        private ArrayList _orderList;       // список путевых листов

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;charset=utf8";

        // пустой конструктор
        public CardMachineWorkClass()
        {
        }

        // КОНСТРУКТОР с некторыми значениями
        public CardMachineWorkClass(int month, int year)
        {
            _month = month;
            _year = year;

            _days = GetDaysInMonth(year, month);
        }
        //public CardMachineWorkClass(string orgNumber, string chiefPost, string chiefRank, 
        //    string chiefName, string makePost, string makeRank, string makeName, int month, int year)
        //{
        //    _orgNumber = orgNumber;
        //    _chiefPost = chiefPost;
        //    _chiefRank = chiefRank;
        //    _chiefName = chiefName;
        //    _makePost = makePost;
        //    _makeRank = makeRank;
        //    _makeName = makeName;
        //    _month = month;
        //    _year = year;

        //    _days = GetDaysInMonth(year, month);
        //}

#region Getters&Setters

        //public string OrgNumber
        //{
        //    get { return _orgNumber; }
        //    set { _orgNumber = value; }
        //}

        //public string ChiefPost
        //{
        //    get { return _chiefPost; }
        //    set { _chiefPost = value; }
        //}

        //public string ChiefRank
        //{
        //    get { return _chiefRank; }
        //    set { _chiefRank = value; }
        //}

        //public string ChiefName
        //{
        //    get { return _chiefName; }
        //    set { _chiefName = value; }
        //}

        //public string MakePost
        //{
        //    get { return _makePost; }
        //    set { _makePost = value; }
        //}

        //public string MakeRank
        //{
        //    get { return _makeRank; }
        //    set { _makeRank = value; }
        //}

        //public string MakeName
        //{
        //    get { return _makeName; }
        //    set { _makeName = value; }
        //}

        public int VehicleId
        {
            get { return _vehicleId; }
            set { _vehicleId = value; }
        }

        public int[] VehicleIds
        {
            get => _vehicleIds;
            set => _vehicleIds = value;
        }

        public string VehicleModel
        {
            get { return _vehicleModel; }
            set { _vehicleModel = value; }
        }

        public int VehicleType
        {
            get { return _vehicleType; }
            set { _vehicleType = value; }
        }

        public string VehicleRegNumber
        {
            get { return _vehicleRegNumber; }
            set { _vehicleRegNumber = value; }
        }
        
        public int Month
        {
            get => _month;
            set => _month = value;
        }

        public int Year
        {
            get => _year;
            set => _year = value;
        }

        public int Days
        {
            get { return _days; }
            set { _days = value; }
        }

        public int SpeedometerStart
        {
            get { return _speedometerStart; }
            set { _speedometerStart = value; }
        }

        public int SpeedometerEnd
        {
            get { return _speedometerEnd; }
            set { _speedometerEnd = value; }
        }

        public int ResultOdometr
        {
            get { return _resultOdometr; }
            set { _resultOdometr = value; }
        }

        public int PlanOdometr
        {
            get { return _planOdometr; }
            set { _planOdometr = value; }
        }

        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }

        public int SpeedometerOut
        {
            get => _speedometerOut;
            set => _speedometerOut = value;
        }

        public int SpeedometerIn
        {
            get => _speedometerIn;
            set => _speedometerIn = value;
        }

        public int ResultOrderOdometr
        {
            get { return _resultOrderOdometr; }
            set { _resultOrderOdometr = value; }
        }

        public int WithCargo
        {
            get { return _withCargo; }
            set { _withCargo = value; }
        }

        public int WithTrailer
        {
            get { return _withTrailer; }
            set { _withTrailer = value; }
        }

        public int CargoOnMachine
        {
            get { return _cargoOnMachine; }
            set { _cargoOnMachine = value; }
        }

        public int CargoOnTrailer
        {
            get { return _cargoOnTrailer; }
            set { _cargoOnTrailer = value; }
        }

        public float Refuel
        {
            get { return _refuel; }
            set { _refuel = value; }
        }

        public float FuelBalanceStart
        {
            get { return _fuelBalanceStart; }
            set { _fuelBalanceStart = value; }
        }

        public float ResultRefuel
        {
            get { return _resultRefuel; }
            set { _resultRefuel = value; }
        }

        public float FuelBalanceEnd
        {
            get { return _fuelBalanceEnd; }
            set { _fuelBalanceEnd = value; }
        }

        public float FuelConsumption
        {
            get { return _fuelConsumption; }
            set { _fuelConsumption = value; }
        }

        public float FuelNorma
        {
            get { return _fuelNorma; }
            set { _fuelNorma = value; }
        }

        public float FuelEconomy
        {
            get { return _fuelEconomy; }
            set { _fuelEconomy = value; }
        }

        //public float FuelUneconomy
        //{
        //    get { return _fuelUneconomy; }
        //    set { _fuelUneconomy = value; }
        //}

        public int WorkingDays
        {
            get { return _workingDays; }
            set { _workingDays = value; }
        }

        public int? TrailerId
        {
            get => _trailerId;
            set => _trailerId = value;
        }

        public int Gorod100
        {
            get => _gorod100;
            set => _gorod100 = value;
        }

        public int Gorod300
        {
            get => _gorod300;
            set => _gorod300 = value;
        }

        public int Gorod1000
        {
            get => _gorod1000;
            set => _gorod1000 = value;
        }

        public int Track
        {
            get => _track;
            set => _track = value;
        }

        public int Bezdor
        {
            get => _bezdor;
            set => _bezdor = value;
        }

        public int Ostan
        {
            get => _ostan;
            set => _ostan = value;
        }

        public int Medl
        {
            get => _medl;
            set => _medl = value;
        }

        public float Otopitel
        {
            get => _otopitel;
            set => _otopitel = value;
        }

        public float Generator
        {
            get => _generator;
            set => _generator = value;
        }

        public int Cond
        {
            get => _cond;
            set => _cond = value;
        }

        public float DopCoefficient
        {
            get => _dopCoefficient;
            set => _dopCoefficient = value;
        }

        public float WinterCoefficient
        {
            get => _winterCoefficient;
            set => _winterCoefficient = value;
        }

        public string ConnStr
        {
            get => connStr;
            set => connStr = value;
        }

        public ArrayList OrderList
        {
            get => _orderList;
            set => _orderList = value;
        }

        
#endregion

#region Functions
        // Функция получения общего количества дней в выбранном месяце
        private int GetDaysInMonth(int year, int month)
        {
            return new DateTime(year, month, 1).AddMonths(1).AddDays(-1).Day;
        }

        // Функция получение автомобиля по его госномеру
        public void GetOneVehicle(string vehicle)
        {
            string regNumber = "";
            int index = vehicle.IndexOf("*");
            // получение регистрационного номера автомобиля
            regNumber = vehicle.Substring(index + 2, vehicle.Length - (index + 2));
            
            // создание экземпляра класса VehicleClass
            VehicleClass oneVehicle = new VehicleClass();
            oneVehicle.GetVehicleByRegnumber(regNumber);

            _vehicleId = oneVehicle.VehicleId;
            _vehicleModel = oneVehicle.Model;
            _vehicleType = oneVehicle.Type;
            _vehicleRegNumber = oneVehicle.RegNumber;
        }

        // Функция получения показаний одометра на начало и конец месяца
        public int[] GetSatrEndOdometr(int year, int month, int days, ArrayList list, DateTime flagDate)
        {
            int min = 0, max = 0; // минимальное и максимальное значения
            if (list.Count > 0)
            {
                CardMachineWorkClass card = new CardMachineWorkClass();
                card = (CardMachineWorkClass)list[0];
                DateTime minDate = card.OrderDate;
                DateTime maxDate = minDate;
                foreach (CardMachineWorkClass obj in list)
                {
                    if (obj.OrderDate < minDate)
                    {
                        minDate = obj.OrderDate;
                        min = obj.SpeedometerOut;
                        FuelBalanceStart = obj.FuelBalanceStart;
                    }

                    if (obj.OrderDate > maxDate)
                    {
                        maxDate = obj.OrderDate;
                        max = obj.SpeedometerIn;
                        FuelBalanceEnd = obj.FuelBalanceEnd;
                    }
                }
            }
            else if (new DateTime(year, month, days).AddMonths(-1) > flagDate)
            {
                int[] minMax = new int[2];
                DateTime date = new DateTime(year, month, days).AddMonths(-1);
                CardMachineWorkClass orderCard = new CardMachineWorkClass();
                orderCard.OrderList = orderCard.GetTravelOrderByVehicleIdAndDate(_vehicleId, date, true);
                minMax = GetSatrEndOdometr(date.Year, date.Month, date.Day, orderCard.OrderList, flagDate);
                min = minMax[1];
                max = minMax[1];
            }
            return new[] {min, max};
        }

        // Функция вычисления расхода топлива по норме
        private float CalculateFuelNorma(CardMachineWorkClass card)
        {
            NormaClass norma = new NormaClass();
            norma.GetNormaById(_vehicleId);
            return CalculatePlanFuelConsumption(norma, card);
        }

        // Метод вычисления планируемого расхода топлива по маршруту
        private float CalculatePlanFuelConsumption(NormaClass norma, CardMachineWorkClass card)
        {
            float result = 0;
            // расчет расхода топлива по линейной норме или по норме с прицепом
            result = card.TrailerId == 0 ? card.ResultOrderOdometr / 100 * norma.Fuel :
                card.ResultOrderOdometr / 100 * norma.Trailer;
            // прибавление повышающих коэффициентов
            result += card.Gorod100 / 100 * norma.Fuel * (norma.Gorod100 / 100);
            result += card.Gorod300 / 100 * norma.Fuel * (norma.Gorod300 / 100);
            result += card.Gorod1000 / 100 * norma.Fuel * (norma.Gorod1000 / 100);
            result += card.Bezdor / 100 * norma.Fuel * (norma.Bezdor / 100);
            result += card.Medl / 100 * norma.Fuel * (norma.Medl / 100);
            result += card.Ostan / 100 * norma.Fuel * (norma.Ostan / 100);
            result += card.Cond / 100 * norma.Fuel * (norma.Cond / 100);
            // прибавление дополнительных коэффициентов
            result = norma.Boost1 > 1 ? result * norma.Boost1 : result;
            result = norma.Boost2 > 1 ? result * norma.Boost2 : result;
            result = norma.Boost3 > 1 ? result * norma.Boost3 : result;
            // прибавление топлива на отопитель и генератор
            if (card.Otopitel > 0 && norma.Otopitel > 0)
                result += card.Otopitel * norma.Otopitel;
            if (card.Generator > 0 && norma.Generator > 0)
                result += card.Generator * norma.Generator;
            // вычитание понижающих коэффициентов
            result -= card.Track / 100 * norma.Fuel * (norma.Track / 100);
            // при наличии коэффициента зимних норм
            if (card.WinterCoefficient > 0)
                result = result * card.WinterCoefficient;
            // применение дополнительного коэффициента при его наличии
            if (card.DopCoefficient > 0)
                result = result * card.DopCoefficient;
            return result;
        }

        // Метод расчета экономии/пережога топлива
        private float CalculateSavings()
        {
            float savings = 0;
            if (FuelNorma > 0 && FuelConsumption > 0)
                savings = FuelConsumption - FuelNorma;
            return savings;
        }

        // Функция расчета машино-дней в работе
        private int CalculateWorkingsDays(TimeSpan resTime)
        {
            int result = 0;
            result = resTime.Days < 1 && resTime.Hours > 0 ? 1 : resTime.Days + 1;
            return result;
        }

#endregion

#region DBfunctions

        // Функция получения заполненного путевого листа из БД по Id автомобиля и дате возвращения (месяц и год)
        public ArrayList GetTravelOrderByVehicleIdAndDate(int veId, DateTime date, bool flag)
        {
            // строка запроса на выбор из таблиц TravelOrder и CompletedTravelOrderClass данных по order_Id
            string connectionStr = "SELECT * FROM travelorder JOIN completedtravelorder ON " +
                                   "travelorder.order_Id = completedtravelorder.order_Id " +
                                   "WHERE travelorder.vehicle_Id = @VehicleId AND travelorder.order_completed_flag = @Flag " +
                                   "AND completedtravelorder.completed_time_in < @MaxDate " +
                                   "AND completedtravelorder.completed_time_in > @MinDate";
            // создание списка структур для записи данных из баз
            ArrayList orderList = new ArrayList();
            // создание объекта для подключения к БД
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@VehicleId", veId);
                command.Parameters.AddWithValue("@MaxDate", date.AddDays(1));
                command.Parameters.AddWithValue("@MinDate", date.AddMonths(-1));
                command.Parameters.AddWithValue("@Flag", flag);
                // объект для чтения ответа сервера
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчное считывание данных
                    {
                        CardMachineWorkClass card = new CardMachineWorkClass();
                        card.OrderDate = reader.GetDateTime(25);
                        card.OrderNumber = reader.GetString(6).Trim();
                        card.SpeedometerOut = reader.GetInt32(8);
                        card.SpeedometerIn = reader.GetInt32(22);
                        card.ResultOrderOdometr = card.SpeedometerIn - card.SpeedometerOut;
                        card.WithCargo = reader.GetInt32(35);
                        card.CargoOnTrailer = reader.GetInt32(38);
                        card.CargoOnMachine = reader.GetInt32(37);
                        card.CargoOnTrailer = reader.GetInt32(39);
                        card.FuelBalanceStart = reader.GetFloat(11);
                        card.FuelBalanceEnd = reader.GetFloat(26);
                        card.Refuel = reader.GetFloat(27);
                        card.FuelConsumption = card.FuelBalanceStart + card.Refuel - card.FuelBalanceEnd;
                        // вычисление расхода топлива по норме, экономия или перерасход
                        int? tmpId = null;
                        if (!reader.IsDBNull(4))
                            tmpId = reader.GetInt32(4);
                        card.TrailerId = tmpId;
                        card.Gorod100 = reader.GetInt32(28);
                        card.Gorod300 = reader.GetInt32(29);
                        card.Gorod1000 = reader.GetInt32(30);
                        card.Track = reader.GetInt32(31);
                        card.Bezdor = reader.GetInt32(32);
                        card.Ostan = reader.GetInt32(33);
                        card.Medl = reader.GetInt32(34);
                        card.Otopitel = reader.GetFloat(40);
                        card.Generator = reader.GetFloat(41);
                        card.Cond = reader.GetInt32(42);
                        card.WinterCoefficient = reader.GetFloat(10);
                        card.DopCoefficient = reader.GetFloat(43);
                        card.FuelNorma = card.CalculateFuelNorma(card); // расход по норме
                        // экономия или пережог
                        card.FuelEconomy = card.CalculateSavings();
                        TimeSpan res = reader.GetDateTime(25).Subtract(reader.GetDateTime(24));
                        card.WorkingDays = CalculateWorkingsDays(res);
                        orderList.Add(card);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }

            return orderList;
        }

#endregion
    }
}
