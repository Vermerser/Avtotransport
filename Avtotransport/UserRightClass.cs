using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // Права пользователей – реализует функционал разграничения прав и ограничения доступа
    class UserRightClass
    {
        // переменные класса
        private int userRightId;            // Id прав пользователя
        private int userId;                 // Id пользователя, которому принадлежат права
        private bool userRightAdmin;        // права Администратора
        private bool userRightWaybill;      // права Путевые листы
        private bool userRightWayblock;     // права Путевые-блокировка
        private bool userRightAvto;         // права Автомобили
        private bool userRightDriver;       // права Водители
        private bool userRightMechanic;     // права Механик
        private bool userRightGuides;       // права Остальные справочники

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;";
        // пустой конструктор
        public UserRightClass()
        {
        }

        // конструктор со всеми переменными класса
        public UserRightClass(int userId, bool userRightAdmin, bool userRightWaybill, bool userRightWayblock,
            bool userRightAvto, bool userRightDriver, bool userRightMechanic, bool userRightGuides)
        {
            this.userId = userId;
            this.userRightAdmin = userRightAdmin;
            this.userRightWaybill = userRightWaybill;
            this.userRightWayblock = userRightWayblock;
            this.userRightAvto = userRightAvto;
            this.userRightDriver = userRightDriver;
            this.userRightMechanic = userRightMechanic;
            this.userRightGuides = userRightGuides;
        }

#region Getters&Setters&ToString
        // геттеры и сеттеры
        public int UserRightId
        {
            get { return userRightId; }
            set { userRightId = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public bool UserRightAdmin
        {
            get { return userRightAdmin; }
            set { userRightAdmin = value; }
        }

        public bool UserRightWaybill
        {
            get { return userRightWaybill; }
            set { userRightWaybill = value; }
        }

        public bool UserRightWayblock
        {
            get { return userRightWayblock; }
            set { userRightWayblock = value; }
        }

        public bool UserRightAvto
        {
            get { return userRightAvto; }
            set { userRightAvto = value; }
        }

        public bool UserRightDriver
        {
            get { return userRightDriver; }
            set { userRightDriver = value; }
        }

        public bool UserRightMechanic
        {
            get { return userRightMechanic; }
            set { userRightMechanic = value; }
        }

        public bool UserRightGuides
        {
            get { return userRightGuides; }
            set { userRightGuides = value; }
        }
        
        public override string ToString()
        {
            return $"{userRightAdmin}{userRightWaybill}{userRightWayblock}" +
                   $"{userRightAvto}{userRightDriver}{userRightMechanic}{userRightGuides}";
        }

#endregion
#region DBfunctions
        // Функция получения прав пользователя из БД по Id пользователя
        public void GetRightById(int uId)
        {
            // строка запроса на выбор из таблицы Userright данных по user_Id
            string connectionStr = $"SELECT * FROM userright WHERE user_Id = {uId}";
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
                        UserRightAdmin = reader.GetBoolean(2);
                        UserRightWaybill = reader.GetBoolean(3);
                        UserRightWayblock = reader.GetBoolean(4);
                        userRightAvto = reader.GetBoolean(5);
                        userRightDriver = reader.GetBoolean(6);
                        userRightMechanic = reader.GetBoolean(7);
                        userRightGuides = reader.GetBoolean(8);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция добавления прав пользователя в таблицу UserRight БД
        public void AddDataInUserrightTable(UserRightClass uRights)
        {
            string columns = "user_Id, user_right_admin, user_right_waybill, user_right_wayblock, user_right_avto, " +
                             "user_right_driver, user_right_mechanic, user_right_guides";
            // строка запроса на добавление в таблицу UserRight данных
            string connectionStr = $"INSERT INTO userright ({columns}) VALUES ({uRights.UserId}, {uRights.UserRightAdmin}, " +
                                   $"{uRights.UserRightWaybill}, {uRights.UserRightWayblock}, {uRights.UserRightAvto}, " +
                                   $"{uRights.UserRightDriver}, {uRights.UserRightMechanic}, {uRights.UserRightGuides})";
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

        // Функция обновления данных в таблице UserRight
        public void EditDataInUserrightTable(UserRightClass userRight)
        {
            // строка запроса для обновления данных в таблице UserRight
            string connectionStr = $"UPDATE userright SET user_right_admin = {userRight.UserRightAdmin}, " +
                                   $"user_right_waybill = {userRight.UserRightWaybill}, user_right_wayblock = {userRight.UserRightWayblock}, " +
                                   $"user_right_avto = {userRight.UserRightAvto}, user_right_driver = {userRight.UserRightDriver}, " +
                                   $"user_right_mechanic = {userRight.UserRightMechanic}, user_right_guides = {userRight.UserRightGuides} " +
                                   $"WHERE user_id = {userRight.UserId}";
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
