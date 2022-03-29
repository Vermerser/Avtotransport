namespace Avtotransport
{
    partial class AddEditItineraryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditItineraryForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.ostanovBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.city100Box = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.medlBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.fieldBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.city1000Box = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.trackBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.city300Box = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.distanceBox = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(122, 255);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 36);
            this.panel2.TabIndex = 13;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ostanovBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.city100Box);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.medlBox);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.fieldBox);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.city1000Box);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.trackBox);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.city300Box);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.distanceBox);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 248);
            this.panel1.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(288, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "км";
            // 
            // ostanovBox
            // 
            this.ostanovBox.Location = new System.Drawing.Point(196, 219);
            this.ostanovBox.Name = "ostanovBox";
            this.ostanovBox.Size = new System.Drawing.Size(86, 20);
            this.ostanovBox.TabIndex = 8;
            this.ostanovBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "С остановками";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(288, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "км";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "км";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "км";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "км";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(288, 66);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 13);
            this.label19.TabIndex = 45;
            this.label19.Text = "км";
            // 
            // city100Box
            // 
            this.city100Box.Location = new System.Drawing.Point(196, 63);
            this.city100Box.Name = "city100Box";
            this.city100Box.Size = new System.Drawing.Size(86, 20);
            this.city100Box.TabIndex = 2;
            this.city100Box.TextChanged += new System.EventHandler(this.countBox_TextChanged);
            this.city100Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatBox_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 66);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(179, 13);
            this.label20.TabIndex = 43;
            this.label20.Text = "Город с начелением 100 тыс. чел.";
            // 
            // medlBox
            // 
            this.medlBox.Location = new System.Drawing.Point(196, 193);
            this.medlBox.Name = "medlBox";
            this.medlBox.Size = new System.Drawing.Size(86, 20);
            this.medlBox.TabIndex = 7;
            this.medlBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatBox_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 196);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "Медленно";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(288, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "км";
            // 
            // fieldBox
            // 
            this.fieldBox.Location = new System.Drawing.Point(196, 167);
            this.fieldBox.Name = "fieldBox";
            this.fieldBox.Size = new System.Drawing.Size(86, 20);
            this.fieldBox.TabIndex = 6;
            this.fieldBox.TextChanged += new System.EventHandler(this.countBox_TextChanged);
            this.fieldBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatBox_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 170);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Поле";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(288, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "км";
            // 
            // city1000Box
            // 
            this.city1000Box.Location = new System.Drawing.Point(196, 115);
            this.city1000Box.Name = "city1000Box";
            this.city1000Box.Size = new System.Drawing.Size(86, 20);
            this.city1000Box.TabIndex = 4;
            this.city1000Box.TextChanged += new System.EventHandler(this.countBox_TextChanged);
            this.city1000Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatBox_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Город с начелением 1 млн чел.";
            // 
            // trackBox
            // 
            this.trackBox.Location = new System.Drawing.Point(196, 141);
            this.trackBox.Name = "trackBox";
            this.trackBox.Size = new System.Drawing.Size(86, 20);
            this.trackBox.TabIndex = 5;
            this.trackBox.TextChanged += new System.EventHandler(this.countBox_TextChanged);
            this.trackBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatBox_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Трасса";
            // 
            // city300Box
            // 
            this.city300Box.Location = new System.Drawing.Point(196, 89);
            this.city300Box.Name = "city300Box";
            this.city300Box.Size = new System.Drawing.Size(86, 20);
            this.city300Box.TabIndex = 3;
            this.city300Box.TextChanged += new System.EventHandler(this.countBox_TextChanged);
            this.city300Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floatBox_KeyPress);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(196, 11);
            this.nameBox.MaxLength = 100;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(278, 20);
            this.nameBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Город с начелением 300 тыс. чел.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Маршрут";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Расстояние";
            // 
            // distanceBox
            // 
            this.distanceBox.Location = new System.Drawing.Point(196, 37);
            this.distanceBox.Name = "distanceBox";
            this.distanceBox.Size = new System.Drawing.Size(86, 20);
            this.distanceBox.TabIndex = 4;
            this.distanceBox.TabStop = false;
            // 
            // AddEditItineraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 296);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditItineraryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Учетная карточка маршрута";
            this.Load += new System.EventHandler(this.AddEditItineraryForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox city100Box;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox medlBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox fieldBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox city1000Box;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox trackBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox city300Box;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox distanceBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ostanovBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}