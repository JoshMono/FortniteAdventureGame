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

        int playerX;
        int playerY;

        PictureBox picturePlayer

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
                picturePlayer = pictureBox1;


                playerX = picturePlayer.Location.X;
                playerY = picturePlayer.Location.Y;

            }
            else
            {
                try
                {
                    client = new TcpClient("127.0.0.1", 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                    picturePlayer = pictureBox2;
                    playerX = picturePlayer.Location.X;
                    playerY = picturePlayer.Location.Y;
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
            int xInt = picturePlayer.Location.X + 10;
            int yInt = picturePlayer.Location.Y + 10;
            byte x = Convert.ToByte(picturePlayer.Location.X);
            byte y = Convert.ToByte(picturePlayer.Location.Y);
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
                    Console.WriteLine("0");
                    int playerX = Convert.ToInt16(buffer[0]);
                    int playerY = Convert.ToInt16(buffer[1]);
                    picturePlayer.Location = new Point(playerX, playerY);
                }
                else
                {
                    Console.WriteLine("1");
                    int playerX = Convert.ToInt16(buffer[0] + buffer[4]);
                    int playerY = Convert.ToInt16(buffer[1] + buffer[3]);
                    picturePlayer.Location = new Point(playerX, playerY);
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
                playerY = playerY - 2;
                picturePlayer.Location = new Point(playerX, playerY);

                byte x1;
                byte x2;

                byte y1;
                byte y2;

                if (playerX > 255)
                {

                    int x1Int = picturePlayer.Location.X;
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
                if (picturePlayer.Location.Y > 255)
                {
                    int y1Int = picturePlayer.Location.Y;

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


            if (direction == "down")
            {
                Console.WriteLine("test123");
                playerY = playerY + 2;
                playerX = picturePlayer.Location.X;
                picturePlayer.Location = new Point(playerX, playerY);

                byte x1;
                byte x2;

                byte y1;
                byte y2;

                if (playerX > 255)
                {

                    int x1Int = picturePlayer.Location.X;
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
                if (picturePlayer.Location.Y > 255)
                {
                    int y1Int = picturePlayer.Location.Y;

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
                playerY = picturePlayer.Location.Y;
                playerX = playerX - 2;
                picturePlayer.Location = new Point(playerX, playerY);

                byte x1;
                byte x2;

                byte y1;
                byte y2;

                if (playerX > 255)
                {

                    int x1Int = picturePlayer.Location.X;
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
                if (picturePlayer.Location.Y > 255)
                {
                    int y1Int = picturePlayer.Location.Y;

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
                playerY = picturePlayer.Location.Y;
                picturePlayer.Location = new Point(playerX, playerY);

                byte x1;
                byte x2;

                byte y1;
                byte y2;

                if (playerX > 255)
                {

                    int x1Int = picturePlayer.Location.X;
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
                if (picturePlayer.Location.Y > 255)
                {
                    int y1Int = picturePlayer.Location.Y;

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
