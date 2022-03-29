using System;
using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // ТО и пробег - класс реализует функционал действий с данными о сроках прохождения очередного ТО автомобилей
    class ServiceMileageClass
    {
        // переменные класса
        private int serviceId;          // Id техобслуживания и пробегов
        private int vehicleId;          // Id автомобиля
        private int speedometer;        // спидометр
        private int counter;            // счетчик моточасов
        private int speedometerTo1;     // спидометр до то1
        private int speedometerTo2;     // спидометр до то2
        private int intervalTo1;        // интервал до то1
        private int intervalTo2;        // интервал до то2
        private int counterTo1;         // счетчик моточасов до то1
        private int counterTo2;         // счетчик моточасов до то2
        private int counterTo3;         // счетчик моточасов до то3
        private int counterIntervalTo1; // интервал до то1
        private int counterIntervalTo2; // интервал до то2
        private int counterIntervalTo3; // интервал до то3
        private int speedometerLimit;   // лимит спидометра
        private int runLimit;           // лимитированный пробег
        private int speedometerControl; // контрольный спидометр
        private DateTime controlDate1;  // дата контроля 1
        private DateTime controlDate2;  // дата контроля 2
        private int avtoState;          // состояние автомобиля

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;charset=utf8";

        // пустой конструктор
        public ServiceMileageClass()
        {
        }

        // конструктор с переменными класса
        public ServiceMileageClass(int serviceId, int vehicleId, int speedometer, int counter, 
            int speedometerTo1, int speedometerTo2, int intervalTo1, int intervalTo2, int counterTo1, 
            int counterTo2, int counterTo3, int counterIntervalTo1, int counterIntervalTo2, 
            int counterIntervalTo3, int speedometerLimit, int runLimit, int speedometerControl, 
            DateTime controlDate1, DateTime controlDate2, int avtoState)
        {
            this.serviceId = serviceId;
            this.vehicleId = vehicleId;
            this.speedometer = speedometer;
            this.counter = counter;
            this.speedometerTo1 = speedometerTo1;
            this.speedometerTo2 = speedometerTo2;
            this.intervalTo1 = intervalTo1;
            this.intervalTo2 = intervalTo2;
            this.counterTo1 = counterTo1;
            this.counterTo2 = counterTo2;
            this.counterTo3 = counterTo3;
            this.counterIntervalTo1 = counterIntervalTo1;
            this.counterIntervalTo2 = counterIntervalTo2;
            this.counterIntervalTo3 = counterIntervalTo3;
            this.speedometerLimit = speedometerLimit;
            this.runLimit = runLimit;
            this.speedometerControl = speedometerControl;
            this.controlDate1 = controlDate1;
            this.controlDate2 = controlDate2;
            this.avtoState = avtoState;
        }

#region Getters&Setters&ToString
        public int ServiceId
        {
            get { return serviceId; }
            set { serviceId = value; }
        }

        public int VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }

        public int Speedometer
        {
            get { return speedometer; }
            set { speedometer = value; }
        }

        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }

        public int SpeedometerTo1
        {
            get { return speedometerTo1; }
            set { speedometerTo1 = value; }
        }

        public int SpeedometerTo2
        {
            get { return speedometerTo2; }
            set { speedometerTo2 = value; }
        }

        public int IntervalTo1
        {
            get { return intervalTo1; }
            set { intervalTo1 = value; }
        }

        public int IntervalTo2
        {
            get { return intervalTo2; }
            set { intervalTo2 = value; }
        }

        public int CounterTo1
        {
            get { return counterTo1; }
            set { counterTo1 = value; }
        }

        public int CounterTo2
        {
            get { return counterTo2; }
            set { counterTo2 = value; }
        }

        public int CounterTo3
        {
            get { return counterTo3; }
            set { counterTo3 = value; }
        }

        public int CounterIntervalTo1
        {
            get { return counterIntervalTo1; }
            set { counterIntervalTo1 = value; }
        }

        public int CounterIntervalTo2
        {
            get { return counterIntervalTo2; }
            set { counterIntervalTo2 = value; }
        }

        public int CounterIntervalTo3
        {
            get { return counterIntervalTo3; }
            set { counterIntervalTo3 = value; }
        }

        public int SpeedometerLimit
        {
            get { return speedometerLimit; }
            set { speedometerLimit = value; }
        }

        public int RunLimit
        {
            get { return runLimit; }
            set { runLimit = value; }
        }

        public int SpeedometerControl
        {
            get { return speedometerControl; }
            set { speedometerControl = value; }
        }

        public DateTime ControlDate1
        {
            get { return controlDate1; }
            set { controlDate1 = value; }
        }

        public DateTime ControlDate2
        {
            get { return controlDate2; }
            set { controlDate2 = value; }
        }

        public int AvtoState
        {
            get { return avtoState; }
            set { avtoState = value; }
        }

        public override string ToString()
        {
            return $"ServiceId: {serviceId}, VehicleId: {vehicleId}, Speedometer: {speedometer}, " +
                   $"Counter: {counter}, SpeedometerTo1: {speedometerTo1}, SpeedometerTo2: {speedometerTo2}, " +
                   $"IntervalTo1: {intervalTo1}, IntervalTo2: {intervalTo2}, CounterTo1: {counterTo1}, " +
                   $"CounterTo2: {counterTo2}, CounterTo3: {counterTo3}, CounterIntervalTo1: {counterIntervalTo1}, " +
                   $"CounterIntervalTo2: {counterIntervalTo2}, CounterIntervalTo3: {counterIntervalTo3}, " +
                   $"SpeedometerLimit: {speedometerLimit}, RunLimit: {runLimit}, SpeedometerControl: {speedometerControl}, " +
                   $"ControlDate1: {controlDate1}, ControlDate2: {controlDate2}, AvtoState: {avtoState}";
        }
        #endregion
