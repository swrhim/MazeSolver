using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MazeSolver
{
    class MazeSolver
    {
        static void Main(string[] args)
        {
            string line;
            StreamReader file = new StreamReader(@"C:\Users\Daniel\Documents\Visual Studio 2010\Projects\MazeSolver\Maze\Maze.txt");
            char[][] maze = new char[10][];
            int count = 0;
            while ((line = file.ReadLine()) != null)
            {
                maze[count] = line.ToCharArray();
                count++;
            }
            file.Close();

            Console.WriteLine("This is the maze:");
            DrawMaze(maze);

            Console.WriteLine("\n\n\nHit Enter to solve the maze");
            //pause
            Console.ReadLine();

            SolveMaze(maze);

        }

        public static void SolveMaze(char[][] maze)
        {
            int starti = 0;
            int startj = 0;

            for (int i = 0; i < maze.Length; i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    if (maze[i][j] == 'S')
                    {
                        maze[i][j] = 'X';
                        starti = i;
                        startj = j;
                        break;
                    }
                }
            }
        }

        public static void DrawMaze(char[][] maze)
        {
            for (int i = 0; i < maze.Length; i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    Console.Write(maze[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
