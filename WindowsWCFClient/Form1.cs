using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsWCFClient.DownloadService;

namespace WindowsWCFClient
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class Form1 : Form, IDownloadServiceCallback
    {
        InstanceContext context = null;
        DownloadServiceClient client = null;
        public Form1()
        {
            InitializeComponent();
            context = new InstanceContext(this);
        }

        public void Progress(int percent, FileContract file)
        {
            CheckForIllegalCrossThreadCalls = false;
            lblDownload.Visible = true;
            progressBar.Visible = true;
            progressBar.Value = percent;
            lblProgress.Text = string.Format("{0} % complete", percent);
            lblDownload.Text = string.Format("Downloading {0}...", file.Name);
            File.WriteAllBytes(@"D:\Windows-Client\" + file.Name.Substring(file.Name.IndexOf(@"ClickOnce\") + 10, file.Name.Length - (file.Name.IndexOf(@"ClickOnce\") + 10)), file.Content);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            lblProgress.Visible = true;
            lblProgress.Text = "Fetching Files...";
            client = new DownloadServiceClient(context);
            client.DownloadDocument();
            lblProgress.Text = "Download Complete";
        }
    }
}
