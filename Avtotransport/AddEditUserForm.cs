using System;
using System.Drawing;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна добавления и редактирования данных о пользователе
    public partial class AddEditUserForm : Form
    {
        // переменные класса
        private bool editFlag;  // флаг редактирования данных о пользователе
        private int userId;     // Id пользователя
        public string name, specispecialty, login, password;
        public bool delStatus;
        public bool[] userRights = new bool[7];

        public AddEditUserForm(string button, int id)
        {
            InitializeComponent();
            editFlag = false;
            userId = id;
            stActivComboBox.SelectedIndex = 0;
            // в случае открытия формы для редактирования
            CheckEditFlag(button);
        }

        // Функция проверки, для каких целей открыта форма
        private void CheckEditFlag(string flag)
        {
            // при открытии формы для редактирования данных пользователя
            if (flag == "editUser")
            {
                editFlag = true;
                // создание экземпляра класса UserClass
                UserClass editUser = new UserClass();
                // создание экземпляра класса UserRightClass
                UserRightClass userRight = new UserRightClass();
                // получение пользователя из БД по его Id
                editUser.GetUserById(userId);
                // получение прав доступа пользователя
                userRight.GetRightById(userId);
                // скрытие из формы данных для авторизации
                ResizeForm();
                // заполнение полей формы для редактирования данных пользователя
                nameBox.Text = editUser.UserName;
                specialtyBox.Text = editUser.UserSpecialty;
                stActivComboBox.SelectedIndex = editUser.UserDelStatus ? 1 : 0;
                // отметка соответствующих прав доступа пользователя
                GetUserRight(userRight);
            }
        }

        // Обработчик нажатия кнопки Ок
        private void button1_Click(object sender, EventArgs e)
        {
            // проверка заполненности всех полей формы
            // если не введены ФИО пользователя
            if (nameBox.TextLength == 0)
            {
                MessageBox.Show("Введите фамилию, имя, отчество пользователя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // если не введено название должности пользователя
            else if (specialtyBox.TextLength == 0)
            {
                MessageBox.Show("Введите название должности пользователя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если не выбрано ни одно из прав пользователя
            else if (userRightBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя-бы один пункт из прав пользователя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!editFlag)  // если открыта форма для добавления пользователя
            {
                // при не введенном логине пользователя
                if (loginBox.TextLength == 0)
                {
                    MessageBox.Show("Введите логин пользователя для последующей авторизации!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // при не введенном логине пользователя
                else if (passwordBox.TextLength == 0)
                {
                    MessageBox.Show("Введите пароль пользователя для последующей авторизации!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (!CheckUserLogin(loginBox.Text))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            // присвоение переменным класса соответствующих значений
            SetValue();
            // закрытие формы
            Close();
        }

        // Функция проверки наличия в БД пользователя с одинаковым логином
        private bool CheckUserLogin(string uLogin)
        {
            // споздание экземпляра класса UserClass
            UserClass user = new UserClass();
            // поиск в таблице User БД пользователя по логину
            user.GetUserByLogin(uLogin);
            // если такой логин есть в БД
            if (uLogin == user.UserLogin)
                return false;
            else
                return true;
        }

        // Функция присвоения переменным класса соответствующих значений
        private void SetValue()
        {
            name = nameBox.Text;
            specispecialty = specialtyBox.Text;
            if (!editFlag) // если открыта форма для добавления пользователя
            {
                login = loginBox.Text;
                password = passwordBox.Text;
            }
            delStatus = stActivComboBox.SelectedIndex == 0 ? false : true;
            // заполнение массива с правами пользователя
            for (int i = 0; i < userRightBox.CheckedItems.Count; i++)
            {
                userRights[userRightBox.CheckedIndices[i]] = true;
            }
        }

        // Функция скрытия из формы данных для авторизации и изменения размеров окна
        private void ResizeForm()
        {
            // скрытиt из формы данных для авторизации
            groupBox1.Visible = false;
            // изменениt размеров окна на величину скрытых данных
            panel.Height = 219;
            this.Height = 320;
            panel1.Location = new Point (47,237);
        }

        // Функция определения прав пользователя
        private void GetUserRight(UserRightClass uRight)
        {
            if (uRight.UserRightAdmin)
                userRightBox.SetItemChecked(0, true);
            if (uRight.UserRightWaybill)
                userRightBox.SetItemChecked(1, true);
            if (uRight.UserRightWayblock)
                userRightBox.SetItemChecked(2, true);
            if (uRight.UserRightAvto)
                userRightBox.SetItemChecked(3, true);
            if (uRight.UserRightDriver)
                userRightBox.SetItemChecked(4, true);
            if (uRight.UserRightMechanic)
                userRightBox.SetItemChecked(5, true);
            if (uRight.UserRightGuides)
                userRightBox.SetItemChecked(6, true);
        }
    }
}
