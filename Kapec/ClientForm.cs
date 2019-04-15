using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kapec
{
    public delegate void Thread4Listener();

    public partial class ClientForm : Form
    {
        bool PrinyatFile = false;
        bool FileStarted = false;

        string ReNameRash = "xxx.docx";

        string DirectTarget = @"D:\\PomoikaSiSharp\";

        byte[] b = new byte[0];

        string[] ujebilo = new string[0];

        decimal RazmerFaila = 0;

        public static int ClientPeresylkaBufferSize = 104857600;

        private NetworkStream Stream4StreamClient;
        private TcpClient StreamClienter1 = new TcpClient();

        private Thread4Listener T4L;
        private Threads1 _myThreads;

        private Thread kurwaldio2;

        private Thread kurwaldio3;

        public ClientForm()
        {
            InitializeComponent();
            ipText.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        }


        Socket Sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        Socket Sender2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        public void RunnerListen()
        {
            byte[] bytes = new byte[99999999];

            int bytesRec = Sender.Receive(bytes);

            infoPole.Items.Clear();

            for(int w = 0; w<bytesRec; w++)
            { infoPole.Items.Add(bytes[w]); }

            string KurwasAdd = String.Format(Encoding.UTF8.GetString(bytes, 0, bytesRec));

            string KurwasAdd2 = "";

            if ((KurwasAdd.Length > 2) && (KurwasAdd.Substring(0, 1) == "#"))
            {
                KurwasAdd2 = KurwasAdd.Substring(0, 3);

                switch (KurwasAdd2)
                {
                    case ("#MM"):
                        {
                            infoPole.Items.Add(KurwasAdd);
                            //Cursor.Position = new Point(Convert.ToInt32(Math.Round(SystemInformation.PrimaryMonitorSize.Width * Convert.ToDouble(KurwasAdd.Substring(2, KurwasAdd.LastIndexOf("|") - 2)))), Convert.ToInt32(Math.Round(SystemInformation.PrimaryMonitorSize.Height * Convert.ToDouble(KurwasAdd.Substring(KurwasAdd.LastIndexOf("|") + 1, KurwasAdd.LastIndexOf("]") - KurwasAdd.LastIndexOf("|") - 1)))));
                            break;
                        }
                    case ("#MC"):
                        {
                            infoPole.Items.Add(KurwasAdd);
                            //Cursor.Position = new Point(Convert.ToInt32(Math.Round(SystemInformation.PrimaryMonitorSize.Width * Convert.ToDouble(KurwasAdd.Substring(2, KurwasAdd.LastIndexOf("|") - 2)))), Convert.ToInt32(Math.Round(SystemInformation.PrimaryMonitorSize.Height * Convert.ToDouble(KurwasAdd.Substring(KurwasAdd.LastIndexOf("|") + 1, KurwasAdd.LastIndexOf("]") - KurwasAdd.LastIndexOf("|") - 1)))));
                            break;
                        }
                    case ("#GD"):
                        {

                            string[] GetDitectories = new string[1];

                            try
                            {
                                GetDitectories = Directory.GetDirectories(KurwasAdd.Substring(4, KurwasAdd.IndexOf(">") - 4));
                                for (int w = 0; w < GetDitectories.Length; w++)
                                {
                                    GetDitectories[w] = GetDitectories[w] + "d";
                                }
                                string[] GetFiles = Directory.GetFiles(KurwasAdd.Substring(4, KurwasAdd.IndexOf(">") - 4));
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

                            MemoryStream fs = new MemoryStream();
                            BinaryFormatter sf = new BinaryFormatter();
                            sf.Serialize(fs, GetDitectories);
                            byte[] PosrednikOfSerialize = new byte[fs.Length];
                            PosrednikOfSerialize = fs.ToArray();

                            byte[] msg = Encoding.UTF8.GetBytes("#GD<" + PosrednikOfSerialize.Length + ">");
                            Sender2.Send(msg);

                            Sender2.Send(PosrednikOfSerialize);

                            break;
                        }
                    case ("#SD"):
                        {
                            string[] StartDitectories = Environment.GetLogicalDrives();
                            string StringOfStartDirect = "";
                            foreach (string s in StartDitectories)
                            { StringOfStartDirect = StringOfStartDirect + s + "-"; }
                            StringOfStartDirect = StringOfStartDirect.Remove(StringOfStartDirect.Length - 1, 1);

                            byte[] msg = Encoding.UTF8.GetBytes("#SD" + StringOfStartDirect);

                            Sender.Send(msg);

                            break;
                        }
                    case ("#GF"):
                        {
                            string BATTHERT = KurwasAdd.Substring(4, KurwasAdd.IndexOf(">") - 4);

                            SendAFile(BATTHERT);

                            infoPole.Items.Add(BATTHERT + ", " + Path.GetFileName(BATTHERT));

                            break;
                        }
                    case ("#CB"):
                        {
                            ClientPeresylkaBufferSize = Convert.ToInt32(KurwasAdd.Substring(4, KurwasAdd.IndexOf(">") - 4));

                            byte[] msg = Encoding.UTF8.GetBytes("#BC<" + ClientPeresylkaBufferSize + ">");

                            Sender.Send(msg);
                            break;
                        }
                    case ("#CT"):
                        {
                            DirectTarget = KurwasAdd.Substring(4,KurwasAdd.Length - 5);

                            break;
                        }
                    case ("#DH"):
                        {
                            WebClient WC = new WebClient();
                            string HTMLCode = WC.DownloadString(KurwasAdd.Substring(4, KurwasAdd.IndexOf(">") - 4));

                            RTB2.Clear();

                            RTB2.AppendText(HTMLCode);

                            MemoryStream fs = new MemoryStream();
                            BinaryFormatter sf = new BinaryFormatter();
                            sf.Serialize(fs, HTMLCode);
                            byte[] PosrednikOfSerialize = new byte[fs.Length];
                            PosrednikOfSerialize = fs.ToArray();

                            byte[] msg = Encoding.UTF8.GetBytes("#DH[" + PosrednikOfSerialize.Length + "]");

                            Sender2.Send(msg);

                            Sender2.Send(PosrednikOfSerialize);

                            break;
                        }
                    default:
                        {
                            infoPole.Items.Add(KurwasAdd);
                            break;
                        }

                }
            }

            else
            {
                infoPole.Items.Add(KurwasAdd);
            }
        }
            

        public void RunListenFilesTV()
        {
            while (true)
            {
                if (PrinyatFile == false)
                {
                    byte[] bytes = new byte[999999999];

                    int bytesRec1 = Sender2.Receive(bytes);

                    string Adder = String.Format(Encoding.UTF8.GetString(bytes, 0, bytesRec1));

                    if ((Adder.Length > 2) && (Adder.Substring(0, 1) == "#"))
                    {
                        string Adder2 = Adder.Substring(0, 3);

                        switch (Adder2)
                        {
                            case ("#SF"):
                                {
                                    FileStarted = true;
                                    PrinyatFile = true;
                                    infoPole.Items.Add("Start translation");

                                    if (Adder.Substring(3, 1) == "[")
                                    {
                                        ReNameRash = Adder.Substring(4, Adder.IndexOf("|") - 4);

                                        RazmerFaila = Convert.ToDecimal(Adder.Substring(Adder.IndexOf("|") + 1, Adder.Length - Adder.IndexOf("|") - 2));

                                        infoPole.Items.Add(RazmerFaila);
                                    }
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    string pather = DirectTarget + @"\" + ReNameRash;

                    long TekushiyRazmer = 0;
                    try
                    {
                        TekushiyRazmer = new FileInfo(pather).Length;
                    }
                    catch
                    { }

                    if (TekushiyRazmer < RazmerFaila)
                    {
                        if (Sender2.Available != 0)
                        {
                            int bytesRec1 = 0;

                            byte[] bytes = new byte[90000000];

                            bytesRec1 = Sender2.Receive(bytes);

                            Array.Resize(ref bytes, bytesRec1);

                            FileStream FS2 = new FileStream(pather, FileMode.OpenOrCreate);

                            FS2.Seek(0, SeekOrigin.End);

                            FS2.Write(bytes, 0, bytes.Length);

                            FS2.Close();

                            infoPole.Items.Add(TekushiyRazmer + " " + RazmerFaila);
                        }
                    }

                    else
                    {
                        PrinyatFile = false;

                        infoPole.Items.Add("End translation");
                    }
                }
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if ((portText.Text != portText2.Text) && (portText.Text != AAAaKAk6OMBIT.Text) && (portText2.Text != AAAaKAk6OMBIT.Text) && (portText.Text.Length > 0) && (portText2.Text.Length > 0) && (AAAaKAk6OMBIT.Text.Length > 0))//StreamClienter2
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipText.Text), Convert.ToInt32(portText.Text));

                IPEndPoint ipStreamEndpoint = new IPEndPoint(IPAddress.Parse(ipText.Text), Convert.ToInt32(portText2.Text));

                IPEndPoint ipFilaAndTVEndpoint = new IPEndPoint(IPAddress.Parse(ipText.Text), Convert.ToInt32(AAAaKAk6OMBIT.Text));

                try
                {
                    // Соединяем сокет с удаленной точкой
                    Sender.Connect(ipEndPoint);

                    StreamClienter1.Connect(ipStreamEndpoint);

                    Sender2.Connect(ipFilaAndTVEndpoint);

                    //возня с тредом c чатом 

                    T4L = new Thread4Listener(RunnerListen);
                    _myThreads = new Threads1(T4L);
                    _myThreads.RunThreads();
                    Control.CheckForIllegalCrossThreadCalls = false;
                    //возня с тредом по стриму
                    kurwaldio2 = new Thread(StreamFromClient);

                    kurwaldio2.IsBackground = true;
                    kurwaldio2.Start();
                    //Возня с тредом с файлами

                    kurwaldio3 = new Thread(RunListenFilesTV);

                    kurwaldio3.IsBackground = true;
                    kurwaldio3.Start();
                }
                catch { infoPole.Items.Add("Connection failed"); }
            }
            else
            { infoPole.Items.Add("Please, write 2 differing ports"); }

        }

        public void StreamFromClient()
        {
			//тут начало стриминга

			while (true)
			{
				BinaryFormatter binFormatter = new BinaryFormatter();
				Stream4StreamClient = StreamClienter1.GetStream();
				binFormatter.Serialize(Stream4StreamClient, kek());
			}
		}

        private static Image kek()
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.CopyFromScreen(0, 0, 0, 0, new Size(bmp.Width, bmp.Height));
            return bmp;
        }


        private void SendButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                byte[] msg = Encoding.UTF8.GetBytes(RTB2.Text);

                Sender.Send(msg);
            }
            catch { infoPole.Items.Add("Messaging failed, check your connection status"); }
        }

        private void SendAFile(string XXXdirect)
        {
            //Достать размер файла
            decimal RazmerFaila = (new FileInfo(XXXdirect).Length);

            byte[] msg = Encoding.UTF8.GetBytes("#GF[" + Path.GetFileName(XXXdirect) + "|" + Convert.ToString(RazmerFaila) + "]");
            Sender2.Send(msg);

            //Распределить размер файла по пакетам для пересылки
            if (RazmerFaila > ClientPeresylkaBufferSize)
            {
                int[] Delitel = new int[0];
                //Есть ли "неровность" в делении файла
                if ((RazmerFaila % ClientPeresylkaBufferSize) == 0)
                {
                    Array.Resize(ref Delitel, Convert.ToInt32(RazmerFaila / Convert.ToDecimal(ClientPeresylkaBufferSize)));
                    for(int w = 0; w<Delitel.Length; w++)
                    {
                        Delitel[w] = ClientPeresylkaBufferSize;
                    }
                }
                else
                {
                    int KolVo = Convert.ToInt32(Math.Truncate(Convert.ToDouble(RazmerFaila / ClientPeresylkaBufferSize)));
                    Array.Resize(ref Delitel, KolVo + 1);
                    for(int w = 0; w<Delitel.Length -1; w++)
                    {
                        Delitel[w] = ClientPeresylkaBufferSize;
                    }

                    Delitel[Delitel.Length - 1] = Convert.ToInt32(Convert.ToDecimal(RazmerFaila) - (Convert.ToDecimal(ClientPeresylkaBufferSize) * Convert.ToDecimal(KolVo)));

                    infoPole.Items.Add(Convert.ToInt32(Convert.ToDecimal(RazmerFaila) - (Convert.ToDecimal(ClientPeresylkaBufferSize) * Convert.ToDecimal(KolVo))) + " <= THIS SHIT" + RazmerFaila + " " + ClientPeresylkaBufferSize);
                }
                FileStream FS = new FileStream(XXXdirect, FileMode.OpenOrCreate);
                FS.Seek(0, SeekOrigin.Begin);

                for (int w = 0; w < Delitel.Length; w++)
                {
                    infoPole.Items.Add(Delitel[w]);
                    //FileStream FS = new FileStream(XXXdirect, FileMode.OpenOrCreate);

                    byte[] a = new byte[Delitel[w]];

                    FS.Read(a, 0, Delitel[w]);

                    if (w != (Delitel.Length -1))
                    {
                        FS.Seek(Delitel[w], SeekOrigin.Current);
                    }

                    Sender2.Send(a);
                }
            }
            else
            {
                FileStream FS = new FileStream(XXXdirect, FileMode.OpenOrCreate);

                byte[] a = new byte[Convert.ToInt32(RazmerFaila)];

                FS.Seek(0, SeekOrigin.Begin);

                FS.Read(a, 0, Convert.ToInt32(RazmerFaila));

                Sender2.Send(a);
            }
        }
    }
}
