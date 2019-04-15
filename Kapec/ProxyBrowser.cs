using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kapec
{
    public delegate void DownloadHTMLcode(string x);

    public partial class ProxyBrowser : Form
    {
        public static DownloadHTMLcode DHTML;

        public ProxyBrowser()
        {
            DHTML = new DownloadHTMLcode(ZagruzitHTML);
            InitializeComponent();
        }

        private void GoHTML_Click(object sender, EventArgs e)
        {
            byte[] msg = Encoding.UTF8.GetBytes("#DH<" + AdressTextBox.Text + ">");

            ServerForm.client.Send(msg);
        }

        private void WebBrowse_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HTMLTB.Text = WebBrowse.DocumentText;
        }

        public void ZagruzitHTML(string x)
        {
            WebBrowse.DocumentText = x;
            HTMLTB.Text = x;
        }
    }
}
