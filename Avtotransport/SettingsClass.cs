using System.IO;
using System.Windows.Forms;

namespace Avtotransport
{
    // Класс настроек программы
    class SettingsClass
    {
        // переменные класса
        private string _orgNumber;       // номер воинской части
        private string commanderRank;   // воинское звание командира части
        private string commanderName;   // фамилия командира части
        private string chiefPost;       // должность подписывающего сводную ведомость
        private string chiefRank;       // воинское звание подписывающего сводную ведомость
        private string chiefName;       // фамилия подписывающего сводную ведомость
        private string proofPost;       // должность проверившего сводную ведомость
        private string proofRank;       // воинское звание проверившего сводную ведомость
        private string proofName;       // фамилия проверившего сводную ведомость
        private string makePost;        // должность составившего сводную ведомость
        private string makeRank;        // воинское звание составившего сводную ведомость
        private string makeName;        // фамилия составившего сводную ведомость

        // строка пути к файлу с настройками
        string path = "options.dat";

        // пустой конструктор
        public SettingsClass()
        {
        }

        // конструктор для печатных форм
        public SettingsClass(string orgNumber, string commanderRank, string commanderName, 
            string chiefPost, string chiefRank, string chiefName, string proofPost, 
            string proofRank, string proofName, string makePost, string makeRank, string makeName)
        {
            this._orgNumber = orgNumber;
            this.commanderRank = commanderRank;
            this.commanderName = commanderName;
            this.chiefPost = chiefPost;
            this.chiefRank = chiefRank;
            this.chiefName = chiefName;
            this.proofPost = proofPost;
            this.proofRank = proofRank;
            this.proofName = proofName;
            this.makePost = makePost;
            this.makeRank = makeRank;
            this.makeName = makeName;
        }

#region Getters&Setters

        public string OrgNumber
        {
            get { return _orgNumber; }
            set { _orgNumber = value; }
        }

        public string CommanderRank
        {
            get { return commanderRank; }
            set { commanderRank = value; }
        }

        public string CommanderName
        {
            get { return commanderName; }
            set { commanderName = value; }
        }

        public string ChiefPost
        {
            get { return chiefPost; }
            set { chiefPost = value; }
        }

        public string ChiefRank
        {
            get { return chiefRank; }
            set { chiefRank = value; }
        }

        public string ChiefName
        {
            get { return chiefName; }
            set { chiefName = value; }
        }

        public string ProofPost
        {
            get { return proofPost; }
            set { proofPost = value; }
        }

        public string ProofRank
        {
            get { return proofRank; }
            set { proofRank = value; }
        }

        public string ProofName
        {
            get { return proofName; }
            set { proofName = value; }
        }

        public string MakePost
        {
            get { return makePost; }
            set { makePost = value; }
        }

        public string MakeRank
        {
            get { return makeRank; }
            set { makeRank = value; }
        }

        public string MakeName
        {
            get { return makeName; }
            set { makeName = value; }
        }

#endregion

#region Methods
        // Метод чтения настроек программы из файла options.dat
        public void ReadOptionsFile()
        {
            try
            {
                // создание объекта класса BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    // пока не достигнут конец файла
                    // считывается каждое значение из файла
                    while (reader.PeekChar() > -1)
                    {
                        OrgNumber = reader.ReadString();
                        CommanderRank = reader.ReadString();
                        CommanderName = reader.ReadString();
                        ChiefPost = reader.ReadString();
                        ChiefRank = reader.ReadString();
                        ChiefName = reader.ReadString();
                        ProofPost = reader.ReadString();
                        ProofRank = reader.ReadString();
                        ProofName = reader.ReadString();
                        MakePost = reader.ReadString();
                        MakeRank = reader.ReadString();
                        MakeName = reader.ReadString();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                File.Open(path, FileMode.Create);
            }
        }

        // Метод записи настроек программы в файл options.dat
        public void SaveOptionsFile(SettingsClass settings)
        {
            // создание объекта класса BinaryWriter
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                // записываем в файл значение каждого поля структуры
                writer.Write(settings.OrgNumber);
                writer.Write(settings.CommanderRank);
                writer.Write(settings.CommanderName);
                writer.Write(settings.ChiefPost);
                writer.Write(settings.ChiefRank);
                writer.Write(settings.ChiefName);
                writer.Write(settings.ProofPost);
                writer.Write(settings.ProofRank);
                writer.Write(settings.ProofName);
                writer.Write(settings.MakePost);
                writer.Write(settings.MakeRank);
                writer.Write(settings.MakeName);
            }
        }
#endregion
    }
}
