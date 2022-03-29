using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // Нормы расхода – класс реализует функционал действий с данными о нормах расхода топлива, 
    // применимых для автомобилей
    class NormaClass
    {
        // переменные класса
        private int normaId;            // Id нормы
        private int vehicleId;          // Id автомобиля
        private float fuel;             // линейная
        private float trailer;          // с прицепом
        private float norma100;         // на 100 тонно-км
        private float norma100trailer;  // на 100 тонно-км с прицепом
        private float trip;             // на одну поездку
        private float mehanism;         // механизмы
        private float oil;              // масло
        private float gorod100;         // город с населением 100 тыс.
        private float gorod300;         // город с населением 300 тыс.
        private float gorod1000;        // город с населением 1 млн
        private float ostan;            // с остановками
        private float medl;             // медленно
        private float bezdor;           // бездорожье
        private float track;            // по трассе
        private float boost1;           // повышающий коэффициент 1
        private float boost2;           // повышающий коэффициент 2
        private float boost3;           // повышающий коэффициент 3
        private float cond;             // кондиционер
        private float otopitel;         // отопитель
        private float generator;        // генератор

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;charset=utf8";

        // пустой конструктор
        public NormaClass()
        {
        }

        // конструктор с переменными класса
        public NormaClass(int normaId, int vehicleId, float fuel, float trailer, float norma100, 
            float norma100Trailer, float trip, float mehanism, float oil, float gorod100, float gorod300, 
            float gorod1000, float ostan, float medl, float bezdor, float track, float boost1, 
            float boost2, float boost3, float cond, float otopitel, float generator)
        {
            this.normaId = normaId;
            this.vehicleId = vehicleId;
            this.fuel = fuel;
            this.trailer = trailer;
            this.norma100 = norma100;
            this.norma100trailer = norma100Trailer;
            this.trip = trip;
            this.oil = oil;
            this.mehanism = mehanism;
            this.gorod100 = gorod100;
            this.gorod300 = gorod300;
            this.gorod1000 = gorod1000;
            this.ostan = ostan;
            this.medl = medl;
            this.bezdor = bezdor;
            this.track = track;
            this.boost1 = boost1;
            this.boost2 = boost2;
            this.boost3 = boost3;
            this.cond = cond;
            this.otopitel = otopitel;
            this.generator = generator;
        }

#region Getters&Setters&ToString
        public int NormaId
        {
            get { return normaId; }
            set { normaId = value; }
        }

        public int VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }

        public float Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public float Trailer
        {
            get { return trailer; }
            set { trailer = value; }
        }

        public float Norma100
        {
            get { return norma100; }
            set { norma100 = value; }
        }

        public float Norma100Trailer
        {
            get { return norma100trailer; }
            set { norma100trailer = value; }
        }

        public float Trip
        {
            get { return trip; }
            set { trip = value; }
        }

        public float Mehanism
        {
            get { return mehanism; }
            set { mehanism = value; }
        }

        public float Oil
        {
            get { return oil; }
            set { oil = value; }
        }

        public float Gorod100
        {
            get { return gorod100; }
            set { gorod100 = value; }
        }

        public float Gorod300
        {
            get { return gorod300; }
            set { gorod300 = value; }
        }

        public float Gorod1000
        {
            get { return gorod1000; }
            set { gorod1000 = value; }
        }

        public float Ostan
        {
            get { return ostan; }
            set { ostan = value; }
        }

        public float Medl
        {
            get { return medl; }
            set { medl = value; }
        }

        public float Bezdor
        {
            get { return bezdor; }
            set { bezdor = value; }
        }

        public float Track
        {
            get { return track; }
            set { track = value; }
        }

        public float Boost1
        {
            get { return boost1; }
            set { boost1 = value; }
        }

        public float Boost2
        {
            get { return boost2; }
            set { boost2 = value; }
        }

        public float Boost3
        {
            get { return boost3; }
            set { boost3 = value; }
        }

        public float Cond
        {
            get { return cond; }
            set { cond = value; }
        }

        public float Otopitel
        {
            get { return otopitel; }
            set { otopitel = value; }
        }

        public float Generator
        {
            get { return generator; }
            set { generator = value; }
        }

        public override string ToString()
        {
            return $"NormaId: {normaId}, VehicleId: {vehicleId}, Fuel: {fuel}, " +
                   $"Trailer: {trailer}, Norma100: {norma100}, Norma100Trailer: {norma100trailer}, " +
                   $"Trip: {trip}, Mehanism: {mehanism}, Oil: {oil}, Gorod100: {gorod100}, " +
                   $"Gorod300: {gorod300}, Gorod1000: {gorod1000}, Ostan: {ostan}, Medl: {medl}, " +
                   $"Bezdor: {bezdor}, Track: {track}, Boost1: {boost1}, Boost2: {boost2}, " +
                   $"Boost3: {boost3}, Cond: {cond}, Otopitel: {otopitel}, Generator: {generator}";
        }

        #endregion
