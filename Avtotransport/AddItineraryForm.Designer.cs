namespace Avtotransport
{
    partial class AddItineraryForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewItinerary = new System.Windows.Forms.ListView();
            this.AddItinerary_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddItinerary_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddItinerary_Distance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(26, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 36);
            this.panel2.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(255, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.listViewItinerary);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 181);
            this.panel1.TabIndex = 12;
            // 
            // listViewItinerary
            // 
            this.listViewItinerary.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewItinerary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewItinerary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewItinerary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AddItinerary_ID,
            this.AddItinerary_Name,
            this.AddItinerary_Distance});
            this.listViewItinerary.FullRowSelect = true;
            this.listViewItinerary.GridLines = true;
            this.listViewItinerary.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewItinerary.Location = new System.Drawing.Point(0, 0);
            this.listViewItinerary.MultiSelect = false;
            this.listViewItinerary.Name = "listViewItinerary";
            this.listViewItinerary.Size = new System.Drawing.Size(435, 180);
            this.listViewItinerary.TabIndex = 9;
            this.listViewItinerary.UseCompatibleStateImageBehavior = false;
            this.listViewItinerary.View = System.Windows.Forms.View.Details;
            // 
            // AddItinerary_ID
            // 
            this.AddItinerary_ID.Text = "Рег. ном.";
            // 
            // AddItinerary_Name
            // 
            this.AddItinerary_Name.Text = "Название маршрута";
            this.AddItinerary_Name.Width = 263;
            // 
            // AddItinerary_Distance
            // 
            this.AddItinerary_Distance.Text = "Расстояние";
            this.AddItinerary_Distance.Width = 110;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(135, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 30);
            this.button3.TabIndex = 6;
            this.button3.Text = "Новый маршрут";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AddItineraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 231);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(455, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(455, 270);
            this.Name = "AddItineraryForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочник маршрутов";
            this.Load += new System.EventHandler(this.AddItineraryForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewItinerary;
        private System.Windows.Forms.ColumnHeader AddItinerary_ID;
        private System.Windows.Forms.ColumnHeader AddItinerary_Name;
        private System.Windows.Forms.ColumnHeader AddItinerary_Distance;
        private System.Windows.Forms.Button button3;
    }
}