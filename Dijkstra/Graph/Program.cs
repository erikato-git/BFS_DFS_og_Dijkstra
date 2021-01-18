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
            CreateGraph(ref myGraph);

        }

        private static void CreateGraph(ref MyGraph<string> myGraph)
        {
            //Adds nodes to our graph
            Node<String> n1 = myGraph.AddNode("Viborg", double.MaxValue);
            Node<String> n2 = myGraph.AddNode("Randers", double.MaxValue);
            Node<String> n3 = myGraph.AddNode("Herning", double.MaxValue);
            Node<String> n4 = myGraph.AddNode("Silkeborg", double.MaxValue);
            Node<String> n5 = myGraph.AddNode("Aarhus", double.MaxValue);
            Node<String> n6 = myGraph.AddNode("Horsens", double.MaxValue);
            Node<String> n7 = myGraph.AddNode("Vejle", double.MaxValue);
            Node<String> n8 = myGraph.AddNode("Holstebro", double.MaxValue);
            Node<String> n9 = myGraph.AddNode("Ringkøbing", double.MaxValue);
            Node<String> n10 = myGraph.AddNode("Billund", double.MaxValue);


            //Creates edges between the graphs nodes
            myGraph.AddEdge("Viborg", "Holstebro",51);
            myGraph.AddEdge("Viborg", "Herning",46.3);
            myGraph.AddEdge("Viborg", "Silkeborg",35.3);
            myGraph.AddEdge("Viborg", "Aarhus",64.2);
            myGraph.AddEdge("Viborg", "Randers",40.5);
            myGraph.AddEdge("Holstebro", "Viborg", 51);
            myGraph.AddEdge("Holstebro", "Herning",34.1);
            myGraph.AddEdge("Holstebro", "Ringkøbing",42.5);
            myGraph.AddEdge("Ringkøbing", "Holstebro", 42.5);
            myGraph.AddEdge("Ringkøbing", "Herning",48);
            myGraph.AddEdge("Ringkøbing", "Billund",76.8);
            myGraph.AddEdge("Herning", "Holstebro", 34.1);
            myGraph.AddEdge("Herning", "Ringkøbing", 48);
            myGraph.AddEdge("Herning", "Billund",59.8);
            myGraph.AddEdge("Herning", "Vejle",75.2);
            myGraph.AddEdge("Herning", "Viborg", 46.3);
            myGraph.AddEdge("Herning", "Silkeborg",43.6);
            myGraph.AddEdge("Herning", "Horsens",80.5);
            myGraph.AddEdge("Billund", "Ringkøbing", 76.8);
            myGraph.AddEdge("Billund", "Herning", 59.8);
            myGraph.AddEdge("Billund", "Vejle",31.1);
            myGraph.AddEdge("Vejle", "Billund", 31.1);
            myGraph.AddEdge("Vejle", "Herning", 75.2);
            myGraph.AddEdge("Vejle", "Horsens",29.7);
            myGraph.AddEdge("Horsens", "Vejle", 29.7);
            myGraph.AddEdge("Horsens", "Herning", 80.5);
            myGraph.AddEdge("Horsens", "Aarhus",48.7);
            myGraph.AddEdge("Horsens", "Silkeborg",44.4);
            myGraph.AddEdge("Aarhus", "Horsens", 48.7);
            myGraph.AddEdge("Aarhus", "Silkeborg",42.7);
            myGraph.AddEdge("Aarhus", "Randers",40);
            myGraph.AddEdge("Aarhus", "Viborg", 64.2);
            myGraph.AddEdge("Silkeborg", "Herning", 43.6);
            myGraph.AddEdge("Silkeborg", "Viborg", 35.3);
            myGraph.AddEdge("Silkeborg", "Randers",71);
            myGraph.AddEdge("Silkeborg", "Aarhus", 42.7);
            myGraph.AddEdge("Silkeborg", "Horsens", 44.4);
            myGraph.AddEdge("Randers", "Viborg", 40.5);
            myGraph.AddEdge("Randers", "Silkeborg", 71);
            myGraph.AddEdge("Randers", "Aarhus", 40);


            myGraph.dijkstra(n9, n5);     //Ringkøbing -> Aarhus

            myGraph.dijkstra(n1, n5);       // Viborg -> Aarhus

            myGraph.dijkstra(n7,n1);        // Vejle -> Viborg


            Console.ReadKey();
        }
    }
}
