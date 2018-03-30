using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPublisherSubscriberDelegate
{
    class WeatherSubscriber
    {
        public string WSName;
        public int temperature;
        
        public WeatherSubscriber(string WSName)
        {
            this.WSName = WSName;
        }
        
        public void Notify(int temperature)
        {
            this.temperature = temperature;
        }

        public void DisplayWeather()
        {
            Console.WriteLine("Subscriber : {0} Temperature : {1} ", WSName, temperature);
        }
    }
}
