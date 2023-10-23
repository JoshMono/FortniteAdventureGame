using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureGame
{
    public partial class TestGame : Form
    {
        bool Host;
        string direction;

        int playerXHost;
        int playerYHost;
        int playerX;
        int playerY;

        PictureBox picturePlayerH;
        PictureBox picturePlayerC;

        byte[] x = { 0 };

        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;

        public TestGame(bool host)
        {
            InitializeComponent();


            Host = host;
            CheckForIllegalCrossThreadCalls = false;

            if (Host)
            {
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket();
                picturePlayerH = pictureBox1;


                playerXHost = picturePlayerH.Location.X;
                playerYHost = picturePlayerH.Location.Y;

            }
            else
            {
                try
                {
                    client = new TcpClient("127.0.0.1", 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                    picturePlayerC = pictureBox2;
                    playerX = picturePlayerC.Location.X;
                    playerY = picturePlayerC.Location.Y;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }

            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            int xInt = picturePlayerH.Location.X + 10;
            int yInt = picturePlayerH.Location.Y + 10;
            byte x = Convert.ToByte(picturePlayerH.Location.X);
            byte y = Convert.ToByte(picturePlayerH.Location.Y);
            byte[] num = { x, y, 10 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();

        }

        private void ReceiveMove()
        {
            Console.WriteLine("penis");
            byte[] buffer = new byte[5];
            Console.WriteLine("penis");
            sock.Receive(buffer);
            Console.WriteLine("penis");
            if (buffer[0] != Convert.ToByte(0))
            {

                if (buffer[3] == Convert.ToByte(0) && buffer[4] == Convert.ToByte(0))
                {
                    if (Host == false) 
                    { 
                        Console.WriteLine("0");
                        int playerXHost = Convert.ToInt16(buffer[0]);
                        int playerYHost = Convert.ToInt16(buffer[1]);
                        picturePlayerH.Location = new Point(playerXHost, playerYHost);
                    }
                    else
                    {
                        int playerX = Convert.ToInt16(buffer[0]);
                        int playerY = Convert.ToInt16(buffer[1]);
                        picturePlayerC.Location = new Point(playerX, playerY);
                    }
                }
                else
                {
                    if (Host)
                    {
                        int playerXHost = Convert.ToInt16(buffer[0] + buffer[4]);
                        int playerYHost = Convert.ToInt16(buffer[1] + buffer[3]);
                        picturePlayerC.Location = new Point(playerXHost, playerYHost);

                    }
                    else
                    {
                        int playerX = Convert.ToInt16(buffer[0] + buffer[4]);
                        int playerY = Convert.ToInt16(buffer[1] + buffer[3]);
                        picturePlayerH.Location = new Point(playerX, playerY);
                    }
                    Console.WriteLine("1");
              
                }

                label1.Text = buffer[2].ToString();
            }
            else
            {
                Console.WriteLine("no Recive");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void TestGame_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == (char)Keys.W)
            {
                direction = "up";
            }
            if (e.KeyValue == (char)Keys.S)
            {
                direction = "down";
            }
            if (e.KeyValue == (char)Keys.A)
            {
                direction = "left";
            }
            if (e.KeyValue == (char)Keys.D)
            {
                direction = "right";
            }
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            Console.WriteLine("test");
            if (direction == "up")
            {
                Console.WriteLine("test123");
                if (Host)
                {
                    playerYHost = playerYHost - 2;
                    picturePlayerH.Location = new Point(playerXHost, playerYHost);

                    byte x1;
                    byte x2;

                    byte y1;
                    byte y2;

                    if (playerXHost > 255)
                    {

                        int x1Int = picturePlayerH.Location.X;
                        int x2Int = x1Int - 256;
                        x1Int = 255;

                        x1 = Convert.ToByte(x1Int);
                        x2 = Convert.ToByte(x2Int);



                    }
                    else
                    {
                        x1 = Convert.ToByte(playerX);
                        x2 = 0;
                    }
                    if (picturePlayerH.Location.Y > 255)
                    {
                        int y1Int = picturePlayerH.Location.Y;

                        int y2Int = y1Int - 256;
                        y1Int = 255;

                        y1 = Convert.ToByte(y1Int);
                        y2 = Convert.ToByte(y2Int);
                    }
                    else
                    {
                        y1 = Convert.ToByte(playerYHost);
                        y2 = 0;
                    }
                    byte[] num = { x1, y1, 10, y2, x2 };

                    sock.Send(num);
                }
                //
                else
                {
                    playerY = playerY - 2;
                    picturePlayerH.Location = new Point(playerX, playerY);

                    byte x1;
                    byte x2;

                    byte y1;
                    byte y2;

                    if (playerXHost > 255)
                    {

                        int x1Int = picturePlayerH.Location.X;
                        int x2Int = x1Int - 256;
                        x1Int = 255;

                        x1 = Convert.ToByte(x1Int);
                        x2 = Convert.ToByte(x2Int);



                    }
                    else
                    {
                        x1 = Convert.ToByte(playerX);
                        x2 = 0;
                    }
                    if (picturePlayerH.Location.Y > 255)
                    {
                        int y1Int = picturePlayerH.Location.Y;

                        int y2Int = y1Int - 256;
                        y1Int = 255;

                        y1 = Convert.ToByte(y1Int);
                        y2 = Convert.ToByte(y2Int);
                    }
                    else
                    {
                        y1 = Convert.ToByte(playerY);
                        y2 = 0;
                    }
                    byte[] num = { x1, y1, 10, y2, x2 };

                    sock.Send(num);

                }


                }


            if (direction == "down")
            {
                Console.WriteLine("test123");
                playerY = playerY + 2;
                playerX = picturePlayerH.Location.X;
                picturePlayerH.Location = new Point(playerX, playerY);

                byte x1;
                byte x2;

                byte y1;
                byte y2;

                if (playerX > 255)
                {

                    int x1Int = picturePlayerH.Location.X;
                    int x2Int = x1Int - 256;
                    x1Int = 255;

                    x1 = Convert.ToByte(x1Int);
                    x2 = Convert.ToByte(x2Int);



                }
                else
                {
                    x1 = Convert.ToByte(playerX);
                    x2 = 0;
                }
                if (picturePlayerH.Location.Y > 255)
                {
                    int y1Int = picturePlayerH.Location.Y;

                    int y2Int = y1Int - 256;
                    y1Int = 255;

                    y1 = Convert.ToByte(y1Int);
                    y2 = Convert.ToByte(y2Int);
                }
                else
                {
                    y1 = Convert.ToByte(playerY);
                    y2 = 0;
                }
                byte[] num = { x1, y1, 10, y2, x2 };

                sock.Send(num);

            }

            if (direction == "left")
            {
                Console.WriteLine("test123");
                playerY = picturePlayerH.Location.Y;
                playerX = playerX - 2;
                picturePlayerH.Location = new Point(playerX, playerY);

                byte x1;
                byte x2;

                byte y1;
                byte y2;

                if (playerX > 255)
                {

                    int x1Int = picturePlayerH.Location.X;
                    int x2Int = x1Int - 256;
                    x1Int = 255;

                    x1 = Convert.ToByte(x1Int);
                    x2 = Convert.ToByte(x2Int);



                }
                else
                {
                    x1 = Convert.ToByte(playerX);
                    x2 = 0;
                }
                if (picturePlayerH.Location.Y > 255)
                {
                    int y1Int = picturePlayerH.Location.Y;

                    int y2Int = y1Int - 256;
                    y1Int = 255;

                    y1 = Convert.ToByte(y1Int);
                    y2 = Convert.ToByte(y2Int);
                }
                else
                {
                    y1 = Convert.ToByte(playerY);
                    y2 = 0;
                }
                byte[] num = { x1, y1, 10, y2, x2 };

                sock.Send(num);

            }
            if (direction == "right")
            {
                Console.WriteLine("test123");
                playerX = playerX + 2;
                playerY = picturePlayerH.Location.Y;
                picturePlayerH.Location = new Point(playerX, playerY);

                byte x1;
                byte x2;

                byte y1;
                byte y2;

                if (playerX > 255)
                {

                    int x1Int = picturePlayerH.Location.X;
                    int x2Int = x1Int - 256;
                    x1Int = 255;

                    x1 = Convert.ToByte(x1Int);
                    x2 = Convert.ToByte(x2Int);



                }
                else
                {
                    x1 = Convert.ToByte(playerX);
                    x2 = 0;
                }
                if (picturePlayerH.Location.Y > 255)
                {
                    int y1Int = picturePlayerH.Location.Y;

                    int y2Int = y1Int - 256;
                    y1Int = 255;

                    y1 = Convert.ToByte(y1Int);
                    y2 = Convert.ToByte(y2Int);
                }
                else
                {
                    y1 = Convert.ToByte(playerY);
                    y2 = 0;
                }
                byte[] num = { x1, y1, 10, y2, x2 };

                sock.Send(num);

            }
            if (direction == null)
            {
                sock.Send(x);
            }
            ReceiveMove();
        }

        private void TestGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.W)
            {
                direction = null;
            }
            if (e.KeyValue == (char)Keys.S)
            {
                direction = null;
            }
        }
    }
}
