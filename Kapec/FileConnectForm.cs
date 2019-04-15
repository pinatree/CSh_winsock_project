using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Kapec
{
    public delegate void GetingThisQWE(string[] peredacha);

    public delegate void GettingTreeView(byte[] xypma);

    public delegate void ObnovitThis();

    public delegate void DownloadByTarget(byte[] content);

    public delegate void UploadBufferChanged();

    public partial class FileConnectForm : Form
    {
        //штука для перекидывания в комбобокс
        public static GetingThisQWE tet;

        public static GettingTreeView GetTreeView1;

        public static ObnovitThis Obnovshik;

        public static DownloadByTarget DBTarget;

        public static UploadBufferChanged UBC;

        bool ojidaniyePriema = false;

        string[] TekushiyeNazvaniya;

        string[] MyTekushiyeNazvaniya;

        string NameCopyFile = "";

        string MyCopyDirectString = "";

        string DirectTarget = @"D:\\PomoikaSiSharp\\";

        string OtherCopyDirectString = "";

        public FileConnectForm()
        {
            //присвоение делегата методу заполнения комбобокс
            tet = new GetingThisQWE(ZapolnitcomboBox);

            UBC = new UploadBufferChanged(UploadValueChanged);

            GetTreeView1 = new GettingTreeView(CreateNewSpisokFilesFromByte);

            Obnovshik = new ObnovitThis(PeredZapolnitMyListView);

            DBTarget = new DownloadByTarget(DownloadByTarget);

            InitializeComponent();

            if (ServerForm.ServerPeresylkaBufferSize < 1073741824)
            {
                DownloadBufferTextBox.Text = Math.Round(Convert.ToDecimal(ServerForm.ServerPeresylkaBufferSize) / 1048576) + " mb";
            }
            else
            {
                DownloadBufferTextBox.Text = Math.Round((Convert.ToDecimal(ServerForm.ServerPeresylkaBufferSize) / 1073741824), 1) + " gb";
            }

            DownloadBufferScB.Value = Convert.ToInt32(ServerForm.ServerPeresylkaBufferSize);
        }

        private void ComboboxOfMyComp_MouseClick(object sender, MouseEventArgs e)
        {
            string[] StartDitectories = Environment.GetLogicalDrives();

            ComboboxOfMyComp.Items.Clear();

            foreach (string s in StartDitectories)
            {
                ComboboxOfMyComp.Items.Add(s);
            }
        }

        private void ComboboxOfOtherComp_MouseClick(object sender, MouseEventArgs e)
        {
            byte[] msg = Encoding.UTF8.GetBytes("#SD");
            ServerForm.client.Send(msg);
        }

        public void ZapolnitcomboBox(string[] xenon)
        {
            ComboboxOfOtherComp.Items.Clear();
            foreach (string s in xenon)
            {
                ComboboxOfOtherComp.Items.Add(s);
            }
        }

        private void OtherStartDirectLoad_Click(object sender, EventArgs e)
        {
            if (ComboboxOfOtherComp.Text.Length != 0)
            {
                byte[] msg = Encoding.UTF8.GetBytes("#GD<" + ComboboxOfOtherComp.Text + ">");
                ServerForm.client.Send(msg);
            }
        }

        private void OtherCompDirectBox_DoubleClick(object sender, EventArgs e)
        {
            int x = 0;

            foreach (ListViewItem item in OtherCompDirectBox.SelectedItems)
            {
                x = item.Index;
            }

            if (TekushiyeNazvaniya[x].Substring(TekushiyeNazvaniya[x].Length -1, 1) != "s")
            {
                byte[] msg = Encoding.UTF8.GetBytes("#GD<" + TekushiyeNazvaniya[x].Substring(0, TekushiyeNazvaniya[x].Length - 1) + ">");
                ServerForm.client.Send(msg);
            }
        }

        public void CreateNewSpisokFilesFromByte(byte[] content)
        {
            try
            {
                MemoryStream memStream = new MemoryStream();
                BinaryFormatter binForm = new BinaryFormatter();
                memStream.Write(content, 0, content.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                string[] obj = (string[])binForm.Deserialize(memStream);

                if (obj.Length != 0)
                {
                    try
                    {
                        OtherFullDirectPole.Text = Path.GetDirectoryName(obj.First().Substring(0, obj.First().Length - 1));

                        OtherCompDirectBox.Items.Clear();

                        TekushiyeNazvaniya = obj;

                        for (int w = 0; w < TekushiyeNazvaniya.Length; w++)
                        {
                            ListViewItem xxx = new ListViewItem();
                            xxx.Text = (Path.GetFileName(TekushiyeNazvaniya[w].Substring(0, TekushiyeNazvaniya[w].Length - 1)));
                            string sravn = Path.GetExtension(TekushiyeNazvaniya[w].Substring(0, TekushiyeNazvaniya[w].Length - 1));
                            if (TekushiyeNazvaniya[w].Substring(TekushiyeNazvaniya[w].Length - 1, 1) == "s")
                            {
                                if ((sravn == ".bmp") || (sravn == ".gif") || (sravn == ".jpeg") || (sravn == ".jpg") || (sravn == ".png") || (sravn == ".jpe") || (sravn == ".pdf") || (sravn == ".BMP") || (sravn == ".GIF") || (sravn == ".JPEG") || (sravn == ".JPG") || (sravn == ".PNG") || (sravn == ".JPE") || (sravn == ".PDF"))
                                {
                                    xxx.ImageKey = "ImageIcon.png";
                                }
                                else
                                {
                                    if ((sravn == ".mp4") || (sravn == ".avi") || (sravn == ".HDrip") || (sravn == ".flv") || (sravn == ".mpeg") || (sravn == ".MP4") || (sravn == ".AVI") || (sravn == ".FLV") || (sravn == ".MPEG"))
                                    {
                                        xxx.ImageKey = "VideoIcon.png";
                                    }
                                    else
                                    {
                                        if (sravn == ".exe")
                                        {
                                            xxx.ImageKey = "EXEIcon.png";
                                        }
                                        else
                                        {
                                            if ((sravn == ".txt") || (sravn == ".odt") || (sravn == ".doc") || (sravn == ".docx") || (sravn == ".docm") || (sravn == ".TXT") || (sravn == ".ODT") || (sravn == ".DOC") || (sravn == ".DOCX") || (sravn == ".DOCM"))
                                            {
                                                xxx.ImageKey = "TextIcon.png";
                                            }
                                            else
                                            {
                                                xxx.ImageKey = "FileIcon.png";
                                            }

                                        }
                                    }
                                }
                            }
                            if (TekushiyeNazvaniya[w].Substring(TekushiyeNazvaniya[w].Length - 1, 1) == "d")
                            {
                                xxx.ImageKey = "PapkaIcon.png";
                            }
                            OtherCompDirectBox.Items.Add(xxx);
                        }
                    }
                    catch
                    { }
                }
                else
                {
                    OtherCompDirectBox.Items.Clear();
                    OtherCompDirectBox.Items.Add("Nope here");
                }
            }
            catch
            { }
        }

        //метод отсылки адреса того, что нужно вернуть обратно
        private void GoZagruzitDirect_Click(object sender, EventArgs e)
        {
            byte[] msg = Encoding.UTF8.GetBytes("#GD<" + OtherFullDirectPole.Text + ">");
            ServerForm.client.Send(msg);
        }
        
        //1 уровень вверх по директории
        private void GoNazadDirect_Click(object sender, EventArgs e)
        {
            try
            {
                OtherFullDirectPole.Text = Path.GetDirectoryName(OtherFullDirectPole.Text);
                GoZagruzitDirect_Click(sender, e);
            }
            catch { }
        }

        private void MyStartDirectLoad_Click(object sender, EventArgs e)
        {

            string[] GetDitectories = new string[1];

            try
            {
                GetDitectories = Directory.GetDirectories(ComboboxOfMyComp.Text);
                for (int w = 0; w < GetDitectories.Length; w++)
                {
                    GetDitectories[w] = GetDitectories[w] + "d";
                }
                string[] GetFiles = Directory.GetFiles(ComboboxOfMyComp.Text);
                for (int w = 0; w < GetFiles.Length; w++)
                {
                    GetFiles[w] = GetFiles[w] + "s";
                }

                int GD = GetDitectories.Length;
                Array.Resize(ref GetDitectories, GetDitectories.Length + GetFiles.Length);
                for (int w = 0; w < GetFiles.Length; w++)
                {
                    GetDitectories[GD + w] = GetFiles[w];
                }
            }
            catch
            {
                GetDitectories = new string[1];
                GetDitectories[0] = "Disk is not ready-";
            }

            ZapolnitMyListView(GetDitectories);
        }

        private void MyCompDirectBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int x = 0;

                foreach (ListViewItem item in MyCompDirectBox.SelectedItems)
                {
                    x = item.Index;
                }

                string[] GetDitectories = new string[1];

                if (MyTekushiyeNazvaniya[x].Substring(MyTekushiyeNazvaniya[x].Length - 1, 1) == "d")
                {
                    GetDitectories = Directory.GetDirectories(MyTekushiyeNazvaniya[x].Substring(0, MyTekushiyeNazvaniya[x].Length - 1));
                    for (int w = 0; w < GetDitectories.Length; w++)
                    {
                        GetDitectories[w] = GetDitectories[w] + "d";
                    }
                    string[] GetFiles = Directory.GetFiles(MyTekushiyeNazvaniya[x].Substring(0, MyTekushiyeNazvaniya[x].Length - 1));
                    for (int w = 0; w < GetFiles.Length; w++)
                    {
                        GetFiles[w] = GetFiles[w] + "s";
                    }

                    int GD = GetDitectories.Length;
                    Array.Resize(ref GetDitectories, GetDitectories.Length + GetFiles.Length);
                    for (int w = 0; w < GetFiles.Length; w++)
                    {
                        GetDitectories[GD + w] = GetFiles[w];
                    }

                    ZapolnitMyListView(GetDitectories);
                }
            }
            catch
            { }
        }

        public void ZapolnitMyListView(string[] GetDitectories)
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;

                if (ComboboxOfMyComp.Text.Length != 0)
                {
                    if (GetDitectories.Length != 0)
                    {
                        try
                        {
                            MyFullDirectPole.Text = Path.GetDirectoryName(GetDitectories.First().Substring(0, GetDitectories.First().Length - 1));

                            MyCompDirectBox.Items.Clear();

                            MyTekushiyeNazvaniya = GetDitectories;

                            for (int w = 0; w < MyTekushiyeNazvaniya.Length; w++)
                            {
                                ListViewItem xxx = new ListViewItem();
                                xxx.Text = (Path.GetFileName(MyTekushiyeNazvaniya[w].Substring(0, MyTekushiyeNazvaniya[w].Length - 1)));
                                string sravn = Path.GetExtension(MyTekushiyeNazvaniya[w].Substring(0, MyTekushiyeNazvaniya[w].Length - 1));
                                if (MyTekushiyeNazvaniya[w].Substring(MyTekushiyeNazvaniya[w].Length - 1, 1) == "s")
                                {
                                    if ((sravn == ".bmp") || (sravn == ".gif") || (sravn == ".jpeg") || (sravn == ".jpg") || (sravn == ".png") || (sravn == ".jpe") || (sravn == ".pdf") || (sravn == ".BMP") || (sravn == ".GIF") || (sravn == ".JPEG") || (sravn == ".JPG") || (sravn == ".PNG") || (sravn == ".JPE") || (sravn == ".PDF"))
                                    {
                                        xxx.ImageKey = "ImageIcon.png";
                                    }
                                    else
                                    {
                                        if ((sravn == ".mp4") || (sravn == ".avi") || (sravn == ".HDrip") || (sravn == ".flv") || (sravn == ".mpeg") || (sravn == ".MP4") || (sravn == ".AVI") || (sravn == ".FLV") || (sravn == ".MPEG"))
                                        {
                                            xxx.ImageKey = "VideoIcon.png";
                                        }
                                        else
                                        {
                                            if (sravn == ".exe")
                                            {
                                                xxx.ImageKey = "EXEIcon.png";
                                            }
                                            else
                                            {
                                                if ((sravn == ".txt") || (sravn == ".odt") || (sravn == ".doc") || (sravn == ".docx") || (sravn == ".docm") || (sravn == ".TXT") || (sravn == ".ODT") || (sravn == ".DOC") || (sravn == ".DOCX") || (sravn == ".DOCM"))
                                                {
                                                    xxx.ImageKey = "TextIcon.png";
                                                }
                                                else
                                                {
                                                    xxx.ImageKey = "FileIcon.png";
                                                }

                                            }
                                        }
                                    }
                                }
                                if (MyTekushiyeNazvaniya[w].Substring(MyTekushiyeNazvaniya[w].Length - 1, 1) == "d")
                                {
                                    xxx.ImageKey = "PapkaIcon.png";
                                }
                                MyCompDirectBox.Items.Add(xxx);
                            }
                        }
                        catch
                        { }
                    }
                    else
                    {
                        MyCompDirectBox.Items.Clear();
                        MyCompDirectBox.Items.Add("Nope here");

                    }
                }
            }
            catch
            { }
        }

        private void GoNazadMyDirect_Click(object sender, EventArgs e)
        {
            try
            {
                MyFullDirectPole.Text = Path.GetDirectoryName(MyFullDirectPole.Text);

                string[] GetDitectories = new string[1];

                try
                {
                    GetDitectories = Directory.GetDirectories(MyFullDirectPole.Text);
                    for (int w = 0; w < GetDitectories.Length; w++)
                    {
                        GetDitectories[w] = GetDitectories[w] + "d";
                    }
                    string[] GetFiles = Directory.GetFiles(MyFullDirectPole.Text);
                    for (int w = 0; w < GetFiles.Length; w++)
                    {
                        GetFiles[w] = GetFiles[w] + "s";
                    }

                    int GD = GetDitectories.Length;
                    Array.Resize(ref GetDitectories, GetDitectories.Length + GetFiles.Length);
                    for (int w = 0; w < GetFiles.Length; w++)
                    {
                        GetDitectories[GD + w] = GetFiles[w];
                    }
                }
                catch
                {
                    GetDitectories = new string[1];
                    GetDitectories[0] = "Disk is not ready-";
                }

                ZapolnitMyListView(GetDitectories);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeredZapolnitMyListView();
        }

        public void PeredZapolnitMyListView()
        {
            string[] GetDitectories = new string[1];

            try
            {
                GetDitectories = Directory.GetDirectories(MyFullDirectPole.Text);
                for (int w = 0; w < GetDitectories.Length; w++)
                {
                    GetDitectories[w] = GetDitectories[w] + "d";
                }
                string[] GetFiles = Directory.GetFiles(MyFullDirectPole.Text);
                for (int w = 0; w < GetFiles.Length; w++)
                {
                    GetFiles[w] = GetFiles[w] + "s";
                }

                int GD = GetDitectories.Length;
                Array.Resize(ref GetDitectories, GetDitectories.Length + GetFiles.Length);
                for (int w = 0; w < GetFiles.Length; w++)
                {
                    GetDitectories[GD + w] = GetFiles[w];
                }
            }
            catch
            {
                GetDitectories = new string[1];
                GetDitectories[0] = "Disk is not ready-";
            }

            ZapolnitMyListView(GetDitectories);
        }

        private void MyCopy_Click(object sender, EventArgs e)
        {
            int x = 0;

            foreach (ListViewItem item in MyCompDirectBox.SelectedItems)
            {
                x = item.Index;
                
                MyCopyDirectString = MyTekushiyeNazvaniya[x].Substring(0, MyTekushiyeNazvaniya[x].Length -1);

                NameCopyFile = Path.GetFileName(MyCopyDirectString);
            }
        }

        private void MyInsert_Click(object sender, EventArgs e)
        {
            if ((MyCopyDirectString.Length != 0) &&(MyFullDirectPole.Text.Length != 0))
            {
                bool itshave = true;

                string[] Dop = MyTekushiyeNazvaniya;
                
                for(int w = 0; w<MyTekushiyeNazvaniya.Length; w++)
                {
                    Dop[w] = Path.GetFileName(MyTekushiyeNazvaniya[w].Substring(0, MyTekushiyeNazvaniya[w].Length -1));
                }

                if (Dop.Contains(Path.GetFileName(MyCopyDirectString)) == false)
                {
                    try
                    {
                        Thread xxx = new Thread(CopyWriter);
                        xxx.IsBackground = true;
                        xxx.Start();

                        PeredZapolnitMyListView();
                    }
                    catch
                    {

                    }
                }
                else
                {
                    int s4et = 1;

                    while (itshave == true)
                    {
                        if (s4et < 10000)
                        {
                            string Cont = Path.GetFileNameWithoutExtension(MyCopyDirectString) + "-copy (" + Convert.ToString(s4et) + ")" + Path.GetExtension(MyCopyDirectString);

                            if (Dop.Contains(Cont) == false)
                            {
                                NameCopyFile = Cont;
                                Thread xxx = new Thread(CopyWriter);
                                xxx.IsBackground = true;
                                xxx.Start();
                                itshave = false;

                                PeredZapolnitMyListView();
                            }
                            s4et++;
                        }
                        else
                        {
                            //>=10000 copies. Do you serious?
                            itshave = false;
                        }
                    }
                }
            }

        }

        public void CopyWriter()
        {
            try
            {
                File.Copy(MyCopyDirectString, MyFullDirectPole.Text + @"\" + NameCopyFile);
            }
            catch { }

            if(InvokeRequired)
            { Invoke(Obnovshik); }
            PeredZapolnitMyListView();
        }

        private void MyDelete_Click(object sender, EventArgs e)
        {
            int x = 0;

            string direct = "";

            foreach (ListViewItem item in MyCompDirectBox.SelectedItems)
            {
                x = item.Index;

                direct = MyTekushiyeNazvaniya[x];
            }

            if (direct.Substring(direct.Length - 1, 1) == "s")
            {
                File.Delete(direct.Substring(0, direct.Length - 1));
                MyCompDirectBox.Items[x].Remove();

                for (int w = x; w < MyTekushiyeNazvaniya.Length - 1; w++)
                {
                    MyTekushiyeNazvaniya[x] = MyTekushiyeNazvaniya[x + 1];
                }

                Array.Resize(ref MyTekushiyeNazvaniya, MyTekushiyeNazvaniya.Length - 1);
            }

            if (direct.Substring(direct.Length - 1, 1) == "d")
            {
                Directory.Delete(direct.Substring(0, direct.Length - 1), true);
                MyCompDirectBox.Items[x].Remove();

                for (int w = x; w < MyTekushiyeNazvaniya.Length - 1; w++)
                {
                    MyTekushiyeNazvaniya[x] = MyTekushiyeNazvaniya[x + 1];
                }

                Array.Resize(ref MyTekushiyeNazvaniya, MyTekushiyeNazvaniya.Length - 1);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Obnovshik();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            int x = 0;

            string PoslatThis = "";

            foreach (ListViewItem item in MyCompDirectBox.SelectedItems)
            {
                x = item.Index;

                PoslatThis = MyTekushiyeNazvaniya[x].Substring(0, MyTekushiyeNazvaniya[x].Length - 1);
            }

            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] message = encoding.GetBytes("#CT<" + OtherFullDirectPole.Text + ">");

            ServerForm.client.Send(message);

            ServerForm.NameOfSendAFile = PoslatThis;
            ServerForm.SAF();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            //find selected item
            int x = 0;

            string PoslatThis = "";

            foreach (ListViewItem item in OtherCompDirectBox.SelectedItems)
            {
                x = item.Index;

                PoslatThis = TekushiyeNazvaniya[x].Substring(0, TekushiyeNazvaniya[x].Length - 1);
            }
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] message = encoding.GetBytes("#GF<" + PoslatThis + ">");

            ServerForm.DirectTarget = MyFullDirectPole.Text;

            ServerForm.client.Send(message);
        }


        public void DownloadByTarget(byte[] content)
        {

        }

        private void DownloadBufferScB_ValueChanged(object sender, EventArgs e)
        {
            decimal ValueX = DownloadBufferScB.Value;

            if (ValueX < 1073741824)
            {             
                DownloadBufferTextBox.Text = Math.Round(ValueX / 1048576) + " mb";
            }
            else
            {
                DownloadBufferTextBox.Text = Math.Round((ValueX / 1073741824), 1) + " gb";
            }
        }

        private void UploadBufferScB_ValueChanged(object sender, EventArgs e)
        {
            decimal ValueX = UploadBufferScB.Value;

            if (ValueX < 1073741824)
            {
                ScrollBarUpload.Text = Math.Round(ValueX / 1048576) + " mb";
            }
            else
            {
                ScrollBarUpload.Text = Math.Round((ValueX / 1073741824), 1) + " gb";
            }
        }

        private void ChangeUploadBuffer_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] message = encoding.GetBytes("#CB<" + UploadBufferScB.Value + ">");

            ServerForm.client.Send(message);
        }

        public void UploadValueChanged()
        {
            if (ServerForm.ServerPeresylkaBufferSize < 1073741824)
            {
                UploadBufferTextBox.Text = Math.Round(Convert.ToDecimal(ServerForm.ServerPeresylkaBufferSize) / 1048576) + " mb";
            }
            else
            {
                UploadBufferTextBox.Text = Math.Round((Convert.ToDecimal(ServerForm.ServerPeresylkaBufferSize) / 1073741824), 1) + " gb";
            }

        }

    }
}
