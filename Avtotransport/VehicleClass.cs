using System.Collections;
using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // Автомобили – класс реализует функционал действий с данными об автомобилях
    class VehicleClass
    {
        // переменные класса
        private int vehicleId;              // Id автомобиля
        private int? driverId;              // Id водителя
        private string model;               // марка
        private int type;                   // тип автомобиля
        private int bodyType;               // тип кузова
        private int motorType;              // тип двигателя
        private float motorSize;            // объем двигателя
        private string regNumber;           // госномер
        private int releaseDate;            // дата выпуска
        private bool trailer;               // наличие прицепа
        private bool usage;                 // статус эксплуатации
        private string bodySize;            // длина кузова
        private int tonnage;                // грузоподъемность
        private int wheel;                  // количество колес
        private int spareWheel;             // количество запасок
        private int passengers;             // количество пассажиров
        private float tonnageCoefficient;   // коэффициент грузоподъемности
        private int fuelType;               // тип топлива
        private int fuelTank;               // емкость бака
        private float fuelBalance;          // остаток топлива

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;charset=utf8";

        // пустой конструктор
        public VehicleClass()
        {
        }

        // конструктор с переменными класса
        public VehicleClass(int vehicleId, int? driverId, string model, int type, int bodyType,
            int motorType, float motorSize, string regNumber, int releaseDate, bool trailer, 
            bool usage, string bodySize, int tonnage, int wheel, int spareWheel, int passengers, 
            float tonnageCoefficient, int fuelType, int fuelTank, float fuelBalance)
        {
            this.vehicleId = vehicleId;
            this.driverId = driverId;
            this.model = model;
            this.type = type;
            this.bodyType = bodyType;
            this.motorType = motorType;
            this.motorSize = motorSize;
            this.regNumber = regNumber;
            this.releaseDate = releaseDate;
            this.trailer = trailer;
            this.usage = usage;
            this.bodySize = bodySize;
            this.tonnage = tonnage;
            this.wheel = wheel;
            this.spareWheel = spareWheel;
            this.passengers = passengers;
            this.tonnageCoefficient = tonnageCoefficient;
            this.fuelType = fuelType;
            this.fuelTank = fuelTank;
            this.fuelBalance = fuelBalance;
        }

#region Getters&Setters&ToString
        public int VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }

        public int? DriverId
        {
            get { return driverId; }
            set { driverId = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public int BodyType
        {
            get { return bodyType; }
            set { bodyType = value; }
        }

        public int MotorType
        {
            get { return motorType; }
            set { motorType = value; }
        }

        public float MotorSize
        {
            get { return motorSize; }
            set { motorSize = value; }
        }

        public string RegNumber
        {
            get { return regNumber; }
            set { regNumber = value; }
        }

        public int ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        public bool Trailer
        {
            get { return trailer; }
            set { trailer = value; }
        }

        public bool Usage
        {
            get { return usage; }
            set { usage = value; }
        }

        public string BodySize
        {
            get { return bodySize; }
            set { bodySize = value; }
        }

        public int Tonnage
        {
            get { return tonnage; }
            set { tonnage = value; }
        }

        public int Wheel
        {
            get { return wheel; }
            set { wheel = value; }
        }

        public int SpareWheel
        {
            get { return spareWheel; }
            set { spareWheel = value; }
        }

        public int Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }

        public float TonnageCoefficient
        {
            get { return tonnageCoefficient; }
            set { tonnageCoefficient = value; }
        }

        public int FuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }

        public int FuelTank
        {
            get { return fuelTank; }
            set { fuelTank = value; }
        }

        public float FuelBalance
        {
            get { return fuelBalance; }
            set { fuelBalance = value; }
        }

        public override string ToString()
        {
            return $"VehicleId: {vehicleId}, DriverId: {driverId}, Model: {model}, Type: {type}, " +
                   $"BodyType: {bodyType}, MotorType: {motorType}, MotorSize: {motorSize}, " +
                   $"RegNumber: {regNumber}, ReleaseDate: {releaseDate}, Trailer: {trailer}, " +
                   $"Usage: {usage}, BodySize: {bodySize}, Tonnage: {tonnage}, Wheel: {wheel}, " +
                   $"SpareWheel: {spareWheel}, Passengers: {passengers}, TonnageCoefficient: {tonnageCoefficient}, " +
                   $"FuelType: {fuelType}, FuelTank: {fuelTank}, FuelBalance: {fuelBalance}";
        }
