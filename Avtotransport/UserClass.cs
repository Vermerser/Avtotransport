using System.Collections;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // Пользователи – класс реализует функционал действий с данными пользователей
    class UserClass
    {
        // переменные класса
        private int userId;             // Id пользователя
        private string userName;        // ФИО пользователя
        private string userSpecialty;   // должность
        private string userLogin;       // логин пользователя
        private string userPassword;    // пароль пользователя
        private bool userDelStatus;     // статус активности пользователя

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;charset=utf8";

        // пустой конструктор
        public UserClass()
        {
        }

        // конструктор со всеми переменными класса
        public UserClass(int userId, string userName, string userSpecialty, 
            string userLogin, string userPassword, bool userDelStatus)
        {
            this.userId = userId;
            this.userName = userName;
            this.userSpecialty = userSpecialty;
            this.userLogin = userLogin;
            this.userPassword = userPassword;
            this.userDelStatus = userDelStatus;
        }

#region Getters&Setters&ToString
        // геттеры и сеттеры
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string UserSpecialty
        {
            get { return userSpecialty; }
            set { userSpecialty = value; }
        }

        public string UserLogin
        {
            get { return userLogin; }
            set { userLogin = value; }
        }

        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }

        public bool UserDelStatus
        {
            get { return userDelStatus; }
            set { userDelStatus = value; }
        }

        public override string ToString()
        {
            return $"UserId: {userId}, UserName: {userName}, UserSpecialty: {userSpecialty}, " +
                   $"UserLogin: {userLogin}, UserPassword: {userPassword}, UserDelStatus: {userDelStatus}";
        }
#endregion
#region DBfunctions
        // Функция получения пользователя из БД по Id
        public void GetUserById(int uId)
        {
            // строка запроса на выбор из таблицы User данных по user_Id
            string connectionStr = $"SELECT * FROM user WHERE user_Id = {uId}";
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
                        UserId = reader.GetInt32(0);
                        UserName = reader.GetString(1).Trim();
                        UserSpecialty = reader.GetString(2).Trim();
                        UserLogin = reader.GetString(3).Trim();
                        UserPassword = reader.GetString(4).Trim();
                        UserDelStatus = reader.GetBoolean(5);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция получения пользователя из БД по логину
        public void GetUserByLogin(string uLogin)
        {
            // строка запроса на выбор из таблицы User данных по user_login
            string connectionStr = $"SELECT * FROM user WHERE user_login = '{uLogin}'";
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
                        UserId = reader.GetInt32(0);
                        UserName = reader.GetString(1).Trim();
                        UserSpecialty = reader.GetString(2).Trim();
                        UserLogin = reader.GetString(3).Trim();
                        UserPassword = reader.GetString(4).Trim();
                        UserDelStatus = reader.GetBoolean(5);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция чтения данных из таблицы User базы данных
        public ArrayList ReadUserData()
        {
            // строка запроса на выбор из таблицы User данных
            string connectionStr = "SELECT * FROM user";
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
                        resultList.Add(new UserClass(reader.GetInt32(0), reader.GetString(1).Trim(), 
                            reader.GetString(2).Trim(), reader.GetString(3).Trim(), 
                            reader.GetString(4).Trim(), reader.GetBoolean(5)));
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
            return resultList;
        }

        // Функция добавления пользователя в таблицу User БД
        public void AddDataInUserTable(string name, string spec, string login, string pass, bool delStat)
        {
            string columns = "user_name, user_specialty, user_login, user_password, user_del_status";
            int stat = delStat ? 1 : 0;
            // строка запроса на добавление в таблицу User данных
            string connectionStr = $"INSERT INTO user ({columns}) VALUES (N'{name}', N'{spec}', '{login}', '{pass}', {stat})";
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

        // Функция обновления данных в таблице User
        public void EditDataInUserTable(UserClass editUser)
        {
            int stat = editUser.UserDelStatus ? 1 : 0;
            // строка запроса для обновления данных в таблице User
            string connectionStr = $"UPDATE user SET user_name = N'{editUser.UserName}', user_specialty = N'{editUser.UserSpecialty}', " +
                                   $"user_del_status = {stat} WHERE user_id = {editUser.UserId}";
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

        // Функция удаления пользователя из таблицы User
        public void DelDataFromUserTable(int delID)
        {
            // строка запроса на выбор из таблицы User данных
            string connectionStr = $"DELETE FROM user WHERE user_id = '{delID}'";
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

        // Функция хэширования пароля
        public string GetHashPassword(string pass, string log)
        {
            // хеширование пароля и логина в одной строке
            string tmp = pass + log;
            //перевод строки в байт-массив  
            byte[] bytes = Encoding.Unicode.GetBytes(tmp);
            //создание объекта для получения средст шифрования  
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            //вычисление хеш-представления в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);
            string result = string.Empty;
            //формирование одной целой строки из массива  
            foreach (byte b in byteHash)
                result += string.Format("{0:x2}", b);

            return result;
        }
    }
}
