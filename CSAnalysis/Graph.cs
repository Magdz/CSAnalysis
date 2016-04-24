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

        public List<Path> Paths;
        public List<Path> Loops;
        public List<List<int>> NonTouching;

        private static bool[] visited;
        private static List<string> PathGain;
        private static List<int> PathNodes;
        private static bool startLoop;

        private enum Track
        {
            Path, Loop
        }

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
            Paths = new List<Path>();
            Loops = new List<Path>();
            PathNodes = new List<int>();
            PathGain = new List<string>();
            BackTracking(0, Nodes - 1, Track.Path);
            for(int i = 0; i< Nodes; ++i)
            {
                startLoop = true;
                BackTracking(i, i, Track.Loop);
                visited[i] = true;
            }
            NonTouching = new List<List<int>>();
            NonTouchingLoops();
        }

        private void BackTracking(int start, int end, Track track)
        {
            if(start == end && !startLoop)
            {
                if (PathGain.Count == 0) return;
                Path currentPath = new Path(new List<int>(PathNodes), new List<string>(PathGain));
                if (track == Track.Path) Paths.Add(currentPath);
                else if (track == Track.Loop) Loops.Add(currentPath);
                return;
            }
            visited[start] = true;
            if (startLoop)
            {
                visited[start] = false;
                startLoop = false;
            }
            PathNodes.Add(start);
            for (int i = 0; i < Nodes; ++i)
            {
                if (!visited[i] && theGraph[start, i] != null)
                {
                    PathGain.Add(theGraph[start, i]);
                    BackTracking(i, end, track);
                    PathGain.Remove(theGraph[start, i]);
                }
            }
            PathNodes.Remove(start);
            visited[start] = false;
        }

        private void NonTouchingLoops()
        {
            for (int i = 0; i < (Loops.Count + 1) / 2; ++i) 
            {
                NonTouching.Add(new List<int>());
                for (int j = i; j < Loops.Count; ++j) 
                {
                    if (!TouchDetector(Loops[i], Loops[j])) NonTouching[i].Add(j);
                }
            }
        }

        private bool TouchDetector(Path Path1, Path Path2)
        {
            foreach (int node1 in Path1.Nodes)
            {
                foreach (int node2 in Path2.Nodes)
                {
                    if (node1 == node2) return true;
                }
            }
            return false;
        }

        public void Debugging()
        {
            //for (int i = 0; i < Nodes; ++i)
            //{
            //    for (int j = 0; j < Nodes; ++j)
            //    {
            //        Debug.Write(theGraph[i,j]);
            //    }
            //    Debug.WriteLine("");
            //}
            Debug.WriteLine("Non Touching List:");
            foreach(List<int> List in NonTouching)
            {
                foreach(int node in List)
                {
                    Debug.Write(node + ",");
                }
                Debug.WriteLine("");
            }
        }
    }
}
