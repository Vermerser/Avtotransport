using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtotransport
{
    // Класс, реализующий функционал отчетов о расходе топлива
    class FuelReportClass
    {
        // переменные класса
        private int vehacleId;              // Id автомобиля
        private string vehicleModel;        // модель автомобиля
        private string vehicleRegnumber;    // регистрационный номер автомобиля
        private int speedometrStart;        // спидометр начало
        private int speedometrFinish;       // спидометр конец
        private int resultRun;              // пробег
        private float fuelConsumptionNorma; // расход топлива по норме
        private float fuelConsumptionFact;  // расход топлива фактически
        private float fuelEconomy;          // экономия
        private float fuelUneconomy;        // пережог

        // конструкторы
        public FuelReportClass()
        {
        }

        public FuelReportClass(int vehacleId, string vehicleModel, string vehicleRegnumber, 
            int speedometrStart, int speedometrFinish, int resultRun, float fuelConsumptionNorma, 
            float fuelConsumptionFact, float fuelEconomy, float fuelUneconomy)
        {
            this.vehacleId = vehacleId;
            this.vehicleModel = vehicleModel;
            this.vehicleRegnumber = vehicleRegnumber;
            this.speedometrStart = speedometrStart;
            this.speedometrFinish = speedometrFinish;
            this.resultRun = resultRun;
            this.fuelConsumptionNorma = fuelConsumptionNorma;
            this.fuelConsumptionFact = fuelConsumptionFact;
            this.fuelEconomy = fuelEconomy;
            this.fuelUneconomy = fuelUneconomy;
        }

#region Getters&Setters

        public int VehacleId
        {
            get { return vehacleId; }
            set { vehacleId = value; }
        }

        public string VehicleModel
        {
            get { return vehicleModel; }
            set { vehicleModel = value; }
        }

        public string VehicleRegnumber
        {
            get { return vehicleRegnumber; }
            set { vehicleRegnumber = value; }
        }

        public int SpeedometrStart
        {
            get { return speedometrStart; }
            set { speedometrStart = value; }
        }

        public int SpeedometrFinish
        {
            get { return speedometrFinish; }
            set { speedometrFinish = value; }
        }

        public int ResultRun
        {
            get { return resultRun; }
            set { resultRun = value; }
        }

        public float FuelConsumptionNorma
        {
            get { return fuelConsumptionNorma; }
            set { fuelConsumptionNorma = value; }
        }

        public float FuelConsumptionFact
        {
            get { return fuelConsumptionFact; }
            set { fuelConsumptionFact = value; }
        }

        public float FuelEconomy
        {
            get { return fuelEconomy; }
            set { fuelEconomy = value; }
        }

        public float FuelUneconomy
        {
            get { return fuelUneconomy; }
            set { fuelUneconomy = value; }
        }

#endregion


    }
}
