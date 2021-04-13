using System;
using System.Collections.Generic;
using System.Text;

namespace Classclass
{
    class Weather
    {
        Random rnd = new Random();
        private int minTemp;
        private int maxTemp;

        public int MinTemp { get; set; }

        public int MaxTemp
        {
            get
            {
                return maxTemp;
            }

            set
            {
                if (value > MinTemp)
                {
                    maxTemp = value;
                }
                else
                {
                    maxTemp = minTemp;
                }
            }
        }

        public Weather(int minTemp, int maxTemp) {
            MinTemp = minTemp;
            MaxTemp = maxTemp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>random temperature</returns>
        public int getRandomTemp()
        {
            return rnd.Next(MinTemp, MaxTemp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="temp">input temprature int number</param>
        /// <returns>return type of weather</returns>
        public string getWeatherType(int temp)
        {
            if (temp <= 0)
            {
                return "snow";
            }
            else
            {
                return "rain";
            }
        }
    }
}
