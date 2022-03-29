using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна справочника пользователей
    public partial class UsersForm : Form
    {

        public UsersForm()
        {
            InitializeComponent();
            ReadUsers();
        }

        // Считывание данных из таблицы User
        private void ReadUsers()
        {
            // создание коллекции объектов
            ArrayList userList = new ArrayList();
            UserClass user = new UserClass();
            userList.AddRange(user.ReadUserData());
            // заполнение таблицы данными из базы данных
            PrintUsers(listViewUsers, userList);
        }

#region ListViews
        // Процедура вывода информации о пользователях в listView
        private void PrintUsers(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка пользователей
            ListViewItem lvi;
            foreach (object item in list)
            {
                // создание экземпляра класса UserClass
                UserClass user = new UserClass();
                // создание экземпляра класса UserRightClass
                UserRightClass userRight = new UserRightClass();
                user = (UserClass) item;
                lvi = new ListViewItem(Convert.ToString(user.UserId));
                lvi.SubItems.Add(user.UserName);
                lvi.SubItems.Add(user.UserSpecialty);
                if (!user.UserDelStatus)
                    lvi.SubItems.Add("Активен");
                else
                    lvi.SubItems.Add("Заблокирован");
                // получение прав доступа пользователя
                userRight.GetRightById(user.UserId);
                // получение строки с перечислением прав доступа
                string rights = GetStringUserRight(userRight);
                lvi.SubItems.Add(rights);
                listV.Items.Add(lvi);
                // выделение заблокированного пользователя
                if (user.UserDelStatus)
                    lvi.ForeColor = Color.Gray;
            }
        }

        // обработчик процедуры выбора элементов в списке пользователей
        private void listViewUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewUsers.SelectedItems.Count > 0)
                SwitchingVisibility(true);
            else
                SwitchingVisibility(false);
        }

        // Функция определения прав пользователя
        private string GetStringUserRight(UserRightClass uRight)
        {
            string result = "";
            if (uRight.UserRightAdmin)
                result += "Администратор";
            if (uRight.UserRightWaybill)
            {
                if (result.Length > 0)
                    result += ", ";
                result += "Путевые листы";
            }
            if (uRight.UserRightWayblock)
            {
                if (result.Length > 0)
                    result += ", ";
                result += "Путевые-блокировка";
            }
            if (uRight.UserRightAvto)
            {
                if (result.Length > 0)
                    result += ", ";
                result += "Автомобили";
            }
            if (uRight.UserRightDriver)
            {
                if (result.Length > 0)
                    result += ", ";
                result += "Водители";
            }
            if (uRight.UserRightMechanic)
            {
                if (result.Length > 0)
                    result += ", ";
                result += "Механик";
            }
            if (uRight.UserRightGuides)
            {
                if (result.Length > 0)
                    result += ", ";
                result += "Остальные справочники";
            }

            return result;
        }
#endregion
#region Buttons
        // Обработчик кнопки "Добавить" пользователя
        private void addButton_Click(object sender, EventArgs e)
        {
            // открытие формы добавления пользователя
            AddEditUserForm aeForm = new AddEditUserForm("", 0);
            aeForm.ShowDialog();
            if (aeForm.DialogResult == DialogResult.OK)
            {
                // добавление пользователя в БД
                UserClass newUser = new UserClass();
                // предварительное шифрование пароля перед добавлением в БД
                string hashPass = newUser.GetHashPassword(aeForm.password, aeForm.login);
                newUser.AddDataInUserTable(aeForm.name, aeForm.specispecialty, aeForm.login, hashPass, aeForm.delStatus);
                // получение Id добавленного пользователя
                newUser.GetUserByLogin(aeForm.login);
                // добавление прав нового пользователя в БД
                UserRightClass userRights = new UserRightClass(newUser.UserId, aeForm.userRights[0], aeForm.userRights[1],
                    aeForm.userRights[2], aeForm.userRights[3], aeForm.userRights[4], aeForm.userRights[5], aeForm.userRights[6]);
                userRights.AddDataInUserrightTable(userRights);
                // обновление данных в таблице пользователей
                ReadUsers();
            }
        }

        // Обработчик кнопки "Редактировать" пользователя
        private void editButton_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id редактируемого пользователя
                int editId = Convert.ToInt32(listViewUsers.SelectedItems[0].Text);
                // открытие формы редактирования пользователя
                AddEditUserForm aeForm = new AddEditUserForm("editUser", editId);
                aeForm.ShowDialog();
                if (aeForm.DialogResult == DialogResult.OK)
                {
                    // создание экземпляра класса UserClass
                    UserClass editUser = new UserClass(editId, aeForm.name, aeForm.specispecialty, "", "", aeForm.delStatus);
                    // создание экземпляра класса UserRightClass
                    UserRightClass userRight = new UserRightClass(editId, aeForm.userRights[0], aeForm.userRights[1],
                    aeForm.userRights[2], aeForm.userRights[3], aeForm.userRights[4], aeForm.userRights[5],
                    aeForm.userRights[6]);
                    // обновление данных в таблицах User и UserRight БД
                    editUser.EditDataInUserTable(editUser);
                    userRight.EditDataInUserrightTable(userRight);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadUsers();
                }
            }
        }

        // Обработчик кнопки "Редактировать" пользователя в контекстном меню
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editButton_Click(sender, e);
        }

        private void listViewUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editButton_Click(sender, e);
        }

        // Обработчик кнопки "Удалить" пользователя
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count == 0)
                return;
            else
            {
                // запрос на подтверждение удаления
                DialogResult confirmationResult = MessageBox.Show(
                        "Вы уверены, что хотите удалить пользователя из системы?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                if (confirmationResult == DialogResult.Yes)
                {
                    UserClass delUser = new UserClass();
                    delUser.DelDataFromUserTable(Convert.ToInt32(listViewUsers.SelectedItems[0].Text));
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadUsers();
                }
            }
        }

        // Обработчик кнопки "Удалить" пользователя в контекстном меню
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteButton_Click(sender, e);
        }

        // Обработчик нажатия клавиши Delete на выбраном водителе
        private void listViewUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deleteButton_Click(sender, e);
        }
#endregion

        // Функция переключения видимости кнопок
        private void SwitchingVisibility(bool flag)
        {
            editButton.Enabled = flag;
            deleteButton.Enabled = flag;
            editToolStripMenuItem.Enabled = flag;
            deleteToolStripMenuItem.Enabled = flag;
        }
    }
}
