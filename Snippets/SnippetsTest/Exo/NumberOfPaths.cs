using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SnippetsTest.Exo
{
    /*
     * 2D array - starting a 0,0 going to i-1,j-1, only down and right
     * Can go only on case = 1
     * How many possible path?
     * 
     * 1 1 1 1
     * 1 1 1 1
     * 1 1 1 1 => 10 possible paths
     */
    

    [TestFixture]
    public class NumberOfPaths
    {
        [Test]
        public void Run()
        {
            var maze = new int[][] {
                new int[] { 1, 1, 1, 1 },
                new int[] { 1, 1, 0, 1 },
                new int[] { 1, 1, 1, 1 }};

            var nbOfPaths = GetNbOfPathsIter(maze, 3, 4);
        }

        // a = maze
        // M = nb rows
        // N = nb cols
        private static int GetNbOfPathsRecur(int[][] a, int M, int N)
        {
            return GetNbOfPathsRecurDo(a, M, N, 0, 0);
        }

        // a = maze
        // M = nb rows
        // N = nb cols
        private static int GetNbOfPathsIter(int[][] a, int M, int N)
        {
            if (a == null)
                return 0;

            var currentNode = new TreeNode(0, 0, null);
            var nbPaths = 0;

            do
            {
                var y = currentNode.Pos.Y;
                var x = currentNode.Pos.X;

                // Terminal condition
                if (y == 0 & x == 0 && !currentNode.CanGoDown() && !currentNode.CanGoRight())
                    break;

                // End of maze - backtracking
                if(y == M - 1 && x == N - 1)
                {
                    ++nbPaths;
                    currentNode = currentNode.Parent;
                    continue;
                }

                if (currentNode.CanGoDown() && y < M - 1 && a[y + 1][x] == 1)
                {
                    var newNode = new TreeNode(y + 1, x, currentNode);
                    currentNode.Down = newNode;

                    currentNode = newNode;
                    continue;
                }

                if (currentNode.CanGoRight() && x < N - 1 && a[y][x + 1] == 1)
                {
                    var newNode = new TreeNode(y, x + 1, currentNode);
                    currentNode.Right = newNode;

                    currentNode = newNode;
                    continue;
                }

                // Backtracking
                currentNode = currentNode.Parent;

            } while (true);

            return nbPaths;
        }

        struct Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        class TreeNode
        {
            public Point Pos { get; set; }

            public TreeNode Parent { get; set; }
            public TreeNode Down { get; set; }
            public TreeNode Right { get; set; }

            public TreeNode(int i, int j, TreeNode parent)
            {
                Pos = new Point(j, i);
                Parent = parent;
            }

            public bool CanGoDown()
            {
                return Down == null;
            }

            public bool CanGoRight()
            {
                return Right == null;
            }
        }

        private static int GetNbOfPathsRecurDo(int[][] a, int nbRows, int nbCols, int posY, int posX)
        {
            if (posY == nbRows - 1 && posX == nbCols - 1)
                return 1;

            int nbPathsDown = 0;
            int nbPathsRight = 0;

            if(posY < nbRows - 1 && a[posY + 1][posX] == 1)
                nbPathsDown = GetNbOfPathsRecurDo(a, nbRows, nbCols, posY + 1, posX);
            if (posX < nbCols - 1 && a[posY][posX + 1] == 1)
                nbPathsRight = GetNbOfPathsRecurDo(a, nbRows, nbCols, posY, posX + 1);

            return nbPathsDown + nbPathsRight;
        }
    }
}
