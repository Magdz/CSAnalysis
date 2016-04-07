using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAnalysis
{
    class Graph
    {
        private int Nodes;
        private int Edges;
        private string[,] theGraph;

        public Graph(int Nodes, int Edges)
        {
            this.Nodes = Nodes;
            this.Edges = Edges;
            theGraph = new string[Nodes, Nodes];
        }

        public void AddEdge(int from, int to, string value)
        {
            theGraph[from, to] = value;
        }
    }
}
