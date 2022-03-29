namespace Avtotransport
{
    partial class BatteryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatteryForm));
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.listViewBattery = new System.Windows.Forms.ListView();
            this.Battery_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Battery_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_Regnumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Battery_Installationdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Сurrentrun_Years = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Сurrentrun_Km = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Сurrentrun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dublicateButton = new System.Windows.Forms.Button();
            this.dublicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonsPanel.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonsPanel.Controls.Add(this.dublicateButton);
            this.buttonsPanel.Controls.Add(this.deleteButton);
            this.buttonsPanel.Controls.Add(this.editButton);
            this.buttonsPanel.Controls.Add(this.addButton);
            this.buttonsPanel.Location = new System.Drawing.Point(202, 309);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(544, 36);
            this.buttonsPanel.TabIndex = 9;
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(420, 3);
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
            this.editButton.Location = new System.Drawing.Point(281, 3);
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
            // listViewBattery
            // 
            this.listViewBattery.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewBattery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBattery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewBattery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Battery_ID,
            this.Battery_type,
            this.Vehicle_Model,
            this.Vehicle_Regnumber,
            this.Battery_Installationdate,
            this.Сurrentrun_Years,
            this.Сurrentrun_Km,
            this.Value,
            this.Сurrentrun});
            this.listViewBattery.ContextMenuStrip = this.contextMenuStrip;
            this.listViewBattery.FullRowSelect = true;
            this.listViewBattery.GridLines = true;
            this.listViewBattery.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewBattery.HideSelection = false;
            this.listViewBattery.Location = new System.Drawing.Point(2, 3);
            this.listViewBattery.MultiSelect = false;
            this.listViewBattery.Name = "listViewBattery";
            this.listViewBattery.Size = new System.Drawing.Size(945, 293);
            this.listViewBattery.TabIndex = 8;
            this.listViewBattery.UseCompatibleStateImageBehavior = false;
            this.listViewBattery.View = System.Windows.Forms.View.Details;
            this.listViewBattery.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewBattery_ItemSelectionChanged);
            this.listViewBattery.DoubleClick += new System.EventHandler(this.listViewBattery_DoubleClick);
            this.listViewBattery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewBattery_KeyDown);
            // 
            // Battery_ID
            // 
            this.Battery_ID.Text = "Рег. ном.";
            // 
            // Battery_type
            // 
            this.Battery_type.Text = "Тип аккумулятора";
            this.Battery_type.Width = 160;
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
            // Battery_Installationdate
            // 
            this.Battery_Installationdate.Text = "Дата установки";
            this.Battery_Installationdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Battery_Installationdate.Width = 110;
            // 
            // Сurrentrun_Years
            // 
            this.Сurrentrun_Years.Text = "Наработка, лет и мес.";
            this.Сurrentrun_Years.Width = 135;
            // 
            // Сurrentrun_Km
            // 
            this.Сurrentrun_Km.Text = "Наработка, км";
            this.Сurrentrun_Km.Width = 90;
            // 
            // Value
            // 
            this.Value.Text = "Уровень";
            this.Value.Width = 115;
            // 
            // Сurrentrun
            // 
            this.Сurrentrun.Text = "%";
            this.Сurrentrun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Сurrentrun.Width = 40;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dublicateToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(155, 70);
            // 
            // dublicateButton
            // 
            this.dublicateButton.Enabled = false;
            this.dublicateButton.Location = new System.Drawing.Point(142, 3);
            this.dublicateButton.Name = "dublicateButton";
            this.dublicateButton.Size = new System.Drawing.Size(120, 30);
            this.dublicateButton.TabIndex = 5;
            this.dublicateButton.Text = "Дублировать";
            this.dublicateButton.UseVisualStyleBackColor = true;
            this.dublicateButton.Click += new System.EventHandler(this.dublicateButton_Click);
            // 
            // dublicateToolStripMenuItem
            // 
            this.dublicateToolStripMenuItem.Enabled = false;
            this.dublicateToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.dublicate_button;
            this.dublicateToolStripMenuItem.Name = "dublicateToolStripMenuItem";
            this.dublicateToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.dublicateToolStripMenuItem.Text = "Дублировать";
            this.dublicateToolStripMenuItem.Click += new System.EventHandler(this.dublicateToolStripMenuItem_Click);
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
            // BatteryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 359);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.listViewBattery);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 398);
            this.Name = "BatteryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочник аккумуляторов";
            this.buttonsPanel.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListView listViewBattery;
        private System.Windows.Forms.ColumnHeader Battery_ID;
        private System.Windows.Forms.ColumnHeader Battery_type;
        private System.Windows.Forms.ColumnHeader Vehicle_Model;
        private System.Windows.Forms.ColumnHeader Vehicle_Regnumber;
        private System.Windows.Forms.ColumnHeader Battery_Installationdate;
        private System.Windows.Forms.ColumnHeader Сurrentrun_Years;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Сurrentrun_Km;
        private System.Windows.Forms.ColumnHeader Сurrentrun;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.Button dublicateButton;
        private System.Windows.Forms.ToolStripMenuItem dublicateToolStripMenuItem;
    }
}