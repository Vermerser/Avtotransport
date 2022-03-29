using System;
using System.Windows.Forms;

namespace Avtotransport
{
    public partial class SettingPrintingForm : Form
    {
        // экземпляр класса SettingsClass
        SettingsClass settings = new SettingsClass();

        public SettingPrintingForm()
        {
            InitializeComponent();
            // чтение настроек из файла options.dat
            settings.ReadOptionsFile();
        }
        // Метод загрузки формы
        private void SettingPrintingForm_Load(object sender, EventArgs e)
        {
            AddTextBoxString(numberTextBox, settings.OrgNumber);
            AddTextBoxString(rankTextBox1, settings.CommanderRank);
            AddTextBoxString(nameTextBox1, settings.CommanderName);
            AddTextBoxString(postTextBox2, settings.ChiefPost);
            AddTextBoxString(rankTextBox2, settings.ChiefRank);
            AddTextBoxString(nameTextBox2, settings.ChiefName);
            AddTextBoxString(postTextBox3, settings.ProofPost);
            AddTextBoxString(rankTextBox3, settings.ProofRank);
            AddTextBoxString(nameTextBox3, settings.ProofName);
            AddTextBoxString(postTextBox4, settings.MakePost);
            AddTextBoxString(rankTextBox4, settings.MakeRank);
            AddTextBoxString(nameTextBox4, settings.MakeName);
        }

        // Метод заполнения TextBox при наличии данных
        private void AddTextBoxString(TextBox box, string text)
        {
            if (text != null)
                box.Text = text;
        }

        // Обработчик нажатия кнопки Ок
        private void okButton_Click(object sender, EventArgs e)
        {
            SetValue();
            settings.SaveOptionsFile(settings);
            DialogResult = DialogResult.OK;
            Close();
        }

        // Метод присвоения переменной класса соответствующих данных
        private void SetValue()
        {
            settings.OrgNumber = numberTextBox.Text;
            settings.CommanderRank = rankTextBox1.Text;
            settings.CommanderName = nameTextBox1.Text;
            settings.ChiefPost = postTextBox2.Text;
            settings.ChiefRank = rankTextBox2.Text;
            settings.ChiefName = nameTextBox2.Text;
            settings.ProofPost = postTextBox3.Text;
            settings.ProofRank = rankTextBox3.Text;
            settings.ProofName = nameTextBox3.Text;
            settings.MakePost = postTextBox4.Text;
            settings.MakeRank = rankTextBox4.Text;
            settings.MakeName = nameTextBox4.Text;
        }
    }
}
