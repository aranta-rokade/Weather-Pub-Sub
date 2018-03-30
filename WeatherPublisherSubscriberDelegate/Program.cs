using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPublisherSubscriberDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Name of Weather Publisher Station : ");
            string WPName = Console.ReadLine();
            WeatherPublisher WP = WeatherPublisher.GetPublisher(WPName);

            Console.WriteLine("Enter the no of subscribers : ");
            int WSNo = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < WSNo; i++)
            {
                Console.WriteLine("Enter the Name of Weather Subscriber Station : {0} ", (1 + i));
                string WSName = Console.ReadLine();
                WP.AddSubscriber(WSName);
            }

            int choice = 0;
            do
            {
                Console.WriteLine("Enter the latest temperature : ");
                int temperature = Convert.ToInt32(Console.ReadLine());
                WP.GetNotification(temperature);

                Console.WriteLine("Do you want to continue ? 0-yes");
                choice = Convert.ToInt32(Console.ReadLine());

            } while (choice==0);
        }
    }
}
