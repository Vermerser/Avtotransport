namespace Avtotransport
{
    partial class AddEditUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditUserForm));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userRightBox = new System.Windows.Forms.CheckedListBox();
            this.stActivComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.specialtyBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(135, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.groupBox2);
            this.panel.Controls.Add(this.stActivComboBox);
            this.panel.Controls.Add(this.label7);
            this.panel.Controls.Add(this.groupBox1);
            this.panel.Controls.Add(this.specialtyBox);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.nameBox);
            this.panel.Controls.Add(this.label2);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(314, 324);
            this.panel.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.userRightBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 83);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Права пользователя";
            // 
            // userRightBox
            // 
            this.userRightBox.BackColor = System.Drawing.SystemColors.Control;
            this.userRightBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userRightBox.CheckOnClick = true;
            this.userRightBox.ColumnWidth = 145;
            this.userRightBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userRightBox.FormattingEnabled = true;
            this.userRightBox.Items.AddRange(new object[] {
            "Администратор",
            "Путевые листы",
            "Путевые-блокировка",
            "Автомобили",
            "Водители",
            "Механик",
            "Остальные справочники"});
            this.userRightBox.Location = new System.Drawing.Point(1, 19);
            this.userRightBox.MultiColumn = true;
            this.userRightBox.Name = "userRightBox";
            this.userRightBox.Size = new System.Drawing.Size(293, 60);
            this.userRightBox.TabIndex = 0;
            // 
            // stActivComboBox
            // 
            this.stActivComboBox.FormattingEnabled = true;
            this.stActivComboBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.stActivComboBox.Items.AddRange(new object[] {
            "Активный",
            "Заблокирован"});
            this.stActivComboBox.Location = new System.Drawing.Point(7, 187);
            this.stActivComboBox.Name = "stActivComboBox";
            this.stActivComboBox.Size = new System.Drawing.Size(300, 21);
            this.stActivComboBox.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Статус активности";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.passwordBox);
            this.groupBox1.Controls.Add(this.loginBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(7, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 105);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные для авторизации";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Логин";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(9, 78);
            this.passwordBox.MaxLength = 20;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(284, 20);
            this.passwordBox.TabIndex = 5;
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(9, 39);
            this.loginBox.MaxLength = 20;
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(284, 20);
            this.loginBox.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Пароль";
            // 
            // specialtyBox
            // 
            this.specialtyBox.Location = new System.Drawing.Point(6, 58);
            this.specialtyBox.Name = "specialtyBox";
            this.specialtyBox.Size = new System.Drawing.Size(300, 20);
            this.specialtyBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Должность";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(7, 19);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(300, 20);
            this.nameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Фамилия, имя, отчество";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(47, 342);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 36);
            this.panel1.TabIndex = 6;
            // 
            // AddEditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 386);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Учетная карточка пользователя";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ComboBox stActivComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox specialtyBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox userRightBox;
    }
}