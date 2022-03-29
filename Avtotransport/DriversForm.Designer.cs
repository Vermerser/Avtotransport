namespace Avtotransport
{
    partial class DriversForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriversForm));
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.listViewDrivers = new System.Windows.Forms.ListView();
            this.Driver_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Driver_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Driver_Certificate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Driver_Adres = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Driver_Meddate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Driver_Controldate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonsPanel.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonsPanel.Controls.Add(this.deleteButton);
            this.buttonsPanel.Controls.Add(this.editButton);
            this.buttonsPanel.Controls.Add(this.addButton);
            this.buttonsPanel.Location = new System.Drawing.Point(280, 309);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(426, 36);
            this.buttonsPanel.TabIndex = 7;
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
            // listViewDrivers
            // 
            this.listViewDrivers.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDrivers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewDrivers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Driver_ID,
            this.Driver_Name,
            this.Driver_Certificate,
            this.Driver_Adres,
            this.Driver_Meddate,
            this.Driver_Controldate});
            this.listViewDrivers.ContextMenuStrip = this.contextMenuStrip;
            this.listViewDrivers.FullRowSelect = true;
            this.listViewDrivers.GridLines = true;
            this.listViewDrivers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDrivers.HideSelection = false;
            this.listViewDrivers.Location = new System.Drawing.Point(2, 3);
            this.listViewDrivers.MultiSelect = false;
            this.listViewDrivers.Name = "listViewDrivers";
            this.listViewDrivers.Size = new System.Drawing.Size(982, 293);
            this.listViewDrivers.TabIndex = 6;
            this.listViewDrivers.UseCompatibleStateImageBehavior = false;
            this.listViewDrivers.View = System.Windows.Forms.View.Details;
            this.listViewDrivers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewDrivers_ItemSelectionChanged);
            this.listViewDrivers.DoubleClick += new System.EventHandler(this.listViewDrivers_DoubleClick);
            this.listViewDrivers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewDrivers_KeyDown);
            // 
            // Driver_ID
            // 
            this.Driver_ID.Text = "Рег. ном.";
            // 
            // Driver_Name
            // 
            this.Driver_Name.Text = "Фамилия, имя, отчество";
            this.Driver_Name.Width = 255;
            // 
            // Driver_Certificate
            // 
            this.Driver_Certificate.Text = "Водительское удостоверение";
            this.Driver_Certificate.Width = 190;
            // 
            // Driver_Adres
            // 
            this.Driver_Adres.Text = "Адрес проживания";
            this.Driver_Adres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Driver_Adres.Width = 255;
            // 
            // Driver_Meddate
            // 
            this.Driver_Meddate.Text = "Дата медосмотра";
            this.Driver_Meddate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Driver_Meddate.Width = 110;
            // 
            // Driver_Controldate
            // 
            this.Driver_Controldate.Text = "Дата контроля";
            this.Driver_Controldate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Driver_Controldate.Width = 110;
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
            this.editToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.edit_user;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editToolStripMenuItem.Text = "Редактировать";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.delete_user;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // DriversForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 359);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.listViewDrivers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 398);
            this.Name = "DriversForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочник водителей";
            this.buttonsPanel.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListView listViewDrivers;
        private System.Windows.Forms.ColumnHeader Driver_ID;
        private System.Windows.Forms.ColumnHeader Driver_Name;
        private System.Windows.Forms.ColumnHeader Driver_Certificate;
        private System.Windows.Forms.ColumnHeader Driver_Adres;
        private System.Windows.Forms.ColumnHeader Driver_Meddate;
        private System.Windows.Forms.ColumnHeader Driver_Controldate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}