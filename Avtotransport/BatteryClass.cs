using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // Аккумуляторы – класс реализует функционал действий с данными об аккумуляторах
    class BatteryClass
    {
        // переменные класса
        private int batteryId;                      // Id аккумулятора
        private int? vehicleId;                     // Id автомобиля
        private string batteryType;                 // тип аккумулятора
        private string batteryMadename;             // изготовитель аккумулятора
        private DateTime batteryDate;               // дата изготовления
        private float batteryCoast;                 // стоимость аккумулятора
        private int batteryBeforeinstKm;            // наработка до установки, км
        private int batteryBeforeinstMonth;         // наработка до установки, мес
        private int batteryTimenormYears;           // норма наработки, лет
        private int batteryTimenormMonth;           // норма наработки, мес
        private int batteryRunnorm;                 // норма пробега
        private DateTime batteryInstallationdate;   // дата установки
        private DateTime batteryRemovedate;         // дата снятия
        private int batteryCurrentrun;              // текущий пробег
        private int batteryCurrentmonth;            // текущая наработка
        private bool batteryStatus;                 // статус эксплуатации

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;charset=utf8";

        // пустой конструктор
        public BatteryClass()
        {
        }

        // конструктор с переменными класса
        public BatteryClass(int batteryId, int? vehicleId, string batteryType, string batteryMadename, DateTime batteryDate, 
            float batteryCoast, int batteryBeforeinstKm, int batteryBeforeinstMonth, int batteryTimenormYears, 
            int batteryTimenormMonth, int batteryRunnorm, DateTime batteryInstallationdate, DateTime batteryRemovedate, 
            int batteryCurrentrun, int batteryCurrentmonth, bool batteryStatus)
        {
            this.batteryId = batteryId;
            this.vehicleId = vehicleId;
            this.batteryType = batteryType;
            this.batteryMadename = batteryMadename;
            this.batteryDate = batteryDate;
            this.batteryCoast = batteryCoast;
            this.batteryBeforeinstKm = batteryBeforeinstKm;
            this.batteryBeforeinstMonth = batteryBeforeinstMonth;
            this.batteryTimenormYears = batteryTimenormYears;
            this.batteryTimenormMonth = batteryTimenormMonth;
            this.batteryRunnorm = batteryRunnorm;
            this.batteryInstallationdate = batteryInstallationdate;
            this.batteryRemovedate = batteryRemovedate;
            this.batteryCurrentrun = batteryCurrentrun;
            this.batteryCurrentmonth = batteryCurrentmonth;
            this.batteryStatus = batteryStatus;
        }

#region Getters&Setters&ToString

        public int BatteryId
        {
            get { return batteryId; }
            set { batteryId = value; }
        }

        public int? VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }
        
        public string BatteryType
        {
            get { return batteryType; }
            set { batteryType = value; }
        }

        public string BatteryMadename
        {
            get { return batteryMadename; }
            set { batteryMadename = value; }
        }

        public DateTime BatteryDate
        {
            get { return batteryDate; }
            set { batteryDate = value; }
        }

        public float BatteryCoast
        {
            get { return batteryCoast; }
            set { batteryCoast = value; }
        }

        public int BatteryBeforeinstKm
        {
            get { return batteryBeforeinstKm; }
            set { batteryBeforeinstKm = value; }
        }

        public int BatteryBeforeinstMonth
        {
            get { return batteryBeforeinstMonth; }
            set { batteryBeforeinstMonth = value; }
        }

        public int BatteryTimenormYears
        {
            get { return batteryTimenormYears; }
            set { batteryTimenormYears = value; }
        }

        public int BatteryTimenormMonth
        {
            get { return batteryTimenormMonth; }
            set { batteryTimenormMonth = value; }
        }

        public int BatteryRunnorm
        {
            get { return batteryRunnorm; }
            set { batteryRunnorm = value; }
        }

        public DateTime BatteryInstallationdate
        {
            get { return batteryInstallationdate; }
            set { batteryInstallationdate = value; }
        }

        public DateTime BatteryRemovedate
        {
            get { return batteryRemovedate; }
            set { batteryRemovedate = value; }
        }

        public int BatteryCurrentrun
        {
            get { return batteryCurrentrun; }
            set { batteryCurrentrun = value; }
        }

        public int BatteryCurrentmonth
        {
            get { return batteryCurrentmonth; }
            set { batteryCurrentmonth = value; }
        }

        public bool BatteryStatus
        {
            get { return batteryStatus; }
            set { batteryStatus = value; }
        }

        public override string ToString()
        {
            return $"DriverId: {batteryId}, VehicleId: {vehicleId}, BatteryType: {batteryType}, " +
                   $"BatteryMadename: {batteryMadename}, BatteryDate: {batteryDate}, " +
                   $"BatteryCoast: {batteryCoast}, BatteryBeforeinstKm: {batteryBeforeinstKm}, " +
                   $"BatteryBeforeinstMonth: {batteryBeforeinstMonth}, BatteryTimenormYears: {batteryTimenormYears}, " +
                   $"BatteryTimenormMonth: {batteryTimenormMonth}, BatteryRunnorm: {batteryRunnorm}, " +
                   $"BatteryInstallationdate: {batteryInstallationdate}, BatteryRemovedate: {batteryRemovedate}, " +
                   $"BatteryCurrentrun: {batteryCurrentrun}, BatteryCurrentmonth: {batteryCurrentmonth}, " +
                   $"BatteryStatus: {batteryStatus}";
        }
