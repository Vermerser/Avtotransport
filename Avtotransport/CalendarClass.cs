using System;

namespace Avtotransport
{
    // Класс, реализующий функционал календаря
        static class CalendarClass
    {
        // переменные класса
        private static int _lastYear;           // последний год в календаре
        private static int[] _yearsMas;         // массив с годами
        private static int[,] _monthMas;        // многомерный массив с номерами месяцов в году

        static CalendarClass()
        {
        }
        
#region Getters&Setters
        public static int LastYear
        {
            get => _lastYear;
            set => _lastYear = value;
        }

        public static int[] YearsMas
        {
            get => _yearsMas;
            set => _yearsMas = value;
        }

        public static int[,] MonthMas
        {
            get => _monthMas;
            set => _monthMas = value;
        }
        #endregion

#region Functions
        // Функция создания массива с годами
        public static void GetYearsMas(int startYear)
        {
            int count = _lastYear - startYear;
            _yearsMas = new int[++count];
            for (int i = 0; i < count; i++)
            {
                _yearsMas[i] = startYear++;
            }
        }
        
        // Функция создания массива с месяцами
        public static void GetMonthMas(DateTime startTime)
        {
            int startMonth = startTime.Month;
            int endMonth = DateTime.Today.Month;
            _monthMas = new int[_yearsMas.Length,12];
            // если в календаре один год
            if (_yearsMas.Length == 1)
            {
                for (int i = startMonth - 1; i < endMonth; i++)
                {
                    _monthMas[0, i] = 1;
                }
            }
            // если в календаре больше одного года
            else
            {
                // заполнение начального года
                for (int i = startMonth - 1; i < 12; i++)
                {
                    _monthMas[0, i] = 1;
                }
                // заполнение промежуточных годов
                if (DateTime.Today.Year - startTime.Year > 1)
                {
                    for (int i = 1; i < DateTime.Today.Year - startTime.Year; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            _monthMas[i, j] = 1;
                        }
                    }
                }
                // заполнение последнего года
                for (int i = 0; i < endMonth; i++)
                {
                    _monthMas[_yearsMas.Length - 1, i] = 1;
                }
            }
        }

#endregion
    }
}
