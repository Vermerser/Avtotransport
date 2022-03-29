namespace Avtotransport
{
    partial class ItineraryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItineraryForm));
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.listViewItinerary = new System.Windows.Forms.ListView();
            this.Itinerary_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Distance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItineraryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.City100 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.City300 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.City1000 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Track = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Field = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Medl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ostanov = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.buttonsPanel.Location = new System.Drawing.Point(317, 308);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(426, 36);
            this.buttonsPanel.TabIndex = 13;
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
            // listViewItinerary
            // 
            this.listViewItinerary.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewItinerary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewItinerary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewItinerary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Itinerary_ID,
            this.Distance,
            this.ItineraryName,
            this.City100,
            this.City300,
            this.City1000,
            this.Track,
            this.Field,
            this.Medl,
            this.Ostanov});
            this.listViewItinerary.ContextMenuStrip = this.contextMenuStrip;
            this.listViewItinerary.FullRowSelect = true;
            this.listViewItinerary.GridLines = true;
            this.listViewItinerary.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewItinerary.HideSelection = false;
            this.listViewItinerary.Location = new System.Drawing.Point(1, 2);
            this.listViewItinerary.MultiSelect = false;
            this.listViewItinerary.Name = "listViewItinerary";
            this.listViewItinerary.Size = new System.Drawing.Size(1061, 293);
            this.listViewItinerary.TabIndex = 12;
            this.listViewItinerary.UseCompatibleStateImageBehavior = false;
            this.listViewItinerary.View = System.Windows.Forms.View.Details;
            this.listViewItinerary.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewItinerary_ItemSelectionChanged);
            this.listViewItinerary.DoubleClick += new System.EventHandler(this.listViewTire_DoubleClick);
            this.listViewItinerary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewTire_KeyDown);
            // 
            // Itinerary_ID
            // 
            this.Itinerary_ID.Text = "Рег. ном.";
            // 
            // Distance
            // 
            this.Distance.Text = "Расстояние, км";
            this.Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Distance.Width = 100;
            // 
            // ItineraryName
            // 
            this.ItineraryName.Text = "Маршрут";
            this.ItineraryName.Width = 200;
            // 
            // City100
            // 
            this.City100.Text = "Город 100 тыс., км";
            this.City100.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.City100.Width = 110;
            // 
            // City300
            // 
            this.City300.Text = "Город 300 тыс., км";
            this.City300.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.City300.Width = 110;
            // 
            // City1000
            // 
            this.City1000.Text = "Город 1 млн, км";
            this.City1000.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.City1000.Width = 110;
            // 
            // Track
            // 
            this.Track.Text = "Трасса, км";
            this.Track.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Track.Width = 85;
            // 
            // Field
            // 
            this.Field.Text = "Поле, км";
            this.Field.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Field.Width = 85;
            // 
            // Medl
            // 
            this.Medl.Text = "Медленно, км";
            this.Medl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Medl.Width = 85;
            // 
            // Ostanov
            // 
            this.Ostanov.Text = "С остановками, км";
            this.Ostanov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Ostanov.Width = 115;
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
            // ItineraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 359);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.listViewItinerary);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 398);
            this.Name = "ItineraryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочник маршрутов";
            this.buttonsPanel.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListView listViewItinerary;
        private System.Windows.Forms.ColumnHeader Itinerary_ID;
        private System.Windows.Forms.ColumnHeader Distance;
        private System.Windows.Forms.ColumnHeader ItineraryName;
        private System.Windows.Forms.ColumnHeader City100;
        private System.Windows.Forms.ColumnHeader City300;
        private System.Windows.Forms.ColumnHeader City1000;
        private System.Windows.Forms.ColumnHeader Track;
        private System.Windows.Forms.ColumnHeader Field;
        private System.Windows.Forms.ColumnHeader Medl;
        private System.Windows.Forms.ColumnHeader Ostanov;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}