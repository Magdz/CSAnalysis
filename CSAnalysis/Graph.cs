using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ArrayList Paths;

        static bool[] visited;
        static ArrayList PathGain;
        static ArrayList PathNodes;

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

        public void Analyze()
        {
            visited = new bool[Nodes];
            Paths = new ArrayList();
            PathNodes = new ArrayList();
            PathGain = new ArrayList();
            BackTracking(0, Nodes - 1);
        }

        private void BackTracking(int start, int end)
        {
            if(start == end)
            {
                Paths.Add(new Path(PathNodes, PathGain));
                return;
            }
            visited[start] = true;
            PathNodes.Add(start);
            for (int i = 0; i < Nodes; ++i)
            {
                if (!visited[i] && theGraph[start, i] != null)
                {
                    PathGain.Add(theGraph[start, i]);
                    BackTracking(i, end);
                    PathGain.Remove(theGraph[start, i]);
                }
            }
            PathNodes.Remove(start);
            visited[start] = false;
        }

        public void Debuging()
        {
            for (int i = 0; i < Nodes; ++i)
            {
                for (int j = 0; j < Nodes; ++j)
                {
                    Debug.Write(theGraph[i,j]);
                }
                Debug.WriteLine("");
            }
        }
    }
}
