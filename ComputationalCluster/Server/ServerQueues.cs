﻿using ComputationalCluster.Misc;
using ComputationalCluster.Shared.Messages.SolutionsNamespace;
using ComputationalCluster.Shared.Messages.SolvePartialProblemsNamespace;
using ComputationalCluster.Shared.Messages.SolveRequestNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationalCluster.Nodes
{
    public sealed class ServerQueues
    {
        public ServerQueues()
        {
            this.SolveRequests = new Queue<SolveRequest>();
            this.Solutions = new Queue<Solutions>();
            this.ProblemsToSolve = new Queue<SolvePartialProblems>();
            this.FinalSolutions = new Queue<Solutions>();
        }

        public Queue<SolveRequest> SolveRequests { get; set; }

        /*
         * Solutions message is used for sending info about ongoing computations, partial and final solutions from CN, 
         * to TM and to CC and to relay information for synchronizing info with Backup CS. In addition to sending task 
         * and solution data it also gives information about the time it took to compute the solution and whether 
         * computations were stopped due to timeout.
         */
        public Queue<Solutions> Solutions { get; set; }
        public Queue<Solutions> FinalSolutions { get; set; }
        public Queue<SolvePartialProblems> ProblemsToSolve { get; set; }
    }
}
