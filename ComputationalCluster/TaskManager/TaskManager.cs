﻿using ComputationalCluster.Shared.Messages.StatusNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ComputationalCluster.Shared.Utilities;
using System.Threading;
using ComputationalCluster.Shared.Messages.SolveRequestNamespace;
using ComputationalCluster.Shared.Messages.RegisterNamespace;



namespace ComputationalCluster.Nodes
{
    public sealed class TaskManager : Node
    {
        public TaskManager()
        {
            nodeType = NodeType.TaskManager;
        }


        public void startInstance(Int32 _port, String _HostName, Int32 _timeout)
        {
                 
            Timeout = _timeout;
            Port = _port;
            HostName = _HostName;           
            

            Console.WriteLine("Task Manager Started");
            String message = "";
            
            //for (int i = 0; i < 1; i++)
            //{
            //    Status _status = new Status();
            //    message = _status.SerializeToXML();

            //    Shared.Connection.ConnectionService.ConnectAndSendMessage(port, HostName, message);
            //}

            Register registerRequest = new Register();
            message = registerRequest.SerializeToXML();
            try
            {
                Shared.Connection.ConnectionService.ConnectAndSendMessage(Port, HostName, message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Status statusRequest = new Status();
            message = statusRequest.SerializeToXML();

            while (true)
            {
                Thread.Sleep(Timeout);
                try
                {
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
