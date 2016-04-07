using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAnalysis
{
    class Path
    {
        public ArrayList Nodes;
        public ArrayList Values;

        public Path(ArrayList Nodes, ArrayList Values)
        {
            this.Nodes = Nodes;
            this.Values = Values;
        }
    }
}
