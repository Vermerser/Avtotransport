using System;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна авторизации
    public partial class AuthorizationForm : Form
    {
        // переменные класса
        public string Login;
        public string Password;
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // если введен только пароль
            if (loginTextBox.TextLength == 0 && passwordTextBox.TextLength > 0)
                MessageBox.Show("Введите логин!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // если введен только логин
            else if (loginTextBox.TextLength > 0 && passwordTextBox.TextLength == 0)
                MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Login = loginTextBox.Text;
                Password = passwordTextBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
