using System;
using System.ServiceModel;

namespace DownloadServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(DownloadService.DownloadService)))
            {
                host.Open();
                Console.WriteLine("Service started running at : {0}", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                Console.ReadLine();
            }
        }
    }
}