#endregion
#region DBfunctions
        // Функция чтения данных из таблицы Battery базы данных
        public ArrayList ReadBatteryData()
        {
            // строка запроса на выбор из таблицы Battery данных
            string connectionStr = "SELECT * FROM battery";
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
                        resultList.Add(new BatteryClass(reader.GetInt32(0), tmp, 
                            reader.GetString(2).Trim(), reader.GetString(3).Trim(), reader.GetDateTime(4), 
                            reader.GetFloat(5), reader.GetInt32(6), reader.GetInt32(7), 
                            reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), 
                            reader.GetDateTime(11), reader.GetDateTime(12), reader.GetInt32(13),
                            reader.GetInt32(14), reader.GetBoolean(15)));
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
            return resultList;
        }

        // Функция получения аккумулятора из БД по Id
        public void GetBatteryById(int bId)
        {
            // строка запроса на выбор из таблицы Battery данных по battery_Id
            string connectionStr = $"SELECT * FROM battery WHERE battery_Id = {bId}";
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
                        BatteryId = reader.GetInt32(0);
                        int? tmp = null;
                        if (!reader.IsDBNull(1))
                            tmp = reader.GetInt32(1);
                        VehicleId = tmp;
                        BatteryType = reader.GetString(2).Trim();
                        BatteryMadename = reader.GetString(3).Trim();
                        BatteryDate = reader.GetDateTime(4);
                        BatteryCoast = reader.GetFloat(5);
                        BatteryBeforeinstKm = reader.GetInt32(6);
                        BatteryBeforeinstMonth = reader.GetInt32(7);
                        BatteryTimenormYears = reader.GetInt32(8);
                        BatteryTimenormMonth = reader.GetInt32(9);
                        BatteryRunnorm = reader.GetInt32(10);
                        BatteryInstallationdate = reader.GetDateTime(11);
                        BatteryRemovedate = reader.GetDateTime(12);
                        BatteryCurrentrun = reader.GetInt32(13);
                        BatteryCurrentmonth = reader.GetInt32(14);
                        BatteryStatus = reader.GetBoolean(15);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция чтения данных из таблицы Battery БД по vehicle_Id
        public ArrayList GetBatteryByVehicleId(int vId)
        {
            // строка запроса на выбор из таблицы Battery данных
            string connectionStr = $"SELECT * FROM battery WHERE vehicle_Id = {vId}";
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
                        resultList.Add(new BatteryClass(reader.GetInt32(0), vId, reader.GetString(2).Trim(), 
                            reader.GetString(3).Trim(), reader.GetDateTime(4), reader.GetFloat(5), 
                            reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9), 
                            reader.GetInt32(10), reader.GetDateTime(11), reader.GetDateTime(12), reader.GetInt32(13),
                            reader.GetInt32(14), reader.GetBoolean(15)));
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
            return resultList;
        }

        // Функция добавления аккумулятора в таблицу Battery БД
        public void AddDataInBatteryTable(BatteryClass newBattery)
        {
            string columns = "vehicle_Id, battery_type, battery_madename, battery_date, battery_coast, " +
                             "battery_beforeinst_km, battery_beforeinst_month, battery_timenorm_years, " +
                             "battery_timenorm_month, battery_runnorm, battery_installationdate, " +
                             "battery_removedate, battery_currentrun_km, battery_currentrun_month, battery_status";
            // строка запроса на добавление в таблицу Battery данных
            string connectionStr = $"INSERT INTO battery ({columns}) VALUES (@VehicleId, @Type, @Madename, " +
                                   $"@BDate, @Coast, @Beforeinst1, @Beforeinst2, @Timenorm1, @Timenorm2, " +
                                   $"@Runnorm, @IDate, @RDate, @Currentrun, @Currentmonth, @Status)";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                if (newBattery.VehicleId == 0)
                    command.Parameters.AddWithValue("@VehicleId", null);
                else
                    command.Parameters.AddWithValue("@VehicleId", newBattery.VehicleId);
                command.Parameters.AddWithValue("@Type", newBattery.BatteryType);
                command.Parameters.AddWithValue("@Madename", newBattery.BatteryMadename);
                command.Parameters.AddWithValue("@BDate", newBattery.BatteryDate);
                command.Parameters.AddWithValue("@Coast", newBattery.BatteryCoast);
                command.Parameters.AddWithValue("@Beforeinst1", newBattery.BatteryBeforeinstKm);
                command.Parameters.AddWithValue("@Beforeinst2", newBattery.BatteryBeforeinstMonth);
                command.Parameters.AddWithValue("@Timenorm1", newBattery.BatteryTimenormYears);
                command.Parameters.AddWithValue("@Timenorm2", newBattery.BatteryTimenormMonth);
                command.Parameters.AddWithValue("@Runnorm", newBattery.BatteryRunnorm);
                command.Parameters.AddWithValue("@IDate", newBattery.BatteryInstallationdate);
                command.Parameters.AddWithValue("@RDate", newBattery.BatteryRemovedate);
                command.Parameters.AddWithValue("@Currentrun", newBattery.BatteryCurrentrun);
                command.Parameters.AddWithValue("@Currentmonth", newBattery.batteryCurrentmonth);
                command.Parameters.AddWithValue("@Status", newBattery.BatteryStatus);

                command.ExecuteNonQuery();
            }
        }

        // Функция обновления данных в таблице Battery
        public void EditDataInBatteryTable(BatteryClass editBattery)
        {
            // строка запроса для обновления данных в таблице Battery
            string connectionStr = "UPDATE battery SET vehicle_Id = @VehicleId, battery_type = @Type, battery_madename = @Madename, " +
                                   "battery_date = @BDate, battery_coast = @Coast, battery_beforeinst_km = @Beforeinst1, " +
                                   "battery_beforeinst_month = @Beforeinst2, battery_timenorm_years = @Timenorm1, " +
                                   "battery_timenorm_month = @Timenorm2, battery_runnorm = @Runnorm, battery_installationdate = @IDate, " +
                                   "battery_removedate = @RDate, battery_currentrun_km = @Currentrun, battery_currentrun_month = @Currentmonth, " +
                                   "battery_status = @Status WHERE battery_Id = @ID";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@ID", editBattery.BatteryId);
                if (editBattery.VehicleId == 0)
                    command.Parameters.AddWithValue("@VehicleId", null);
                else
                    command.Parameters.AddWithValue("@VehicleId", editBattery.VehicleId);
                command.Parameters.AddWithValue("@Type", editBattery.BatteryType);
                command.Parameters.AddWithValue("@Madename", editBattery.BatteryMadename);
                command.Parameters.AddWithValue("@BDate", editBattery.BatteryDate);
                command.Parameters.AddWithValue("@Coast", editBattery.BatteryCoast);
                command.Parameters.AddWithValue("@Beforeinst1", editBattery.BatteryBeforeinstKm);
                command.Parameters.AddWithValue("@Beforeinst2", editBattery.BatteryBeforeinstMonth);
                command.Parameters.AddWithValue("@Timenorm1", editBattery.BatteryTimenormYears);
                command.Parameters.AddWithValue("@Timenorm2", editBattery.BatteryTimenormMonth);
                command.Parameters.AddWithValue("@Runnorm", editBattery.BatteryRunnorm);
                command.Parameters.AddWithValue("@IDate", editBattery.BatteryInstallationdate);
                command.Parameters.AddWithValue("@RDate", editBattery.BatteryRemovedate);
                command.Parameters.AddWithValue("@Currentrun", editBattery.BatteryCurrentrun);
                command.Parameters.AddWithValue("@Currentmonth", editBattery.batteryCurrentmonth);
                command.Parameters.AddWithValue("@Status", editBattery.BatteryStatus);

                command.ExecuteNonQuery();
            }
        }

        // Функция удаления аккумулятора из таблицы Battery
        public void DelDataFromBatteryTable(int delID)
        {
            // строка запроса на выбор из таблицы Battery данных
            string connectionStr = $"DELETE FROM battery WHERE battery_Id = '{delID}'";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                command.ExecuteNonQuery();
            }
        }
#endregion

        // Метод изменения данных текущего пробега после принятия путевого листа
        public void EditCurrentRun(int vId, int addRun)
        {
            // создание коллекции объектов
            ArrayList tireList = new ArrayList();
            // создание экземпляра класса BatteryClass
            BatteryClass battery = new BatteryClass();
            tireList.AddRange(battery.GetBatteryByVehicleId(vId));
            foreach (object item in tireList)
            {
                battery = (BatteryClass)item;
                // если аккумулятор эксплуатируется
                if (!battery.BatteryStatus)
                {
                    battery.BatteryCurrentrun += addRun;
                    battery.EditDataInBatteryTable(battery);
                }
            }
        }
    }
}
