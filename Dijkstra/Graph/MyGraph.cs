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
        public Node<T> AddNode(T value, double initValue)
        {
            Node<T> n = new Node<T>(value, initValue);
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
            nodeSet.Find(x => x.Data.Equals(From)).AddEdge(nodeSet.Find(x => x.Data.Equals(To)),km); 
        }

        /// <summary>
        /// Creates an edge between two nodes
        /// </summary>
        /// <param name="From">First node</param>
        /// <param name="To">Second node</param>
        public void AddEdge(T From, T To, double km)
        {
            nodeSet.Find(x => x.Data.Equals(From)).AddEdge(nodeSet.Find(x => x.Data.Equals(To)),km);
            nodeSet.Find(x => x.Data.Equals(To)).AddEdge(nodeSet.Find(x => x.Data.Equals(From)),km);

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



        //find startknuden
        public void dijkstra(Node<T> From, Node<T> Destination)
        {
            Queue<Node<T>> traverseOrder = new Queue<Node<T>>();

            Queue<Node<T>> Q = new Queue<Node<T>>();
            HashSet<Node<T>> S = new HashSet<Node<T>>();
            Q.Enqueue(From);
            S.Add(From);
                
            From.Value = 0;
            From.Parent = From;

            while (Q.Count > 0)
            {
                Node<T> e = Q.Dequeue();    // det første element i Q tages ud
                traverseOrder.Enqueue(e);

                // Dijkstra

                foreach (Edge<T> edge in e.MyEdges)
                {

                    if (edge.To.Value > edge.Km + e.Value)      // sørger for at knuderne overskrives med den laveste værdi
                    {
                        edge.To.Value = edge.Km + e.Value;      // opdaterer knuderne med den sammenlagte vægt på edges
                        edge.To.Parent = e;                     // sætter parent for at udprinte stien senere
                    }


                    if (!S.Contains(edge.To))   // set'tet bruges til at der kun ligges én af hver knude i Q
                    {
                        Q.Enqueue(edge.To);
                        S.Add(edge.To);
                    }

                }

            }

            // Print stien ud

            var list = traverseOrder.ToList();  // Laver køen om til en liste for at finde destinationsknuden i traverseOrder
            Node<T> dest = list.Find(x => x.Data.Equals(Destination.Data));     // finder destinationsknuden
            List<Node<T>> path = new List<Node<T>>();
            Node<T> parent = dest.Parent;
            path.Add(parent);

            while (!parent.Data.Equals(From.Data))      // Lægger alle forældrene i en liste fra destinationsknuden
            {
                parent = parent.Parent;
                path.Add(parent);
            }

            path.Reverse(); // reverser den for at udskrive stien i den rigtige rækkefølge

            foreach(var i in path)
            {
                Console.Write(i.Data + "->");
            }
            Console.Write(dest+"\n");
        }

    }

}