#region DBfunctions
        // Функция получения сервисных данных из БД по Id
        public void GetServicemileageById(int vId)
        {
            // строка запроса на выбор из таблицы Servicemileage данных по vehicle_Id
            string connectionStr = $"SELECT * FROM servicemileage WHERE vehicle_Id = {vId}";
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
                        ServiceId = reader.GetInt32(0);
                        VehicleId = reader.GetInt32(1);
                        Speedometer = reader.GetInt32(2);
                        Counter = reader.GetInt32(3);
                        SpeedometerTo1 = reader.GetInt32(4);
                        SpeedometerTo2 = reader.GetInt32(5);
                        IntervalTo1 = reader.GetInt32(6);
                        IntervalTo2 = reader.GetInt32(7);
                        CounterTo1 = reader.GetInt32(8);
                        CounterTo2 = reader.GetInt32(9);
                        CounterTo3 = reader.GetInt32(10);
                        CounterIntervalTo1 = reader.GetInt32(11);
                        CounterIntervalTo2 = reader.GetInt32(12);
                        CounterIntervalTo3 = reader.GetInt32(13);
                        SpeedometerLimit = reader.GetInt32(14);
                        RunLimit = reader.GetInt32(15);
                        SpeedometerControl = reader.GetInt32(16);
                        ControlDate1 = reader.GetDateTime(17);
                        ControlDate2 = reader.GetDateTime(18);
                        AvtoState = reader.GetInt32(19);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция добавления данных в таблицу Servicemileage БД
        public void AddDataInServicemileageTable(ServiceMileageClass newService)
        {
            string columns = "vehicle_Id, service_speedometer, service_counter, service_speedometer_to1, " +
                             "service_speedometer_to2, service_interval_to1, service_interval_to2, " +
                             "service_counter_to1, service_counter_to2, service_counter_to3, " +
                             "service_counterinterval_to1, service_counterinterval_to2, " +
                             "service_counterinterval_to3, service_speedometerlimit, " +
                             "service_runlimit, service_speedometercontrol, service_controldate1, " +
                             "service_controldate2, service_avtostate";
            // строка запроса на добавление в таблицу Servicemileage данных
            string connectionStr = $"INSERT INTO servicemileage ({columns}) VALUES (@VehicleId, @Speedometer, @Counter, " +
                                   $"@SpeedometerTo1, @SpeedometerTo2, @IntervalTo1, @IntervalTo2, @CounterTo1, " +
                                   $"@CounterTo2, @CounterTo3, @CounterIntervalTo1, @CounterIntervalTo2, " +
                                   $"@CounterIntervalTo3, @SpeedometerLimit, @RunLimit, @SpeedometerControl, " +
                                   $"@ControlDate1, @ControlDate2, @AvtoState)";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@VehicleId", newService.VehicleId);
                command.Parameters.AddWithValue("@Speedometer", newService.Speedometer);
                command.Parameters.AddWithValue("@Counter", newService.Counter);
                command.Parameters.AddWithValue("@SpeedometerTo1", newService.SpeedometerTo1);
                command.Parameters.AddWithValue("@SpeedometerTo2", newService.SpeedometerTo2);
                command.Parameters.AddWithValue("@IntervalTo1", newService.IntervalTo1);
                command.Parameters.AddWithValue("@IntervalTo2", newService.IntervalTo2);
                command.Parameters.AddWithValue("@CounterTo1", newService.CounterTo1);
                command.Parameters.AddWithValue("@CounterTo2", newService.CounterTo2);
                command.Parameters.AddWithValue("@CounterTo3", newService.CounterTo3);
                command.Parameters.AddWithValue("@CounterIntervalTo1", newService.CounterIntervalTo1);
                command.Parameters.AddWithValue("@CounterIntervalTo2", newService.CounterIntervalTo2);
                command.Parameters.AddWithValue("@CounterIntervalTo3", newService.CounterIntervalTo3);
                command.Parameters.AddWithValue("@SpeedometerLimit", newService.SpeedometerLimit);
                command.Parameters.AddWithValue("@RunLimit", newService.RunLimit);
                command.Parameters.AddWithValue("@SpeedometerControl", newService.SpeedometerControl);
                command.Parameters.AddWithValue("@ControlDate1", newService.ControlDate1);
                command.Parameters.AddWithValue("@ControlDate2", newService.ControlDate2);
                command.Parameters.AddWithValue("@AvtoState", newService.AvtoState);

                command.ExecuteNonQuery();
            }
        }

        // Функция обновления данных в таблице Servicemileage
        public void EditDataInServicemileageTable(ServiceMileageClass editService)
        {
            // строка запроса для обновления данных в таблице Servicemileage
            string connectionStr = "UPDATE servicemileage SET vehicle_Id = @VehicleId, " +
                                   "service_speedometer = @Speedometer, service_counter = @Counter, " +
                                   "service_speedometer_to1 = @SpeedometerTo1, " +
                                   "service_speedometer_to2 = @SpeedometerTo2, " +
                                   "service_interval_to1 = @IntervalTo1, service_interval_to2 = @IntervalTo2, " +
                                   "service_counter_to1 = @CounterTo1, service_counter_to2 = @CounterTo2, " +
                                   "service_counter_to3 = @CounterTo2, service_counterinterval_to1 = @CounterIntervalTo1, " +
                                   "service_counterinterval_to2 = @CounterIntervalTo2, " +
                                   "service_counterinterval_to3 = @CounterIntervalTo3, " +
                                   "service_speedometerlimit = @SpeedometerLimit, service_runlimit = @RunLimit, " +
                                   "service_speedometercontrol = @SpeedometerControl, " +
                                   "service_controldate1 = @ControlDate1, service_controldate2 = @ControlDate2, " +
                                   "service_avtostate = @AvtoState WHERE service_Id = @ID";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@ID", editService.ServiceId);
                command.Parameters.AddWithValue("@VehicleId", editService.VehicleId);
                command.Parameters.AddWithValue("@Speedometer", editService.Speedometer);
                command.Parameters.AddWithValue("@Counter", editService.Counter);
                command.Parameters.AddWithValue("@SpeedometerTo1", editService.SpeedometerTo1);
                command.Parameters.AddWithValue("@SpeedometerTo2", editService.SpeedometerTo2);
                command.Parameters.AddWithValue("@IntervalTo1", editService.IntervalTo1);
                command.Parameters.AddWithValue("@IntervalTo2", editService.IntervalTo2);
                command.Parameters.AddWithValue("@CounterTo1", editService.CounterTo1);
                command.Parameters.AddWithValue("@CounterTo2", editService.CounterTo2);
                command.Parameters.AddWithValue("@CounterTo3", editService.CounterTo3);
                command.Parameters.AddWithValue("@CounterIntervalTo1", editService.CounterIntervalTo1);
                command.Parameters.AddWithValue("@CounterIntervalTo2", editService.CounterIntervalTo2);
                command.Parameters.AddWithValue("@CounterIntervalTo3", editService.CounterIntervalTo3);
                command.Parameters.AddWithValue("@SpeedometerLimit", editService.SpeedometerLimit);
                command.Parameters.AddWithValue("@RunLimit", editService.RunLimit);
                command.Parameters.AddWithValue("@SpeedometerControl", editService.SpeedometerControl);
                command.Parameters.AddWithValue("@ControlDate1", editService.ControlDate1);
                command.Parameters.AddWithValue("@ControlDate2", editService.ControlDate2);
                command.Parameters.AddWithValue("@AvtoState", editService.AvtoState);

                command.ExecuteNonQuery();
            }
        }
#endregion
    }
}
