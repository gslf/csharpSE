using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.ShortestPath {
    /// <summary>
    /// The Dijkstra algorithm finds the shortest paths in a weighted graph, 
    /// using a dynamic adjacency list. It sets initial distances to infinity, 
    /// except for the source vertex set to zero. The algorithm iteratively 
    /// updates the shortest distances to unprocessed vertices. Its dynamic 
    /// design allows adding vertices and edges flexibly, and the GetDistances 
    /// method returns these shortest paths as an array.
    /// </summary>
    public class DijkstraShortestPath {
        private int _vertices;
        private List<List<KeyValuePair<int, int>>> _adjacencyList;
        private int[] _distances;

        /// <summary>
        /// The constructor initializes the graph with a given number of vertices.
        /// </summary>
        /// <param name="vertices">The number of vertices in the graph.</param>
        public DijkstraShortestPath(int vertices) {
            _vertices = vertices;
            _adjacencyList = new List<List<KeyValuePair<int, int>>>(vertices);
            _distances = new int[vertices];

            for (int i = 0; i < vertices; i++) {
                _adjacencyList.Add(new List<KeyValuePair<int, int>>());
                // Set the initial distance to int.MaxValue, indicating that the
                // initial distance from each node to the source is infinite.
                _distances[i] = int.MaxValue;
            }
        }

        /// <summary>
        /// Adds an edge to the graph between two specified vertices with a 
        /// given weight.
        /// </summary>
        /// <param name="u">The source vertex of the edge.</param>
        /// <param name="v">The destination vertex of the edge.</param>
        /// <param name="weight">The weight of the edge connecting the 
        /// vertices.</param>
        public void AddEdge(int u, int v, int weight) {
            _adjacencyList[u].Add(new KeyValuePair<int, int>(v, weight));
        }


        /// <summary>
        /// Executes the Dijkstra algorithm to find the shortest path from a 
        /// single source vertex to all other vertices in the graph.
        /// </summary>
        /// <param name="source">The index of the source vertex from which 
        /// to calculate shortest paths.</param>
        public void PathCalc(int source) {
            // Analyzed vertices
            bool[] shortestPathTreeSet = new bool[_vertices];

            _distances[source] = 0;

            // Iterate over all vertices
            for (int count = 0; count < _vertices - 1; count++) {
                int u = MinDistance(_distances, shortestPathTreeSet);

                // Mark the vertex as analyzed
                shortestPathTreeSet[u] = true;

                // Updates the distances of vertices adjacent to the
                // selected vertex if the distance through u is less
                // than the current distance.
                foreach (var next in _adjacencyList[u]) {
                    if (!shortestPathTreeSet[next.Key] && _distances[u] != int.MaxValue &&
                        _distances[u] + next.Value < _distances[next.Key]) {
                        _distances[next.Key] = _distances[u] + next.Value;
                    }
                }
            }
        }

        /// <summary>
        /// Finds the vertex with the minimum distance from the source 
        /// that has not been processed yet.
        /// </summary>
        /// <param name="distances">Array of distances from the source 
        /// to each vertex.</param>
        /// <param name="sptSet">Boolean array indicating whether a vertex 
        /// is included in the shortest path tree or the shortest distance 
        /// is finalized.</param>
        /// <returns>The index of the vertex with the minimum distance.</returns>
        private int MinDistance(int[] distances, bool[] sptSet) {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < _vertices; v++) {
                if (!sptSet[v] && distances[v] <= min) {
                    min = distances[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        /// <summary>
        /// Retrieves the shortest distances from the source vertex to all 
        /// other vertices in the graph.
        /// </summary>
        /// <returns>An array of distances from the source to each vertex 
        /// in the graph.</returns>
        public int[] GetDistances() {
            return _distances;
        }
    }
}
