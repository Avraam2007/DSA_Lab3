using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Lab3 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("················································································\r");
            Console.WriteLine(":                                                                              :\r");
            Console.WriteLine(":      __         ______      ____                   __ __         ____        :\r");
            Console.WriteLine(":     /\\ \\       /\\  _  \\    /\\  _`\\                _\\ \\\\ \\___    / __ \\       :\r");
            Console.WriteLine(":     \\ \\ \\      \\ \\ \\L\\ \\   \\ \\ \\L\\ \\             /\\__   _  _\\  /\\_\\L\\ \\      :\r");
            Console.WriteLine(":      \\ \\ \\  __  \\ \\  __ \\   \\ \\  _ <'            \\/ _L\\ \\\\ \\L  \\/_/_\\_<      :\r");
            Console.WriteLine(":       \\ \\ \\L\\ \\  \\ \\ \\/\\ \\   \\ \\ \\L\\ \\             /\\_   _  _\\  /\\ \\L\\ \\     :\r");
            Console.WriteLine(":        \\ \\____/   \\ \\_\\ \\_\\   \\ \\____/             \\/_/\\_\\\\_\\/  \\ \\____/     :\r");
            Console.WriteLine(":         \\/___/     \\/_/\\/_/    \\/___/                 \\/_//_/    \\/___/      :\r");
            Console.WriteLine(":                                                                              :\r");
            Console.WriteLine("················································································");
            List<List<int>> adjGraph = new List<List<int>> {
                new List<int>() { 1, 2 },
                new List<int>() { 0, 3, 4 },
                new List<int>() { 0, 5, 6 },
                new List<int>() { 1 },
                new List<int>() { 1 },
                new List<int>() { 2 },
                new List<int>() { 2 }
            };

            Search search = new Search(adjGraph);
            List<List<int>> components = search.GetComponents();

            search.DFS_iter(0);

            Console.WriteLine("\n!!!Connected Components in a Graph!!!\n");
            foreach (var component in components) {
                Console.WriteLine($"Graph {components.IndexOf(component)+1}");
                foreach (var node in component) {
                    Console.Write(node + " ");
                }
                Console.WriteLine();
            }

            search.BFS(0);

            Console.WriteLine($"\n!!!Shortest path between nodes!!!\n");

            Console.Write("Enter start of the path: ");
            int from = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter start of the path: ");
            int to = Convert.ToInt32(Console.ReadLine());

            List<int> shortestPath = search.GetShortestPath(from, to);
            Console.WriteLine($"\n!Shortest path from {from} to {to}!\n");
            foreach (var step in shortestPath) {
                Console.Write(step + " ");
            }

            Console.WriteLine("\n\nPress Enter to exit...\n");
            Console.ReadLine();
        }
    }
}