#endregion

#region DBfunctions
        // Функция чтения данных из таблицы Vehicle базы данных
        public ArrayList ReadVehicleData()
        {
            // строка запроса на выбор из таблицы Vehicle данных
            string connectionStr = "SELECT * FROM vehicle";
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
                        resultList.Add(new VehicleClass(reader.GetInt32(0), tmp,
                            reader.GetString(2).Trim(), reader.GetInt32(3), reader.GetInt32(4), 
                            reader.GetInt32(5), reader.GetFloat(6), reader.GetString(7).Trim(),
                            reader.GetInt32(8), reader.GetBoolean(9), reader.GetBoolean(10),
                            reader.GetString(11).Trim(), reader.GetInt32(12), reader.GetInt32(13),
                            reader.GetInt32(14), reader.GetInt32(15), reader.GetFloat(16),
                            reader.GetInt32(17), reader.GetInt32(18), reader.GetFloat(19)));
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
            return resultList;
        }

        // Функция получения автомобиля из БД по Id
        public void GetVehicleById(int vId)
        {
            // строка запроса на выбор из таблицы Vehicle данных по vehicle_Id
            string connectionStr = $"SELECT * FROM vehicle WHERE vehicle_Id = {vId}";
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
                        VehicleId = reader.GetInt32(0);
                        int? tmp = null;
                        if (!reader.IsDBNull(1))
                            tmp = reader.GetInt32(1);
                        DriverId = tmp;
                        Model = reader.GetString(2).Trim();
                        Type = reader.GetInt32(3);
                        BodyType = reader.GetInt32(4);
                        MotorType = reader.GetInt32(5);
                        MotorSize = reader.GetInt32(6);
                        RegNumber = reader.GetString(7).Trim();
                        ReleaseDate = reader.GetInt32(8);
                        Trailer = reader.GetBoolean(9);
                        Usage = reader.GetBoolean(10);
                        BodySize = reader.GetString(11);
                        Tonnage = reader.GetInt32(12);
                        Wheel = reader.GetInt32(13);
                        SpareWheel = reader.GetInt32(14);
                        Passengers = reader.GetInt32(15);
                        TonnageCoefficient = reader.GetInt32(16);
                        FuelType = reader.GetInt32(17);
                        FuelTank = reader.GetInt32(18);
                        FuelBalance = reader.GetFloat(19);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция получения автомобиля из БД по vehicle_regnumber
        public void GetVehicleByRegnumber(string rNumber)
        {
            // строка запроса на выбор из таблицы Vehicle данных по vehicle_regnumber
            string connectionStr = $"SELECT * FROM vehicle WHERE vehicle_regnumber = '{rNumber}'";
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
                        VehicleId = reader.GetInt32(0);
                        Model = reader.GetString(2).Trim();
                        Type = reader.GetInt32(3);
                        RegNumber = reader.GetString(7).Trim();
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция добавления данных в таблицу Vehicle БД
        public void AddDataInVehicleTable(VehicleClass newVehicle)
        {
            string columns = "driver_Id, vehicle_model, vehicle_type, vehicle_bodytype, vehicle_motortype," +
                             "vehicle_motorsize, vehicle_regnumber, vehicle_releasedate, vehicle_trailer, " +
                             "vehicle_usage, vehicle_bodysize, vehicle_tonnage, vehicle_wheel, vehicle_sparewheel, " +
                             "vehicle_passengers, vehicle_tonnagecoefficient, vehicle_fueltype, vehicle_fueltank, " +
                             "vehicle_fuelbalance";
            // строка запроса на добавление в таблицу Vehicle данных
            string connectionStr = $"INSERT INTO vehicle ({columns}) VALUES (@DriverId, @Model, @Type, " +
                                   $"@BodyType, @MotorType, @MotorSize, @RegNumber, @ReleaseDate, " +
                                   $"@Trailer, @Usage, @BodySize, @Tonnage, @Wheel, @SpareWheel, " +
                                   $"@Passengers, @TonnageCoefficient, @FuelType, @FuelTank, @FuelBalance)";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                if (newVehicle.DriverId == 0)
                    command.Parameters.AddWithValue("@DriverId", null);
                else
                    command.Parameters.AddWithValue("@DriverId", newVehicle.DriverId);
                command.Parameters.AddWithValue("@Model", newVehicle.Model);
                command.Parameters.AddWithValue("@Type", newVehicle.Type);
                command.Parameters.AddWithValue("@BodyType", newVehicle.BodyType);
                command.Parameters.AddWithValue("@MotorType", newVehicle.MotorType);
                command.Parameters.AddWithValue("@MotorSize", newVehicle.MotorSize);
                command.Parameters.AddWithValue("@RegNumber", newVehicle.RegNumber);
                command.Parameters.AddWithValue("@ReleaseDate", newVehicle.ReleaseDate);
                command.Parameters.AddWithValue("@Trailer", newVehicle.Trailer);
                command.Parameters.AddWithValue("@Usage", newVehicle.Usage);
                command.Parameters.AddWithValue("@BodySize", newVehicle.BodySize);
                command.Parameters.AddWithValue("@Tonnage", newVehicle.Tonnage);
                command.Parameters.AddWithValue("@Wheel", newVehicle.Wheel);
                command.Parameters.AddWithValue("@SpareWheel", newVehicle.SpareWheel);
                command.Parameters.AddWithValue("@Passengers", newVehicle.Passengers);
                command.Parameters.AddWithValue("@TonnageCoefficient", newVehicle.TonnageCoefficient);
                command.Parameters.AddWithValue("@FuelType", newVehicle.FuelType);
                command.Parameters.AddWithValue("@FuelTank", newVehicle.FuelTank);
                command.Parameters.AddWithValue("@FuelBalance", newVehicle.FuelBalance);

                command.ExecuteNonQuery();
            }
        }

        // Функция обновления данных в таблице Vehicle
        public void EditDataInVehicleTable(VehicleClass editVehicle)
        {
            // строка запроса для обновления данных в таблице Vehicle
            string connectionStr = "UPDATE vehicle SET driver_Id = @DriverId, vehicle_model = @Model, " +
                                   "vehicle_type = @Type, vehicle_bodytype = @BodyType, vehicle_motortype = @MotorType, " +
                                   "vehicle_motorsize = @MotorSize, vehicle_regnumber = @RegNumber, " +
                                   "vehicle_releasedate = @ReleaseDate, vehicle_trailer = @Trailer, " +
                                   "vehicle_usage = @Usage, vehicle_bodysize = @BodySize, vehicle_tonnage = @Tonnage, " +
                                   "vehicle_wheel = @Wheel, vehicle_sparewheel = @SpareWheel, " +
                                   "vehicle_passengers = @Passengers, vehicle_tonnagecoefficient = @TonnageCoefficient, " +
                                   "vehicle_fueltype = @FuelType, vehicle_fueltank = @FuelTank, " +
                                   "vehicle_fuelbalance = @FuelBalance WHERE vehicle_Id = @ID";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@ID", editVehicle.VehicleId);
                if (editVehicle.DriverId == 0)
                    command.Parameters.AddWithValue("@DriverId", null);
                else
                    command.Parameters.AddWithValue("@DriverId", editVehicle.DriverId);
                command.Parameters.AddWithValue("@Model", editVehicle.Model);
                command.Parameters.AddWithValue("@Type", editVehicle.Type);
                command.Parameters.AddWithValue("@BodyType", editVehicle.BodyType);
                command.Parameters.AddWithValue("@MotorType", editVehicle.MotorType);
                command.Parameters.AddWithValue("@MotorSize", editVehicle.MotorSize);
                command.Parameters.AddWithValue("@RegNumber", editVehicle.RegNumber);
                command.Parameters.AddWithValue("@ReleaseDate", editVehicle.ReleaseDate);
                command.Parameters.AddWithValue("@Trailer", editVehicle.Trailer);
                command.Parameters.AddWithValue("@Usage", editVehicle.Usage);
                command.Parameters.AddWithValue("@BodySize", editVehicle.BodySize);
                command.Parameters.AddWithValue("@Tonnage", editVehicle.Tonnage);
                command.Parameters.AddWithValue("@Wheel", editVehicle.Wheel);
                command.Parameters.AddWithValue("@SpareWheel", editVehicle.SpareWheel);
                command.Parameters.AddWithValue("@Passengers", editVehicle.Passengers);
                command.Parameters.AddWithValue("@TonnageCoefficient", editVehicle.TonnageCoefficient);
                command.Parameters.AddWithValue("@FuelType", editVehicle.FuelType);
                command.Parameters.AddWithValue("@FuelTank", editVehicle.FuelTank);
                command.Parameters.AddWithValue("@FuelBalance", editVehicle.FuelBalance);

                command.ExecuteNonQuery();
            }
        }

        // Функция удаления автомобиля из таблицы Vehicle
        public void DelDataFromVehicleTable(int delID)
        {
            // строка запроса на выбор из таблицы Vehicle данных
            string connectionStr = $"DELETE FROM vehicle WHERE vehicle_Id = '{delID}'";
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

#region Types
        // Метод получения типа автомобиля
        public string GetVehicleType(int type)
        {
            string result = "";
            switch (type)
            {
                case 1:
                    result = "Бронированный";
                    break;
                case 2:
                    result = "Бронированный специальный";
                    break;
                case 3:
                    result = "Грузовой";
                    break;
                case 4:
                    result = "Грузовой специальный";
                    break;
                case 5:
                    result = "Легковой";
                    break;
                case 6:
                    result = "Легковой специальный";
                    break;
                case 7:
                    result = "Автобус";
                    break;
                case 8:
                    result = "Пассажирский";
                    break;
                case 9:
                    result = "Грузопассажирский";
                    break;
                case 10:
                    result = "Специальный";
                    break;
                case 11:
                    result = "Строймеханизмы";
                    break;
                case 12:
                    result = "ДорСтройТехника";
                    break;
                default:
                    break;
            }
            return result;
        }

        // Метод получения типа кузова
        public string GetVehicleBodyType(int type)
        {
            string result = "";
            switch (type)
            {
                case 1:
                    result = "Самосвал";
                    break;
                case 2:
                    result = "Бортовой";
                    break;
                case 3:
                    result = "Фургон";
                    break;
                case 4:
                    result = "Рефрижиратор";
                    break;
                case 5:
                    result = "Цистерна";
                    break;
                case 6:
                    result = "Лесовоз";
                    break;
                case 7:
                    result = "Седельный тягач";
                    break;
                case 8:
                    result = "Плетевоз";
                    break;
                case 9:
                    result = "Автокран";
                    break;
                case 10:
                    result = "Трактор";
                    break;
                case 11:
                    result = "Бульдозер";
                    break;
                case 12:
                    result = "Экскаватор";
                    break;
                case 13:
                    result = "Джип";
                    break;
                case 14:
                    result = "Автобус";
                    break;
                case 15:
                    result = "Самопогрузчик";
                    break;
                case 16:
                    result = "Пикап";
                    break;
                case 17:
                    result = "Прицеп";
                    break;
                case 18:
                    result = "Полуприцеп";
                    break;
                case 19:
                    result = "Пожарный";
                    break;
                case 20:
                    result = "Санитарный";
                    break;
                default:
                    break;
            }
            return result;
        }

        // Метод получения типа двигателя
        public string GetVehicleMotorType(int type)
        {
            string result = "";
            switch (type)
            {
                case 1:
                    result = "Бензин карбюратор";
                    break;
                case 2:
                    result = "Бензин инжектор";
                    break;
                case 3:
                    result = "Газ-бензин карбюратор";
                    break;
                case 4:
                    result = "Газ-бензин инжектор";
                    break;
                case 5:
                    result = "Дизель";
                    break;
                case 6:
                    result = "Газодизель";
                    break;
                case 7:
                    result = "Дизель с бензиновым пускателем";
                    break;
                case 8:
                    result = "Электрический";
                    break;
                default:
                    break;
            }
            return result;
        }

        // Метод получения типа топлива для отображения
        public string GetStringFuelType(int typeIndex)
        {
            string result = "";
            switch (typeIndex)
            {
                case 1:
                    result = "Дизель";
                    break;
                case 2:
                    result = "Н80";
                    break;
                case 3:
                    result = "А92";
                    break;
                case 4:
                    result = "А95";
                    break;
                case 5:
                    result = "А98";
                    break;
                case 6:
                    result = "КПГ";
                    break;
                case 7:
                    result = "СУГ";
                    break;
                case 8:
                    result = "Керосин";
                    break;
                case 9:
                    result = "Биодизель";
                    break;
                default:
                    break;
            }
            return result;
        }
#endregion
    }
}
