using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Avtotransport
{
    // Основное рабочее окно программы
    public partial class MainForm : Form
    {
        // переменные класса
        private bool _isSuperadmin;      // флаг суперадмина
        private bool _isUser;            // флаг пользователя
        private bool _isGuest;           // флаг гостя
        private bool _reportsFlag;       // флаг отчетов
        private DateTime _minDate;       // минимальная дата регистрации путевых листов
        private int _currentIntMonth;    // выбранный месяц в числовом выражении
        private string _currentMonth;    // выбранный месяц в словесном выражении
        
        // переменные класса для диаграммы
        private int viNumInRg = 9; // массив с данными для диаграммы
        private string[,] _rgsValues;

        // экземпляр класса ReportClass
        private ReportClass _fuelReport;

        // создание переменных класса UserClass и UserRightClass
        UserClass _user = new UserClass();
        UserRightClass userRight = new UserRightClass();
        // создание переменной класса SettingsClass
        SettingsClass prSettings = new SettingsClass();

        public MainForm()
        {
            InitializeComponent();
            _reportsFlag = false;
            ResetUserFlags();
            SecurityClass authorization = new SecurityClass(false);
            // проверка валидности авторизации и определение прав пользователя
            ValidAuthorization(authorization.UserAuthorizationFlag, authorization.UserRole, 
                authorization.user);
            // чтение файла с настройками
            prSettings.ReadOptionsFile();
        }

        // Событие загрузки формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            // вывод подсказок на кнопках управления
            SetButtonsToolTips();
            // установка в нижней панели имени пользователя и специальности
            SetUserNameInStrip();
            // позиционирование панели с путевыми листами и восстановление размеров окна
            orderPanel.Location = new Point(0, 89);
            orderPanel.Width = 1063;
            orderPanel.Height = 420;
            ReadOrders();
            reportsPanel.Visible = false;
            // установка в диалоге текущей даты и времени
            dateTimeStatusLabel.Text = DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString();
        }

        // Функция вывода подсказок на кнопках управления
        private void SetButtonsToolTips()
        {
            ToolTip b = new ToolTip();
            b.SetToolTip(userGuideButton, "Справочник пользователей");
            b.SetToolTip(driverGuideButton, "Справочник водителей");
            b.SetToolTip(batteryGuideButton, "Справочника аккумуляторов");
            b.SetToolTip(tireGuideButton, "Справочника автомобильных шин");
            b.SetToolTip(vehicleGuideButton, "Справочник автомобилей");
            b.SetToolTip(itineraryGuideButton, "Справочник маршрутов");
            b.SetToolTip(addOrderButton, "Выписать путевой лист");
            b.SetToolTip(deleteOrderButton, "Удалить путевой лист");
            b.SetToolTip(editOrderButton, "Изменить путевой лист");
            b.SetToolTip(complOrderButton, "Принять путевой лист");
            b.SetToolTip(printOrderButton, "Вывести на печать путевой лист");
            b.SetToolTip(searchOrderButton, "Поиск путевого листа");
            b.SetToolTip(reportsButton, "Отчеты");
        }

        // Функция сброса флагов пользователей
        private void ResetUserFlags()
        {
            _isSuperadmin = false;
            _isUser = false;
            _isGuest = false;
        }

        // Функция проверки валидности авторизации
        private void ValidAuthorization(bool aFlag, int uRole, UserClass aUser)
        {
            // если пользователь авторизовался
            if (aFlag)
            {
                // присвоение прав авторизованного пользователя
                switch (uRole)
                {
                    case 0:
                        _isSuperadmin = true;
                        break;
                    case 1:
                        _isUser = true;
                        _user = aUser;
                        userRight.GetRightById(_user.UserId);
                        break;
                    case 2:
                        _isGuest = true;
                        break;
                    default:
                        break;
                }
                // проверка прав доступа к справочникам
                CheckAccessRights();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        // Функция проверки прав доступа к справочникам
        private void CheckAccessRights()
        {
            // если пользователь имеет права суперадмина
            if (_isSuperadmin)
            {
                GetUserRightAdmin(true);
            }
            // если пользователь имеет права пользователя
            else if (_isUser)
            {
                // проверка индивидуальных прав пользователя
                // если пользователь не является администратором
                if (!userRight.UserRightAdmin)
                {
                    userGuideButton.Enabled = false;
                    userToolStripMenuItem.Enabled = false;
                }
                // если пользователь не имеет доступа к справочнику водителей
                if (!userRight.UserRightDriver)
                {
                    driverGuideButton.Enabled = false;
                    driverToolStripMenuItem.Enabled = false;
                }
                // если пользователь не имеет доступа к справочнику автомобилей
                if (!userRight.UserRightAvto)
                {
                    vehicleGuideButton.Enabled = false;
                    avtoToolStripMenuItem.Enabled = false;
                }
                // если пользователь не имеет доступа к справочнику автошин и аккумуляторов
                if (!userRight.UserRightMechanic)
                {
                    tireGuideButton.Enabled = false;
                    tireToolStripMenuItem.Enabled = false;
                    batteryGuideButton.Enabled = false;
                    batteryToolStripMenuItem.Enabled = false;
                }
                // если пользователь не имеет доступа к справочнику маршрутов
                if (!userRight.UserRightGuides)
                {
                    itineraryGuideButton.Enabled = false;
                    itineraryToolStripMenuItem.Enabled = false;
                }
                // если пользователь не имеет прав доступа к Путевым листам
                if (!userRight.UserRightWaybill && !userRight.UserRightAdmin)
                {
                    travelOrderToolStripMenuItem.Enabled = false;
                    addOrderButton.Enabled = false;
                }
                // если пользователь не имеет прав Путевые-блокировка
                if (!userRight.UserRightWayblock)
                    lockToolStripMenuItem.Enabled = false;
                // если пользователь является администратором
                if (userRight.UserRightAdmin)
                {
                    GetUserRightAdmin(true);
                }
            }
            // если пользователь имеет права гостя
            else
            {
                // закрытие доступа ко всем функциям, кроме отчетов
                guidesToolStripMenuItem.Enabled = false;
                travelOrderToolStripMenuItem.Enabled = false;
                userGuideButton.Enabled = false;
                driverGuideButton.Enabled = false;
                batteryGuideButton.Enabled = false;
                tireGuideButton.Enabled = false;
                vehicleGuideButton.Enabled = false;
                itineraryGuideButton.Enabled = false;
                addOrderButton.Enabled = false;
            }
            // первоначальное скрытие видимости кнопок операций с путевыми листами
            SwitchingVisibility(false);
        }

        // Считывание данных из таблицы Travelorder
        private void ReadOrders()
        {
            // создание коллекции объектов
            ArrayList orderList = new ArrayList();
            TravelOrderClass order = new TravelOrderClass();
            orderList.AddRange(order.ReadTravelOrderData());
            // заполнение таблицы данными из базы данных
            PrintOrders(listViewOrders, orderList);
            // определение минимальной даты для календаря
            AddMinDate(orderList);
        }

#region topButtons
        //==========СПРАВОЧНИКИ==========//
        // Обработчик нажатия кнопки вызова Справочника пользователей
        private void userGuideButton_Click(object sender, EventArgs e)
        {
            UsersForm uForm = new UsersForm();
            uForm.ShowDialog();
        }

        // Обработчик нажатия кнопки вызова Справочника водителей
        private void driverGuideButton_Click(object sender, EventArgs e)
        {
            DriversForm dForm = new DriversForm();
            dForm.ShowDialog();
        }

        // Обработчик нажатия кнопки вызова Справочника аккумуляторов
        private void batteryGuideButton_Click(object sender, EventArgs e)
        {
            BatteryForm bForm = new BatteryForm();
            bForm.ShowDialog();
        }

        // Обработчик нажатия кнопки вызова Справочника автомобильных шин
        private void tireGuideButton_Click(object sender, EventArgs e)
        {
            TireForm tForm = new TireForm();
            tForm.ShowDialog();
        }

        // Обработчик нажатия кнопки вызова Справочника автомобилей
        private void vehicleGuideButton_Click(object sender, EventArgs e)
        {
            VehicleForm vForm = new VehicleForm(userRight.UserRightMechanic, (_isSuperadmin || userRight.UserRightAdmin));
            vForm.ShowDialog();
        }

        // Обработчик нажатия кнопки вызова Справочника маршрутов
        private void itineraryGuideButton_Click(object sender, EventArgs e)
        {
            ItineraryForm iForm = new ItineraryForm();
            iForm.ShowDialog();
        }

        //==========ПУТЕВОЙ ЛИСТ==========//
        // Обработчик нажатия кнопки Выписать путевой лист
        private void addOrderButton_Click(object sender, EventArgs e)
        {
            AddEditOrderForm oForm = new AddEditOrderForm(0);
            oForm.ShowDialog();
            if (oForm.DialogResult == DialogResult.OK)
            {
                // добавление путевого листа в БД
                TravelOrderClass newOrder = new TravelOrderClass(0, oForm.itineraryId, oForm.driverId,
                    oForm.vehicleId, oForm.trailerId, oForm.number, oForm.date, oForm.validityDate,
                    oForm.speedometerOut, oForm.motoOut, oForm.winterCoefficient, oForm.fuelBalance, 
                    oForm.fuelCharge, oForm.customer, oForm.timeOut, oForm.timeIn, oForm.transportationKind, 
                    oForm.dopInfo, false, false);
                newOrder.AddDataInTravelOrderTable(newOrder);
                // при отображении отчетов скрыть их
                if (_reportsFlag)
                {
                    _reportsFlag = false;
                    reportsPanel.Visible = false;
                    orderPanel.Visible = true;
                }
                // обновление данных в таблице путевых листов
                ReadOrders();
            }
        }

        // Обработчик нажатия кнопки Удалить путевой лист
        private void deleteOrderButton_Click(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id удаляемого путевого листа
                int delId = Convert.ToInt32(listViewOrders.SelectedItems[0].Text);
                TravelOrderClass delOrder = new TravelOrderClass();
                delOrder.GetTravelOrderById(delId);
                // если путевой лист заблокирован для редактирования
                if (delOrder.Lockflag)
                {
                    MessageBox.Show("Путевой лист заблокирован для удаления!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    // запрос на подтверждение удаления
                    DialogResult confirmationResult = MessageBox.Show(
                            "Вы уверены, что хотите удалить выбранный путевой лист из системы?",
                            "Подтверждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1);

                    if (confirmationResult == DialogResult.Yes)
                    {
                        delOrder.DelDataFromTravelOrderTable(delId);
                        // считывание новых данных из БД и обновление данных в таблице listView
                        ReadOrders();
                    }
                }
            }
        }

        // Обработчик нажатия кнопки Изменить путевой лист
        private void editOrderButton_Click(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id редактируемого путевого листа
                int editId = Convert.ToInt32(listViewOrders.SelectedItems[0].Text);
                TravelOrderClass editOrder = new TravelOrderClass();
                editOrder.GetTravelOrderById(editId);
                // если путевой лист заблокирован для редактирования
                if (editOrder.Lockflag)
                {
                    MessageBox.Show("Путевой лист заблокирован для редактирования!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    // создание экземпляра класса CompletedTravelOrderClass
                    CompletedTravelOrderClass complOrder = new CompletedTravelOrderClass();
                    complOrder.GetCompletedTravelOrderById(editId);
                    // открытие для редактирования незаполненного путевого листа
                    if (!editOrder.CompletedFlag)
                    {
                        // открытие формы редактирования путевого листа
                        AddEditOrderForm aeForm = new AddEditOrderForm(editId);
                        aeForm.ShowDialog();
                        if (aeForm.DialogResult == DialogResult.OK)
                        {
                            // создание экземпляра класса TravelOrderClass
                            editOrder = new TravelOrderClass(editId, aeForm.itineraryId,
                                aeForm.driverId, aeForm.vehicleId, aeForm.trailerId, aeForm.number, 
                                aeForm.date, aeForm.validityDate, aeForm.speedometerOut, aeForm.motoOut, 
                                aeForm.winterCoefficient, aeForm.fuelBalance, aeForm.fuelCharge, aeForm.customer, 
                                aeForm.timeOut, aeForm.timeIn, aeForm.transportationKind, aeForm.dopInfo, false, false);
                            // обновление данных в таблице TravelOrder БД
                            editOrder.EditDataInTravelOrderTable(editOrder);
                            // считывание новых данных из БД и обновление данных в таблице listView
                            ReadOrders();
                        }
                    }
                    // открытие для редактирования заполненного путевого листа
                    else
                    {
                        // открытие формы редактирования заполненного путевого листа
                        CompletedOrderForm coForm = new CompletedOrderForm(editId);
                        coForm.ShowDialog();
                        if (coForm.DialogResult == DialogResult.OK)
                        {
                            // изменение данных о выписанном ранее путевом листе
                            editOrder.SpeedometerOut = coForm.speedometerOut;
                            editOrder.MotoOut = coForm.motoOut;
                            editOrder.FuelBalance = coForm.fuelBalanceOut;
                            editOrder.WinterCoefficient = coForm.winterCoefficient;
                            editOrder.CompletedFlag = coForm.completedFlag;
                            editOrder.EditDataInTravelOrderTable(editOrder);
                            // добавление заполненного путевого листа в БД
                            complOrder = new CompletedTravelOrderClass(coForm.completedId, coForm.orderId,
                                coForm.speedometerIn, coForm.motoIn, coForm.timeOut, coForm.timeIn, coForm.fuelBalance,
                                coForm.refuel, coForm.gorod100, coForm.gorod300, coForm.gorod1000, coForm.track,
                                coForm.bezdor, coForm.ostan, coForm.medl, coForm.withCargo, coForm.withoutCargo,
                                coForm.cargo, coForm.withTrailer, coForm.onTrailer, coForm.otopitel, coForm.generator,
                                coForm.cond, coForm.dopCoefficient, coForm.transportationKind, coForm.oilNorma, coForm.oilFact);
                            complOrder.EditDataInCompletedTravelOrderTable(complOrder);
                            editOrder.EditDataInTravelOrderTable(editOrder);

                            UppdateVehicleData(ref editOrder, ref coForm);
                            // считывание новых данных из БД и обновление данных в таблице listView
                            ReadOrders();
                        }
                    }
                }
            }
        }

        // Обработчик нажатия кнопки Принять путевой лист
        private void complOrderButton_Click(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count == 0)
                return;
            else
            {
                // получение Id путевого листа для его Принятия
                int editId = Convert.ToInt32(listViewOrders.SelectedItems[0].Text);
                // создание экземпляра класса TravelOrderClass
                TravelOrderClass editOrder = new TravelOrderClass();
                editOrder.GetTravelOrderById(editId);
                CompletedOrderForm coForm = new CompletedOrderForm(editOrder.OrderId);
                coForm.ShowDialog();
                if (coForm.DialogResult == DialogResult.OK)
                {
                    // изменение данных о выписанном ранее путевом листе
                    editOrder.SpeedometerOut = coForm.speedometerOut;
                    editOrder.MotoOut = coForm.motoOut;
                    editOrder.FuelBalance = coForm.fuelBalanceOut;
                    editOrder.WinterCoefficient = coForm.winterCoefficient;
                    editOrder.CompletedFlag = coForm.completedFlag;
                    editOrder.EditDataInTravelOrderTable(editOrder);
                    // добавление заполненного путевого листа в БД
                    CompletedTravelOrderClass complOrder = new CompletedTravelOrderClass(0, coForm.orderId,
                        coForm.speedometerIn, coForm.motoIn, coForm.timeOut, coForm.timeIn, coForm.fuelBalance,
                        coForm.refuel, coForm.gorod100, coForm.gorod300, coForm.gorod1000, coForm.track,
                        coForm.bezdor, coForm.ostan, coForm.medl, coForm.withCargo, coForm.withoutCargo,
                        coForm.cargo, coForm.withTrailer, coForm.onTrailer, coForm.otopitel, coForm.generator,
                        coForm.cond, coForm.dopCoefficient, coForm.transportationKind, coForm.oilNorma, coForm.oilFact);
                    complOrder.AddDataInCompletedTravelOrderTable(complOrder);

                    UppdateVehicleData(ref editOrder, ref coForm);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadOrders();
                }
            }
        }

        // Обработчик нажатия кнопки Вывести на печать путевой лист
        private void printOrderButton_Click(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count == 0)
                return;
            else
            {
                // вывод окна предварительного просмотра путевого листа
                PrintOrderForm pForm = new PrintOrderForm(Convert.ToInt32(listViewOrders.SelectedItems[0].Text), 
                    prSettings.OrgNumber);
                pForm.ShowDialog();
            }
        }

        // Обработчик нажатия кнопки Поиск путевого листа
        private void searchOrderButton_Click(object sender, EventArgs e)
        {
            SearchOrderForm sForm = new SearchOrderForm();
            sForm.ShowDialog();
            if (sForm.DialogResult == DialogResult.OK)
            {
                for (int i = 0; i < listViewOrders.Items.Count; i++)
                {
                    if (listViewOrders.Items[i].SubItems[0].Text == Convert.ToString(sForm.orderId))
                    {
                        // при отображении отчетов скрыть их
                        if (_reportsFlag)
                        {
                            _reportsFlag = false;
                            reportsPanel.Visible = false;
                            orderPanel.Visible = true;
                        }
                        listViewOrders.Select();
                        listViewOrders.Items[i].Selected = true;
                        listViewOrders.EnsureVisible(i);
                        break;
                    }
                }
            }
        }

        // Обработчик нажатия кнопки Блокировка
        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // получение Id блокируемого путевого листа
            int editId = Convert.ToInt32(listViewOrders.SelectedItems[0].Text);
            // создание экземпляра класса TravelOrderClass
            TravelOrderClass lockOrder = new TravelOrderClass();
            lockOrder.GetTravelOrderById(editId);
            // смена флага блокировки на противоположный
            lockOrder.Lockflag = lockOrder.Lockflag ? false : true;
            // обновление данных в БД
            lockOrder.EditDataInTravelOrderTable(lockOrder);
            // считывание новых данных из БД и обновление данных в таблице listView
            ReadOrders();
        }

        // Обработчик нажатия кнопки Отчеты
        private void reportsButton_Click(object sender, EventArgs e)
        {
            if (!_reportsFlag)
            {
                PositionReportsPanel();
            }
            else
            {
                _reportsFlag = false;
                reportsPanel.Visible = false;
                orderPanel.Visible = true;
            }
        }
#endregion

#region topMenu
        //=========ФАЙЛ============
        // Выбор пункта меню "Главная"
        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_Load(sender, e);
        }

        // Настройка печатных форм
        private void settingPrintingFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingPrintingForm sForm = new SettingPrintingForm();
            sForm.ShowDialog();
            if (sForm.DialogResult == DialogResult.OK)
            {
                // обновление данных о настройках
                prSettings.ReadOptionsFile();
            }
        }

        // Выбор пункта меню "Выход из системы"
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        // Выбор пункта меню "Выход"
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //=========ОТЧЕТЫ============
        // Выбор пункта меню "Расход топлива"
        private void fuelRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionReportsPanel();
            reportsTabControl.SelectedTab = tabPage1;
        }
        
        // Выбор пункта меню "Интенсивность использования автотранспорта"
        private void intensityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionReportsPanel();
            reportsTabControl.SelectedTab = tabPage2;
        }
        // Выбор пункта меню "Сводная ведомость учета работы машин"
        private void summaryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionReportsPanel();
            reportsTabControl.SelectedTab = tabPage3;
        }
        // Выбор пункта меню "Карточка учета работы машин"
        private void cardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionReportsPanel();
            reportsTabControl.SelectedTab = tabPage4;
        }

        //=========ПОМОЩЬ============
        // Обработчик нажатия кнопки О программе
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aBox = new AboutBox();
            aBox.ShowDialog();
        }
