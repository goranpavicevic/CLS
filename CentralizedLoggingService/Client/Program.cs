﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        public static IServices proxy;
        
        static void Main(string[] args)
        {
            bool isConnected = false;
            do
            {
                Console.WriteLine("Input your port");
                string port = Console.ReadLine();

                try
                {
                    ConnectToDBM(port);
                    Console.WriteLine(proxy.ViewTree());
                    isConnected = true;
                }
                catch
                {
                    Console.WriteLine("You entered wrong port");
                    continue;
                }
            } while (!isConnected);
            

            do
            {
                int x = 0;
                Console.WriteLine("Choose:");
                Console.WriteLine("1.Create folder");
                Console.WriteLine("2.Delete folder");
                Console.WriteLine("3.Create File");
                Console.WriteLine("4.Delete File");
                Console.WriteLine("5.View File");

                x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Input folder you want to create");
                        string folderCreate = Console.ReadLine();
                        proxy.CreateNewFolder(folderCreate);
                        break;

                    case 2:
                        Console.WriteLine("Input folder you want to delete");
                        string folderDelete = Console.ReadLine();
                        proxy.DeleteFolder(folderDelete);
                        break;

                    case 3:
                        Console.WriteLine("Input file you want to create");
                        string fileCreate = Console.ReadLine();
                        proxy.CreateNewFile(fileCreate);
                        break;

                    case 4:
                        Console.WriteLine("Input file you want to delete");
                        string fileDelete = Console.ReadLine();
                        proxy.DeleteFolder(fileDelete);            
                        break;

                    case 5:
                        proxy.ViewTree();
                        break;
                }

            } while (true);

        }
        public static void ConnectToDBM(string port)
        {
            var binding = new NetTcpBinding();
            ChannelFactory<IServices> factory = new
           ChannelFactory<IServices>(binding, new
           EndpointAddress("net.tcp://localhost:"+ port +"/DBM"));
            proxy = factory.CreateChannel();
        }
    }
}
