using System.Collections;
using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // Маршруты – класс реализует функционал действий с данными о маршрутах
    class ItineraryClass
    {
        // переменные класса
        private int itineraryId;        // Id маршрута
        private string itineraryName;   // название маршрута
        private float distance;         // общее расстояние
        private float city100;          // город с населением 100 тыс.
        private float city300;          // город с населением 300 тыс.
        private float city1000;         // город с населением 1 млн
        private float track;            // трасса
        private float field;            // поле
        private float medl;             // медленно
        private float ostanov;          // с остановками

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;charset=utf8";

        // пустой конструктор
        public ItineraryClass()
        {
        }

        // конструктор с переменными класса
        public ItineraryClass(int itineraryId, string itineraryName, float distance, float city100, 
            float city300, float city1000, float track, float field, float medl, float ostanov)
        {
            this.itineraryId = itineraryId;
            this.itineraryName = itineraryName;
            this.distance = distance;
            this.city100 = city100;
            this.city300 = city300;
            this.city1000 = city1000;
            this.track = track;
            this.field = field;
            this.medl = medl;
            this.ostanov = ostanov;
        }

#region Getters&Setters&ToString
        public int ItineraryId
        {
            get { return itineraryId; }
            set { itineraryId = value; }
        }

        public string ItineraryName
        {
            get { return itineraryName; }
            set { itineraryName = value; }
        }

        public float Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public float City100
        {
            get { return city100; }
            set { city100 = value; }
        }

        public float City300
        {
            get { return city300; }
            set { city300 = value; }
        }

        public float City1000
        {
            get { return city1000; }
            set { city1000 = value; }
        }

        public float Track
        {
            get { return track; }
            set { track = value; }
        }

        public float Field
        {
            get { return field; }
            set { field = value; }
        }

        public float Medl
        {
            get { return medl; }
            set { medl = value; }
        }

        public float Ostanov
        {
            get { return ostanov; }
            set { ostanov = value; }
        }

        public override string ToString()
        {
            return $"ItineraryId: {itineraryId}, ItineraryName: {itineraryName}, Distance: {distance}, " +
                   $"City100: {city100}, City300: {city300}, City1000: {city1000}, Track: {track}, " +
                   $"Field: {field}, Medl: {medl}, Ostanov: {ostanov}";
        }
        #endregion
#region DBfunctions
        // Функция чтения данных из таблицы Itinerary базы данных
        public ArrayList ReadItineraryData()
        {
            // строка запроса на выбор из таблицы Tire данных
            string connectionStr = "SELECT * FROM itinerary";
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
                        resultList.Add(new ItineraryClass(reader.GetInt32(0), reader.GetString(1).Trim(),
                            reader.GetFloat(2), reader.GetFloat(3), reader.GetFloat(4), reader.GetFloat(5), 
                            reader.GetFloat(6), reader.GetFloat(7), reader.GetFloat(8), reader.GetFloat(9)));
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
            return resultList;
        }

        // Функция получения маршрута из БД по Id
        public void GetItineraryById(int iId)
        {
            // строка запроса на выбор из таблицы Itinerary данных по itinerary_Id
            string connectionStr = $"SELECT * FROM itinerary WHERE itinerary_Id = {iId}";
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
                        ItineraryId = reader.GetInt32(0);
                        ItineraryName = reader.GetString(1).Trim();
                        Distance = reader.GetFloat(2);
                        City100 = reader.GetFloat(3);
                        City300 = reader.GetFloat(4);
                        City1000 = reader.GetFloat(5);
                        Track = reader.GetFloat(6);
                        Field = reader.GetFloat(7);
                        Medl = reader.GetFloat(8);
                        Ostanov = reader.GetFloat(9);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция добавления маршрута в таблицу Itinerary БД
        public void AddDataInItineraryTable(ItineraryClass newItinerary)
        {
            string columns = "itinerary_name, itinerary_distance, itinerary_city100, itinerary_city300, " +
                             "itinerary_city1000, itinerary_track, itinerary_field, itinerary_medl, " +
                             "itinerary_ostanov";
            // строка запроса на добавление в таблицу Itinerary данных
            string connectionStr = $"INSERT INTO itinerary ({columns}) VALUES (@Name, @Distance, " +
                                   $"@City100, @City300, @City1000, @Track, @Field, @Medl, @Ostanov)";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@Name", newItinerary.ItineraryName);
                command.Parameters.AddWithValue("@Distance", newItinerary.Distance);
                command.Parameters.AddWithValue("@City100", newItinerary.City100);
                command.Parameters.AddWithValue("@City300", newItinerary.City300);
                command.Parameters.AddWithValue("@City1000", newItinerary.City1000);
                command.Parameters.AddWithValue("@Track", newItinerary.Track);
                command.Parameters.AddWithValue("@Field", newItinerary.Field);
                command.Parameters.AddWithValue("@Medl", newItinerary.Medl);
                command.Parameters.AddWithValue("@Ostanov", newItinerary.Ostanov);
                
                command.ExecuteNonQuery();
            }
        }

        // Функция обновления данных в таблице Itinerary
        public void EditDataInItineraryTable(ItineraryClass editItinerary)
        {
            // строка запроса для обновления данных в таблице Itinerary
            string connectionStr = "UPDATE itinerary SET itinerary_name = @Name, itinerary_distance = @Distance, " +
                                   "itinerary_city100 = @City100, itinerary_city300 = @City300, itinerary_city1000 = @City1000, " +
                                   "itinerary_track = @Track, itinerary_field = @Field, itinerary_medl = @Medl, " +
                                   "itinerary_ostanov = @Ostanov WHERE itinerary_Id = @ID";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@ID", editItinerary.ItineraryId);
                command.Parameters.AddWithValue("@Name", editItinerary.ItineraryName);
                command.Parameters.AddWithValue("@Distance", editItinerary.Distance);
                command.Parameters.AddWithValue("@City100", editItinerary.City100);
                command.Parameters.AddWithValue("@City300", editItinerary.City300);
                command.Parameters.AddWithValue("@City1000", editItinerary.City1000);
                command.Parameters.AddWithValue("@Track", editItinerary.Track);
                command.Parameters.AddWithValue("@Field", editItinerary.Field);
                command.Parameters.AddWithValue("@Medl", editItinerary.Medl);
                command.Parameters.AddWithValue("@Ostanov", editItinerary.Ostanov);

                command.ExecuteNonQuery();
            }
        }

        // Функция удаления маршрута из таблицы Itinerary
        public void DelDataFromItineraryTable(int delID)
        {
            // строка запроса на выбор из таблицы Itinerary данных
            string connectionStr = $"DELETE FROM itinerary WHERE itinerary_Id = '{delID}'";
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
