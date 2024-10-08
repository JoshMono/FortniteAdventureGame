﻿using System;
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
        string ipAdress;

        bool up = false;
        bool right = false;
        bool down = false;
        bool left = false;

        bool sendSocket = false;

        int playerXHost;
        int playerYHost;
        int playerX;
        int playerY;

        PictureBox picturePlayerH;
        PictureBox picturePlayerC;

        byte[] x = { 0 };

        byte[] num;

        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server;
        private TcpClient client;

        public TestGame(bool host, string ip)
        {
            InitializeComponent();

            ipAdress = ip;
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

                picturePlayerC = pictureBox2;
                playerX = picturePlayerC.Location.X;
                playerY = picturePlayerC.Location.Y;

            }
            else
            {
                try
                {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                    picturePlayerC = pictureBox2;
                    playerX = picturePlayerC.Location.X;
                    playerY = picturePlayerC.Location.Y;

                    picturePlayerH = pictureBox1;
                    playerXHost = picturePlayerH.Location.X;
                    playerYHost = picturePlayerH.Location.Y;
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
            byte[] buffer = new byte[5];
            sock.Receive(buffer);
            if (buffer[0] != Convert.ToByte(0))
            {

                if (buffer[3] == Convert.ToByte(0) && buffer[4] == Convert.ToByte(0))
                {
                    if (Host)
                    {
                        int playerX = Convert.ToInt16(buffer[0]);
                        int playerY = Convert.ToInt16(buffer[1]);
                        picturePlayerC.Location = new Point(playerX, playerY);

                    }
                    else
                    {
                        int playerXHost = Convert.ToInt16(buffer[0]);
                        int playerYHost = Convert.ToInt16(buffer[1]);
                        picturePlayerH.Location = new Point(playerXHost, playerYHost);
                    }
                }
                else
                {
                    if (Host)
                    {
                        int playerX = Convert.ToInt16(buffer[0] + buffer[4]);
                        int playerY = Convert.ToInt16(buffer[1] + buffer[3]);
                        picturePlayerC.Location = new Point(playerX, playerY);

                    }
                    else
                    {
                        int playerXHost = Convert.ToInt16(buffer[0] + buffer[4]);
                        int playerYHost = Convert.ToInt16(buffer[1] + buffer[3]);
                        picturePlayerH.Location = new Point(playerXHost, playerYHost);
                    }

                }

                label1.Text = buffer[2].ToString();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void TestGame_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == (char)Keys.W)
            {
                up = true;
            }
            if (e.KeyValue == (char)Keys.S)
            {
                down = true;
            }
            if (e.KeyValue == (char)Keys.A)
            {
                left = true;
            }
            if (e.KeyValue == (char)Keys.D)
            {
                right = true;
            }
        }

        private void mainGameTimer(object sender, EventArgs e)
        {

            if (Host)
            {
                playerYHost = picturePlayerH.Location.Y;
                playerXHost = picturePlayerH.Location.X;
            }
            else
            {
                playerY = picturePlayerC.Location.Y;
                playerX = picturePlayerC.Location.X;
            }

            if (playerX > 500)
            {
                playerX = playerX - 4;
            }

            if (playerY > 500)
            {
                playerY = playerY - 4;
            }

            if (playerXHost > 500)
            {
                playerXHost = playerXHost - 4;
            }

            if (playerYHost > 500)
            {
                playerYHost = playerYHost - 4;
            }

            //
            if (up)
            {

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
                        x1 = Convert.ToByte(playerXHost);
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
                    sendSocket = true;
                    Console.WriteLine(num);

                }
                //
                else
                {
                    playerY = playerY - 2;
                    picturePlayerC.Location = new Point(playerX, playerY);

                    byte x1;
                    byte x2;

                    byte y1;
                    byte y2;

                    if (playerX > 255)
                    {

                        int x1Int = picturePlayerC.Location.X;
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
                    if (picturePlayerC.Location.Y > 255)
                    {
                        int y1Int = picturePlayerC.Location.Y;

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
                    sendSocket = true;
                    Console.WriteLine(num);

                }
            }

            //
            if (down)
            {
                if (Host)
                {
                    playerYHost = playerYHost + 2;
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
                        x1 = Convert.ToByte(playerXHost);
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
                    sendSocket = true;
                    Console.WriteLine(num);

                }
                else
                {
                    playerY = playerY + 2;
                    picturePlayerC.Location = new Point(playerX, playerY);

                    byte x1;
                    byte x2;

                    byte y1;
                    byte y2;

                    if (playerX > 255)
                    {

                        int x1Int = picturePlayerC.Location.X;
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
                    if (picturePlayerC.Location.Y > 255)
                    {
                        int y1Int = picturePlayerC.Location.Y;

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
                    sendSocket = true;
                    Console.WriteLine(num);

                }
            }

            //
            if (left)
            {
                if (Host)
                {
                    playerXHost = playerXHost - 2;
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
                        x1 = Convert.ToByte(playerXHost);
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
                    sendSocket = true;
                    Console.WriteLine(num);

                }
                else
                {
                    playerX = playerX - 2;
                    picturePlayerC.Location = new Point(playerX, playerY);

                    byte x1;
                    byte x2;

                    byte y1;
                    byte y2;

                    if (playerX > 255)
                    {

                        int x1Int = picturePlayerC.Location.X;
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
                    if (picturePlayerC.Location.Y > 255)
                    {
                        int y1Int = picturePlayerC.Location.Y;

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
                    sendSocket = true;
                    Console.WriteLine(num);

                }
            }
            //

            if (right)
            {
                if (Host)
                {
                    playerXHost = playerXHost + 2;
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
                        x1 = Convert.ToByte(playerXHost);
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
                    sendSocket = true;
                    Console.WriteLine(num);

                }
                else
                {
                    playerX = playerX + 2;
                    picturePlayerC.Location = new Point(playerX, playerY);

                    byte x1;
                    byte x2;

                    byte y1;
                    byte y2;

                    if (playerX > 255)
                    {

                        int x1Int = picturePlayerC.Location.X;
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
                    if (picturePlayerC.Location.Y > 255)
                    {
                        int y1Int = picturePlayerC.Location.Y;

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

                    sendSocket = true;
                    Console.WriteLine(num);

                }

            }

            if (!sendSocket)
            {
                sock.Send(x);
            }
            else if (sendSocket) 
            {
                sock.Send(num);
                sendSocket = false;
            }
            ReceiveMove();

        }
        private void TestGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.W)
            {
                up = false;
            }
            if (e.KeyValue == (char)Keys.S)
            {
                down = false;
            }
            if (e.KeyValue == (char)Keys.D)
            {
                right = false;
            }
            if (e.KeyValue == (char)Keys.A)
            {
                left = false;
            }
        }
    }
}
