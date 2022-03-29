namespace Avtotransport
{
    partial class AddDriverForm
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
            this.listViewDriver = new System.Windows.Forms.ListView();
            this.AddDriver_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddDriver_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddDriver_Certificate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(34, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 36);
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
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.listViewDriver);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 181);
            this.panel1.TabIndex = 12;
            // 
            // listViewDriver
            // 
            this.listViewDriver.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDriver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewDriver.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AddDriver_ID,
            this.AddDriver_Name,
            this.AddDriver_Certificate});
            this.listViewDriver.FullRowSelect = true;
            this.listViewDriver.GridLines = true;
            this.listViewDriver.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDriver.Location = new System.Drawing.Point(0, 0);
            this.listViewDriver.MultiSelect = false;
            this.listViewDriver.Name = "listViewDriver";
            this.listViewDriver.Size = new System.Drawing.Size(312, 180);
            this.listViewDriver.TabIndex = 9;
            this.listViewDriver.UseCompatibleStateImageBehavior = false;
            this.listViewDriver.View = System.Windows.Forms.View.Details;
            // 
            // AddDriver_ID
            // 
            this.AddDriver_ID.Text = "Рег. ном.";
            // 
            // AddDriver_Name
            // 
            this.AddDriver_Name.Text = "Фамилия, имя, отчество";
            this.AddDriver_Name.Width = 250;
            // 
            // AddDriver_Certificate
            // 
            this.AddDriver_Certificate.Text = "Удостоверение";
            this.AddDriver_Certificate.Width = 0;
            // 
            // AddDriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 231);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(332, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(332, 270);
            this.Name = "AddDriverForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddDriverForm";
            this.Load += new System.EventHandler(this.AddDriverForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewDriver;
        private System.Windows.Forms.ColumnHeader AddDriver_ID;
        private System.Windows.Forms.ColumnHeader AddDriver_Name;
        private System.Windows.Forms.ColumnHeader AddDriver_Certificate;
    }
}