using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // Заполненный путевой лист – класс дополняет класс Путевой лист после заполнения путевого листа
    class CompletedTravelOrderClass
    {
        // переменные класса
        private int _completedId;            // Id заполненного путевого листа
        private int? _orderId;               // Id путевого листа
        private int _peedometerIn;          // спидометр возвращение
        private int _motoIn;                 // моточасы возвращение
        private DateTime _timeOut;           // фактическое время выезда
        private DateTime _timeIn;            // фактическое время возвращения
        private float _fuelBalance;          // остаток топлива
        private float _refuel;               // заправка
        private int _gorod100;               // город с населением 100 тыс.
        private int _gorod300;               // город с населением 300 тыс.
        private int _gorod1000;              // город с населением 1 млн
        private int _track;                  // по трассе
        private int _bezdor;                 // бездорожье
        private int _ostan;                  // с остановками
        private int _medl;                   // медленно
        private int _withCargo;              // с грузом
        private int _withoutCargo;           // без груза
        private int _cargo;                  // груз
        private int _withTrailer;            // с прицепом
        private int _onTrailer;              // на прицепе
        private float _otopitel;             // отопитель
        private float _generator;            // генератор
        private int _cond;                   // кондиционер
        private float _dopCoefficient;       // дополнительный коэффициент
        private string _transportationKind;  // вид перевозки
        private float _oilNorma;             // расход масла по норме
        private float _oilFact;              // расход масла фактически

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;charset=utf8";

        // пустой конструктор
        public CompletedTravelOrderClass()
        {
        }

        // конструктор с переменными класса
        public CompletedTravelOrderClass(int completedId, int? orderId, int speedometerIn, int motoIn, 
            DateTime timeOut, DateTime timeIn, float fuelBalance, float refuel, int gorod100, 
            int gorod300, int gorod1000, int track, int bezdor, int ostan, int medl, int withCargo, 
            int withoutCargo, int cargo, int withTrailer, int onTrailer, float otopitel, float generator, 
            int cond, float dopCoefficient, string transportationKind, float oilNorma, float oilFact)
        {
            this._completedId = completedId;
            this._orderId = orderId;
            this._peedometerIn = speedometerIn;
            this._motoIn = motoIn;
            this._timeOut = timeOut;
            this._timeIn = timeIn;
            this._fuelBalance = fuelBalance;
            this._refuel = refuel;
            this._gorod100 = gorod100;
            this._gorod300 = gorod300;
            this._gorod1000 = gorod1000;
            this._track = track;
            this._bezdor = bezdor;
            this._ostan = ostan;
            this._medl = medl;
            this._withCargo = withCargo;
            this._withoutCargo = withoutCargo;
            this._cargo = cargo;
            this._withTrailer = withTrailer;
            this._onTrailer = onTrailer;
            this._otopitel = otopitel;
            this._generator = generator;
            this._cond = cond;
            this._dopCoefficient = dopCoefficient;
            this._transportationKind = transportationKind;
            this._oilNorma = oilNorma;
            this._oilFact = oilFact;
        }

#region Getters&Setters&ToString
        public int CompletedId
        {
            get { return _completedId; }
            set { _completedId = value; }
        }

        public int? OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        public int SpeedometerIn
        {
            get { return _peedometerIn; }
            set { _peedometerIn = value; }
        }

        public int MotoIn
        {
            get { return _motoIn; }
            set { _motoIn = value; }
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

        public float FuelBalance
        {
            get { return _fuelBalance; }
            set { _fuelBalance = value; }
        }

        public float Refuel
        {
            get { return _refuel; }
            set { _refuel = value; }
        }

        public int Gorod100
        {
            get { return _gorod100; }
            set { _gorod100 = value; }
        }

        public int Gorod300
        {
            get { return _gorod300; }
            set { _gorod300 = value; }
        }

        public int Gorod1000
        {
            get { return _gorod1000; }
            set { _gorod1000 = value; }
        }

        public int Track
        {
            get { return _track; }
            set { _track = value; }
        }

        public int Bezdor
        {
            get { return _bezdor; }
            set { _bezdor = value; }
        }

        public int Ostan
        {
            get { return _ostan; }
            set { _ostan = value; }
        }

        public int Medl
        {
            get { return _medl; }
            set { _medl = value; }
        }

        public int WithCargo
        {
            get { return _withCargo; }
            set { _withCargo = value; }
        }

        public int WithoutCargo
        {
            get { return _withoutCargo; }
            set { _withoutCargo = value; }
        }

        public int Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        public int WithTrailer
        {
            get { return _withTrailer; }
            set { _withTrailer = value; }
        }

        public int OnTrailer
        {
            get { return _onTrailer; }
            set { _onTrailer = value; }
        }

        public float Otopitel
        {
            get { return _otopitel; }
            set { _otopitel = value; }
        }

        public float Generator
        {
            get { return _generator; }
            set { _generator = value; }
        }

        public int Cond
        {
            get { return _cond; }
            set { _cond = value; }
        }

        public float DopCoefficient
        {
            get { return _dopCoefficient; }
            set { _dopCoefficient = value; }
        }

        public string TransportationKind
        {
            get { return _transportationKind; }
            set { _transportationKind = value; }
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

        public override string ToString()
        {
            return $"CompletedId: {_completedId}, OrderId: {_orderId}, SpeedometerIn: {_peedometerIn}, " +
                   $"MotoIn: {_motoIn}, TimeOut: {_timeOut}, TimeIn: {_timeIn}, FuelBalance: {_fuelBalance}, " +
                   $"Refuel: {_refuel}, Gorod100: {_gorod100}, Gorod300: {_gorod300}, Gorod1000: {_gorod1000}, " +
                   $"Track: {_track}, Bezdor: {_bezdor}, Ostan: {_ostan}, Medl: {_medl}, WithCargo: {_withCargo}, " +
                   $"WithoutCargo: {_withoutCargo}, Cargo: {_cargo}, WithTrailer: {_withTrailer}, " +
                   $"OnTrailer: {_onTrailer}, Otopitel: {_otopitel}, Generator: {_generator}, Cond: {_cond}, " +
                   $"DopCoefficient: {_dopCoefficient}, TransportationKind: {_transportationKind}, " +
                   $"OilNorma: {_oilNorma}, OilFact: {_oilFact}";
        }

#endregion
#region DBfunctions
        // Функция чтения данных из таблицы CompletedTravelOrder базы данных
        public ArrayList ReadCompletedTravelOrderData()
        {
            // строка запроса на выбор из таблицы CompletedTravelOrder данных
            string connectionStr = "SELECT * FROM completedtravelorder";
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
                        int? tmp = null;
                        if (!reader.IsDBNull(1))
                            tmp = reader.GetInt32(1);
                        resultList.Add(new CompletedTravelOrderClass(reader.GetInt32(0), tmp, reader.GetInt32(2), 
                            reader.GetInt32(3), reader.GetDateTime(4), reader.GetDateTime(5), reader.GetFloat(6), 
                            reader.GetFloat(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), 
                            reader.GetInt32(11), reader.GetInt32(12), reader.GetInt32(13), reader.GetInt32(14), 
                            reader.GetInt32(15), reader.GetInt32(16), reader.GetInt32(17), reader.GetInt32(18), 
                            reader.GetInt32(19), reader.GetFloat(20), reader.GetFloat(21), reader.GetInt32(22), 
                            reader.GetFloat(23), reader.GetString(24).Trim(), reader.GetFloat(25), reader.GetFloat(26)));
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
            return resultList;
        }

        // Функция получения заполненного путевого листа из БД по Id
        public void GetCompletedTravelOrderById(int toId)
        {
            // строка запроса на выбор из таблицы CompletedTravelOrder данных по order_Id
            string connectionStr = $"SELECT * FROM completedtravelorder WHERE order_Id = {toId}";
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
                        CompletedId = reader.GetInt32(0);
                        SpeedometerIn = reader.GetInt32(2);
                        MotoIn = reader.GetInt32(3);
                        TimeOut = reader.GetDateTime(4);
                        TimeIn = reader.GetDateTime(5);
                        FuelBalance = reader.GetFloat(6);
                        Refuel = reader.GetFloat(7);
                        Gorod100 = reader.GetInt32(8);
                        Gorod300 = reader.GetInt32(9);
                        Gorod1000 = reader.GetInt32(10);
                        Track = reader.GetInt32(11);
                        Bezdor = reader.GetInt32(12);
                        Ostan = reader.GetInt32(13);
                        Medl = reader.GetInt32(14);
                        WithCargo = reader.GetInt32(15);
                        WithoutCargo = reader.GetInt32(16);
                        Cargo = reader.GetInt32(17);
                        WithTrailer = reader.GetInt32(18);
                        OnTrailer = reader.GetInt32(19);
                        Otopitel = reader.GetFloat(20);
                        Generator = reader.GetFloat(21);
                        Cond = reader.GetInt32(22);
                        DopCoefficient = reader.GetFloat(23);
                        TransportationKind = reader.GetString(24).Trim();
                        OilNorma = reader.GetFloat(25);
                        OilFact = reader.GetFloat(26);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция добавления данных в таблицу CompletedTravelOrder БД
        public void AddDataInCompletedTravelOrderTable(CompletedTravelOrderClass newCompletedTravelOrder)
        {
            string columns = "order_Id, completed_speedometer_in, completed_moto_in, completed_time_out, completed_time_in, " +
                             "completed_fuelbalance, completed_refuel, completed_gorod100, completed_gorod300, " +
                             "completed_gorod1000, completed_track, completed_bezdor, completed_ostan, completed_medl, " +
                             "completed_with_cargo, completed_without_cargo, completed_cargo, completed_with_trailer, " +
                             "completed_on_trailer, completed_otopitel, completed_generator, completed_cond, " +
                             "completed_dop_coefficient, completed_transportation_kind, completed_oil_norma, completed_oil_fact";
            // строка запроса на добавление в таблицу TravelOrder данных
            string connectionStr = $"INSERT INTO completedtravelorder ({columns}) VALUES (@OrderId, @SpeedometerIn, @MotoIn, " +
                                   $"@TimeOut, @TimeIn, @FuelBalance, @Refuel, @Gorod100, @Gorod300, @Gorod1000, @Track, " +
                                   $"@Bezdor, @Ostan, @Medl, @WithCargo, @WithoutCargo, @Cargo, @WithTrailer, " +
                                   $"@OnTrailer, @Otopitel, @Generator, @Cond, @DopCoefficient, @TransportationKind, " +
                                   $"@OilNorma, @OilFact)";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                if (newCompletedTravelOrder.OrderId == 0)
                    command.Parameters.AddWithValue("@OrderId", null);
                else
                    command.Parameters.AddWithValue("@OrderId", newCompletedTravelOrder.OrderId);
                command.Parameters.AddWithValue("@SpeedometerIn", newCompletedTravelOrder.SpeedometerIn);
                command.Parameters.AddWithValue("@MotoIn", newCompletedTravelOrder.MotoIn);
                command.Parameters.AddWithValue("@TimeOut", newCompletedTravelOrder.TimeOut);
                command.Parameters.AddWithValue("@TimeIn", newCompletedTravelOrder.TimeIn);
                command.Parameters.AddWithValue("@FuelBalance", newCompletedTravelOrder.FuelBalance);
                command.Parameters.AddWithValue("@Refuel", newCompletedTravelOrder.Refuel);
                command.Parameters.AddWithValue("@Gorod100", newCompletedTravelOrder.Gorod100);
                command.Parameters.AddWithValue("@Gorod300", newCompletedTravelOrder.Gorod300);
                command.Parameters.AddWithValue("@Gorod1000", newCompletedTravelOrder.Gorod1000);
                command.Parameters.AddWithValue("@Track", newCompletedTravelOrder.Track);
                command.Parameters.AddWithValue("@Bezdor", newCompletedTravelOrder.Bezdor);
                command.Parameters.AddWithValue("@Ostan", newCompletedTravelOrder.Ostan);
                command.Parameters.AddWithValue("@Medl", newCompletedTravelOrder.Medl);
                command.Parameters.AddWithValue("@WithCargo", newCompletedTravelOrder.WithCargo);
                command.Parameters.AddWithValue("@WithoutCargo", newCompletedTravelOrder.WithoutCargo);
                command.Parameters.AddWithValue("@Cargo", newCompletedTravelOrder.Cargo);
                command.Parameters.AddWithValue("@WithTrailer", newCompletedTravelOrder.WithTrailer);
                command.Parameters.AddWithValue("@OnTrailer", newCompletedTravelOrder.OnTrailer);
                command.Parameters.AddWithValue("@Otopitel", newCompletedTravelOrder.Otopitel);
                command.Parameters.AddWithValue("@Generator", newCompletedTravelOrder.Generator);
                command.Parameters.AddWithValue("@Cond", newCompletedTravelOrder.Cond);
                command.Parameters.AddWithValue("@DopCoefficient", newCompletedTravelOrder.DopCoefficient);
                command.Parameters.AddWithValue("@TransportationKind", newCompletedTravelOrder.TransportationKind);
                command.Parameters.AddWithValue("@OilNorma", newCompletedTravelOrder.OilNorma);
                command.Parameters.AddWithValue("@OilFact", newCompletedTravelOrder.OilFact);

                command.ExecuteNonQuery();
            }
        }

        // Функция обновления данных в таблице CompletedTravelOrder
        public void EditDataInCompletedTravelOrderTable(CompletedTravelOrderClass editCompletedTravelOrder)
        {
            // строка запроса для обновления данных в таблице CompletedTravelOrder
            string connectionStr = "UPDATE completedtravelorder SET order_Id = @OrderId, completed_speedometer_in = @SpeedometerIn, " +
                                   "completed_moto_in = @MotoIn, completed_time_out = @TimeOut, completed_time_in = @TimeIn, " +
                                   "completed_fuelbalance = @FuelBalance, completed_refuel = @Refuel, completed_gorod100 = @Gorod100, " +
                                   "completed_gorod300 = @Gorod300, completed_gorod1000 = @Gorod1000, completed_track = @Track, " +
                                   "completed_bezdor = @Bezdor, completed_ostan = @Ostan, completed_medl = @Medl, " +
                                   "completed_with_cargo = @WithCargo, completed_without_cargo = @WithoutCargo, completed_cargo = @Cargo, " +
                                   "completed_with_trailer = @WithTrailer, completed_on_trailer = @OnTrailer, " +
                                   "completed_otopitel = @Otopitel, completed_generator = @Generator, completed_cond = @Cond, " +
                                   "completed_dop_coefficient = @DopCoefficient, completed_transportation_kind = @TransportationKind, " +
                                   "completed_oil_norma = @OilNorma, completed_oil_fact = @OilFact WHERE completed_Id = @ID";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@ID", editCompletedTravelOrder.CompletedId);
                if (editCompletedTravelOrder.OrderId == 0)
                    command.Parameters.AddWithValue("@OrderId", null);
                else
                    command.Parameters.AddWithValue("@OrderId", editCompletedTravelOrder.OrderId);
                command.Parameters.AddWithValue("@SpeedometerIn", editCompletedTravelOrder.SpeedometerIn);
                command.Parameters.AddWithValue("@MotoIn", editCompletedTravelOrder.MotoIn);
                command.Parameters.AddWithValue("@TimeOut", editCompletedTravelOrder.TimeOut);
                command.Parameters.AddWithValue("@TimeIn", editCompletedTravelOrder.TimeIn);
                command.Parameters.AddWithValue("@FuelBalance", editCompletedTravelOrder.FuelBalance);
                command.Parameters.AddWithValue("@Refuel", editCompletedTravelOrder.Refuel);
                command.Parameters.AddWithValue("@Gorod100", editCompletedTravelOrder.Gorod100);
                command.Parameters.AddWithValue("@Gorod300", editCompletedTravelOrder.Gorod300);
                command.Parameters.AddWithValue("@Gorod1000", editCompletedTravelOrder.Gorod1000);
                command.Parameters.AddWithValue("@Track", editCompletedTravelOrder.Track);
                command.Parameters.AddWithValue("@Bezdor", editCompletedTravelOrder.Bezdor);
                command.Parameters.AddWithValue("@Ostan", editCompletedTravelOrder.Ostan);
                command.Parameters.AddWithValue("@Medl", editCompletedTravelOrder.Medl);
                command.Parameters.AddWithValue("@WithCargo", editCompletedTravelOrder.WithCargo);
                command.Parameters.AddWithValue("@WithoutCargo", editCompletedTravelOrder.WithoutCargo);
                command.Parameters.AddWithValue("@Cargo", editCompletedTravelOrder.Cargo);
                command.Parameters.AddWithValue("@WithTrailer", editCompletedTravelOrder.WithTrailer);
                command.Parameters.AddWithValue("@OnTrailer", editCompletedTravelOrder.OnTrailer);
                command.Parameters.AddWithValue("@Otopitel", editCompletedTravelOrder.Otopitel);
                command.Parameters.AddWithValue("@Generator", editCompletedTravelOrder.Generator);
                command.Parameters.AddWithValue("@Cond", editCompletedTravelOrder.Cond);
                command.Parameters.AddWithValue("@DopCoefficient", editCompletedTravelOrder.DopCoefficient);
                command.Parameters.AddWithValue("@TransportationKind", editCompletedTravelOrder.TransportationKind);
                command.Parameters.AddWithValue("@OilNorma", editCompletedTravelOrder.OilNorma);
                command.Parameters.AddWithValue("@OilFact", editCompletedTravelOrder.OilFact);

                command.ExecuteNonQuery();
            }
        }
#endregion
    }
}
