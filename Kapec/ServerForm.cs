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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZeroMQ;
using System.Messaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kapec
{
    public delegate void Thread4ServerListener();

    public delegate void SendAFiler();
    
    public partial class ServerForm : Form
    {
        private NetworkStream Stream4StreamServer;
        private TcpListener StreamListenerServer;
        private TcpClient StreamClientServer;
        
        private Thread4ServerListener T4SL;

        public static SendAFiler SAF;

        private Threads2 _myThreads1;

        public static int ServerPeresylkaBufferSize = 104857600;

        private Thread KThread_1;
        private Thread KThread_2;

        //Массивы для текста и файлов

        byte[] b = new byte[0];

        string PriemType = "";
                

        bool PrinyatFile = false;
        bool FileStarted = false;

        string ReNameRash = "xxx.docx";

        public static string NameOfSendAFile = "";

        decimal RazmerFaila = 0;    

        public static string DirectTarget = @"D:\\PomoikaSiSharp\\";

        public ServerForm()
        {
            InitializeComponent();

            SAF = new SendAFiler(StartToSendAFile);

            string IP = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            ipText.Text = (IP);
            
        }
        //Обьявление сокетов
        public static Socket client;

        public static Socket client2;   

        public void ReceiveCallback(IAsyncResult AsyncCall)
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                Byte[] message = encoding.GetBytes("You connected to server");

                client = (Socket)AsyncCall.AsyncState;
                client = client.EndAccept(AsyncCall);

                client.Send(message);

               T4SL = new Thread4ServerListener(RunListenPort);
               _myThreads1 = new Threads2(T4SL);
               _myThreads1.RunServerThreads();
               Control.CheckForIllegalCrossThreadCalls = false;
        }

        public void ReceiveCallback4Stream(IAsyncResult AsyncCall)
        {
            StreamClientServer = new TcpClient();
            StreamClientServer = StreamListenerServer.EndAcceptTcpClient(AsyncCall);

			KThread_1 = new Thread(CalculateThread);
			KThread_1.IsBackground = true;
			KThread_1.Start();
        }

        public void ReciveCallBack4TVandF(IAsyncResult AsyncCall)
        {
            client2 = (Socket)AsyncCall.AsyncState;
            client2 = client2.EndAccept(AsyncCall);


			KThread_2 = new Thread(RunListenFiles);
			KThread_2.IsBackground = true;
			KThread_2.Start();
        }



        private void CreateButton_Click_1(object sender, EventArgs e)
        {
            if ((portText.Text != StreamPortText.Text) && (portText.Text != FandTVPortText.Text) && (StreamPortText.Text != FandTVPortText.Text) && (portText.Text.Length > 0) && (StreamPortText.Text.Length > 0) && (FandTVPortText.Text.Length > 0))
            {
                try
                {
                    Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    
                    IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Parse(ipText.Text), Convert.ToInt32(portText.Text));

                    listenSocket.Bind(ipEndpoint);

                    listenSocket.Listen(10);

                    listenSocket.BeginAccept(new AsyncCallback(ReceiveCallback), listenSocket);
                    
                    Socket listenSocket2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    IPEndPoint ipEndpoint2 = new IPEndPoint(IPAddress.Parse(ipText.Text), Convert.ToInt32(FandTVPortText.Text));

                    listenSocket2.Bind(ipEndpoint2);

                    listenSocket2.Listen(10);

                    listenSocket2.BeginAccept(new AsyncCallback(ReciveCallBack4TVandF), listenSocket2);

                    infoPole.Items.Add("In process...");


                    Control.CheckForIllegalCrossThreadCalls = false;
					
                    StreamListenerServer = new TcpListener(new IPEndPoint(IPAddress.Parse(ipText.Text), Convert.ToInt32(StreamPortText.Text)));
                    StreamListenerServer.AllowNatTraversal(true);
                    StreamListenerServer.Start();
                    StreamListenerServer.BeginAcceptTcpClient(ReceiveCallback4Stream, StreamListenerServer);
                }
                catch
                { infoPole.Items.Add("Port creating failed"); }
            }
            else
            { infoPole.Items.Add("Please, write 2 differing ports"); }
        }       

        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] message = Encoding.UTF8.GetBytes(textBox1.Text);

                client.Send(message);
            }
            catch
            { infoPole.Items.Add("Messaging failed, check your connection status"); }
        }

        public void CalculateThread()
        {
            while (true)
              {
                if (StreamChB.Checked)
                {
                    BinaryFormatter binFormatter = new BinaryFormatter();
                    Stream4StreamServer = StreamClientServer.GetStream();
                    PB1.Image = (Image)binFormatter.Deserialize(Stream4StreamServer);
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        //чатик
        public void RunListenPort()
        {
            byte[] bytes = new byte[99999999];

            int bytesRec1 = client.Receive(bytes);

            string Adder = String.Format(Encoding.UTF8.GetString(bytes, 0, bytesRec1));

            if ((Adder.Length >2) && (Adder.Substring(0,1) == "#"))
            {
                string SubAdder = Adder.Substring(0, 3);

                switch(SubAdder)
                {
                    case ("#SD"):
                        {
                            string[] SubSubAdder = Adder.Substring(3, Adder.Length - 3).Split(Convert.ToChar("-"));

                            FileConnectForm.tet(SubSubAdder);
                            break;
                        }
                    case ("#BC"):
                        {
                            ServerPeresylkaBufferSize = Convert.ToInt32(Adder.Substring(4,Adder.Length - 5));
                            FileConnectForm.UBC();
                            break;
                        }
                    default:
                        {
                            infoPole.Items.Add(Adder);
                            break;
                        }

                }
            }
            else
            {
                infoPole.Items.Add(Adder);
            }
        }       

        public void RunListenFiles()
        {
            while (true)
            {
                if (PrinyatFile == false)
                {
                    byte[] bytes = new byte[999999999];

                    int bytesRec1 = client2.Receive(bytes);

                    string Adder = String.Format(Encoding.UTF8.GetString(bytes, 0, bytesRec1));

                    if ((Adder.Length > 2) && (Adder.Substring(0, 1) == "#"))
                    {
                        string Adder2 = Adder.Substring(0, 3);

                        switch (Adder2)
                        {
                            case ("#GF"):
                                {
                                    FileStarted = true;
                                    PrinyatFile = true;
                                    PriemType = "File";
                                    infoPole.Items.Add("Start translation");

                                    if (Adder.Substring(3, 1) == "[")
                                    {
                                        ReNameRash = Adder.Substring(4, Adder.IndexOf("|") - 4);

                                        RazmerFaila = Convert.ToDecimal(Adder.Substring(Adder.IndexOf("|") + 1, Adder.Length - Adder.IndexOf("|") - 2));

                                        infoPole.Items.Add(RazmerFaila);
                                    }
                                    break;
                                }

                            case ("#GD"):
                                {
                                    RazmerFaila = Convert.ToInt32(Adder.Substring(4, Adder.Length - 5));
                                    infoPole.Items.Add(RazmerFaila);

                                    FileStarted = true;
                                    PrinyatFile = true;
                                    PriemType = "SpisokOfDirect";
                                    infoPole.Items.Add("Start translation");
                                    break;
                                }

                            case ("#DH"):
                                {
                                    RazmerFaila = Convert.ToInt32(Adder.Substring(4, Adder.Length - 5));
                                    infoPole.Items.Add(RazmerFaila);

                                    FileStarted = true;
                                    PrinyatFile = true;
                                    PriemType = "HTTPCode";
                                    infoPole.Items.Add("Start translation");
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    if (PriemType == "File")
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
                            if (client2.Available != 0)
                            {
                                int bytesRec1 = 0;
                            
                                byte[] bytes = new byte[90000000];

                                bytesRec1 = client2.Receive(bytes);

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

                    if (PriemType == "SpisokOfDirect")
                    {
                        if ((b.Length) != RazmerFaila)
                        {
                            int bytesRec1 = 0;

                            byte[] bytes = new byte[99999];

                            bytesRec1 = client2.Receive(bytes);

                            infoPole.Items.Add(bytesRec1);

                            Array.Resize(ref bytes, bytesRec1);
                            Array.Resize(ref b, b.Length + bytesRec1);
                            bytes.CopyTo(b, b.Length - bytesRec1);

                        }
                        else
                        {
                            //переслать с помощью делегата в treeView
                            FileConnectForm.GetTreeView1(b);

                            Array.Resize(ref b, 0);
                            PrinyatFile = false;
                            infoPole.Items.Add("End translation");
                        }
                    }

                    if(PriemType == "HTTPCode")
                    {

                        if ((b.Length) != RazmerFaila)
                        {
                            int bytesRec1 = 0;

                            byte[] bytes = new byte[99999];

                            bytesRec1 = client2.Receive(bytes);

                            infoPole.Items.Add(bytesRec1);

                            Array.Resize(ref bytes, bytesRec1);
                            Array.Resize(ref b, b.Length + bytesRec1);
                            bytes.CopyTo(b, b.Length - bytesRec1);

                        }
                        else
                        {
                            // ProxyBrowser.DHTML(Adder.Substring(4, Adder.IndexOf(">") - 4));
                            // break;
                            //переслать с помощью делегата в treeView
                            MemoryStream memStream = new MemoryStream();
                            BinaryFormatter binForm = new BinaryFormatter();
                            memStream.Write(b, 0, b.Length);
                            memStream.Seek(0, SeekOrigin.Begin);
                            string obj = (string)binForm.Deserialize(memStream);

                            ProxyBrowser.DHTML(obj);
                            Array.Resize(ref b, 0);
                            PrinyatFile = false;
                            infoPole.Items.Add("End translation");
                        }
                    }
                }
            }

        }


        private void PB1_MouseMove_1(object sender, MouseEventArgs e)
        {
                if (CheckCursorGo.Checked == true)
                {
                    textBox2.Text = Convert.ToString(e.Location.X); textBox5.Text = Convert.ToString(Math.Round((Convert.ToDouble(e.Location.X) / Convert.ToDouble(PB1.Size.Width)), 2));
                    textBox3.Text = Convert.ToString(e.Location.Y); textBox4.Text = Convert.ToString(Math.Round((Convert.ToDouble(e.Location.Y) / Convert.ToDouble(PB1.Size.Height)), 2));

                    string SendMouseMover = String.Format("#MM<" + textBox5.Text + "|" + textBox4.Text + ">");

                    ASCIIEncoding encoding = new ASCIIEncoding();
                    Byte[] message = encoding.GetBytes(SendMouseMover);

                    client.Send(message);
                    Thread.Sleep(50);
                }
        }

        private void FilesConnectButton_Click(object sender, EventArgs e)
        {
            FileConnectForm FileConnectForm1 = new FileConnectForm();
            FileConnectForm1.Show();            
        }

        private void PB1_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckCursorClick.Checked)
            {
                string SendMouseMover = String.Format("#MC<" + Convert.ToString(Math.Round((Convert.ToDouble(e.Location.X) / Convert.ToDouble(PB1.Size.Width)), 2)) + "|" + Convert.ToString(Math.Round((Convert.ToDouble(e.Location.Y) / Convert.ToDouble(PB1.Size.Height)), 2)) + ">");

                ASCIIEncoding encoding = new ASCIIEncoding();
                Byte[] message = encoding.GetBytes(SendMouseMover);

                client.Send(message);
            }
        }


        public void StartToSendAFile()
        {
            Thread STSAF = new Thread(SendAFile);
            STSAF.Start();
        }


        public void SendAFile()
        {
            //Достать размер файла
            decimal RazmerFaila = Convert.ToDecimal(new FileInfo(NameOfSendAFile).Length);

            byte[] msg = Encoding.UTF8.GetBytes("#SF[" + Path.GetFileName(NameOfSendAFile) + "|" + Convert.ToString(RazmerFaila) + "]");
            client2.Send(msg);

            //Распределить размер файла по пакетам для пересылки
            if (RazmerFaila > ServerPeresylkaBufferSize)
            {
                int[] Delitel = new int[0];
                //Есть ли "неровность" в делении файла
                if ((RazmerFaila % ServerPeresylkaBufferSize) == 0)
                {
                    Array.Resize(ref Delitel, Convert.ToInt32(RazmerFaila / ServerPeresylkaBufferSize));
                    for (int w = 0; w < Delitel.Length; w++)
                    {
                        Delitel[w] = ServerPeresylkaBufferSize;
                    }
                }
                else
                {
                    int KolVo = Convert.ToInt32(Math.Truncate(Convert.ToDouble(RazmerFaila / ServerPeresylkaBufferSize)));
                    Array.Resize(ref Delitel, KolVo + 1);
                    for (int w = 0; w < Delitel.Length - 1; w++)
                    {
                        Delitel[w] = ServerPeresylkaBufferSize;
                    }

                    Delitel[Delitel.Length - 1] = Convert.ToInt32(Convert.ToDecimal(RazmerFaila) - (Convert.ToDecimal(ServerPeresylkaBufferSize) * Convert.ToDecimal(KolVo)));
                }
                FileStream FS1 = new FileStream(NameOfSendAFile, FileMode.OpenOrCreate);

                for (int w = 0; w < Delitel.Length; w++)
                {
                    byte[] a = new byte[Delitel[w]];

                    FS1.Read(a, 0, Delitel[w]);

                    if (w != (Delitel.Length - 1))
                    {
                        FS1.Seek(Delitel[w], SeekOrigin.Current);
                    }

                    client2.Send(a);
                }
            }
            else
            {
                FileStream FS = new FileStream(NameOfSendAFile, FileMode.OpenOrCreate);

                byte[] a = new byte[Convert.ToInt32(RazmerFaila)];

                FS.Seek(0, SeekOrigin.Begin);

                FS.Read(a, 0, Convert.ToInt32(RazmerFaila));

                client2.Send(a);
            }

        }

        private void WindowProxyOpen_Click(object sender, EventArgs e)
        {
            ProxyBrowser xxx = new ProxyBrowser();
            xxx.Show();
        }
	}    
}
                    