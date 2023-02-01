using System;
using System.Collections.Generic;
using System.Text;

namespace NaukaV2
{
    public class Program
    {
        static string[,] grid =
        {
            {"1","2","3"},
            {"4","5","6"},
            {"7","8","9" }
        };
        public static bool isDraw;

        public static void Main(string[] args)
        {
            Board();
            Player1Turn();
        }

        public static void Board()
        {
            Console.WriteLine(" _________________");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", grid[0, 0], grid[0, 1], grid[0, 2]);
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", grid[1, 0], grid[1, 1], grid[1, 2]);
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", grid[2, 0], grid[2, 1], grid[2, 2]);
            Console.WriteLine("|_____|_____|_____|");
        }

        public static void Player1Turn()
        {
            Console.WriteLine("\n Player X Turn \n");
            string playerNum = Console.ReadLine();
            string playerSymbol = "X";

            bool found = false;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (playerNum == grid[i, j])
                    {
                        grid[i, j] = playerSymbol;
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine(" \n field is taken");
                Player1Turn();
            }
            else
            {
                Board();
                CheckWinner(grid);
                if (isDraw == true)
                {
                    Console.WriteLine("\n ITS A DRAW");
                    return;
                }
                if (CheckWinner(grid) == true)
                {
                    Console.WriteLine("\n THE WINNER IS O");
                    return;
                }
                Player2Turn();
            }
        }

        public static void Player2Turn()
        {
            Console.WriteLine("\n Player O Turn");
            string playerNum = Console.ReadLine();
            string playerSymbol = "O";

            bool found = false;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (playerNum == grid[i, j])
                    {
                        grid[i, j] = playerSymbol;
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine(" \n field is taken");
                Player2Turn();
            }
            else
            {
                Board();
                    
                if(isDraw == true)
                {
                    Console.WriteLine("\n ITS A DRAW");
                    return;
                }
                else if (CheckWinner(grid) == true)
                {
                    Console.WriteLine("\n THE WINNER IS O");
                    return;
                }
                Player1Turn();
            }
        }

        public static bool CheckWinner(string[,] board)
        {
             
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] || board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
            {

                return true;
            }
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[0, i] == board[2, i] || board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
                {
                    return true;
                }
            }
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if(grid[i,j] == "X" || grid[i, j] == "O")
                    {
                        continue;
                    }
                    return false;                  
                }
            }            
            isDraw = true;
            return true;
        }
    }
}
