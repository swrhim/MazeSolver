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
            Console.WriteLine("Enter the maze location. If location is unknown, hit 'Enter'");
            string location = Console.ReadLine();
            if (location ==  "")
                location = @"C:\Users\Daniel\Documents\Visual Studio 2010\Projects\MazeSolver\Maze\Maze.txt";
            
            string line;
            StreamReader file = new StreamReader(location);
            int size = CountLinesInFile(location);
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

            DrawMaze(maze);
            Console.ReadLine();

        }

        public static int CountLinesInFile(string fileLocation)
        {
            int count = 0;
            using (StreamReader r = new StreamReader(fileLocation))
            {
                string line;
                while((line=r.ReadLine()) != null)
                {
                    count++;
                }
                return count;
            }
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

            TraverseMaze(maze, starti, startj);
        }

        public static void TraverseMaze(char[][] maze, int i, int j)
        {
            if (maze[i][j] == 'F')
            {
                maze[i][j] = 'X';
                return;
            }
            
            if (maze[i][j] == '0')
            {
                maze[i][j] = 'X';
            }

            //up
            if (i < maze.Length)
            {
                if (maze[i + 1][j] == '0')
                    TraverseMaze(maze, i + 1, j);
            }
            //down
            if (i > 0)
            {
                if (maze[i - 1][j] == '0')
                    TraverseMaze(maze, i - 1, j);
            }

            //left
            if (j > 0)
            {
                if (maze[i][j - 1] == '0')
                    TraverseMaze(maze, i, j - 1);
            }

            //right
            if (j < maze[i].Length)
            {
                if (maze[i][j + 1] == '0')
                    TraverseMaze(maze, i, j + 1);
            }

            if (CheckFinish(maze, i, j))
                return;
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

        public static bool CheckFinish(char[][] maze, int i, int j)
        {
            //up
            if (i < maze.Length)
            {
                if (maze[i + 1][j] == 'F')
                {
                    maze[i + 1][j] = 'X';
                    return true;
                }
            }
            //down
            if (i > 0)
            {
                if (maze[i - 1][j] == 'F')
                {
                    maze[i - 1][j] = 'X';
                    return true;
                }
            }

            //left
            if (j > 0)
            {
                if (maze[i][j - 1] == 'F')
                {
                    maze[i][j - 1] = 'X';
                    return true;
                }
            }

            //right
            if (j < maze[i].Length)
            {
                if (maze[i][j + 1] == 'F')
                {
                    maze[i][j + 1] = 'X';
                    return true;
                }
            }

            return false;
        }
    }
}
