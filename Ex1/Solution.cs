using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public class Solution<T>
    {
        public List<State<T>> nodeList{get; set;} // List of all the nodes in the shortest path.

        // Ctor.
        public Solution()
        {
            this.nodeList = new List<State<T>>();
        }
        
    }
}
