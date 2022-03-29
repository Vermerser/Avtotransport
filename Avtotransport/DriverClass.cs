using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Avtotransport
{
    // Водители – класс реализует функционал действий с данными о водителях
    class DriverClass
    {
        // переменные класса
        private int driverId;               // Id водителя
        private string driverName;          // ФИО водителя
        private string driverCertificate;   // водительское удостоверение
        private string driverAdres;         // адрес проживания
        private DateTime driverMeddate;     // дата медосмотра
        private DateTime driverControldate; // дата контроля

        // строка подключения к БД
        private string connStr = "server=localhost;user=root;database=avtodb;port=3306;password=root;charset=utf8";

        // пустой конструктор
        public DriverClass()
        {
        }

        // конструктор с переменными класса
        public DriverClass(int driverId, string driverName, string driverCertificate, string driverAdres, 
            DateTime driverMeddate, DateTime driverControldate)
        {
            this.driverId = driverId;
            this.driverName = driverName;
            this.driverCertificate = driverCertificate;
            this.driverAdres = driverAdres;
            this.driverMeddate = driverMeddate;
            this.driverControldate = driverControldate;
        }

#region Getters&Setters&ToString
        public int DriverId
        {
            get { return driverId; }
            set { driverId = value; }
        }

        public string DriverName
        {
            get { return driverName; }
            set { driverName = value; }
        }

        public string DriverCertificate
        {
            get { return driverCertificate; }
            set { driverCertificate = value; }
        }

        public string DriverAdres
        {
            get { return driverAdres; }
            set { driverAdres = value; }
        }

        public DateTime DriverMeddate
        {
            get { return driverMeddate; }
            set { driverMeddate = value; }
        }

        public DateTime DriverControldate
        {
            get { return driverControldate; }
            set { driverControldate = value; }
        }

        public override string ToString()
        {
            return $"DriverId: {driverId}, DriverName: {driverName}, DriverCertificate: {driverCertificate}, " +
                   $"DriverAdres: {driverAdres}, DriverMeddate: {driverMeddate}, " +
                   $"DriverControldate: {driverControldate}";
        }
        #endregion
#region DBfunctions
        // Функция чтения данных из таблицы Driver базы данных
        public ArrayList ReadDriverData()
        {
            // строка запроса на выбор из таблицы Driver данных
            string connectionStr = "SELECT * FROM driver";
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
                        resultList.Add(new DriverClass(reader.GetInt32(0), reader.GetString(1).Trim(),
                            reader.GetString(2).Trim(), reader.GetString(3).Trim(),
                            reader.GetDateTime(4), reader.GetDateTime(5)));
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
            return resultList;
        }

        // Функция получения водителя из БД по Id
        public void GetDriverById(int dId)
        {
            // строка запроса на выбор из таблицы Driver данных по driver_Id
            string connectionStr = $"SELECT * FROM driver WHERE driver_Id = {dId}";
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
                        DriverId = reader.GetInt32(0);
                        DriverName = reader.GetString(1).Trim();
                        DriverCertificate = reader.GetString(2).Trim();
                        DriverAdres = reader.GetString(3).Trim();
                        DriverMeddate = reader.GetDateTime(4);
                        DriverControldate = reader.GetDateTime(5);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция получения водителя из БД по водительскому удостоверению
        public void GetDriverByCertificate(string dCert)
        {
            // строка запроса на выбор из таблицы Driver данных по driver_certificate
            string connectionStr = $"SELECT * FROM driver WHERE driver_certificate = '{dCert}'";
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
                        DriverId = reader.GetInt32(0);
                        DriverName = reader.GetString(1).Trim();
                        DriverCertificate = reader.GetString(2).Trim();
                        DriverAdres = reader.GetString(3).Trim();
                        DriverMeddate = reader.GetDateTime(4);
                        DriverControldate = reader.GetDateTime(5);
                    }
                }
                // закрытие reader
                reader.Close();
                // закрытие соединения с БД
                connection.Close();
            }
        }

        // Функция добавления водителя в таблицу Driver БД
        public void AddDataInDriverTable(DriverClass newDriver)
        {
            string columns = "driver_name, driver_certificate, driver_adres, driver_meddate, driver_controldate";
            // строка запроса на добавление в таблицу Driver данных
            string connectionStr = $"INSERT INTO driver ({columns}) VALUES (@Name, @Certificate, @Adres, " +
                                   $"@Meddate, @Controldate)";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@Name", newDriver.DriverName);
                command.Parameters.AddWithValue("@Certificate", newDriver.DriverCertificate);
                command.Parameters.AddWithValue("@Adres", newDriver.DriverAdres);
                command.Parameters.AddWithValue("@Meddate", newDriver.DriverMeddate);
                command.Parameters.AddWithValue("@Controldate", newDriver.DriverControldate);

                command.ExecuteNonQuery();
            }
        }

        // Функция обновления данных в таблице Driver
        public void EditDataInDriverTable(DriverClass editDriver)
        {
            // строка запроса для обновления данных в таблице Driver
            string connectionStr = "UPDATE driver SET driver_name = @Name, driver_certificate = @Certificate, " +
                                   "driver_adres = @Adres, driver_meddate = @Meddate, driver_controldate = @Controldate " +
                                   "WHERE driver_Id = @ID";
            // создание подключения
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                // устанавка соединения с БД
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(connectionStr, connection);
                // параметры
                command.Parameters.AddWithValue("@ID", editDriver.DriverId);
                command.Parameters.AddWithValue("@Name", editDriver.DriverName);
                command.Parameters.AddWithValue("@Certificate", editDriver.DriverCertificate);
                command.Parameters.AddWithValue("@Adres", editDriver.DriverAdres);
                command.Parameters.AddWithValue("@Meddate", editDriver.DriverMeddate);
                command.Parameters.AddWithValue("@Controldate", editDriver.DriverControldate);

                command.ExecuteNonQuery();
            }
        }

        // Функция удаления водителя из таблицы Driver
        public void DelDataFromDriverTable(int delID)
        {
            // строка запроса на выбор из таблицы Driver данных
            string connectionStr = $"DELETE FROM driver WHERE driver_id = '{delID}'";
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