#region DBfunctions
        // Функция получения нормы из БД по Id
        public void GetNormaById(int vId)
        {
            // строка запроса на выбор из таблицы Norma данных по vehicle_Id
            string connectionStr = $"SELECT * FROM norma WHERE vehicle_Id = {vId}";
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
                        NormaId = reader.GetInt32(0);
                        VehicleId = reader.GetInt32(1);
                        Fuel = reader.GetFloat(2);
                        Trailer = reader.GetFloat(3);
                        Norma100 = reader.GetFloat(4);
                        Norma100Trailer = reader.GetFloat(5);
                        Trip = reader.GetFloat(6);
                        Mehanism = reader.GetFloat(7);
                        Oil = reader.GetFloat(8);
                        Gorod100 = reader.GetFloat(9);
                        Gorod300 = reader.GetFloat(10);
                        Gorod1000 = reader.GetFloat(11);
                        Ostan = reader.GetFloat(12);
                        Medl = reader.GetFloat(13);
                        Bezdor = reader.GetFloat(14);
                        Track = reader.GetFloat(15);
                        Boost1 = reader.GetFloat(16);
                        Boost2 = reader.GetFloat(17);
                        Boost3 = reader.GetFloat(18);
                        Cond = reader.GetFloat(19);
                        Otopitel = reader.GetFloat(20);
                        Generator = reader.GetFloat(21);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция добавления нормы в таблицу Norma БД
        public void AddDataInNormaTable(NormaClass newNorma)
        {
            string columns = "vehicle_Id, norma_fuel, norma_trailer, norma_100, norma_100trailer, " +
                             "norma_trip, norma_mehanism, norma_oil, norma_gorod100, norma_gorod300, " +
                             "norma_gorod1000, norma_ostan, norma_medl, norma_bezdor, norma_track, " +
                             "norma_boost1, norma_boost2, norma_boost3, norma_cond, norma_otopitel, " +
                             "norma_generator";
            // строка запроса на добавление в таблицу Norma данных
            string connectionStr = $"INSERT INTO norma ({columns}) VALUES (@VehicleId, @Fuel, @Trailer, " +
                                   $"@Norma100, @Norma100Trailer, @Trip, @Mehanism, @Oil, @Gorod100, @Gorod300, " +
                                   $"@Gorod1000, @Ostan, @Medl, @Bezdor, @Track, @Boost1, @Boost2, @Boost3, " +
                                   $"@Cond, @Otopitel, @Generator)";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@VehicleId", newNorma.VehicleId);
                command.Parameters.AddWithValue("@Fuel", newNorma.Fuel);
                command.Parameters.AddWithValue("@Trailer", newNorma.Trailer);
                command.Parameters.AddWithValue("@Norma100", newNorma.Norma100);
                command.Parameters.AddWithValue("@Norma100Trailer", newNorma.Norma100Trailer);
                command.Parameters.AddWithValue("@Trip", newNorma.Trip);
                command.Parameters.AddWithValue("@Mehanism", newNorma.Mehanism);
                command.Parameters.AddWithValue("@Oil", newNorma.Oil);
                command.Parameters.AddWithValue("@Gorod100", newNorma.Gorod100);
                command.Parameters.AddWithValue("@Gorod300", newNorma.Gorod300);
                command.Parameters.AddWithValue("@Gorod1000", newNorma.Gorod1000);
                command.Parameters.AddWithValue("@Ostan", newNorma.Ostan);
                command.Parameters.AddWithValue("@Medl", newNorma.Medl);
                command.Parameters.AddWithValue("@Bezdor", newNorma.Bezdor);
                command.Parameters.AddWithValue("@Track", newNorma.Track);
                command.Parameters.AddWithValue("@Boost1", newNorma.Boost1);
                command.Parameters.AddWithValue("@Boost2", newNorma.Boost2);
                command.Parameters.AddWithValue("@Boost3", newNorma.Boost3);
                command.Parameters.AddWithValue("@Cond", newNorma.Cond);
                command.Parameters.AddWithValue("@Otopitel", newNorma.Otopitel);
                command.Parameters.AddWithValue("@Generator", newNorma.Generator);

                command.ExecuteNonQuery();
            }
        }

        // Функция обновления данных в таблице Norma
        public void EditDataInNormaTable(NormaClass editNorma)
        {
            // строка запроса для обновления данных в таблице Norma
            string connectionStr = "UPDATE norma SET vehicle_Id = @VehicleId, norma_fuel = @Fuel, " +
                                   "norma_trailer = @Trailer, norma_100 = @Norma100, " +
                                   "norma_100trailer = @Norma100Trailer, norma_trip = @Trip, " +
                                   "norma_mehanism = @Mehanism, norma_oil = @Oil, norma_gorod100 = @Gorod100, " +
                                   "norma_gorod300 = @Gorod300, norma_gorod1000 = @Gorod1000, " +
                                   "norma_ostan = @Ostan, norma_medl = @Medl, norma_bezdor = @Bezdor, " +
                                   "norma_track = @Track, norma_boost1 = @Boost1, " +
                                   "norma_boost2 = @Boost2, norma_boost3 = @Boost3, " +
                                   "norma_cond = @Cond, norma_otopitel = @Otopitel, " +
                                   "norma_generator = @Generator WHERE norma_Id = @ID";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@ID", editNorma.NormaId);
                command.Parameters.AddWithValue("@VehicleId", editNorma.VehicleId);
                command.Parameters.AddWithValue("@Fuel", editNorma.Fuel);
                command.Parameters.AddWithValue("@Trailer", editNorma.Trailer);
                command.Parameters.AddWithValue("@Norma100", editNorma.Norma100);
                command.Parameters.AddWithValue("@Norma100Trailer", editNorma.Norma100Trailer);
                command.Parameters.AddWithValue("@Trip", editNorma.Trip);
                command.Parameters.AddWithValue("@Mehanism", editNorma.Mehanism);
                command.Parameters.AddWithValue("@Oil", editNorma.Oil);
                command.Parameters.AddWithValue("@Gorod100", editNorma.Gorod100);
                command.Parameters.AddWithValue("@Gorod300", editNorma.Gorod300);
                command.Parameters.AddWithValue("@Gorod1000", editNorma.Gorod1000);
                command.Parameters.AddWithValue("@Ostan", editNorma.Ostan);
                command.Parameters.AddWithValue("@Medl", editNorma.Medl);
                command.Parameters.AddWithValue("@Bezdor", editNorma.Bezdor);
                command.Parameters.AddWithValue("@Track", editNorma.Track);
                command.Parameters.AddWithValue("@Boost1", editNorma.Boost1);
                command.Parameters.AddWithValue("@Boost2", editNorma.Boost2);
                command.Parameters.AddWithValue("@Boost3", editNorma.Boost3);
                command.Parameters.AddWithValue("@Cond", editNorma.Cond);
                command.Parameters.AddWithValue("@Otopitel", editNorma.Otopitel);
                command.Parameters.AddWithValue("@Generator", editNorma.Generator);

                command.ExecuteNonQuery();
            }
        }
#endregion
    }
}
