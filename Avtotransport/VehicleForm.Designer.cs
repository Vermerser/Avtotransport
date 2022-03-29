namespace Avtotransport
{
    partial class VehicleForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehicleForm));
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.listViewVehicle = new System.Windows.Forms.ListView();
            this.Vehicle_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_Regnumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Driver_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_bodytype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_motortype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_motorsize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_releasedate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_trailer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonsPanel.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonsPanel.Controls.Add(this.deleteButton);
            this.buttonsPanel.Controls.Add(this.editButton);
            this.buttonsPanel.Controls.Add(this.addButton);
            this.buttonsPanel.Location = new System.Drawing.Point(253, 309);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(426, 36);
            this.buttonsPanel.TabIndex = 11;
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(303, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(120, 30);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(153, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(120, 30);
            this.editButton.TabIndex = 3;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(120, 30);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // listViewVehicle
            // 
            this.listViewVehicle.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewVehicle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Vehicle_ID,
            this.Vehicle_Model,
            this.Vehicle_Regnumber,
            this.Driver_name,
            this.Vehicle_type,
            this.Vehicle_bodytype,
            this.Vehicle_motortype,
            this.Vehicle_motorsize,
            this.Vehicle_releasedate,
            this.Vehicle_trailer});
            this.listViewVehicle.ContextMenuStrip = this.contextMenuStrip;
            this.listViewVehicle.FullRowSelect = true;
            this.listViewVehicle.GridLines = true;
            this.listViewVehicle.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewVehicle.HideSelection = false;
            this.listViewVehicle.Location = new System.Drawing.Point(1, 3);
            this.listViewVehicle.MultiSelect = false;
            this.listViewVehicle.Name = "listViewVehicle";
            this.listViewVehicle.Size = new System.Drawing.Size(932, 259);
            this.listViewVehicle.TabIndex = 10;
            this.listViewVehicle.UseCompatibleStateImageBehavior = false;
            this.listViewVehicle.View = System.Windows.Forms.View.Details;
            this.listViewVehicle.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewBattery_ItemSelectionChanged);
            this.listViewVehicle.DoubleClick += new System.EventHandler(this.listViewBattery_DoubleClick);
            this.listViewVehicle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewBattery_KeyDown);
            // 
            // Vehicle_ID
            // 
            this.Vehicle_ID.Text = "Рег. ном.";
            // 
            // Vehicle_Model
            // 
            this.Vehicle_Model.Text = "Марка автомобиля";
            this.Vehicle_Model.Width = 140;
            // 
            // Vehicle_Regnumber
            // 
            this.Vehicle_Regnumber.Text = "Гос. номер";
            this.Vehicle_Regnumber.Width = 95;
            // 
            // Driver_name
            // 
            this.Driver_name.Text = "Водитель";
            this.Driver_name.Width = 120;
            // 
            // Vehicle_type
            // 
            this.Vehicle_type.Text = "Тип автомобиля";
            this.Vehicle_type.Width = 110;
            // 
            // Vehicle_bodytype
            // 
            this.Vehicle_bodytype.Text = "Тип кузова";
            this.Vehicle_bodytype.Width = 110;
            // 
            // Vehicle_motortype
            // 
            this.Vehicle_motortype.Text = "Тип двигателя";
            this.Vehicle_motortype.Width = 90;
            // 
            // Vehicle_motorsize
            // 
            this.Vehicle_motorsize.Text = "Объем двиг.";
            this.Vehicle_motorsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Vehicle_motorsize.Width = 76;
            // 
            // Vehicle_releasedate
            // 
            this.Vehicle_releasedate.Text = "Год выпуска";
            this.Vehicle_releasedate.Width = 80;
            // 
            // Vehicle_trailer
            // 
            this.Vehicle_trailer.Text = "Прицеп";
            this.Vehicle_trailer.Width = 50;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(155, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editToolStripMenuItem.Text = "Редактировать";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // infoPanel
            // 
            this.infoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoPanel.Controls.Add(this.label7);
            this.infoPanel.Controls.Add(this.label8);
            this.infoPanel.Controls.Add(this.label5);
            this.infoPanel.Controls.Add(this.label6);
            this.infoPanel.Controls.Add(this.label3);
            this.infoPanel.Controls.Add(this.label4);
            this.infoPanel.Controls.Add(this.label2);
            this.infoPanel.Controls.Add(this.label1);
            this.infoPanel.Location = new System.Drawing.Point(1, 271);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(932, 30);
            this.infoPanel.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Webdings", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "g";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "- необходимо пройти ТО1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "- необходимо пройти ТО2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Webdings", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(168, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "g";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "- контрольный спидометр";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Webdings", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label6.ForeColor = System.Drawing.Color.DarkOrange;
            this.label6.Location = new System.Drawing.Point(333, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "g";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(523, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "- контрольная дата";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Webdings", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label8.ForeColor = System.Drawing.Color.LawnGreen;
            this.label8.Location = new System.Drawing.Point(500, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "g";
            // 
            // VehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 359);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.listViewVehicle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 398);
            this.Name = "VehicleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочник автомобилей";
            this.buttonsPanel.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListView listViewVehicle;
        private System.Windows.Forms.ColumnHeader Vehicle_ID;
        private System.Windows.Forms.ColumnHeader Vehicle_Model;
        private System.Windows.Forms.ColumnHeader Vehicle_Regnumber;
        private System.Windows.Forms.ColumnHeader Driver_name;
        private System.Windows.Forms.ColumnHeader Vehicle_type;
        private System.Windows.Forms.ColumnHeader Vehicle_bodytype;
        private System.Windows.Forms.ColumnHeader Vehicle_motortype;
        private System.Windows.Forms.ColumnHeader Vehicle_motorsize;
        private System.Windows.Forms.ColumnHeader Vehicle_releasedate;
        private System.Windows.Forms.ColumnHeader Vehicle_trailer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}