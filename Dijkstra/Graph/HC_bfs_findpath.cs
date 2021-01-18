using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instance of our graph
            MyGraph<string> myGraph = new MyGraph<string>();

            //Create the graph
            Node<String> start, target;
            CreateGraph(ref myGraph, out start, out target);
            Console.WriteLine(GetPath(myGraph, start, target));
        }

        private static string GetPath(MyGraph<string> graph, Node<String> start, Node<String> target)
        {
            Dictionary<Node<String>, Node<String>> predecessor = new Dictionary<Node<string>, Node<string>>();
            if (!Bfs(graph, start, target, predecessor))
            {
                return "No path available";
            }

            Node<String> currentNode = target;
            int distance = 0;
            string path = currentNode.Data + "\n";
            while (predecessor[currentNode] != null)
            {
                currentNode = predecessor[currentNode];
                path += currentNode.Data + "\n";
                distance ++;
            }
            path += "\nDistance: " + distance;
            return path;
        }

        private static bool Bfs(MyGraph<string> graph, Node<String> start, Node<String> target,
            Dictionary<Node<String>, Node<String>> predecessor)
        {
            if (start == target) { return true; }

            Queue<Node<String>> queue = new Queue<Node<String>>();

            predecessor.Add(start, null);
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                Node<String> currentNode = queue.Dequeue();

                foreach (Edge<String> edge in currentNode.MyEdges)
                {
                    Node<String> node = edge.To;
                        if (!predecessor.ContainsKey(node))
                        {
                            predecessor.Add(node, currentNode);
                            queue.Enqueue(node);
                            if (node == target)
                            {
                                return true;
                            }
                        }
                    }
                }
            return false;
        }


        private static void CreateGraph(ref MyGraph<string> myGraph, out Node<String> n3, out Node<String> n7)
        {
            //Adds nodes to our graph
            Node<String> n1 = myGraph.AddNode("OREGON");
            Node<String> n2 = myGraph.AddNode("CALIFORNIA");
            n3 = myGraph.AddNode("IDAHO");
            Node<String> n4 = myGraph.AddNode("UTAH");
            Node<String> n5 = myGraph.AddNode("NEW MEXICO");
            Node<String> n6 = myGraph.AddNode("KANSAS");
            n7 = myGraph.AddNode("SOUTH DAKOTA");
            Node<String> n8 = myGraph.AddNode("NORTH DAKOTA");
            Node<String> n9 = myGraph.AddNode("IOWA");
            Node<String> n10 = myGraph.AddNode("TENNESSEE");
            Node<String> n11 = myGraph.AddNode("NEW YORK");
            Node<String> n12 = myGraph.AddNode("FLORIDA");
            Node<String> n13 = myGraph.AddNode("TEXAS");

            //Creates edges between the graphs nodes
            myGraph.AddEdge("OREGON", "CALIFORNIA");
            myGraph.AddEdge("CALIFORNIA", "UTAH");
            myGraph.AddEdge("UTAH", "IDAHO");
            myGraph.AddEdge("UTAH", "NEW MEXICO");
            myGraph.AddEdge("NEW MEXICO", "KANSAS");
            myGraph.AddEdge("NEW MEXICO", "TEXAS");
            myGraph.AddEdge("TEXAS", "TENNESSEE");
            myGraph.AddEdge("TEXAS", "FLORIDA");
            myGraph.AddEdge("TEXAS", "KANSAS");
            myGraph.AddEdge("KANSAS", "SOUTH DAKOTA");
            myGraph.AddEdge("SOUTH DAKOTA", "NORTH DAKOTA");
            myGraph.AddEdge("NORTH DAKOTA", "IOWA");
            myGraph.AddEdge("IOWA", "TENNESSEE");
            myGraph.AddEdge("TENNESSEE", "FLORIDA");
            myGraph.AddEdge("TENNESSEE", "NEW YORK");
        }

    }
}
