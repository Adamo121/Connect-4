using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME44
{
    class Program
    {
        static string[,] Start()
        {
            Console.WriteLine("Connect 4\t");
            string[,] p = new string[7, 6];  
            for (int a = 0; a < 7; a++)
            {
                for (int b = 0; b < 6; b++)
                    p[a, b] = " ";
            }
            return p;
        }

        static string ChoiceXorO()
        {
            string startingP = "";
            string play = "";
            Console.WriteLine("Choose \"X\" or \"O\"");
            play = Console.ReadLine();
            play = play.ToUpper();

            while (play != "x" && play != "X" && play != "o" && play != "O")
            {
                Console.WriteLine("Wrong input!");
                Console.WriteLine("Choose \"X\" or \"O\"");
                play = Console.ReadLine();
                play = play.ToUpper();
            }

            Random rnd = new Random();
            int number = rnd.Next(2);

            if (number == 0)
            {
                Console.WriteLine("Player \'X\' STARTS!");
                startingP = "X";
            }
            else
            {
                Console.WriteLine("Player \'O\' STARTS!");
                startingP = "O";
            }

            return startingP;
        }
        static void DrawBoard(string[,]p)
        {
            Console.WriteLine("  _____________________________");
            Console.WriteLine("F | {0} | {1} | {2} | {3} | {4} | {5} | {6} |", p[0, 5], p[1, 5], p[2, 5], p[3, 5], p[4, 5], p[5, 5], p[6, 5]);
            Console.WriteLine("  _____________________________");
            Console.WriteLine("E | {0} | {1} | {2} | {3} | {4} | {5} | {6} |", p[0, 4], p[1, 4], p[2, 4], p[3, 4], p[4, 4], p[5, 4], p[6, 4]);
            Console.WriteLine("  _____________________________");
            Console.WriteLine("D | {0} | {1} | {2} | {3} | {4} | {5} | {6} |", p[0, 3], p[1, 3], p[2, 3], p[3, 3], p[4, 3], p[5, 3], p[6, 3]);
            Console.WriteLine("  _____________________________");
            Console.WriteLine("C | {0} | {1} | {2} | {3} | {4} | {5} | {6} |", p[0, 2], p[1, 2], p[2, 2], p[3, 2], p[4, 2], p[5, 2], p[6, 2]);
            Console.WriteLine("  _____________________________");
            Console.WriteLine("B | {0} | {1} | {2} | {3} | {4} | {5} | {6} |", p[0, 1], p[1, 1], p[2, 1], p[3, 1], p[4, 1], p[5, 1], p[6, 1]);
            Console.WriteLine("  _____________________________");
            Console.WriteLine("A | {0} | {1} | {2} | {3} | {4} | {5} | {6} |", p[0, 0], p[1, 0], p[2, 0], p[3, 0], p[4, 0], p[5, 0], p[6, 0]);
            Console.WriteLine("  _____________________________");
            Console.WriteLine("    1   2   3   4   5   6   7  ");
        }
        static string[,] PlayerMove(string[,] boardState, string currPlayer)
        {
            string[] moves = { "1", "2", "3", "4", "5", "6", "7" };
            string move;
            int check2 = -1, check1 = -1;
            int index1, index2 = -1;

            do
            {
                //Check if input is number 1-7
                do
                {
                    Console.WriteLine("Player \"{0}\" pick a column.", currPlayer);
                    move = Console.ReadLine();
                    check1 = Array.IndexOf(moves, move);
                    index1 = int.Parse(move) - 1;
                    if(check1 == -1)
                    {
                        Console.WriteLine("Choose column from 1 to 7!");
                    }

                } while (check1 == -1);

                //Check if there is any free space in selected column

                do
                {
                    index2++;
                    if(index2 > 5)
                    {
                        index2 = -1;
                        check1 = -1;
                        check2 = -1;
                        Console.WriteLine("Column {0} is allready stacked!",move);
                        break;
                    }
                    else
                    {
                        check2 = 0;
                    }

                } while (boardState[index1, index2] != " ");
                
                

            } while (check1 == -1 && check2 != 0);

            boardState[index1, index2] = currPlayer;

            Console.Clear();

            return boardState;
        }
        
        static string SwitchPlayers(string curP)
        {
            string nextP;

            if(curP == "X")
            {
                nextP = "O";
            }
            else
            {
                nextP = "X";
            }

            return nextP;
        }

        static string WinCheck(string[,] cBoard)
        {
            string gg = " ";
            string[,] p = cBoard;
            
            //Vertical win possibilities

            for (int a = 0; a < 7; a++)
            {
                for (int b = 0; b + 3 < 6; b++)
                {
                    if(p[a, b] == "X" && p[a, b+1] == "X" && p[a, b+2] == "X" && p[a, b+3] == "X")
                    {
                        return "X";
                    }
                    else if((p[a, b] == "O" && p[a, b + 1] == "O" && p[a, b + 2] == "O" && p[a, b + 3] == "O"))
                    {
                        return "O";
                    }                    
                }                    
            }
            //Horizontal win possibilities

            for (int a = 0; a +3 < 7; a++)
            {
                for (int b = 0; b < 6; b++)
                {
                    if (p[a, b] == "X" && p[a+1, b] == "X" && p[a+2, b] == "X" && p[a+3, b] == "X")
                    {
                        return "X";
                    }
                    else if (p[a, b] == "O" && p[a + 1, b] == "O" && p[a + 2, b] == "O" && p[a + 3, b] == "O")
                    {
                        return "O";
                    }
                }
            }

            //Incline/> possibilities

            for (int a = 0; a + 3 < 7; a++)
            {
                for (int b = 0; b + 3 < 6; b++)
                {
                    if (p[a, b] == "X" && p[a+1, b+1] == "X" && p[a+2, b+2] == "X" && p[a+3, b+3] == "X")
                    {
                        return "X";
                    }
                    else if (p[a, b] == "O" && p[a + 1, b + 1] == "O" && p[a + 2, b + 2] == "O" && p[a + 3, b + 3] == "O")
                    {
                        return "O";
                    }
                }
            }

            //Decline\> possibilities

            for (int a = 0; a + 3 < 7; a++)
            {
                for (int b = 5; b > 2; b--) 
                {
                    if (p[a, b] == "X" && p[a+1, b-1] == "X" && p[a+2, b-2] == "X" && p[a+3, b-3] == "X")
                    {
                        return "X";
                    }
                    else if (p[a, b] == "O" && p[a+1, b-1] == "O" && p[a+2, b-2] == "O" && p[a+3, b-3] == "O")
                    {
                        return "O";
                    }
                }
            }
            return gg;
        }
        

        static void Main(string[] args)

            
        {
            string yesOrNo = "Y";

            do
            {
                string GG = " ";
                string currentPlayer;
                string[,] board;
                board = Start();
                currentPlayer = ChoiceXorO();
                DrawBoard(board);

                do
                {
                    board = PlayerMove(board, currentPlayer);
                    DrawBoard(board);
                    currentPlayer = SwitchPlayers(currentPlayer);
                    GG = WinCheck(board);
                }
                while (GG == " ");

                if (GG == "X")
                {
                    Console.WriteLine("Player \"X\" won!");
                }
                else if (GG == "O")
                {
                    Console.WriteLine("Player \"O\" won!");
                }
               
                Console.WriteLine("Play again? Y/N");
                string answer = Console.ReadLine();
                yesOrNo = answer.ToUpper();
            }
            while (yesOrNo == "Y");
        }
    }
}
