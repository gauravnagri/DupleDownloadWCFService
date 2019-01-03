using System;
using System.Windows.Forms;
using DownloadServiceClient.DownloadService;

namespace DownloadServiceClient
{
    public partial class Form1 : Form, DownloadService.IDownloadServiceCallback
    {
        DownloadService.DownloadServiceClient client;
        public Form1()
        {
            InitializeComponent();
        }

        public void Progress(int percent, DownloadService.DownloadServiceClient.DownloadService.FileContract file)
        {
            throw new NotImplementedException();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            label1.Text = "Fetching Documents...";
            client.DownloadDocument();
        }
    }
}