#endregion

#region ListViews
        // Процедура вывода информации о путевых листах в listView
        private void PrintOrders(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка путевых листов
            ListViewItem lvi;
            foreach (object item in list)
            {
                // создание экземпляров классов TravelOrder, VehicleClass, DriverClass, ItineraryClass 
                TravelOrderClass order = new TravelOrderClass();
                VehicleClass vehicle = new VehicleClass();
                DriverClass driver = new DriverClass();
                ItineraryClass itinerary = new ItineraryClass();
                order = (TravelOrderClass)item;
                lvi = new ListViewItem(Convert.ToString(order.OrderId));
                lvi.SubItems.Add(Convert.ToString(order.Number));
                // марка автомобиля и его госномер
                vehicle.GetVehicleById((int)order.VehicleId);
                lvi.SubItems.Add(vehicle.Model);
                lvi.SubItems.Add(vehicle.RegNumber);
                // водитель
                driver.GetDriverById((int)order.DriverId);
                lvi.SubItems.Add(driver.DriverName);

                string tmpStr = Convert.ToString(order.Date);
                lvi.SubItems.Add(_cutSubstringFromString(ref tmpStr, " ", 0));
                tmpStr = Convert.ToString(order.ValidityDate);
                lvi.SubItems.Add(_cutSubstringFromString(ref tmpStr, " ", 0));
                // выезд и возвращение
                tmpStr = Convert.ToString(order.TimeOut);
                _cutSubstringFromString(ref tmpStr, " ", 0);
                lvi.SubItems.Add(tmpStr);
                tmpStr = Convert.ToString(order.TimeIn);
                _cutSubstringFromString(ref tmpStr, " ", 0);
                lvi.SubItems.Add(tmpStr);
                // маршрут
                itinerary.GetItineraryById((int)order.ItineraryId);
                lvi.SubItems.Add(itinerary.ItineraryName);
                listV.Items.Add(lvi);
                // выделение путевых листов, не заполненных после возвращения
                if (!order.CompletedFlag)
                    lvi.BackColor = Color.LightGreen;
                // выделение путевых листов, заблокированных от редактирования
                if (order.Lockflag)
                    lvi.ForeColor = Color.Red;
            }
        }

        // обработчик процедуры выбора элементов в списке путевых листов
        private void listViewOrders_ItemSelectionChanged(object sender, 
            ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewOrders.SelectedItems.Count > 0)
                SwitchingVisibility(true);
            else
                SwitchingVisibility(false);
        }

        // Обработчик двойного нажатия клавиши мыши на выбранном путевом листе
        private void listViewOrders_DoubleClick(object sender, EventArgs e)
        {
            // если вошел не Гость
            if (!_isGuest)
            {
                // если у пользователя есть соответствующие права
                if (_isSuperadmin || userRight.UserRightAdmin || userRight.UserRightWaybill)
                    editOrderButton_Click(sender, e);
            }
        }

        // Обработчик нажатия клавиши Delete на выбраном путевом листе
        private void listViewOrders_KeyDown(object sender, KeyEventArgs e)
        {
            // если вошел не Гость
            if (!_isGuest)
            {
                // если у пользователя есть соответствующие права
                if (_isSuperadmin || userRight.UserRightAdmin || userRight.UserRightWaybill)
                {
                    if (e.KeyCode == Keys.Delete)
                        deleteOrderButton_Click(sender, e);
                }
            }
        }
