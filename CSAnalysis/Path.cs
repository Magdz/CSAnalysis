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
        public List<int> Nodes;
        public List<string> Values;

        public Path(List<int> Nodes, List<string> Values)
        {
            this.Nodes = Nodes;
            this.Values = Values;
        }
    }
}
