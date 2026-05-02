using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA_Lab3 {
    public class Search {
        private readonly List<List<int>> Graph;
        private List<bool> visited;

        public Search(List<List<int>> s1) {
            this.Graph = s1;
        }

        public void DFS_iter(int s) {
            Console.WriteLine("\n!!!DFS!!!\n");
            if (s >= Graph.Count || s < 0) {
                return;
            }
            Stack<int> S = new Stack<int>();
            this.visited = new List<bool>();
            visited.AddRange(Enumerable.Repeat(false, Graph.Count));
            S.Push(s);
            while (S.Count != 0) {
                var v = S.Pop();
                if (!visited[v]) {
                    visited[v] = true;
                    Console.WriteLine($"Peak {v}");
                    foreach (var x in Graph[v]) {
                        if (!visited[x]) {
                            S.Push(x);
                        }
                    }
                }
            }
            Console.WriteLine("\nEnd!");
        }

        private void DFS(List<bool> visited, int s, List<int> res) {
            visited[s] = true;
            res.Add(s);

            foreach (int i in Graph[s]) {
                if (!visited[i]) {
                    DFS(visited, i, res);
                }
            }
        }

        public List<List<int>> GetComponents() {
            int V = Graph.Count;
            this.visited = new List<bool>();
            this.visited.AddRange(Enumerable.Repeat(false, V));
            List<List<int>> res = new List<List<int>>();

            for (int i = 0; i < V; i++) {
                if (!visited[i]) {
                    List<int> component = new List<int>();
                    DFS(this.visited, i, component);
                    res.Add(component);
                }
            }
            return res;
        }

        public void BFS(int s) {
            Console.WriteLine("\n!!!BFS!!!\n");
            if (s >= Graph.Count || s < 0) {
                return;
            }
            Queue<int> Q = new Queue<int>();
            this.visited = new List<bool>();
            visited.AddRange(Enumerable.Repeat(false, Graph.Count));
            visited[s] = true;
            Q.Enqueue(s);
            while (Q.Count != 0) { 
                var v = Q.Dequeue();
                Console.WriteLine($"Peak {v}");
                foreach (var x in Graph[v]) {
                    if (!visited[x]) {
                        visited[x] = true;
                        Q.Enqueue(x);
                    }
                }
            }
            Console.WriteLine("\nEnd!");
        }

        public List<int> GetShortestPath(int start, int end) {
            if (start >= Graph.Count || start < 0 || end >= Graph.Count || end < 0) {
                Console.WriteLine("Невірні початкова або кінцева вершини.");
                return null;
            }

            Queue<int> Q = new Queue<int>();
            this.visited = new List<bool>();
            this.visited.AddRange(Enumerable.Repeat(false, Graph.Count));

            int[] parent = new int[Graph.Count];
            for (int i = 0; i < parent.Length; i++) {
                parent[i] = -1;
            }

            visited[start] = true;
            Q.Enqueue(start);

            bool isFound = false;

            while (Q.Count != 0) {
                var v = Q.Dequeue();

                if (v == end) {
                    isFound = true;
                    break;
                }

                foreach (var item in Graph[v]) {
                    if (!visited[item]) {
                        visited[item] = true;
                        parent[item] = v;
                        Q.Enqueue(item);
                    }
                }
            }

            List<int> path = new List<int>();
            if (isFound) {
                int current = end;
                while (current != -1) {
                    path.Add(current);
                    current = parent[current];
                }
                path.Reverse();
            }
            else {
                Console.WriteLine("Path isn't found");
            }

            return path;
        }
    }
}
