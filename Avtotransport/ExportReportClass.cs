using System;
using System.Collections;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс импорта отчета в документ MsWord
    class ExportReportClass
    {
        private enum TxtAligment { Left, Center, Right, Justify }
        // переменные класса
        private string _nameTempDoc = "";       // название шаблона
        private string _rPeriod = "";           // период отчета
        private string _cMonth = "";            // месяц составления карточки учета
        private string _cYear = "";             // год составления карточки учета
        private int _tableNum;                  // номер таблицы
        private int _addRowsCount;              // количество строк для вставки в таблицу
        private DateTime _minDate;              // минимальная дата регистрации путевых листов
        private WordDocument _wordDoc = null;
        // экземпляр класса SettingsClass
        SettingsClass settings = new SettingsClass();
        // экземпляр класа ReportClass
        private ReportClass _report;
        // экземпляр класса CardMachineWorkClass
        private CardMachineWorkClass _cardMachine;
        // экземпляр класса VehicleClass
        //private VehicleClass _vehicle;

        // конструктор
        public ExportReportClass(string name)
        {
            // размер зеркальных полей страницы
            int margin = 43;
            // чтение настроек из файла options.dat
            settings.ReadOptionsFile();
            //NameSvodDoc = name + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".doc";
            NameTempDoc = name;
        }

#region Getters&Setters

        public string NameTempDoc
        {
            get { return _nameTempDoc; }
            set { _nameTempDoc = value; }
        }

        public string RPeriod
        {
            get { return _rPeriod; }
            set { _rPeriod = value; }
        }

        public string CMonth
        {
            get { return _cMonth; }
            set { _cMonth = value; }
        }

        public string CYear
        {
            get { return _cYear; }
            set { _cYear = value; }
        }

        public int TableNum
        {
            get { return _tableNum; }
            set { _tableNum = value; }
        }

        public int AddRowsCount
        {
            get { return _addRowsCount; }
            set { _addRowsCount = value; }
        }

        public DateTime MinDate
        {
            get { return _minDate; }
            set { _minDate = value; }
        }

        public WordDocument WordDoc
        {
            get { return _wordDoc; }
            set { _wordDoc = value; }
        }

        public ReportClass Report
        {
            get { return _report; }
            set { _report = value; }
        }

        public CardMachineWorkClass CardMachine
        {
            get { return _cardMachine; }
            set { _cardMachine = value; }
        }

        //public VehicleClass Vehicle
        //{
        //    get { return _vehicle; }
        //    set { _vehicle = value; }
        //}

#endregion

        // ПУТЬ К ШАБЛОНУ ПО ДАННЫМ ФОРМЫ
        private string pathToTemplate
        {
            get
            {
                return Application.StartupPath + "\\" + _nameTempDoc;
            }
        }

        // Формирование документа (Сводная ведомость учета работы машин)
        public void GetDocumentStrukture(ListView lvi)
        {
            WordDoc = new WordDocument(pathToTemplate);
            GetTopSv();
            GetTitleSv();
            GetEconomiFuel();
            FillExistingTableSv(lvi);
            GetBottomSv();
            OpenDocument();
        }

        // Формирование документа (Карточка учета работы машин)
        public void GetCardStrukture(DateTime minDate)
        {
            MinDate = minDate;
            WordDoc = new WordDocument(pathToTemplate);
            GetTitleCard();
            //GetEconomiFuel();
            //FillExistingTable(lvi);
            GetBottomCard();
            OpenDocument();
        }

#region Svodnaya
        //** СВОДНАЯ ВЕДОМОСТЬ УЧЕТА РАБОТЫ МАШИН **//
        // Утверждение документа
        private void GetTopSv()
        {
            // создание строк утверждения
            ReplaceStringInTemplate("@@oNumber", settings.OrgNumber, TxtAligment.Left);
            ReplaceStringInTemplate("@@comanderRank&Name", settings.CommanderRank.PadRight(25) + 
                settings.CommanderName, TxtAligment.Left);
            ReplaceStringInTemplate("@@date", "____." + DateTime.Today.ToString("MM.yyyy"), TxtAligment.Left);
        }

        // Шапка документа
        private void GetTitleSv()
        {
            // создание строки периода
            ReplaceStringInTemplate("@@period", RPeriod, TxtAligment.Center);
        }


        // Подпись документа
        private void GetBottomSv()
        {
            // создание строк подписи
            ReplaceStringInTemplate("@@ChiefPost", settings.ChiefPost, TxtAligment.Left);
            ReplaceStringInTemplate("@@ChiefRank", settings.ChiefRank, TxtAligment.Left);
            ReplaceStringInTemplate("@@Name", settings.ChiefName, TxtAligment.Left);
            ReplaceStringInTemplate("@@ProofPost", settings.ProofPost, TxtAligment.Left);
            ReplaceStringInTemplate("@@ProofRank", settings.ProofRank, TxtAligment.Left);
            ReplaceStringInTemplate("@@Name", settings.ProofName, TxtAligment.Left);
            ReplaceStringInTemplate("@@MakePost", settings.MakePost, TxtAligment.Left);
            ReplaceStringInTemplate("@@MakeRank", settings.MakeRank, TxtAligment.Left);
            ReplaceStringInTemplate("@@Name", settings.MakeName, TxtAligment.Left);
        }

        // Масло по норме, экономия и пережог топлива
        private void GetEconomiFuel()
        {
            ReplaceStringInTemplate("@@oilNorma", Convert.ToString(Math.Round(_report.OilNorma, 2)), 
                TxtAligment.Left);
            ReplaceStringInTemplate("@@fuelEcon", Convert.ToString(Math.Round(_report.BenzinEconomy, 2)),
                TxtAligment.Left);
            ReplaceStringInTemplate("@@fuelUnecon", Convert.ToString(Math.Round(_report.BenzinUneconomy, 2)),
                TxtAligment.Left);
            ReplaceStringInTemplate("@@dizelEcon", Convert.ToString(Math.Round(_report.DiselEconomy, 2)),
                TxtAligment.Left);
            ReplaceStringInTemplate("@@dizelUnecon", Convert.ToString(Math.Round(_report.DiselUneconomy, 2)),
                TxtAligment.Left);
        }

        // ВЫБОР И ЗАПОЛНЕНИЕ ИМЕЮЩЕЙСЯ ТАБЛИЦЫ
        private void FillExistingTableSv(ListView lvi)
        {
            // такая конвертация типов работает не всегда, не на всех сочетаниях типов
            _wordDoc.SelectTable(_tableNum);
            // вставка строк в таблицу
            for (int i = 0; i < lvi.Items.Count; i++)
            {
                _wordDoc.AddRowToTable();
                for (int j = 1, column = 2; j < lvi.Items[i].SubItems.Count; j++)
                {
                    // столбец Тип и марка машины
                    if (j == 1)
                    {
                        _wordDoc.SetSelectionToCell(i + 5, column++);
                        _wordDoc.Selection.Text = lvi.Items[i].SubItems[j++].Text + " " +
                                                 lvi.Items[i].SubItems[j].Text; // тип и марка
                    }
                    // столбец Пробег
                    else if (j == 6)
                    {
                        column += 2;
                        _wordDoc.SetSelectionToCell(i + 5, column++);
                        _wordDoc.Selection.Text = lvi.Items[i].SubItems[j].Text;
                    }
                    // столбец Перевезено груза
                    else if (j == 9)
                    {
                        _wordDoc.SetSelectionToCell(i + 5, ++column);
                        _wordDoc.Selection.Text = lvi.Items[i].SubItems[j].Text;
                        column++;
                    }
                    // столбец Горючее - сорт
                    else if (j == 11)
                    {
                        column += 3;
                        _wordDoc.SetSelectionToCell(i + 5, column++);
                        _wordDoc.Selection.Text = lvi.Items[i].SubItems[j].Text;
                    }
                    else
                    {
                        _wordDoc.SetSelectionToCell(i + 5, column++);
                        _wordDoc.Selection.Text = lvi.Items[i].SubItems[j].Text;
                    }
                    _wordDoc.Selection.FontSize = 9;
                    _wordDoc.Selection.Aligment = TextAligment.Center;
                }
            }
        }
        #endregion

#region Card
        //** КАРТОЧКА УЧЕТА РАБОТЫ МАШИН **//
        // Шапка документа
        private void GetTitleCard()
        {
            // номер воинской части
            ReplaceStringInTemplate("@@orgNumber", settings.OrgNumber, TxtAligment.Left);
            // на машину
            ReplaceStringInTemplate("@@vType&Name", new VehicleClass().GetVehicleType(_cardMachine.VehicleType) + 
                                                    ", " + _cardMachine.VehicleModel, TxtAligment.Left);
            // государственный номер
            ReplaceStringInTemplate("@@vNumber", _cardMachine.VehicleRegNumber, TxtAligment.Left);
            // на месяц и год
            ReplaceStringInTemplate("@@Month", CMonth, TxtAligment.Left);
            ReplaceStringInTemplate("@@Year", CYear, TxtAligment.Left);
            // показания одометра на начало месяца
            int[] minMaxOdometr = new int[2];
            minMaxOdometr = _cardMachine.GetSatrEndOdometr(_cardMachine.Year, _cardMachine.Month,
                _cardMachine.Days, _cardMachine.OrderList, _minDate);
            _cardMachine.SpeedometerStart = minMaxOdometr[0];
            _cardMachine.SpeedometerEnd = minMaxOdometr[1];
            _cardMachine.ResultOdometr = minMaxOdometr[1] - minMaxOdometr[0];
            ReplaceStringInTemplate("@@startSpeed", Convert.ToString(_cardMachine.SpeedometerStart), TxtAligment.Left);
            // показания одометра на конец месяца
            ReplaceStringInTemplate("@@endSpeed", Convert.ToString(_cardMachine.SpeedometerEnd), TxtAligment.Left);
            // общий пробег
            ReplaceStringInTemplate("@@resultSpeed", Convert.ToString(_cardMachine.ResultOdometr), 
                TxtAligment.Left);
            // пробег по плану
            ReplaceStringInTemplate("@@Plane", Convert.ToString(minMaxOdometr[1] - minMaxOdometr[0]),
                TxtAligment.Left);
        }

        // Обратная сторона и подпись документа
        private void GetBottomCard()
        {
            // обратная сторона

            // создание строк подписи
            ReplaceStringInTemplate("@@ChiefPost", settings.ChiefPost, TxtAligment.Left);
            ReplaceStringInTemplate("@@ChiefRank", settings.ChiefRank, TxtAligment.Left);
            ReplaceStringInTemplate("@@Name", settings.ChiefName, TxtAligment.Left);
            ReplaceStringInTemplate("@@MakePost", settings.MakePost, TxtAligment.Left);
            ReplaceStringInTemplate("@@MakeRank", settings.MakeRank, TxtAligment.Left);
            ReplaceStringInTemplate("@@Name", settings.MakeName, TxtAligment.Left);
            ReplaceStringInTemplate("@@tMonth", Convert.ToString(DateTime.Today.Month), TxtAligment.Left);
            ReplaceStringInTemplate("@@tYear", Convert.ToString(DateTime.Today.Year), TxtAligment.Left);
        }

#endregion

        // Метод замены строки в шаблоне 
        private void ReplaceStringInTemplate(string toFindStr, string replaceStr, TxtAligment aligment)
        {
            try
            {
                // поиск строки для замены
                _wordDoc.SetSelectionToText(toFindStr);
                // вставка новой строки вместо другой
                _wordDoc.Selection.Text = replaceStr;
                switch (aligment)
                {
                    case TxtAligment.Left:
                        _wordDoc.Selection.Aligment = TextAligment.Left;
                        break;
                    case TxtAligment.Right:
                        _wordDoc.Selection.Aligment = TextAligment.Right;
                        break;
                    case TxtAligment.Center:
                        _wordDoc.Selection.Aligment = TextAligment.Center;
                        break;
                    case TxtAligment.Justify:
                        _wordDoc.Selection.Aligment = TextAligment.Justify;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception error)
            {
                if (_wordDoc != null) { _wordDoc.Close(); }
                MessageBox.Show("Ошибка при замене текста на метке в документе  Word. Подробности: " + error.Message);
                return;
            }
        }

        // Сохранение документа
        private void OpenDocument()
        {
            // открытие документа
            _wordDoc.Visible = true;
        }

    }
}
