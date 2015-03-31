﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ComputationalCluster.Shared.Utilities;
using ComputationalCluster.Shared.Messages.SolveRequestNamespace;
using ComputationalCluster.Shared.Messages.DivideProblemNamespace;
using ComputationalCluster.Shared.Messages.RegisterNamespace;
using System.Threading;
using ComputationalCluster.Shared.Messages.StatusNamespace;

namespace ComputationalCluster.Nodes
{
    public sealed class Client : Node
    {
        public Client()
        {
            nodeType = NodeType.Client;
        }

        public void startInstance(Int32 Port, String HostName, Int32 Timeout) {


            //Timeout = _timeout;
            //Port = _port;
            //HostName = _HostName;
            HostName = "192.168.143.130";
            Port = 13000;

            Console.WriteLine("Client Started");
            while (Port == 0)
            {
                Console.WriteLine(" Parameters Syntax: [-address [IPv4 address or IPv6 address or host name]] [-port[port number]]");
                Console.Write("> ");


                String parameters;
                parameters = Console.ReadLine();
                parameters = parameters.Replace(" ", string.Empty);
                Shared.Connection.ConnectionService.CheckInputSyntax(parameters, Port, HostName);
            }

           

            String message = "";
            Register registerRequest = new Register();
            message = registerRequest.SerializeToXML();

            Shared.Connection.ConnectionService.ConnectAndSendMessage(Port, HostName, message);

            Status statusRequest = new Status();
            message = statusRequest.SerializeToXML();

            while(true)
            {
                Thread.Sleep(Timeout);
                try {
                    Shared.Connection.ConnectionService.ConnectAndSendMessage(Port, HostName, message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }                
            }


            //Shared.Utilities.Utilities.waitUntilUserClose();
        }

    }

}
