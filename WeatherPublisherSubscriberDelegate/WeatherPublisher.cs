using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WeatherPublisherSubscriberDelegate
{
    public delegate void NotifySubscriberDelegate(int temperature);
    public delegate void DisplaySubscriberDelegate();

    class WeatherPublisher
    {
        static WeatherPublisher WPObj;
        string WPName;
        public ArrayList WSList = new ArrayList();
        int temperature;
        
        //NotifySubscriberDelegate notify;
        //DisplaySubscriberDelegate display;
        event NotifySubscriberDelegate notifyEvent;
        event DisplaySubscriberDelegate displayEvent;

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

        public void AddSubscriber(string WSName)
        {
            WeatherSubscriber WS = new WeatherSubscriber(WSName);
            WSList.Add(WS);
            //notify += new NotifySubscriberDelegate(WS.Notify);
            //display += new DisplaySubscriberDelegate(WS.DisplayWeather);
            notifyEvent += WS.Notify;
            displayEvent += WS.DisplayWeather;
        }

        public void GetNotification(int temperature)
        {
            this.temperature = temperature;
            //notify(temperature);
            //display();
            notifyEvent(temperature);
            displayEvent();
        }
    }
}
