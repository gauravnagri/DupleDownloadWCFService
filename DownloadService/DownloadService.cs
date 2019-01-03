using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DownloadService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Reentrant)]
    public class DownloadService : IDownloadService
    {
        public void DownloadDocument()
        {
            FileContract contract;
            var files = Directory.GetFiles(@"C:\Users\gnagri\Desktop\ClickOnce");
            int percent = 0;
            for(int i=0; i < files.Length; i++)
            {
                contract = new FileContract();
                contract.Name = files[i];
                contract.Content = File.ReadAllBytes(files[i]);
                percent = (i + 1) * 100/ files.Length;
                OperationContext.Current.GetCallbackChannel<IReportCallback>().Progress((int)percent, contract);
            }
        }
    }
}
