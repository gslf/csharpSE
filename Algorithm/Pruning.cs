using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Pruning {
    /// <summary>
    /// Backtracking with pruning is an efficient computational 
    /// technique commonly used in search and optimization problems 
    /// within software development. It incrementally builds solution 
    /// candidates and abandons them ("backtracks") when it becomes 
    /// clear they can't lead to a valid solution, thus "pruning" the 
    /// search tree to enhance efficiency. This approach is especially 
    /// effective in constraint satisfaction problems, such as puzzles 
    /// and combinatorial optimization, where it systematically 
    /// explores and eliminates non-viable paths, reducing the search 
    /// space.
    /// </summary>
    public class Pruning {
        
        private int[,] maze;
        private int rows, cols; // Labyrinth sizes
        private const int PATH = 1, WALL = 0, VISITED = 2, DESTINATION = 3;

        /// <summary>
        /// A constructor that initialize the maze.
        /// </summary>
        /// <param name="maze">The matrix representation of the maze to solve.</param>
        public Pruning(int[,] maze) {
            this.maze = maze;
            rows = maze.GetLength(0);
            cols = maze.GetLength(1);
        }

        /// <summary>
        /// Solves the maze from a given start point to an end point using backtracking with pruning. 
        /// Returns true if a path is found, otherwise false.
        /// </summary>
        /// <param name="startX">The X-coordinate of the starting point.</param>
        /// <param name="startY">The Y-coordinate of the starting point.</param>
        /// <param name="endX">The X-coordinate of the end point.</param>
        /// <param name="endY">The Y-coordinate of the end point.</param>
        /// <returns>Boolean indicating whether a path was found.</returns>
        public bool SolveMaze(int startX, int startY, int endX, int endY) {

            // Starting positiong validity Check
            if (!IsValid(startX, startY) || maze[startX, startY] == WALL) {
                return false;
            }

            // Destination check
            if (startX == endX && startY == endY) {
                maze[startX, startY] = DESTINATION;
                return true;
            }

            // Visited cell check 
            if (maze[startX, startY] == VISITED) {
                return false;
            }

            maze[startX, startY] = VISITED;

            // Recursive try moving in each direction: down,
            // right, up, left (clockwise).
            if (SolveMaze(startX + 1, startY, endX, endY) ||
                SolveMaze(startX, startY + 1, endX, endY) ||
                SolveMaze(startX - 1, startY, endX, endY) ||
                SolveMaze(startX, startY - 1, endX, endY)) {
                return true;
            }

            // If it's not possible to find a path, mark the
            // passage as unvisited (backtracking).
            maze[startX, startY] = PATH;
            return false;
        }

        /// <summary>
        /// Checks if the specified coordinates are within the bounds of the maze.
        /// </summary>
        /// <param name="x">The X-coordinate to check.</param>
        /// <param name="y">The Y-coordinate to check.</param>
        /// <returns>Boolean indicating whether the coordinates are valid within the maze.</returns>
        private bool IsValid(int x, int y) {
            return x >= 0 && y >= 0 && x < rows && y < cols;
        }
    }
}
