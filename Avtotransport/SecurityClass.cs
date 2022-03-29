using System.Windows.Forms;

namespace Avtotransport
{
    // Безопасность – класс реализует функционал авторизации пользователя в системе
    class SecurityClass
    {
        private bool userAuthorizationFlag; // флаг авторизации пользователя
        private int userRole;               // права авторизованного пользователя:
                                            // 0 - суперадмин;
                                            // 1 - пользователь;
                                            // 2 - гость.

        public UserClass user = new UserClass();   // создание переменной класса UserClass

        // конструктор
        public SecurityClass(bool userAuthorizationFlag)
        {
            this.userAuthorizationFlag = userAuthorizationFlag;
            UserAuthorization();
        }

        // Getters & Setters
        public bool UserAuthorizationFlag
        {
            get { return userAuthorizationFlag; }
            set { userAuthorizationFlag = value; }
        }

        public int UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }

        // Функция авторизации пользователя
        public void UserAuthorization()
        {
            // если пользователь не авторизован в системе
            if (!userAuthorizationFlag)
            {
                // показ окна авторизации пользователя в системе
                AuthorizationForm athForm = new AuthorizationForm();
                if (athForm.ShowDialog() == DialogResult.OK)
                {
                    // проверка введенных логина и пароля пользователя
                    if (UserAuthentication(athForm.Login, athForm.Password))
                    {
                        // пользователь успешно авторизован
                        UserAuthorizationFlag = true;
                    }
                    else
                    {
                        // ошибка авторизации пользователя
                        DialogResult result = MessageBox.Show("Неверно введен логин или пароль. Повторите попытку авторизоваться " +
                                                              "как пользователь или войдите как гость.", "Ошибка авторизации!", 
                                                              MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        // если пользователь желает повторить авторизацию
                        if (result == DialogResult.Retry)
                        {
                            UserAuthorizationFlag = false;
                            UserAuthorization();    // рекурсивный вызов функции авторизации
                        }
                        // в противном случае
                        else
                            UserAuthorizationFlag = false;
                    }
                }
            }
        }

        // Функция проверки авторизованного пользователя
        private bool UserAuthentication(string aLogin, string aPassword)
        {
            bool result = false;
            // если авторизовался суперадмин
            if (aLogin == "superadmin" && aPassword == "superadmin")
            {
                UserRole = 0;
                result = true;
            }
            // если авторизовался пользователь
            else if (aLogin.Length > 0 && aPassword.Length > 0)
            {
                // получение пользователя из БД по логину
                user.GetUserByLogin(aLogin);
                // хэширование пароля перед проверкой в БД
                string hashPass = user.GetHashPassword(aPassword, aLogin);
                // если логин и пароль есть в БД
                if (user.UserLogin == aLogin && user.UserPassword == hashPass)
                {
                    // проверка статуса блокировки пользователя
                    if (!user.UserDelStatus)
                    {
                        UserRole = 1;
                        result = true;
                    }
                }
            }
            // если авторизовался гость
            else if (aLogin.Length == 0 && aPassword.Length == 0)
            {
                UserRole = 2;
                result = true;
            }
            return result;
        }
    }
}