#endregion

#region Reports
        // Функция задания начальных значений отчетов
        private void ReportWindowsLoad()
        {
            startDateTimePicker.Value = DateTime.Today;
            endDateTimePicker.Value = DateTime.Today;
            // минимальный период - с и по минимальное число
            startDateTimePicker.MinDate = _minDate;
            endDateTimePicker.MinDate = _minDate;
            // максимальный период - с и по сегодняшнее число
            startDateTimePicker.MaxDate = DateTime.Today;
            endDateTimePicker.MaxDate = DateTime.Today;
            // скрытие панелей и отчетов
            avtoRateListView.Visible = false;   // интенсивность использования автотранспорта
            vedomostListView.Visible = false;   // сводная ведомость учета работы машин
            panel2.Visible = false;             // панель об итоговом расходе топлива
            diagramPictureBox.Visible = false;  // диаграмма о расходе топлива
            label5.Visible = false;             // надпись об отсутствии данных о расходе топлива
            label6.Visible = false;             // надпись об отсутствии данных об использовании автотранспорта
            label7.Visible = false;
            OnPrintButton.Visible = false;      // кнопка вывода сводной ведомости для печати
        }

        // Обработчик нажатия кнопки "Вывести отчет"
        private void addRateButton_Click(object sender, EventArgs e)
        {
            // формирование отчета
            bool reportFlag = false;
            // создание коллекции типов автомобилей
            List<int> typeList = new List<int>();
            // создание коллекций объектов автомобилей
            ArrayList reportList = new ArrayList();
            // создание коллекций объектов прицепов
            ArrayList reportTrailerList = new ArrayList();
            // создание экземпляра класса ReportClass
            ReportClass report = new ReportClass();
            _fuelReport = new ReportClass(0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

            reportFlag = report.GetStatisticFlag(startDateTimePicker.Value, 
                endDateTimePicker.Value, ref _fuelReport, ref reportList, ref reportTrailerList, 
                ref typeList);
            
            if (reportFlag)
            {
                // вывод отчета на экран
                avtoRateListView.Visible = true;
                vedomostListView.Visible = true;
                panel2.Visible = true;
                diagramPictureBox.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                OnPrintButton.Visible = true;
                // отчет о расходе топлива
                report.PrintResultFuel(resultRichTextBox, ref _fuelReport);
                // вывод диаграммы
                CreateCircleDiagramm(_fuelReport);
                // отчет об интенсивности использования автотранспорта
                // сводная ведомость учета работы машин
                report.PrintReports(avtoRateListView, vedomostListView, reportList, 
                    reportTrailerList, typeList);
            }
            else
            {
                avtoRateListView.Visible = false;
                vedomostListView.Visible = false;
                panel2.Visible = false;
                diagramPictureBox.Visible = false;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                OnPrintButton.Visible = false;
            }
        }

        // Метод создания массива значений для вывода на диаграмме
        private void CreateRg(ReportClass report)
        {
            _rgsValues = new string[viNumInRg, 2];
            _rgsValues[0, 0] = Convert.ToString(report.Disel);
            _rgsValues[0, 1] = "Дизель";
            _rgsValues[1, 0] = Convert.ToString(report.N80);
            _rgsValues[1, 1] = "Н80";
            _rgsValues[2, 0] = Convert.ToString(report.A92);
            _rgsValues[2, 1] = "А92";
            _rgsValues[3, 0] = Convert.ToString(report.A95);
            _rgsValues[3, 1] = "А95";
            _rgsValues[4, 0] = Convert.ToString(report.A98);
            _rgsValues[4, 1] = "А98";
            _rgsValues[5, 0] = Convert.ToString(report.Kpg);
            _rgsValues[5, 1] = "КПГ";
            _rgsValues[6, 0] = Convert.ToString(report.Sug);
            _rgsValues[6, 1] = "СУГ";
            _rgsValues[7, 0] = Convert.ToString(report.Kerosin);
            _rgsValues[7, 1] = "Керосин";
            _rgsValues[8, 0] = Convert.ToString(report.Biodisel);
            _rgsValues[8, 1] = "Биодизель";
        }

        // Метод рисования диаграммы
        private void CreateCircleDiagramm(ReportClass report)
        {
            // создание массива значений для вывода на графике
            CreateRg(report);
            // создание экземпляра класса DiagramPaintClass и передача ему размера холста
            DiagramPaintClass clPaint = new DiagramPaintClass(diagramPictureBox.Width, diagramPictureBox.Height);
            // фон холста
            clPaint.vSetBackground(Color.White);
            // передача значения массива в класс
            clPaint.RgValue = _rgsValues;
            // рисование графика. Параметры: отступ осей x слева, x справа ,
            // y от краев холста, толщина диаграммы,вынос сектора           
            clPaint.vDravCircle3D(20, 250, 50, 20, 0, 0);
            // true - Разноцветные надписи в легенде, false - Цветом шрифта
            clPaint.vDravTextKeyCircle(false);
            // прием нарисованного в pictureBox
            diagramPictureBox.Image = clPaint.Bmp;
        }

        // Обработчик нажатия кнопки "Вывод для печати"
        private void OnPrintButton_Click(object sender, EventArgs e)
        {
            ExportReportClass eReport = new ExportReportClass("svodnayaWordTemplate.dot");
            eReport.RPeriod = GetPeriod();
            eReport.TableNum = 1;
            eReport.Report = _fuelReport;
            eReport.GetDocumentStrukture(vedomostListView);
        }

        //***КАРТОЧКА УЧЕТА РАБОТЫ МАШИН***//
        // Метод срабатывает при выборе вкладки на Отчете
        private void reportsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportsTabControl.SelectedTab.Name == "tabPage4")
                SetDefaultCardValues();
        }

        // Функция установки начальних значений в календаре и видимость кнопок
        private void SetDefaultCardValues()
        {
            // выбор года
            CalendarClass.LastYear = DateTime.Today.Year;
            yearLabel.Text = Convert.ToString(CalendarClass.LastYear);
            CalendarClass.GetYearsMas(_minDate.Year);
            // кнопки переключения года
            ChangeEnableYearButton(DateTime.Today.Year);
            // кнопки выбора месяца
            CalendarClass.GetMonthMas(_minDate);
            DisplayMonthButtons(DateTime.Today.Year);
            // список выбора автомобилей
            ReadVehicles();
            // вывод справочной информации
            PrintInformationListBox(Convert.ToString(machineComboBox.SelectedItem), 
                DateTime.Today.Month, DateTime.Today.Year);
            // видимость кнопки вывода карточек
            printCardButton.Enabled = true;
        }

        // Функция создания массива с кнопками месяца
        private Button[] CreateMonthMassive()
        {
            Button[] btnMonth = new Button[12];
            
            btnMonth[0] = monthButton1;
            btnMonth[1] = monthButton2;
            btnMonth[2] = monthButton3;
            btnMonth[3] = monthButton4;
            btnMonth[4] = monthButton5;
            btnMonth[5] = monthButton6;
            btnMonth[6] = monthButton7;
            btnMonth[7] = monthButton8;
            btnMonth[8] = monthButton9;
            btnMonth[9] = monthButton10;
            btnMonth[10] = monthButton11;
            btnMonth[11] = monthButton12;

            for (int i = 0; i < 12; i++)
            {
                btnMonth[i].Click += MonthButtonOnClick;
            }

            return btnMonth;
        }

        // Функция обработки кнопок переключения годов в календаре
        // Кнопка на год назад
        private void backYearButton_Click(object sender, EventArgs e)
        {
            displayCurrendCalendarInformation(true);
        }

        // Кнопка на год вперед
        private void nextYearButton_Click(object sender, EventArgs e)
        {
            displayCurrendCalendarInformation(false);
        }

        // Функция отображения календаря после нажатия кнопок вперед или назад на год
        private void displayCurrendCalendarInformation(bool backFlag)
        {
            // получение года из поля
            int currentYear = Convert.ToInt16(yearLabel.Text);
            int index = 0;
            foreach (int obj in CalendarClass.YearsMas)
            {
                if (obj == currentYear)
                    break;
                index++;
            }
            currentYear = backFlag ? CalendarClass.YearsMas[index - 1]: CalendarClass.YearsMas[index + 1];
            yearLabel.Text = Convert.ToString(currentYear);
            // изменение видимости кнопок переключения года
            ChangeEnableYearButton(currentYear);
            // отображение кнопок названий месяцев
            DisplayMonthButtons(currentYear);
        }

        // Функция изменения видимости кнопок переключения года
        private void ChangeEnableYearButton(int currentYear)
        {
            backYearButton.Visible = _minDate.Year != currentYear ? true : false;
            nextYearButton.Visible = DateTime.Today.Year != currentYear ? true : false;
        }

        // Функция изменения видимости кнопок месяцев
        private void DisplayMonthButtons(int currentYear)
        {
            Button[] btnMonth = new Button[12];
            btnMonth = CreateMonthMassive(); // массив с кнопками месяца
            int index = 0;
            foreach (int obj in CalendarClass.YearsMas)
            {
                if (obj == currentYear)
                    break;
                index++;
            }
            // определение крайнего месяца в календаре
            for (int i = 0; i < btnMonth.Length; i++)
            {
                // видимость кнопок в календаре
                if (CalendarClass.MonthMas[index, i] == 0)
                    btnMonth[i].Enabled = false; // кнопка недоступна
                else
                    btnMonth[i].Enabled = true; // кнопка доступна
                // выделение кнопки текущего месяца
                if (i + 1 == DateTime.Today.Month)
                {
                    btnMonth[i].Select();
                    _currentIntMonth = GetIntMonth(btnMonth[i].Name);
                }
                    
            }
        }

        // Обработчик нажатия кнопок месяца
        private void MonthButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button) sender;
            if (button != null)
            {
                _currentMonth = button.Text;
                _currentIntMonth = GetIntMonth(button.Name);
                PrintInformationListBox(Convert.ToString(machineComboBox.SelectedItem),
                    _currentIntMonth, Convert.ToInt16(yearLabel.Text));
            }
        }

        // Обработчик изменения выбора автомобиля для Карточки учета работы машин
        private void machineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintInformationListBox(Convert.ToString(machineComboBox.SelectedItem),
                _currentIntMonth, Convert.ToInt16(yearLabel.Text));
        }

        // Функция получения выбранного месяца в числовом выражении
        private int GetIntMonth(string btn)
        {
            string tmpStr = "";
            for (int i = 11; i < btn.Length; i++)
            {
                tmpStr = tmpStr + btn[i];
            }

            return Convert.ToInt16(tmpStr);
        }

        // Функция вывода справочной информации оп карточке учета работы машин
        private void PrintInformationListBox(string vehicle, int month, int year)
        {
            string[] monthMas = GetStringMonthMas();
            informationListBox.Items.Clear();
            informationListBox.Items.Add("Автомобиль: " + vehicle);
            informationListBox.Items.Add("Период: " + monthMas[month - 1] + " " + Convert.ToString(year) + " г.");
        }

        // Считывание данных из таблицы Vehicle
        private void ReadVehicles()
        {
            // создание коллекции объектов
            ArrayList vehicleList = new ArrayList();
            VehicleClass vehicle = new VehicleClass();
            vehicleList.AddRange(vehicle.ReadVehicleData());
            // заполнение списка автомобилей
            if (vehicleList.Count > 0)
            {
                machineComboBox.Items.Add("Все автомобили");
                foreach (VehicleClass obj in vehicleList)
                {
                    machineComboBox.Items.Add(obj.Model + " * " + obj.RegNumber);
                }

                machineComboBox.SelectedIndex = 0;
            }
        }

        // Обработчик нажатия кнопки "Вывести карточку"
        private void printCardButton_Click(object sender, EventArgs e)
        {
            // создание экземпляра класса CardMachineWorkClass
            //CardMachineWorkClass machineWorkCard = new CardMachineWorkClass(prSettings.OrgNumber, prSettings.ChiefPost,
            //    prSettings.ChiefRank, prSettings.ChiefName, prSettings.MakePost, prSettings.MakeRank,
            //    prSettings.MakeName, _currentIntMonth, Convert.ToInt16(yearLabel.Text));
            CardMachineWorkClass machineWorkCard = new CardMachineWorkClass(_currentIntMonth, Convert.ToInt16(yearLabel.Text));
            // если выбраны Все автомобили
            if (machineComboBox.SelectedIndex == 0)
            {
                
            }
            // если выбран один автомобиль
            else if (machineComboBox.SelectedIndex > 0)
            {
                // получение автомобиля по его госномеру
                machineWorkCard.GetOneVehicle(Convert.ToString(machineComboBox.SelectedItem));
                // получение списка путевых листов автомобиля
                machineWorkCard.OrderList = machineWorkCard.GetTravelOrderByVehicleIdAndDate(machineWorkCard.VehicleId, 
                    new DateTime(machineWorkCard.Year, machineWorkCard.Month, machineWorkCard.Days), true);
                // создание экземпляра класса с именем шаблона
                ExportReportClass eReport = new ExportReportClass("carWorkingWordTemplate.dot");
                eReport.CMonth = _currentMonth;
                eReport.CYear = yearLabel.Text;
                eReport.TableNum = 1;
                eReport.CardMachine = machineWorkCard;
                eReport.GetCardStrukture(_minDate);
            }
        }

