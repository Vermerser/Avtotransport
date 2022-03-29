using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // Путевой лист – класс реализует функционал действий с данными о путевых листах
    class TravelOrderClass
    {
        // переменные класса
        private int _orderId;                // Id путевого листа
        private int? _itineraryId;           // Id маршрута
        private int? _driverId;              // Id водителя
        private int? _vehicleId;             // Id автомобиля
        private int? _trailerId;             // Id прицепа
        private string _number;              // номер
        private DateTime _date;              // дата с
        private DateTime _validityDate;      // дата по
        private int _speedometerOut;         // спидометр при выезде
        private int _motoOut;                // моточасы
        private float _winterCoefficient;    // коэффициент зимних норм
        private float _fuelBalance;          // остаток топлива
        private float _fuelCharge;           // расход топлива
        private string _customer;            // заказчик (старший машины)
        private DateTime _timeOut;           // время выезда
        private DateTime _timeIn;            // время возвращения
        private string _transportationKind;  // вид перевозки
        private string _dopInfo;             // дополнительная информация
        private bool _completedFlag;         // путевой лист заполнен
        private bool _lockflag;              // блокировка от редактирования

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;charset=utf8";

        // пустой конструктор
        public TravelOrderClass()
        {
        }

        // конструктор с переменными класса
        public TravelOrderClass(int orderId, int? itineraryId, int? driverId, int? vehicleId, 
            int? trailerId, string number, DateTime date, DateTime validityDate, 
            int speedometerOut, int motoOut, float winterCoefficient, float fuelBalance, 
            float fuelCharge, string customer, DateTime timeOut, DateTime timeIn, 
            string transportationKind, string dopInfo, bool completedFlag, bool lockflag)
        {
            this._orderId = orderId;
            this._itineraryId = itineraryId;
            this._driverId = driverId;
            this._vehicleId = vehicleId;
            this._trailerId = trailerId;
            this._number = number;
            this._date = date;
            this._validityDate = validityDate;
            this._speedometerOut = speedometerOut;
            this._motoOut = motoOut;
            this._winterCoefficient = winterCoefficient;
            this._fuelBalance = fuelBalance;
            this._fuelCharge = fuelCharge;
            this._customer = customer;
            this._timeOut = timeOut;
            this._timeIn = timeIn;
            this._transportationKind = transportationKind;
            this._dopInfo = dopInfo;
            this._completedFlag = completedFlag;
            this._lockflag = lockflag;
        }

#region Getters&Setters&ToString

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        public int? ItineraryId
        {
            get { return _itineraryId; }
            set { _itineraryId = value; }
        }

        public int? DriverId
        {
            get { return _driverId; }
            set { _driverId = value; }
        }

        public int? VehicleId
        {
            get { return _vehicleId; }
            set { _vehicleId = value; }
        }

        public int? TrailerId
        {
            get { return _trailerId; }
            set { _trailerId = value; }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public DateTime ValidityDate
        {
            get { return _validityDate; }
            set { _validityDate = value; }
        }

        public int SpeedometerOut
        {
            get { return _speedometerOut; }
            set { _speedometerOut = value; }
        }

        public int MotoOut
        {
            get { return _motoOut; }
            set { _motoOut = value; }
        }

        public float WinterCoefficient
        {
            get { return _winterCoefficient; }
            set { _winterCoefficient = value; }
        }

        public float FuelBalance
        {
            get { return _fuelBalance; }
            set { _fuelBalance = value; }
        }

        public float FuelCharge
        {
            get { return _fuelCharge; }
            set { _fuelCharge = value; }
        }

        public string Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public DateTime TimeOut
        {
            get { return _timeOut; }
            set { _timeOut = value; }
        }

        public DateTime TimeIn
        {
            get { return _timeIn; }
            set { _timeIn = value; }
        }

        public string TransportationKind
        {
            get { return _transportationKind; }
            set { _transportationKind = value; }
        }

        public string DopInfo
        {
            get { return _dopInfo; }
            set { _dopInfo = value; }
        }

        public bool CompletedFlag
        {
            get { return _completedFlag; }
            set { _completedFlag = value; }
        }

        public bool Lockflag
        {
            get { return _lockflag; }
            set { _lockflag = value; }
        }

        public override string ToString()
        {
            return $"OrderId: {_orderId}, ItineraryId: {_itineraryId}, DriverId: {_driverId}, " +
                   $"VehicleId: {_vehicleId}, TrailerId: {_trailerId}, Number: {_number}, " +
                   $"Date: {_date}, ValidityDate: {_validityDate}, SpeedometerOut: {_speedometerOut}, " +
                   $"MotoOut: {_motoOut}, WinterCoefficient: {_winterCoefficient}, FuelBalance: {_fuelBalance}, " +
                   $"FuelCharge: {_fuelCharge}, Customer: {_customer}, TimeOut: {_timeOut}, " +
                   $"TimeIn: {_timeIn}, TransportationKind: {_transportationKind}, DopInfo: {_dopInfo}, " +
                   $"CompletedFlag: {_completedFlag}, Lockflag: {_lockflag}";
        }

        #endregion
#region DBfunctions
        // Функция чтения данных из таблицы TravelOrder базы данных
        public ArrayList ReadTravelOrderData()
        {
            // строка запроса на выбор из таблицы TravelOrder данных
            string connectionStr = "SELECT * FROM travelorder";
            // создание списка структур для записи данных из базы
            ArrayList resultList = new ArrayList();
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // объект для чтения ответа сервера
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчное считывание данных
                    {
                        int? tmp1 = null, tmp2 = null, tmp3 = null, tmp4 = null;
                        if (!reader.IsDBNull(1))
                            tmp1 = reader.GetInt32(1);
                        if (!reader.IsDBNull(2))
                            tmp2 = reader.GetInt32(2);
                        if (!reader.IsDBNull(3))
                            tmp3 = reader.GetInt32(3);
                        if (!reader.IsDBNull(4))
                            tmp4 = reader.GetInt32(4);
                        resultList.Add(new TravelOrderClass(reader.GetInt32(0), tmp1, tmp2, tmp3, tmp4,
                            reader.GetString(5).Trim(), reader.GetDateTime(6), reader.GetDateTime(7), 
                            reader.GetInt32(8), reader.GetInt32(9), reader.GetFloat(10),
                            reader.GetFloat(11), reader.GetFloat(12), reader.GetString(13).Trim(), 
                            reader.GetDateTime(14), reader.GetDateTime(15), reader.GetString(16).Trim(), 
                            reader.GetString(17).Trim(), reader.GetBoolean(18), reader.GetBoolean(19)));
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
            return resultList;
        }

        // Функция получения путевого листа из БД по Id
        public void GetTravelOrderById(int toId)
        {
            // строка запроса на выбор из таблицы TravelOrder данных по order_Id
            string connectionStr = $"SELECT * FROM travelorder WHERE order_Id = {toId}";
            // создание объекта для подключения к БД
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // объект для чтения ответа сервера
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчное считывание данных
                    {
                        int? tmp = null;
                        OrderId = reader.GetInt32(0);
                        if (!reader.IsDBNull(1))
                            tmp = reader.GetInt32(1);
                        ItineraryId = tmp;
                        tmp = null;
                        if (!reader.IsDBNull(2))
                            tmp = reader.GetInt32(2);
                        DriverId = tmp;
                        tmp = null;
                        if (!reader.IsDBNull(3))
                            tmp = reader.GetInt32(3);
                        VehicleId = tmp;
                        tmp = null;
                        if (!reader.IsDBNull(4))
                            tmp = reader.GetInt32(4);
                        TrailerId = tmp;
                        Number = reader.GetString(5).Trim();
                        Date = reader.GetDateTime(6);
                        ValidityDate = reader.GetDateTime(7);
                        SpeedometerOut = reader.GetInt32(8);
                        MotoOut = reader.GetInt32(9);
                        WinterCoefficient = reader.GetFloat(10);
                        FuelBalance = reader.GetFloat(11);
                        FuelCharge = reader.GetFloat(12);
                        Customer = reader.GetString(13).Trim();
                        TimeOut = reader.GetDateTime(14);
                        TimeIn = reader.GetDateTime(15);
                        TransportationKind = reader.GetString(16).Trim();
                        DopInfo = reader.GetString(17).Trim();
                        CompletedFlag = reader.GetBoolean(18);
                        Lockflag = reader.GetBoolean(19);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция получения путевого листа из БД по order_number
        public void GetTravelOrderByNumber(int number)
        {
            // строка запроса на выбор из таблицы TravelOrder
            string connectionStr = $"SELECT * FROM travelorder WHERE order_number = {number}";
            // создание объекта для подключения к БД
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // объект для чтения ответа сервера
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчное считывание данных
                    {
                        OrderId = reader.GetInt32(0);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция добавления данных в таблицу TravelOrder БД
        public void AddDataInTravelOrderTable(TravelOrderClass newTravelOrder)
        {
            string columns = "itinerary_Id, driver_Id, vehicle_Id, trailer_Id, order_number, order_date, " +
                             "order_validitydate, order_speedometer_out, order_moto_out, order_winter_coefficient, " +
                             "order_fuelbalance, order_fuel_charge, order_customer, order_time_out, order_time_in, " +
                             "order_transportation_kind, order_dopinfo, order_completed_flag, order_lockflag";
            // строка запроса на добавление в таблицу TravelOrder данных
            string connectionStr = $"INSERT INTO travelorder ({columns}) VALUES (@ItineraryId, @DriverId, @VehicleId, @TrailerId, " +
                                   $"@Number, @Date, @ValidityDate, @SpeedometerOut, @MotoOut, @WinterCoefficient, " +
                                   $"@FuelBalance, @FuelCharge, @Customer, @TimeOut, @TimeIn, @TransportationKind, " +
                                   $"@DopInfo, @CompletedFlag, @Lockflag)";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                if (newTravelOrder.ItineraryId == 0)
                    command.Parameters.AddWithValue("@ItineraryId", null);
                else
                    command.Parameters.AddWithValue("@ItineraryId", newTravelOrder.ItineraryId);
                if (newTravelOrder.DriverId == 0)
                    command.Parameters.AddWithValue("@DriverId", null);
                else
                    command.Parameters.AddWithValue("@DriverId", newTravelOrder.DriverId);
                if (newTravelOrder.VehicleId == 0)
                    command.Parameters.AddWithValue("@VehicleId", null);
                else
                    command.Parameters.AddWithValue("@VehicleId", newTravelOrder.VehicleId);
                if (newTravelOrder.TrailerId == 0)
                    command.Parameters.AddWithValue("@TrailerId", null);
                else
                    command.Parameters.AddWithValue("@TrailerId", newTravelOrder.TrailerId);
                command.Parameters.AddWithValue("@Number", newTravelOrder.Number);
                command.Parameters.AddWithValue("@Date", newTravelOrder.Date);
                command.Parameters.AddWithValue("@ValidityDate", newTravelOrder.ValidityDate);
                command.Parameters.AddWithValue("@SpeedometerOut", newTravelOrder.SpeedometerOut);
                command.Parameters.AddWithValue("@MotoOut", newTravelOrder.MotoOut);
                command.Parameters.AddWithValue("@WinterCoefficient", newTravelOrder.WinterCoefficient);
                command.Parameters.AddWithValue("@FuelBalance", newTravelOrder.FuelBalance);
                command.Parameters.AddWithValue("@FuelCharge", newTravelOrder.FuelCharge);
                command.Parameters.AddWithValue("@Customer", newTravelOrder.Customer);
                command.Parameters.AddWithValue("@TimeOut", newTravelOrder.TimeOut);
                command.Parameters.AddWithValue("@TimeIn", newTravelOrder.TimeIn);
                command.Parameters.AddWithValue("@TransportationKind", newTravelOrder.TransportationKind);
                command.Parameters.AddWithValue("@DopInfo", newTravelOrder.DopInfo);
                command.Parameters.AddWithValue("@CompletedFlag", newTravelOrder.CompletedFlag);
                command.Parameters.AddWithValue("@Lockflag", newTravelOrder.Lockflag);

                command.ExecuteNonQuery();
            }
        }

        // Функция обновления данных в таблице TravelOrder
        public void EditDataInTravelOrderTable(TravelOrderClass editTravelOrder)
        {
            // строка запроса для обновления данных в таблице TravelOrder
            string connectionStr = "UPDATE travelorder SET itinerary_Id = @ItineraryId, driver_Id = @DriverId, " +
                                   "vehicle_Id = @VehicleId, trailer_Id = @TrailerId, order_number = @Number, " +
                                   "order_date = @Date, order_validitydate = @ValidityDate, " +
                                   "order_speedometer_out = @SpeedometerOut, order_moto_out = @MotoOut, " +
                                   "order_winter_coefficient = @WinterCoefficient, order_fuelbalance = @FuelBalance, " +
                                   "order_fuel_charge = @FuelCharge, order_customer = @Customer, order_time_out = @TimeOut, " +
                                   "order_time_in = @TimeIn, order_transportation_kind = @TransportationKind, " +
                                   "order_dopinfo = @DopInfo, order_completed_flag = @CompletedFlag, " +
                                   "order_lockflag = @Lockflag WHERE order_Id = @ID";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@ID", editTravelOrder.OrderId);
                if (editTravelOrder.ItineraryId == 0)
                    command.Parameters.AddWithValue("@ItineraryId", null);
                else
                    command.Parameters.AddWithValue("@ItineraryId", editTravelOrder.ItineraryId);
                if (editTravelOrder.DriverId == 0)
                    command.Parameters.AddWithValue("@DriverId", null);
                else
                    command.Parameters.AddWithValue("@DriverId", editTravelOrder.DriverId);
                if (editTravelOrder.VehicleId == 0)
                    command.Parameters.AddWithValue("@VehicleId", null);
                else
                    command.Parameters.AddWithValue("@VehicleId", editTravelOrder.VehicleId);
                if (editTravelOrder.TrailerId == 0)
                    command.Parameters.AddWithValue("@TrailerId", null);
                else
                    command.Parameters.AddWithValue("@TrailerId", editTravelOrder.TrailerId);
                command.Parameters.AddWithValue("@Number", editTravelOrder.Number);
                command.Parameters.AddWithValue("@Date", editTravelOrder.Date);
                command.Parameters.AddWithValue("@ValidityDate", editTravelOrder.ValidityDate);
                command.Parameters.AddWithValue("@SpeedometerOut", editTravelOrder.SpeedometerOut);
                command.Parameters.AddWithValue("@MotoOut", editTravelOrder.MotoOut);
                command.Parameters.AddWithValue("@WinterCoefficient", editTravelOrder.WinterCoefficient);
                command.Parameters.AddWithValue("@FuelBalance", editTravelOrder.FuelBalance);
                command.Parameters.AddWithValue("@FuelCharge", editTravelOrder.FuelCharge);
                command.Parameters.AddWithValue("@Customer", editTravelOrder.Customer);
                command.Parameters.AddWithValue("@TimeOut", editTravelOrder.TimeOut);
                command.Parameters.AddWithValue("@TimeIn", editTravelOrder.TimeIn);
                command.Parameters.AddWithValue("@TransportationKind", editTravelOrder.TransportationKind);
                command.Parameters.AddWithValue("@DopInfo", editTravelOrder.DopInfo);
                command.Parameters.AddWithValue("@CompletedFlag", editTravelOrder.CompletedFlag);
                command.Parameters.AddWithValue("@Lockflag", editTravelOrder.Lockflag);

                command.ExecuteNonQuery();
            }
        }

        // Функция удаления путевого листа из таблицы TravelOrder
        public void DelDataFromTravelOrderTable(int delID)
        {
            // строка запроса на выбор из таблицы TravelOrder данных
            string connectionStr = $"DELETE FROM travelorder WHERE order_Id = '{delID}'";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection); ;
                command.ExecuteNonQuery();
            }
        }
#endregion
    }
}
