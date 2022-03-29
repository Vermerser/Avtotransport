using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // Автомобильные шины – класс реализует функционал действий с данными об автомобильных шинах
    class TireClass
    {
        // переменные класса
        private int tireId;                 // Id автомобильных шин
        private int? vehicleId;             // Id автомобиля
        private string serialNumber;        // серийный номер
        private string size;                // размер
        private string model;               // модель
        private float weight;               // масса
        private float coast;                // стоимость
        private string madeName;            // изготовитель
        private int position;               // позиция
        private bool sparewheel;            // запаска
        private DateTime installationDate;  // дата установки
        private DateTime removeDate;        // дата снятия
        private int runNorma;               // норма пробега, км
        private int workNorma;              // норма наработки, км
        private int currentRun;             // текущий пробег, км
        private int currentYears;           // наработка, лет
        private bool expluataionStatus;     // статус эксплуатации

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;charset=utf8";

        // пустой конструктор
        public TireClass()
        {
        }

        // конструктор с переменными класса
        public TireClass(int tireId, int? vehicleId, string serialNumber, string size, string model, float weight, 
            float coast, string madeName, int position, bool sparewheel, DateTime installationDate, DateTime removeDate, 
            int runNorma, int workNorma, int currentRun, int currentYears, bool expluataionStatus)
        {
            this.tireId = tireId;
            this.vehicleId = vehicleId;
            this.serialNumber = serialNumber;
            this.size = size;
            this.model = model;
            this.weight = weight;
            this.coast = coast;
            this.madeName = madeName;
            this.position = position;
            this.sparewheel = sparewheel;
            this.installationDate = installationDate;
            this.removeDate = removeDate;
            this.runNorma = runNorma;
            this.workNorma = workNorma;
            this.currentRun = currentRun;
            this.currentYears = currentYears;
            this.expluataionStatus = expluataionStatus;
        }

#region Getters&Setters&ToString

        public int TireId
        {
            get { return tireId; }
            set { tireId = value; }
        }

        public int? VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }

        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public float Coast
        {
            get { return coast; }
            set { coast = value; }
        }

        public string MadeName
        {
            get { return madeName; }
            set { madeName = value; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool Sparewheel
        {
            get { return sparewheel; }
            set { sparewheel = value; }
        }

        public DateTime InstallationDate
        {
            get { return installationDate; }
            set { installationDate = value; }
        }

        public DateTime RemoveDate
        {
            get { return removeDate; }
            set { removeDate = value; }
        }

        public int RunNorma
        {
            get { return runNorma; }
            set { runNorma = value; }
        }

        public int WorkNorma
        {
            get { return workNorma; }
            set { workNorma = value; }
        }

        public int CurrentRun
        {
            get { return currentRun; }
            set { currentRun = value; }
        }

        public int CurrentYears
        {
            get { return currentYears; }
            set { currentYears = value; }
        }

        public bool ExpluataionStatus
        {
            get { return expluataionStatus; }
            set { expluataionStatus = value; }
        }

        public override string ToString()
        {
            return $"TireId: {tireId}, VehicleId: {vehicleId}, SerialNumber: {serialNumber}, Size: {size}, " +
                   $"Model: {model}, Weight: {weight}, Coast: {coast}, MadeName: {madeName}, Position: {position}, " +
                   $"Sparewheel: {sparewheel}, InstallationDate: {installationDate}, RemoveDate: {removeDate}, " +
                   $"RunNorma: {runNorma}, WorkNorma: {workNorma}, CurrentRun: {currentRun}, " +
                   $"CurrentYears: {currentYears}, ExpluataionStatus: {expluataionStatus}";
        }
#endregion
#region DBfunctions
        // Функция чтения данных из таблицы Tire базы данных
        public ArrayList ReadTireData()
        {
            // строка запроса на выбор из таблицы Tire данных
            string connectionStr = "SELECT * FROM tire";
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
                        resultList.Add(new TireClass(reader.GetInt32(0), tmp,
                            reader.GetString(2).Trim(), reader.GetString(3).Trim(), reader.GetString(4).Trim(), 
                            reader.GetFloat(5), reader.GetFloat(6), reader.GetString(7).Trim(), reader.GetInt32(8),
                            reader.GetBoolean(9), reader.GetDateTime(10), reader.GetDateTime(11), reader.GetInt32(12), 
                            reader.GetInt32(13), reader.GetInt32(14), reader.GetInt32(15), reader.GetBoolean(16)));
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
            return resultList;
        }

        // Функция получения автомобильной шины из БД по Id
        public void GetTireById(int tId)
        {
            // строка запроса на выбор из таблицы Tire данных по tire_Id
            string connectionStr = $"SELECT * FROM tire WHERE tire_Id = {tId}";
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
                        TireId = reader.GetInt32(0);
                        int? tmp = null;
                        if (!reader.IsDBNull(1))
                            tmp = reader.GetInt32(1);
                        VehicleId = tmp;
                        SerialNumber = reader.GetString(2).Trim();
                        Size = reader.GetString(3).Trim();
                        Model = reader.GetString(4).Trim();
                        Weight = reader.GetFloat(5);
                        Coast = reader.GetFloat(6);
                        MadeName = reader.GetString(7).Trim();
                        Position = reader.GetInt32(8);
                        Sparewheel = reader.GetBoolean(9);
                        InstallationDate = reader.GetDateTime(10);
                        RemoveDate = reader.GetDateTime(11);
                        RunNorma = reader.GetInt32(12);
                        WorkNorma = reader.GetInt32(13);
                        CurrentRun = reader.GetInt32(14);
                        CurrentYears = reader.GetInt32(15);
                        ExpluataionStatus = reader.GetBoolean(16);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция чтения данных из таблицы Tire БД по vehicle_Id
        public ArrayList GetTireByVehicleId(int vId)
        {
            // строка запроса на выбор из таблицы Tire данных
            string connectionStr = $"SELECT * FROM tire WHERE vehicle_Id = {vId}";
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
                        resultList.Add(new TireClass(reader.GetInt32(0), vId, reader.GetString(2).Trim(), 
                            reader.GetString(3).Trim(), reader.GetString(4).Trim(), reader.GetFloat(5), 
                            reader.GetFloat(6), reader.GetString(7).Trim(), reader.GetInt32(8),
                            reader.GetBoolean(9), reader.GetDateTime(10), reader.GetDateTime(11), reader.GetInt32(12),
                            reader.GetInt32(13), reader.GetInt32(14), reader.GetInt32(15), reader.GetBoolean(16)));
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
            return resultList;
        }

        // Функция добавления автомобильной шины в таблицу Tire БД
        public void AddDataInTireTable(TireClass newTire)
        {
            string columns = "vehicle_Id, tire_serialnumber, tire_size, tire_model, tire_weight, " +
                             "tire_coast, tire_madename, tire_position, tire_sparewheel, " +
                             "tire_installationdate, tire_removedate, tire_runnorma, tire_worknorma, " +
                             "tire_currentrun_km, tire_currentrun_years, tire_expluataionstatus";
            // строка запроса на добавление в таблицу Tire данных
            string connectionStr = $"INSERT INTO tire ({columns}) VALUES (@VehicleId, @Serialnumber, " +
                                   $"@Size, @Model, @Weight, @Coast, @Madename, @Position, @Sparewheel, " +
                                   $"@IDate, @RDate, @Runnorm, @Worknorma, @Currentrun, @Currentyears, @Status)";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                if (newTire.VehicleId == 0)
                    command.Parameters.AddWithValue("@VehicleId", null);
                else
                    command.Parameters.AddWithValue("@VehicleId", newTire.VehicleId);
                command.Parameters.AddWithValue("@Serialnumber", newTire.SerialNumber);
                command.Parameters.AddWithValue("@Size", newTire.Size);
                command.Parameters.AddWithValue("@Model", newTire.Model);
                command.Parameters.AddWithValue("@Weight", newTire.Weight);
                command.Parameters.AddWithValue("@Coast", newTire.Coast);
                command.Parameters.AddWithValue("@Madename", newTire.MadeName);
                command.Parameters.AddWithValue("@Position", newTire.Position);
                command.Parameters.AddWithValue("@Sparewheel", newTire.Sparewheel);
                command.Parameters.AddWithValue("@IDate", newTire.InstallationDate);
                command.Parameters.AddWithValue("@RDate", newTire.RemoveDate);
                command.Parameters.AddWithValue("@Runnorm", newTire.RunNorma);
                command.Parameters.AddWithValue("@Worknorma", newTire.WorkNorma);
                command.Parameters.AddWithValue("@Currentrun", newTire.CurrentRun);
                command.Parameters.AddWithValue("@Currentyears", newTire.CurrentYears);
                command.Parameters.AddWithValue("@Status", newTire.ExpluataionStatus);
                
                command.ExecuteNonQuery();
            }
        }

        // Функция обновления данных в таблице Tire
        public void EditDataInTireTable(TireClass editTire)
        {
            // строка запроса для обновления данных в таблице Tire
            string connectionStr = "UPDATE tire SET vehicle_Id = @VehicleId, tire_serialnumber = @Serialnumber, " +
                                   "tire_size = @Size, tire_model = @Model, tire_weight = @Weight, " +
                                   "tire_coast = @Coast, tire_madename = @Madename, tire_position = @Position, " +
                                   "tire_sparewheel = @Sparewheel, tire_installationdate = @IDate, tire_removedate = @RDate, " +
                                   "tire_runnorma = @Runnorm, tire_worknorma = @Worknorma, tire_currentrun_km = @Currentrun, " +
                                   "tire_currentrun_years = @Currentyears, tire_expluataionstatus = @Status " +
                                   "WHERE tire_Id = @ID";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@ID", editTire.TireId);
                if (editTire.VehicleId == 0)
                    command.Parameters.AddWithValue("@VehicleId", null);
                else
                    command.Parameters.AddWithValue("@VehicleId", editTire.VehicleId);
                command.Parameters.AddWithValue("@Serialnumber", editTire.SerialNumber);
                command.Parameters.AddWithValue("@Size", editTire.Size);
                command.Parameters.AddWithValue("@Model", editTire.Model);
                command.Parameters.AddWithValue("@Weight", editTire.Weight);
                command.Parameters.AddWithValue("@Coast", editTire.Coast);
                command.Parameters.AddWithValue("@Madename", editTire.MadeName);
                command.Parameters.AddWithValue("@Position", editTire.Position);
                command.Parameters.AddWithValue("@Sparewheel", editTire.Sparewheel);
                command.Parameters.AddWithValue("@IDate", editTire.InstallationDate);
                command.Parameters.AddWithValue("@RDate", editTire.RemoveDate);
                command.Parameters.AddWithValue("@Runnorm", editTire.RunNorma);
                command.Parameters.AddWithValue("@Worknorma", editTire.WorkNorma);
                command.Parameters.AddWithValue("@Currentrun", editTire.CurrentRun);
                command.Parameters.AddWithValue("@Currentyears", editTire.CurrentYears);
                command.Parameters.AddWithValue("@Status", editTire.ExpluataionStatus);

                command.ExecuteNonQuery();
            }
        }

        // Функция удаления автомобильной шины из таблицы Tire
        public void DelDataFromTireTable(int delID)
        {
            // строка запроса на выбор из таблицы Tire данных
            string connectionStr = $"DELETE FROM tire WHERE tire_Id = '{delID}'";
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

        // Функция подсчета количества автошин, установленных на одном автомобиле
        public int SelCountFromTireTable(int vId)
        {
            int result = 0;
            // строка запроса на выборку из таблицы Tire данных
            string connectionStr = $"SELECT COUNT(vehicle_Id) FROM tire WHERE vehicle_Id = {vId}";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection); ;
                object countObj = command.ExecuteScalar();
                if (countObj != null)
                    result = Convert.ToInt32(countObj);
            }
            return result;
        }
#endregion

        // Метод изменения данных текущего пробега после принятия путевого листа
        public void EditCurrentRun(int vId, int addRun, int wheelCount, int sWheelCount)
        {
            // если автомобиль существует
            if (vId != 0)
            {
                // вычисление наработки каждого колеса
                addRun = addRun / (wheelCount + sWheelCount) * wheelCount;
                // создание коллекции объектов
                ArrayList tireList = new ArrayList();
                // создание экземпляра класса TireClass
                TireClass tire = new TireClass();
                tireList.AddRange(tire.GetTireByVehicleId(vId));
                foreach (object item in tireList)
                {
                    tire = (TireClass)item;
                    // если колесо эксплуатируется
                    if (!tire.ExpluataionStatus)
                    {
                        tire.CurrentRun += addRun;
                        tire.EditDataInTireTable(tire);
                    }
                }
            }
        }
    }
}