#endregion

#region statusStrip
        // Установка в нижней панели имени пользователя и специальности
        private void SetUserNameInStrip()
        {
            // если пользователь имеет права суперадмина
            if (_isSuperadmin)
            {
                userNameStatusLabel.Text = "Супер администратор системы";
                userSpecialtyStatusLabel.Text = "superadmin";
            }
            // если пользователь имеет права пользователя
            else if (_isUser)
            {
                userNameStatusLabel.Text = _user.UserName;
                userSpecialtyStatusLabel.Text = _user.UserSpecialty;
            }
            // если пользователь имеет права гостя
            else
            {
                userNameStatusLabel.Text = "Вы вошли как гость";
                userSpecialtyStatusLabel.Text = "гость";
            }
        }
        // Установка таймера
        private void timer_Tick(object sender, EventArgs e)
        {
            dateTimeStatusLabel.Text = DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString();
        }

#endregion
        
        // Функция определения минимальной даты регистрации путевого листа
        private void AddMinDate(ArrayList oList)
        {
            DateTime tmpMinDate = DateTime.Today;
            foreach (object item in oList)
            {
                // создание экземпляра класса TravelOrderClass 
                TravelOrderClass order = new TravelOrderClass();
                order = (TravelOrderClass)item;
                if (order.Date < tmpMinDate)
                    tmpMinDate = order.Date;
            }
            _minDate = tmpMinDate;
        }

        // Функция вывода периода для сводной ведомости работы машин
        private string GetPeriod()
        {
            string result = "";
            string[] month = GetStringMonthMas();

            int monthStart = startDateTimePicker.Value.Month;
            int monthEnd = endDateTimePicker.Value.Month;
            // сравнение месяцев выбранного периода
            if (monthStart != monthEnd) // если месяца разные
                // вывод их через дефис
                result = month[monthStart - 1] + " - " + month[monthEnd - 1] + " " +
                         Convert.ToString(endDateTimePicker.Value.Year);
            else 
                result = month[monthEnd - 1] + " " + Convert.ToString(endDateTimePicker.Value.Year);

            return result;
        }
        
        // Функция получения названия месяца из числа
        private string[] GetStringMonthMas()
        {
            string[] result = new[]
            {
                "январь", "февраль", "март", "апрель", "май", "июнь", "июль",
                "август", "сентябрь", "октябрь", "ноябрь", "декабрь"
            };

            return result;
        }

        // Функция обновления данных автомобиля после закрытия путевого листа
        private void UppdateVehicleData(ref TravelOrderClass editOrder, ref CompletedOrderForm coForm)
        {
            VehicleClass editVehicle = new VehicleClass();
            int vehicleId = (int)editOrder.VehicleId;
            int trailerId = editOrder.TrailerId != null ? (int)editOrder.TrailerId : 0;
            editVehicle.GetVehicleById(vehicleId);
            ServiceMileageClass editService = new ServiceMileageClass();
            editService.GetServicemileageById(vehicleId);
            // обновление данных по пробегу автошин и аккумуляторов
            // если данные по спидометру не обновлены
            if (editService.Speedometer != coForm.speedometerIn)
            {
                // автошины
                TireClass editTire = new TireClass();
                editTire.EditCurrentRun(vehicleId, (coForm.speedometerIn - editService.Speedometer),
                    editVehicle.Wheel, editVehicle.SpareWheel); // автомобиль
                editTire.EditCurrentRun(trailerId, (coForm.speedometerIn - editService.Speedometer),
                    editVehicle.Wheel, editVehicle.SpareWheel); // прицеп
                // аккумуляторы
                BatteryClass editBattery = new BatteryClass();
                editBattery.EditCurrentRun(vehicleId, (coForm.speedometerIn - editService.Speedometer));
                // если прицеп записан в путевой лист
                if (trailerId != 0)
                {
                    ServiceMileageClass editTrailerService = new ServiceMileageClass();
                    editTrailerService.GetServicemileageById(trailerId);
                    editTrailerService.Speedometer += coForm.withTrailer;
                    editTrailerService.EditDataInServicemileageTable(editTrailerService);
                }
            }
            // остаток топлива
            editVehicle.FuelBalance = coForm.fuelBalance;
            editVehicle.EditDataInVehicleTable(editVehicle);
            // показания спидометра и моточасов
            editService.Speedometer = coForm.speedometerIn;
            editService.Counter = coForm.motoIn;
            editService.EditDataInServicemileageTable(editService);
        }
        
        // Функция переключения видимости кнопок меню для администратора
        private void GetUserRightAdmin(bool flag)
        {
            userGuideButton.Enabled = flag;
            userToolStripMenuItem.Enabled = flag;
            driverGuideButton.Enabled = flag;
            driverToolStripMenuItem.Enabled = flag;
            vehicleGuideButton.Enabled = flag;
            avtoToolStripMenuItem.Enabled = flag;
            tireGuideButton.Enabled = flag;
            tireToolStripMenuItem.Enabled = flag;
            batteryGuideButton.Enabled = flag;
            batteryToolStripMenuItem.Enabled = flag;
            itineraryGuideButton.Enabled = flag;
            itineraryToolStripMenuItem.Enabled = flag;
            travelOrderToolStripMenuItem.Enabled = flag;
            addOrderButton.Enabled = flag;
            lockToolStripMenuItem.Enabled = flag;
            settingPrintingFormsToolStripMenuItem.Enabled = flag;
        }
        
        // Функция переключения видимости кнопок операций с путевыми листами
        private void SwitchingVisibility(bool flag)
        {
            // если вошел не Гость
            if (!_isGuest)
            {
                // если у пользователя есть соответствующие права
                if (_isSuperadmin || userRight.UserRightAdmin || userRight.UserRightWaybill)
                {
                    deleteOrderButton.Enabled = flag;
                    editOrderButton.Enabled = flag;
                    complOrderButton.Enabled = flag;
                    printOrderButton.Enabled = flag;
                    // contextMenuStrip1
                    editToolStripMenuItem.Enabled = flag;
                    deleteToolStripMenuItem.Enabled = flag;
                    complToolStripMenuItem.Enabled = flag;
                    printToolStripMenuItem.Enabled = flag;
                    // travelOrderToolStripMenuItem
                    delOrderToolStripMenuItem.Enabled = flag;
                    editOrderToolStripMenuItem.Enabled = flag;
                    complOrderToolStripMenuItem.Enabled = flag;
                    printOrderToolStripMenuItem.Enabled = flag;
                }
                // если у пользователя есть права на блокировку путевого листа
                if (_isSuperadmin || userRight.UserRightAdmin || userRight.UserRightWayblock)
                    lockToolStripMenuItem.Enabled = flag;
            }
        }

        // Метод позиционирования панели с отчетами и восстановления размеров окна
        private void PositionReportsPanel()
        {
            _reportsFlag = true;
            
            reportsPanel.Visible = true;
            reportsPanel.Location = new Point(0, 89);
            reportsPanel.Width = 1063;
            reportsPanel.Height = 420;

            orderPanel.Visible = false;
            ReportWindowsLoad();
        } 

        // Метод отсечения части строки и образование новой строки
        private string _cutSubstringFromString(ref string s, string c, int startIndex)
        {
            int pos1 = s.IndexOf(c, startIndex);
            string retString = s.Substring(0, pos1);
            s = (s.Substring(pos1 + c.Length)).Trim();
            return retString;
        }

    }
}
