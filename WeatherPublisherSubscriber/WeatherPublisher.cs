using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WeatherPublisherSubscriber
{
    class WeatherPublisher
    {
        static WeatherPublisher WPObj;
        string WPName;
        public ArrayList WSList = new ArrayList();
        int temperature;

        private WeatherPublisher(string WPName)
        {
            this.WPName = WPName;
        }

        public static WeatherPublisher GetPublisher(string WPName)
        {
            if (WPObj == null)
            {
                WPObj = new WeatherPublisher(WPName);
            }

            return WPObj;
        }

        public void GetNotification(int temperature)
        {
            this.temperature = temperature;
            NotifySubscriber(temperature);
        }

        public void NotifySubscriber(int temperature)
        {
            foreach (WeatherSubscriber WS in WSList)
            {
                WS.Notify(temperature);
            }

            foreach (WeatherSubscriber WS in WSList)
            {
                WS.DisplayWeather();
            }
        }
    }
}
