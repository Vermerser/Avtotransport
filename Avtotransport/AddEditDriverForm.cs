using System;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс окна добавления и редактирования данных о водителе
    public partial class AddEditDriverForm : Form
    {
        // переменные класса
        private int driverId;
        public string name, certificate, adres;
        public DateTime meddate, controldate;

        public AddEditDriverForm(int id)
        {
            InitializeComponent();
            driverId = id;
            OpenedEditForm();
        }

        // Обработчик открытия формы для редактирования данных водителя
        private void OpenedEditForm()
        {
            if (driverId > 0)
            {
                // создание экземпляра класса DriverClass
                DriverClass editDriver = new DriverClass();
                // получение водителя из БД по его Id
                editDriver.GetDriverById(driverId);
                // заполнение полей формы для редактирования данных водителя
                nameBox.Text = editDriver.DriverName;
                certificateBox.Text = editDriver.DriverCertificate;
                adresBox.Text = editDriver.DriverAdres;
                dateTimePicker1.Value = editDriver.DriverMeddate;
                // если контрольная дата не установлена
                if (editDriver.DriverControldate == DateTime.MinValue)
                {
                    dateTimePicker2.Checked = false;
                    dateTimePicker2.Value = DateTime.Today;
                }
                else
                {
                    dateTimePicker2.Checked = true;
                    dateTimePicker2.Value = editDriver.DriverControldate;
                }
            }
            else
            {
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today;
            }
        }

        // Обработчик нажатия кнопки Ок
        private void button1_Click(object sender, EventArgs e)
        {
            // проверка заполненности всех полей формы
            // если не введены ФИО пользователя
            if (nameBox.TextLength == 0)
            {
                MessageBox.Show("Введите фамилию, имя, отчество водителя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если не введено водительское удостоверение
            else if (certificateBox.TextLength == 0)
            {
                MessageBox.Show("Введите серию и номер водительского удостоверения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // если в БД существует идентичное водительское удостоверение
            else if (!CheckDriverCertificate(certificateBox.Text))
            {
                MessageBox.Show("Водитель с таким водительским удостоверением уже существует!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
            // присвоение переменным класса соответствующих значений
            SetValue();
            // закрытие формы
            Close();
        }

        // Функция проверки наличия в БД водителя с одинаковым удостоверением
        private bool CheckDriverCertificate(string dCert)
        {
            // если данные водителя не редактируются
            if (driverId == 0)
            {
                // споздание экземпляра класса DriverClass
                DriverClass driver = new DriverClass();
                // поиск в таблице Driver БД водителя по водительскому удостоверению
                driver.GetDriverByCertificate(dCert);
                // если такое водительское удостоверение есть в БД
                if (dCert == driver.DriverCertificate)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }

        // Функция присвоения переменным класса соответствующих значений
        private void SetValue()
        {
            name = nameBox.Text;
            certificate = certificateBox.Text;
            adres = adresBox.Text;
            meddate = dateTimePicker1.Value;
            if (dateTimePicker2.Checked)
                controldate = dateTimePicker2.Value;
        }
    }
}
