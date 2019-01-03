using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DownloadService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract =typeof(IReportCallback))]
    public interface IDownloadService
    {
        [OperationContract]
        void DownloadDocument();
    }

    [DataContract]
    public class FileContract
    {
        [DataMember(Order =2)]
        public string Name { get; set; }
        [DataMember(Order = 1)]
        public byte[] Content { get; set; }
    }

    public interface IReportCallback
    {
        [OperationContract]
        void Progress(int percent, FileContract file);
    }
}
