using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class MyGraph<T>
    {   
        List<Node<T>> nodeSet = new List<Node<T>>(); //Contains all nodes in the graph
        
        public List<Node<T>> NodeSet
        {
            get { return nodeSet; }
            set { nodeSet = value; }
        }

        /// <summary>
        /// Adds a node to the graph
        /// </summary>
        /// <param name="value">The value to be stored in the node</param>
        /// <returns>Created node</returns>
        public Node<T> AddNode(T value)
        {
            Node<T> n = new Node<T>(value);
            nodeSet.Add(n);
            return n;
        }

        /// <summary>
        /// Adds a directed edge between two nodes in the graph
        /// </summary>
        /// <param name="From">Start node</param>
        /// <param name="To">End node</param>
        public void AddDirectedEdge(T From, T To, double km)
        {
            nodeSet.Find(x => x.Data.Equals(From)).AddEdge(nodeSet.Find(x => x.Data.Equals(To))); 
        }

        /// <summary>
        /// Creates an edge between two nodes
        /// </summary>
        /// <param name="From">First node</param>
        /// <param name="To">Second node</param>
        public void AddEdge(T From, T To)
        {
            nodeSet.Find(x => x.Data.Equals(From)).AddEdge(nodeSet.Find(x => x.Data.Equals(To)));
            nodeSet.Find(x => x.Data.Equals(To)).AddEdge(nodeSet.Find(x => x.Data.Equals(From)));

        }

        // Udskrive alle node med edges
        public void printGraph()
        {
            foreach (var node in nodeSet)
            {
                Console.Write(node.ToString());
                Console.Write(", [");
                foreach(var edge in node.MyEdges)
                {
                    Console.Write(edge + ", ");
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }


        public void BFS(Node<T> From, Node<T> Destination)
        {
//            Queue<Node<T>> Q = new Queue<Node<T>>();
            Stack<Node<T>> Q = new Stack<Node<T>>();
            HashSet<Node<T>> S = new HashSet<Node<T>>();
//            Q.Enqueue(From);
            Q.Push(From);
            S.Add(From);
            Node<T> e = null;

            From.Parent = From;

            while (Q.Count > 0)
            {
//                e = Q.Dequeue();    // det første element i Q tages ud
                e = Q.Pop();

                if (e.Data.Equals(Destination.Data))
                {
                    PrintPath(e,From,Destination);
                    break;
                }

                foreach (Edge<T> edge in e.MyEdges)
                {
                    if (!S.Contains(edge.To))   // set'tet bruges til at der kun ligges én af hver knude i Q
                    {
                        edge.To.Parent = edge.From;
//                        Q.Enqueue(edge.To);
                        Q.Push(edge.To);
                        S.Add(edge.To);
                    }
                }

            }

        }

        private void PrintPath(Node<T> e, Node<T> From, Node<T> Destination)
        {
            Node<T> parent = e.Parent;
            List<Node<T>> parents = new List<Node<T>>();

            while (!parent.Data.Equals(From.Data))
            {
                parents.Add(parent);
                parent = parent.Parent;
            }

            parents.Reverse();

            Console.Write(From.Data + "->");
            parents.ForEach(pa => Console.Write(pa.Data + "->"));
            Console.Write(Destination.Data);
        }
    }

}


//Idaho -> South Dakota, base case, sti-udprintning
/*
if (CurrentNode.Data.Equals(To.Data))    //Base case: udprinter stien der består af alle parent-knuder fra start- til slutmålet
{
    List<Node<T>> printPath = new List<Node<T>>();
    path.Reverse();                  //reverse path for at tjekke at knuden der kommer efter er forælder til den sidste knude
    Node<T> LastNode = CurrentNode;

    //Tjekker at p er forælder til den sidste knude og lægges i en ny liste, således at løse ender sorteres fra BFS 
    foreach (var p in path)
    {
        if (p.Equals(LastNode.Parent))
        {
            printPath.Add(p);
        }
        LastNode = p;
    }

    printPath.Reverse();        //Den nye liste reverses igen for at udskrive stien rigtigt

    foreach (var p in printPath)
    {
        Console.Write(p + "->");
    }
    Console.Write(CurrentNode);

    return null;
}
*/