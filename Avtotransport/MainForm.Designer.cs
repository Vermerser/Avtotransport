namespace Avtotransport
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.topMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingPrintingFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guidesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batteryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itineraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.travelOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.complOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuelRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intensityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.reportsButton = new System.Windows.Forms.Button();
            this.searchOrderButton = new System.Windows.Forms.Button();
            this.printOrderButton = new System.Windows.Forms.Button();
            this.complOrderButton = new System.Windows.Forms.Button();
            this.editOrderButton = new System.Windows.Forms.Button();
            this.deleteOrderButton = new System.Windows.Forms.Button();
            this.addOrderButton = new System.Windows.Forms.Button();
            this.itineraryGuideButton = new System.Windows.Forms.Button();
            this.vehicleGuideButton = new System.Windows.Forms.Button();
            this.tireGuideButton = new System.Windows.Forms.Button();
            this.batteryGuideButton = new System.Windows.Forms.Button();
            this.driverGuideButton = new System.Windows.Forms.Button();
            this.userGuideButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.userNameStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.userSpecialtyStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.orderPanel = new System.Windows.Forms.Panel();
            this.listViewOrders = new System.Windows.Forms.ListView();
            this.Order_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Order_Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vehicle_Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Driver_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Order_DateOut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Order_DateIn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Order_TimeOut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Order_TimeIn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Order_Itinerary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.complToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addRateButton = new System.Windows.Forms.Button();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.reportsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.diagramPictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.resultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.avtoRateListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.OnPrintButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.vedomostListView = new System.Windows.Forms.ListView();
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.informationListBox = new System.Windows.Forms.ListBox();
            this.machineComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.printCardButton = new System.Windows.Forms.Button();
            this.monthPanel = new System.Windows.Forms.Panel();
            this.monthButton12 = new System.Windows.Forms.Button();
            this.monthButton11 = new System.Windows.Forms.Button();
            this.monthButton10 = new System.Windows.Forms.Button();
            this.monthButton9 = new System.Windows.Forms.Button();
            this.monthButton8 = new System.Windows.Forms.Button();
            this.monthButton7 = new System.Windows.Forms.Button();
            this.monthButton6 = new System.Windows.Forms.Button();
            this.monthButton5 = new System.Windows.Forms.Button();
            this.monthButton4 = new System.Windows.Forms.Button();
            this.monthButton3 = new System.Windows.Forms.Button();
            this.monthButton2 = new System.Windows.Forms.Button();
            this.monthButton1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.yearLabel = new System.Windows.Forms.Label();
            this.nextYearButton = new System.Windows.Forms.Button();
            this.backYearButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.topMenuStrip.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.orderPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.reportsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.reportsTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diagramPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.monthPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenuStrip
            // 
            this.topMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.guidesToolStripMenuItem,
            this.travelOrderToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.topMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.topMenuStrip.Name = "topMenuStrip";
            this.topMenuStrip.Size = new System.Drawing.Size(1063, 24);
            this.topMenuStrip.TabIndex = 1;
            this.topMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.settingPrintingFormsToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.mainToolStripMenuItem.Text = "Главная";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.mainToolStripMenuItem_Click);
            // 
            // settingPrintingFormsToolStripMenuItem
            // 
            this.settingPrintingFormsToolStripMenuItem.Enabled = false;
            this.settingPrintingFormsToolStripMenuItem.Name = "settingPrintingFormsToolStripMenuItem";
            this.settingPrintingFormsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.settingPrintingFormsToolStripMenuItem.Text = "Настройка печатных форм";
            this.settingPrintingFormsToolStripMenuItem.Click += new System.EventHandler(this.settingPrintingFormsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.exitToolStripMenuItem.Text = "Выход из системы";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.closeToolStripMenuItem.Text = "Выход";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // guidesToolStripMenuItem
            // 
            this.guidesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.driverToolStripMenuItem,
            this.batteryToolStripMenuItem,
            this.tireToolStripMenuItem,
            this.avtoToolStripMenuItem,
            this.itineraryToolStripMenuItem});
            this.guidesToolStripMenuItem.Name = "guidesToolStripMenuItem";
            this.guidesToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.guidesToolStripMenuItem.Text = "Справочники";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.user_guide;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.userToolStripMenuItem.Text = "Пользователи";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userGuideButton_Click);
            // 
            // driverToolStripMenuItem
            // 
            this.driverToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.driver_guide;
            this.driverToolStripMenuItem.Name = "driverToolStripMenuItem";
            this.driverToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.driverToolStripMenuItem.Text = "Водители";
            this.driverToolStripMenuItem.Click += new System.EventHandler(this.driverGuideButton_Click);
            // 
            // batteryToolStripMenuItem
            // 
            this.batteryToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.battery_guide;
            this.batteryToolStripMenuItem.Name = "batteryToolStripMenuItem";
            this.batteryToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.batteryToolStripMenuItem.Text = "Аккумуляторы";
            this.batteryToolStripMenuItem.Click += new System.EventHandler(this.batteryGuideButton_Click);
            // 
            // tireToolStripMenuItem
            // 
            this.tireToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.tire_guide;
            this.tireToolStripMenuItem.Name = "tireToolStripMenuItem";
            this.tireToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.tireToolStripMenuItem.Text = "Автомобильные шины";
            this.tireToolStripMenuItem.Click += new System.EventHandler(this.tireGuideButton_Click);
            // 
            // avtoToolStripMenuItem
            // 
            this.avtoToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.vehicle_guide;
            this.avtoToolStripMenuItem.Name = "avtoToolStripMenuItem";
            this.avtoToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.avtoToolStripMenuItem.Text = "Автомобили";
            this.avtoToolStripMenuItem.Click += new System.EventHandler(this.vehicleGuideButton_Click);
            // 
            // itineraryToolStripMenuItem
            // 
            this.itineraryToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.itinerary_guide;
            this.itineraryToolStripMenuItem.Name = "itineraryToolStripMenuItem";
            this.itineraryToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.itineraryToolStripMenuItem.Text = "Маршруты";
            this.itineraryToolStripMenuItem.Click += new System.EventHandler(this.itineraryGuideButton_Click);
            // 
            // travelOrderToolStripMenuItem
            // 
            this.travelOrderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOrderToolStripMenuItem,
            this.delOrderToolStripMenuItem,
            this.editOrderToolStripMenuItem,
            this.complOrderToolStripMenuItem,
            this.printOrderToolStripMenuItem,
            this.searchOrderToolStripMenuItem});
            this.travelOrderToolStripMenuItem.Name = "travelOrderToolStripMenuItem";
            this.travelOrderToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.travelOrderToolStripMenuItem.Text = "Путевой лист";
            // 
            // addOrderToolStripMenuItem
            // 
            this.addOrderToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.addOrder;
            this.addOrderToolStripMenuItem.Name = "addOrderToolStripMenuItem";
            this.addOrderToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.addOrderToolStripMenuItem.Text = "Выписать";
            this.addOrderToolStripMenuItem.Click += new System.EventHandler(this.addOrderButton_Click);
            // 
            // delOrderToolStripMenuItem
            // 
            this.delOrderToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.delOrder;
            this.delOrderToolStripMenuItem.Name = "delOrderToolStripMenuItem";
            this.delOrderToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.delOrderToolStripMenuItem.Text = "Удалить";
            this.delOrderToolStripMenuItem.Click += new System.EventHandler(this.deleteOrderButton_Click);
            // 
            // editOrderToolStripMenuItem
            // 
            this.editOrderToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.editOrder;
            this.editOrderToolStripMenuItem.Name = "editOrderToolStripMenuItem";
            this.editOrderToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.editOrderToolStripMenuItem.Text = "Изменить";
            this.editOrderToolStripMenuItem.Click += new System.EventHandler(this.editOrderButton_Click);
            // 
            // complOrderToolStripMenuItem
            // 
            this.complOrderToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.compOrder;
            this.complOrderToolStripMenuItem.Name = "complOrderToolStripMenuItem";
            this.complOrderToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.complOrderToolStripMenuItem.Text = "Принять";
            this.complOrderToolStripMenuItem.Click += new System.EventHandler(this.complOrderButton_Click);
            // 
            // printOrderToolStripMenuItem
            // 
            this.printOrderToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.printOrder;
            this.printOrderToolStripMenuItem.Name = "printOrderToolStripMenuItem";
            this.printOrderToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.printOrderToolStripMenuItem.Text = "Печать";
            this.printOrderToolStripMenuItem.Click += new System.EventHandler(this.printOrderButton_Click);
            // 
            // searchOrderToolStripMenuItem
            // 
            this.searchOrderToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.searchOrder;
            this.searchOrderToolStripMenuItem.Name = "searchOrderToolStripMenuItem";
            this.searchOrderToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.searchOrderToolStripMenuItem.Text = "Поиск";
            this.searchOrderToolStripMenuItem.Click += new System.EventHandler(this.searchOrderButton_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fuelRateToolStripMenuItem,
            this.intensityToolStripMenuItem,
            this.summaryListToolStripMenuItem,
            this.cardToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.reportsToolStripMenuItem.Text = "Отчеты";
            // 
            // fuelRateToolStripMenuItem
            // 
            this.fuelRateToolStripMenuItem.Name = "fuelRateToolStripMenuItem";
            this.fuelRateToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.fuelRateToolStripMenuItem.Text = "Расход топлива";
            this.fuelRateToolStripMenuItem.Click += new System.EventHandler(this.fuelRateToolStripMenuItem_Click);
            // 
            // intensityToolStripMenuItem
            // 
            this.intensityToolStripMenuItem.Name = "intensityToolStripMenuItem";
            this.intensityToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.intensityToolStripMenuItem.Text = "Интенсивность использования автотранспорта";
            this.intensityToolStripMenuItem.Click += new System.EventHandler(this.intensityToolStripMenuItem_Click);
            // 
            // summaryListToolStripMenuItem
            // 
            this.summaryListToolStripMenuItem.Name = "summaryListToolStripMenuItem";
            this.summaryListToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.summaryListToolStripMenuItem.Text = "Сводная ведомость учета работы машин";
            this.summaryListToolStripMenuItem.Click += new System.EventHandler(this.summaryListToolStripMenuItem_Click);
            // 
            // cardToolStripMenuItem
            // 
            this.cardToolStripMenuItem.Name = "cardToolStripMenuItem";
            this.cardToolStripMenuItem.Size = new System.Drawing.Size(335, 22);
            this.cardToolStripMenuItem.Text = "Карточка учета работы машин";
            this.cardToolStripMenuItem.Click += new System.EventHandler(this.cardToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpToolStripMenuItem.Text = "Помощь";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPanel.Controls.Add(this.reportsButton);
            this.menuPanel.Controls.Add(this.searchOrderButton);
            this.menuPanel.Controls.Add(this.printOrderButton);
            this.menuPanel.Controls.Add(this.complOrderButton);
            this.menuPanel.Controls.Add(this.editOrderButton);
            this.menuPanel.Controls.Add(this.deleteOrderButton);
            this.menuPanel.Controls.Add(this.addOrderButton);
            this.menuPanel.Controls.Add(this.itineraryGuideButton);
            this.menuPanel.Controls.Add(this.vehicleGuideButton);
            this.menuPanel.Controls.Add(this.tireGuideButton);
            this.menuPanel.Controls.Add(this.batteryGuideButton);
            this.menuPanel.Controls.Add(this.driverGuideButton);
            this.menuPanel.Controls.Add(this.userGuideButton);
            this.menuPanel.Location = new System.Drawing.Point(0, 27);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(1063, 60);
            this.menuPanel.TabIndex = 3;
            // 
            // reportsButton
            // 
            this.reportsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reportsButton.Image = global::Avtotransport.Properties.Resources.reports;
            this.reportsButton.Location = new System.Drawing.Point(734, 3);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(53, 53);
            this.reportsButton.TabIndex = 15;
            this.reportsButton.UseVisualStyleBackColor = true;
            this.reportsButton.Click += new System.EventHandler(this.reportsButton_Click);
            // 
            // searchOrderButton
            // 
            this.searchOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchOrderButton.Image = global::Avtotransport.Properties.Resources.searchOrder;
            this.searchOrderButton.Location = new System.Drawing.Point(663, 3);
            this.searchOrderButton.Name = "searchOrderButton";
            this.searchOrderButton.Size = new System.Drawing.Size(53, 53);
            this.searchOrderButton.TabIndex = 14;
            this.searchOrderButton.UseVisualStyleBackColor = true;
            this.searchOrderButton.Click += new System.EventHandler(this.searchOrderButton_Click);
            // 
            // printOrderButton
            // 
            this.printOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printOrderButton.Enabled = false;
            this.printOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.printOrderButton.Image = global::Avtotransport.Properties.Resources.printOrder;
            this.printOrderButton.Location = new System.Drawing.Point(604, 3);
            this.printOrderButton.Name = "printOrderButton";
            this.printOrderButton.Size = new System.Drawing.Size(53, 53);
            this.printOrderButton.TabIndex = 13;
            this.printOrderButton.UseVisualStyleBackColor = true;
            this.printOrderButton.Click += new System.EventHandler(this.printOrderButton_Click);
            // 
            // complOrderButton
            // 
            this.complOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.complOrderButton.Enabled = false;
            this.complOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.complOrderButton.Image = global::Avtotransport.Properties.Resources.compOrder;
            this.complOrderButton.Location = new System.Drawing.Point(545, 3);
            this.complOrderButton.Name = "complOrderButton";
            this.complOrderButton.Size = new System.Drawing.Size(53, 53);
            this.complOrderButton.TabIndex = 12;
            this.complOrderButton.UseVisualStyleBackColor = true;
            this.complOrderButton.Click += new System.EventHandler(this.complOrderButton_Click);
            // 
            // editOrderButton
            // 
            this.editOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editOrderButton.Enabled = false;
            this.editOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editOrderButton.Image = global::Avtotransport.Properties.Resources.editOrder;
            this.editOrderButton.Location = new System.Drawing.Point(486, 3);
            this.editOrderButton.Name = "editOrderButton";
            this.editOrderButton.Size = new System.Drawing.Size(53, 53);
            this.editOrderButton.TabIndex = 11;
            this.editOrderButton.UseVisualStyleBackColor = true;
            this.editOrderButton.Click += new System.EventHandler(this.editOrderButton_Click);
            // 
            // deleteOrderButton
            // 
            this.deleteOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteOrderButton.Enabled = false;
            this.deleteOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteOrderButton.Image = global::Avtotransport.Properties.Resources.delOrder;
            this.deleteOrderButton.Location = new System.Drawing.Point(427, 3);
            this.deleteOrderButton.Name = "deleteOrderButton";
            this.deleteOrderButton.Size = new System.Drawing.Size(53, 53);
            this.deleteOrderButton.TabIndex = 10;
            this.deleteOrderButton.UseVisualStyleBackColor = true;
            this.deleteOrderButton.Click += new System.EventHandler(this.deleteOrderButton_Click);
            // 
            // addOrderButton
            // 
            this.addOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addOrderButton.Image = global::Avtotransport.Properties.Resources.addOrder;
            this.addOrderButton.Location = new System.Drawing.Point(368, 3);
            this.addOrderButton.Name = "addOrderButton";
            this.addOrderButton.Size = new System.Drawing.Size(53, 53);
            this.addOrderButton.TabIndex = 9;
            this.addOrderButton.UseVisualStyleBackColor = true;
            this.addOrderButton.Click += new System.EventHandler(this.addOrderButton_Click);
            // 
            // itineraryGuideButton
            // 
            this.itineraryGuideButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itineraryGuideButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.itineraryGuideButton.Image = global::Avtotransport.Properties.Resources.itinerary_guide;
            this.itineraryGuideButton.Location = new System.Drawing.Point(298, 3);
            this.itineraryGuideButton.Name = "itineraryGuideButton";
            this.itineraryGuideButton.Size = new System.Drawing.Size(53, 53);
            this.itineraryGuideButton.TabIndex = 8;
            this.itineraryGuideButton.UseVisualStyleBackColor = true;
            this.itineraryGuideButton.Click += new System.EventHandler(this.itineraryGuideButton_Click);
            // 
            // vehicleGuideButton
            // 
            this.vehicleGuideButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vehicleGuideButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.vehicleGuideButton.Image = global::Avtotransport.Properties.Resources.vehicle_guide;
            this.vehicleGuideButton.Location = new System.Drawing.Point(239, 3);
            this.vehicleGuideButton.Name = "vehicleGuideButton";
            this.vehicleGuideButton.Size = new System.Drawing.Size(53, 53);
            this.vehicleGuideButton.TabIndex = 7;
            this.vehicleGuideButton.UseVisualStyleBackColor = true;
            this.vehicleGuideButton.Click += new System.EventHandler(this.vehicleGuideButton_Click);
            // 
            // tireGuideButton
            // 
            this.tireGuideButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tireGuideButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tireGuideButton.Image = global::Avtotransport.Properties.Resources.tire_guide;
            this.tireGuideButton.Location = new System.Drawing.Point(180, 3);
            this.tireGuideButton.Name = "tireGuideButton";
            this.tireGuideButton.Size = new System.Drawing.Size(53, 53);
            this.tireGuideButton.TabIndex = 6;
            this.tireGuideButton.UseVisualStyleBackColor = true;
            this.tireGuideButton.Click += new System.EventHandler(this.tireGuideButton_Click);
            // 
            // batteryGuideButton
            // 
            this.batteryGuideButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.batteryGuideButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.batteryGuideButton.Image = global::Avtotransport.Properties.Resources.battery_guide;
            this.batteryGuideButton.Location = new System.Drawing.Point(121, 3);
            this.batteryGuideButton.Name = "batteryGuideButton";
            this.batteryGuideButton.Size = new System.Drawing.Size(53, 53);
            this.batteryGuideButton.TabIndex = 5;
            this.batteryGuideButton.UseVisualStyleBackColor = true;
            this.batteryGuideButton.Click += new System.EventHandler(this.batteryGuideButton_Click);
            // 
            // driverGuideButton
            // 
            this.driverGuideButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.driverGuideButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.driverGuideButton.Image = global::Avtotransport.Properties.Resources.driver_guide;
            this.driverGuideButton.Location = new System.Drawing.Point(62, 3);
            this.driverGuideButton.Name = "driverGuideButton";
            this.driverGuideButton.Size = new System.Drawing.Size(53, 53);
            this.driverGuideButton.TabIndex = 1;
            this.driverGuideButton.UseVisualStyleBackColor = true;
            this.driverGuideButton.Click += new System.EventHandler(this.driverGuideButton_Click);
            // 
            // userGuideButton
            // 
            this.userGuideButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userGuideButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.userGuideButton.Image = global::Avtotransport.Properties.Resources.user_guide;
            this.userGuideButton.Location = new System.Drawing.Point(3, 3);
            this.userGuideButton.Name = "userGuideButton";
            this.userGuideButton.Size = new System.Drawing.Size(53, 53);
            this.userGuideButton.TabIndex = 0;
            this.userGuideButton.UseVisualStyleBackColor = true;
            this.userGuideButton.Click += new System.EventHandler(this.userGuideButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userNameStatusLabel,
            this.userSpecialtyStatusLabel,
            this.dateTimeStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 512);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1063, 24);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // userNameStatusLabel
            // 
            this.userNameStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.userNameStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.userNameStatusLabel.Name = "userNameStatusLabel";
            this.userNameStatusLabel.Size = new System.Drawing.Size(483, 19);
            this.userNameStatusLabel.Spring = true;
            this.userNameStatusLabel.Text = "имя пользователя";
            this.userNameStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userSpecialtyStatusLabel
            // 
            this.userSpecialtyStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.userSpecialtyStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.userSpecialtyStatusLabel.Name = "userSpecialtyStatusLabel";
            this.userSpecialtyStatusLabel.Size = new System.Drawing.Size(483, 19);
            this.userSpecialtyStatusLabel.Spring = true;
            this.userSpecialtyStatusLabel.Text = "специальность";
            // 
            // dateTimeStatusLabel
            // 
            this.dateTimeStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.dateTimeStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.dateTimeStatusLabel.Name = "dateTimeStatusLabel";
            this.dateTimeStatusLabel.Size = new System.Drawing.Size(81, 19);
            this.dateTimeStatusLabel.Text = "время и дата";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // orderPanel
            // 
            this.orderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderPanel.Controls.Add(this.listViewOrders);
            this.orderPanel.Location = new System.Drawing.Point(0, 89);
            this.orderPanel.Name = "orderPanel";
            this.orderPanel.Size = new System.Drawing.Size(1063, 95);
            this.orderPanel.TabIndex = 5;
            // 
            // listViewOrders
            // 
            this.listViewOrders.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Order_ID,
            this.Order_Number,
            this.Vehicle_Model,
            this.Vehicle_Number,
            this.Driver_Name,
            this.Order_DateOut,
            this.Order_DateIn,
            this.Order_TimeOut,
            this.Order_TimeIn,
            this.Order_Itinerary});
            this.listViewOrders.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewOrders.FullRowSelect = true;
            this.listViewOrders.GridLines = true;
            this.listViewOrders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewOrders.HideSelection = false;
            this.listViewOrders.Location = new System.Drawing.Point(3, 0);
            this.listViewOrders.MultiSelect = false;
            this.listViewOrders.Name = "listViewOrders";
            this.listViewOrders.Size = new System.Drawing.Size(1057, 95);
            this.listViewOrders.TabIndex = 7;
            this.listViewOrders.UseCompatibleStateImageBehavior = false;
            this.listViewOrders.View = System.Windows.Forms.View.Details;
            this.listViewOrders.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewOrders_ItemSelectionChanged);
            this.listViewOrders.DoubleClick += new System.EventHandler(this.listViewOrders_DoubleClick);
            this.listViewOrders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewOrders_KeyDown);
            // 
            // Order_ID
            // 
            this.Order_ID.Text = "Рег. ном.";
            this.Order_ID.Width = 0;
            // 
            // Order_Number
            // 
            this.Order_Number.Text = "Номер";
            this.Order_Number.Width = 145;
            // 
            // Vehicle_Model
            // 
            this.Vehicle_Model.Text = "Марка автомобиля";
            this.Vehicle_Model.Width = 115;
            // 
            // Vehicle_Number
            // 
            this.Vehicle_Number.Text = "Госномер";
            this.Vehicle_Number.Width = 90;
            // 
            // Driver_Name
            // 
            this.Driver_Name.Text = "Водитель";
            this.Driver_Name.Width = 120;
            // 
            // Order_DateOut
            // 
            this.Order_DateOut.Text = "Дата";
            this.Order_DateOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Order_DateOut.Width = 80;
            // 
            // Order_DateIn
            // 
            this.Order_DateIn.Text = "Дата по";
            this.Order_DateIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Order_DateIn.Width = 80;
            // 
            // Order_TimeOut
            // 
            this.Order_TimeOut.Text = "Выезд";
            this.Order_TimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Order_TimeOut.Width = 80;
            // 
            // Order_TimeIn
            // 
            this.Order_TimeIn.Text = "Возвращене";
            this.Order_TimeIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Order_TimeIn.Width = 80;
            // 
            // Order_Itinerary
            // 
            this.Order_Itinerary.Text = "Маршрут";
            this.Order_Itinerary.Width = 264;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.complToolStripMenuItem,
            this.printToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.lockToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 114);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.editOrder;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.editToolStripMenuItem.Text = "Изменить";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editOrderButton_Click);
            // 
            // complToolStripMenuItem
            // 
            this.complToolStripMenuItem.Enabled = false;
            this.complToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.compOrder;
            this.complToolStripMenuItem.Name = "complToolStripMenuItem";
            this.complToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.complToolStripMenuItem.Text = "Заполнить";
            this.complToolStripMenuItem.Click += new System.EventHandler(this.complOrderButton_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.printOrder;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.printToolStripMenuItem.Text = "Печать";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printOrderButton_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.delOrder;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteOrderButton_Click);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Enabled = false;
            this.lockToolStripMenuItem.Image = global::Avtotransport.Properties.Resources.lockOrder;
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.lockToolStripMenuItem.Text = "Блокировка";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // reportsPanel
            // 
            this.reportsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportsPanel.Controls.Add(this.panel1);
            this.reportsPanel.Controls.Add(this.reportsTabControl);
            this.reportsPanel.Location = new System.Drawing.Point(0, 190);
            this.reportsPanel.Name = "reportsPanel";
            this.reportsPanel.Size = new System.Drawing.Size(1063, 319);
            this.reportsPanel.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.addRateButton);
            this.panel1.Controls.Add(this.endDateTimePicker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.startDateTimePicker);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(47, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 26);
            this.panel1.TabIndex = 1;
            // 
            // addRateButton
            // 
            this.addRateButton.Location = new System.Drawing.Point(850, 3);
            this.addRateButton.Name = "addRateButton";
            this.addRateButton.Size = new System.Drawing.Size(115, 20);
            this.addRateButton.TabIndex = 5;
            this.addRateButton.Text = "Вывести отчет";
            this.addRateButton.UseVisualStyleBackColor = true;
            this.addRateButton.Click += new System.EventHandler(this.addRateButton_Click);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTimePicker.Location = new System.Drawing.Point(548, 3);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.endDateTimePicker.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "по";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "с";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTimePicker.Location = new System.Drawing.Point(417, 3);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.startDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите период:";
            // 
            // reportsTabControl
            // 
            this.reportsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportsTabControl.Controls.Add(this.tabPage1);
            this.reportsTabControl.Controls.Add(this.tabPage2);
            this.reportsTabControl.Controls.Add(this.tabPage3);
            this.reportsTabControl.Controls.Add(this.tabPage4);
            this.reportsTabControl.Location = new System.Drawing.Point(3, 32);
            this.reportsTabControl.Name = "reportsTabControl";
            this.reportsTabControl.SelectedIndex = 0;
            this.reportsTabControl.Size = new System.Drawing.Size(1057, 284);
            this.reportsTabControl.TabIndex = 0;
            this.reportsTabControl.SelectedIndexChanged += new System.EventHandler(this.reportsTabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.diagramPictureBox);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1049, 258);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Расход топлива";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(256, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(550, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "За выбранный период данных о расходе топлива нет!";
            // 
            // diagramPictureBox
            // 
            this.diagramPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diagramPictureBox.Location = new System.Drawing.Point(361, 6);
            this.diagramPictureBox.Name = "diagramPictureBox";
            this.diagramPictureBox.Size = new System.Drawing.Size(682, 221);
            this.diagramPictureBox.TabIndex = 4;
            this.diagramPictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.resultRichTextBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(5, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 246);
            this.panel2.TabIndex = 2;
            // 
            // resultRichTextBox
            // 
            this.resultRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.resultRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultRichTextBox.Location = new System.Drawing.Point(19, 38);
            this.resultRichTextBox.Name = "resultRichTextBox";
            this.resultRichTextBox.ReadOnly = true;
            this.resultRichTextBox.Size = new System.Drawing.Size(301, 205);
            this.resultRichTextBox.TabIndex = 1;
            this.resultRichTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(87, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Итого израсходовано ГСМ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.avtoRateListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1049, 258);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Интенсивность использования автотранспорта";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(168, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(712, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "За выбранный период данных об использовании автотранспорта нет!";
            // 
            // avtoRateListView
            // 
            this.avtoRateListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.avtoRateListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader10,
            this.columnHeader27,
            this.columnHeader28});
            this.avtoRateListView.FullRowSelect = true;
            this.avtoRateListView.GridLines = true;
            this.avtoRateListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.avtoRateListView.HideSelection = false;
            this.avtoRateListView.Location = new System.Drawing.Point(3, 3);
            this.avtoRateListView.Name = "avtoRateListView";
            this.avtoRateListView.Size = new System.Drawing.Size(1043, 250);
            this.avtoRateListView.TabIndex = 2;
            this.avtoRateListView.UseCompatibleStateImageBehavior = false;
            this.avtoRateListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Марка автомобиля";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Госномер";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Сп. начало";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Сп. конец";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Пробег";
            this.columnHeader3.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Расход по норме";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Расход фактич.";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Экономия";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Пережег";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 70;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Наработка, дней";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 105;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Масло по норме";
            this.columnHeader27.Width = 100;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Масло фактически";
            this.columnHeader28.Width = 100;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.OnPrintButton);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.vedomostListView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1049, 258);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Сводная ведомость учета работы машин";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // OnPrintButton
            // 
            this.OnPrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OnPrintButton.Location = new System.Drawing.Point(920, 230);
            this.OnPrintButton.Name = "OnPrintButton";
            this.OnPrintButton.Size = new System.Drawing.Size(124, 23);
            this.OnPrintButton.TabIndex = 7;
            this.OnPrintButton.Text = "Вывод для печати";
            this.OnPrintButton.UseVisualStyleBackColor = true;
            this.OnPrintButton.Click += new System.EventHandler(this.OnPrintButton_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(168, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(712, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "За выбранный период данных об использовании автотранспорта нет!";
            // 
            // vedomostListView
            // 
            this.vedomostListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vedomostListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader29,
            this.columnHeader16,
            this.columnHeader30,
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader13,
            this.columnHeader20,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26});
            this.vedomostListView.FullRowSelect = true;
            this.vedomostListView.GridLines = true;
            this.vedomostListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.vedomostListView.HideSelection = false;
            this.vedomostListView.Location = new System.Drawing.Point(3, 4);
            this.vedomostListView.Name = "vedomostListView";
            this.vedomostListView.Size = new System.Drawing.Size(1043, 220);
            this.vedomostListView.TabIndex = 5;
            this.vedomostListView.UseCompatibleStateImageBehavior = false;
            this.vedomostListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "№ п/п";
            this.columnHeader21.Width = 45;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Тип машины";
            this.columnHeader22.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Марка автомобиля";
            this.columnHeader11.Width = 130;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Госномер";
            this.columnHeader12.Width = 90;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Всего дней";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 75;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "В работе, дн.";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader15.Width = 85;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "Лимит, км";
            this.columnHeader29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader29.Width = 90;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Пробег";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader16.Width = 70;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "С грузом, км";
            this.columnHeader30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader30.Width = 80;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Перевезено груза, т";
            this.columnHeader31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader31.Width = 125;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "На прицепе, т";
            this.columnHeader32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader32.Width = 90;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Тип топлива";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 75;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Расход по норме";
            this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader20.Width = 105;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Расход факт.";
            this.columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader23.Width = 105;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Экономия";
            this.columnHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader24.Width = 75;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Пережег";
            this.columnHeader25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader25.Width = 75;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Масло, л";
            this.columnHeader26.Width = 75;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1049, 258);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Карточка учета работы машин";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.Controls.Add(this.informationListBox);
            this.panel3.Controls.Add(this.machineComboBox);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.printCardButton);
            this.panel3.Controls.Add(this.monthPanel);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(300, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(527, 191);
            this.panel3.TabIndex = 0;
            // 
            // informationListBox
            // 
            this.informationListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.informationListBox.Enabled = false;
            this.informationListBox.FormattingEnabled = true;
            this.informationListBox.Location = new System.Drawing.Point(304, 57);
            this.informationListBox.Name = "informationListBox";
            this.informationListBox.Size = new System.Drawing.Size(176, 91);
            this.informationListBox.TabIndex = 7;
            // 
            // machineComboBox
            // 
            this.machineComboBox.FormattingEnabled = true;
            this.machineComboBox.Location = new System.Drawing.Point(304, 29);
            this.machineComboBox.Name = "machineComboBox";
            this.machineComboBox.Size = new System.Drawing.Size(176, 21);
            this.machineComboBox.TabIndex = 6;
            this.machineComboBox.SelectedIndexChanged += new System.EventHandler(this.machineComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(334, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Выберите автомобиль";
            // 
            // printCardButton
            // 
            this.printCardButton.Location = new System.Drawing.Point(321, 161);
            this.printCardButton.Name = "printCardButton";
            this.printCardButton.Size = new System.Drawing.Size(146, 23);
            this.printCardButton.TabIndex = 4;
            this.printCardButton.Text = "Вывести карточку";
            this.printCardButton.UseVisualStyleBackColor = true;
            this.printCardButton.Click += new System.EventHandler(this.printCardButton_Click);
            // 
            // monthPanel
            // 
            this.monthPanel.BackColor = System.Drawing.SystemColors.Control;
            this.monthPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.monthPanel.Controls.Add(this.monthButton12);
            this.monthPanel.Controls.Add(this.monthButton11);
            this.monthPanel.Controls.Add(this.monthButton10);
            this.monthPanel.Controls.Add(this.monthButton9);
            this.monthPanel.Controls.Add(this.monthButton8);
            this.monthPanel.Controls.Add(this.monthButton7);
            this.monthPanel.Controls.Add(this.monthButton6);
            this.monthPanel.Controls.Add(this.monthButton5);
            this.monthPanel.Controls.Add(this.monthButton4);
            this.monthPanel.Controls.Add(this.monthButton3);
            this.monthPanel.Controls.Add(this.monthButton2);
            this.monthPanel.Controls.Add(this.monthButton1);
            this.monthPanel.Controls.Add(this.panel4);
            this.monthPanel.Location = new System.Drawing.Point(8, 29);
            this.monthPanel.Name = "monthPanel";
            this.monthPanel.Size = new System.Drawing.Size(250, 155);
            this.monthPanel.TabIndex = 1;
            // 
            // monthButton12
            // 
            this.monthButton12.Location = new System.Drawing.Point(167, 123);
            this.monthButton12.Name = "monthButton12";
            this.monthButton12.Size = new System.Drawing.Size(75, 23);
            this.monthButton12.TabIndex = 12;
            this.monthButton12.Text = "Декабрь";
            this.monthButton12.UseVisualStyleBackColor = true;
            // 
            // monthButton11
            // 
            this.monthButton11.Location = new System.Drawing.Point(86, 123);
            this.monthButton11.Name = "monthButton11";
            this.monthButton11.Size = new System.Drawing.Size(75, 23);
            this.monthButton11.TabIndex = 11;
            this.monthButton11.Text = "Ноябрь";
            this.monthButton11.UseVisualStyleBackColor = true;
            // 
            // monthButton10
            // 
            this.monthButton10.Location = new System.Drawing.Point(5, 123);
            this.monthButton10.Name = "monthButton10";
            this.monthButton10.Size = new System.Drawing.Size(75, 23);
            this.monthButton10.TabIndex = 10;
            this.monthButton10.Text = "Октябрь";
            this.monthButton10.UseVisualStyleBackColor = true;
            // 
            // monthButton9
            // 
            this.monthButton9.Location = new System.Drawing.Point(167, 94);
            this.monthButton9.Name = "monthButton9";
            this.monthButton9.Size = new System.Drawing.Size(75, 23);
            this.monthButton9.TabIndex = 9;
            this.monthButton9.Text = "Сентябрь";
            this.monthButton9.UseVisualStyleBackColor = true;
            // 
            // monthButton8
            // 
            this.monthButton8.Location = new System.Drawing.Point(86, 94);
            this.monthButton8.Name = "monthButton8";
            this.monthButton8.Size = new System.Drawing.Size(75, 23);
            this.monthButton8.TabIndex = 8;
            this.monthButton8.Text = "Август";
            this.monthButton8.UseVisualStyleBackColor = true;
            // 
            // monthButton7
            // 
            this.monthButton7.Location = new System.Drawing.Point(5, 94);
            this.monthButton7.Name = "monthButton7";
            this.monthButton7.Size = new System.Drawing.Size(75, 23);
            this.monthButton7.TabIndex = 7;
            this.monthButton7.Text = "Июль";
            this.monthButton7.UseVisualStyleBackColor = true;
            // 
            // monthButton6
            // 
            this.monthButton6.Location = new System.Drawing.Point(167, 65);
            this.monthButton6.Name = "monthButton6";
            this.monthButton6.Size = new System.Drawing.Size(75, 23);
            this.monthButton6.TabIndex = 6;
            this.monthButton6.Text = "Июнь";
            this.monthButton6.UseVisualStyleBackColor = true;
            // 
            // monthButton5
            // 
            this.monthButton5.Location = new System.Drawing.Point(86, 65);
            this.monthButton5.Name = "monthButton5";
            this.monthButton5.Size = new System.Drawing.Size(75, 23);
            this.monthButton5.TabIndex = 5;
            this.monthButton5.Text = "Май";
            this.monthButton5.UseVisualStyleBackColor = true;
            // 
            // monthButton4
            // 
            this.monthButton4.Location = new System.Drawing.Point(5, 65);
            this.monthButton4.Name = "monthButton4";
            this.monthButton4.Size = new System.Drawing.Size(75, 23);
            this.monthButton4.TabIndex = 4;
            this.monthButton4.Text = "Апрель";
            this.monthButton4.UseVisualStyleBackColor = true;
            // 
            // monthButton3
            // 
            this.monthButton3.Location = new System.Drawing.Point(167, 36);
            this.monthButton3.Name = "monthButton3";
            this.monthButton3.Size = new System.Drawing.Size(75, 23);
            this.monthButton3.TabIndex = 3;
            this.monthButton3.Text = "Март";
            this.monthButton3.UseVisualStyleBackColor = true;
            // 
            // monthButton2
            // 
            this.monthButton2.Location = new System.Drawing.Point(86, 36);
            this.monthButton2.Name = "monthButton2";
            this.monthButton2.Size = new System.Drawing.Size(75, 23);
            this.monthButton2.TabIndex = 2;
            this.monthButton2.Text = "Февраль";
            this.monthButton2.UseVisualStyleBackColor = true;
            // 
            // monthButton1
            // 
            this.monthButton1.Location = new System.Drawing.Point(5, 36);
            this.monthButton1.Name = "monthButton1";
            this.monthButton1.Size = new System.Drawing.Size(75, 23);
            this.monthButton1.TabIndex = 1;
            this.monthButton1.Text = "Январь";
            this.monthButton1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.yearLabel);
            this.panel4.Controls.Add(this.nextYearButton);
            this.panel4.Controls.Add(this.backYearButton);
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Margin = new System.Windows.Forms.Padding(5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 29);
            this.panel4.TabIndex = 0;
            // 
            // yearLabel
            // 
            this.yearLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yearLabel.AutoSize = true;
            this.yearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yearLabel.Location = new System.Drawing.Point(106, 8);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(35, 13);
            this.yearLabel.TabIndex = 2;
            this.yearLabel.Text = "0000";
            // 
            // nextYearButton
            // 
            this.nextYearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextYearButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nextYearButton.Location = new System.Drawing.Point(210, 2);
            this.nextYearButton.Margin = new System.Windows.Forms.Padding(2);
            this.nextYearButton.Name = "nextYearButton";
            this.nextYearButton.Size = new System.Drawing.Size(23, 23);
            this.nextYearButton.TabIndex = 1;
            this.nextYearButton.Text = ">";
            this.nextYearButton.UseVisualStyleBackColor = false;
            this.nextYearButton.Click += new System.EventHandler(this.nextYearButton_Click);
            // 
            // backYearButton
            // 
            this.backYearButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.backYearButton.Location = new System.Drawing.Point(2, 2);
            this.backYearButton.Margin = new System.Windows.Forms.Padding(2);
            this.backYearButton.Name = "backYearButton";
            this.backYearButton.Size = new System.Drawing.Size(23, 23);
            this.backYearButton.TabIndex = 0;
            this.backYearButton.Text = "<";
            this.backYearButton.UseVisualStyleBackColor = false;
            this.backYearButton.Click += new System.EventHandler(this.backYearButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Выберите месяц";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 536);
            this.Controls.Add(this.reportsPanel);
            this.Controls.Add(this.orderPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.topMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.topMenuStrip;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учет транспортных издержек ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topMenuStrip.ResumeLayout(false);
            this.topMenuStrip.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.orderPanel.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.reportsPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.reportsTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diagramPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.monthPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guidesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itineraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batteryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem travelOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel userNameStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel userSpecialtyStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeStatusLabel;
        private System.Windows.Forms.Button userGuideButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button driverGuideButton;
        private System.Windows.Forms.Button batteryGuideButton;
        private System.Windows.Forms.Button tireGuideButton;
        private System.Windows.Forms.Button itineraryGuideButton;
        private System.Windows.Forms.Button vehicleGuideButton;
        private System.Windows.Forms.Button addOrderButton;
        private System.Windows.Forms.ToolStripMenuItem addOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem complOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchOrderToolStripMenuItem;
        private System.Windows.Forms.Button searchOrderButton;
        private System.Windows.Forms.Button printOrderButton;
        private System.Windows.Forms.Button complOrderButton;
        private System.Windows.Forms.Button editOrderButton;
        private System.Windows.Forms.Button deleteOrderButton;
        private System.Windows.Forms.Panel orderPanel;
        private System.Windows.Forms.ListView listViewOrders;
        private System.Windows.Forms.ColumnHeader Order_ID;
        private System.Windows.Forms.ColumnHeader Order_Number;
        private System.Windows.Forms.ColumnHeader Vehicle_Model;
        private System.Windows.Forms.ColumnHeader Vehicle_Number;
        private System.Windows.Forms.ColumnHeader Driver_Name;
        private System.Windows.Forms.ColumnHeader Order_DateOut;
        private System.Windows.Forms.ColumnHeader Order_DateIn;
        private System.Windows.Forms.ColumnHeader Order_TimeOut;
        private System.Windows.Forms.ColumnHeader Order_TimeIn;
        private System.Windows.Forms.ColumnHeader Order_Itinerary;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem complToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuelRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intensityToolStripMenuItem;
        private System.Windows.Forms.Button reportsButton;
        private System.Windows.Forms.Panel reportsPanel;
        private System.Windows.Forms.TabControl reportsTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox resultRichTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addRateButton;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView avtoRateListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.PictureBox diagramPictureBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView vedomostListView;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem settingPrintingFormsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.Button OnPrintButton;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolStripMenuItem summaryListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cardToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel monthPanel;
        private System.Windows.Forms.Button monthButton12;
        private System.Windows.Forms.Button monthButton11;
        private System.Windows.Forms.Button monthButton10;
        private System.Windows.Forms.Button monthButton9;
        private System.Windows.Forms.Button monthButton8;
        private System.Windows.Forms.Button monthButton7;
        private System.Windows.Forms.Button monthButton6;
        private System.Windows.Forms.Button monthButton5;
        private System.Windows.Forms.Button monthButton4;
        private System.Windows.Forms.Button monthButton3;
        private System.Windows.Forms.Button monthButton2;
        private System.Windows.Forms.Button monthButton1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Button nextYearButton;
        private System.Windows.Forms.Button backYearButton;
        private System.Windows.Forms.Button printCardButton;
        private System.Windows.Forms.ComboBox machineComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox informationListBox;
    }
}

