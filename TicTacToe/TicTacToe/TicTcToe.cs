using System;
using System.Threading;

namespace TicTacToe
{
    class MainClass
    {
        static char[] board = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        static int player = 1;
        static int choice;
        static Boolean single;

        static int flag = 0;

        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Tci Tac Toe!");
            Console.WriteLine("1. Single Player") ;
            Console.WriteLine("2. Two Players");
            Console.WriteLine("Enter 1 or 2:\n");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                single = true;
            }
            else
            {
                single = false;
            }

            // single player
            if (single == true)
            {
                Boolean goFirst;    // checks to see if player goes first. Only necessary in single player
                Console.WriteLine("Go first or second? (Enter 1 or 2): ");
                if (int.Parse(Console.ReadLine()) == 1){
                    goFirst = true;
                }
                else
                {
                    goFirst = false;
                }

                do
                {
                    Console.Clear();
                    if (goFirst == true)
                    {
                        Console.WriteLine("Player 1: O and Computer: X");
                    }
                    else
                    {
                        Console.WriteLine("Computer: O and Player 2: X");
                    }
                    DisplayBoard();

                    if (player == 1)//checking the turn of the player
                    {
                        if (goFirst == true)
                        {
                            Console.WriteLine("Player's Turn");
                            Console.WriteLine("Enter a number from 1 - 9:\n");
                            choice = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Computer's Turn");
                            choice = ComputerChoice();
                        }
                    }
                    else if (player == 2)
                    {
                        if (goFirst == true)
                        {
                            Console.WriteLine("Computer's Turn");
                            choice = ComputerChoice();
                        }
                        else
                        {
                            Console.WriteLine("Player's Turn");
                            Console.WriteLine("Enter a number from 1 - 9:\n");
                            choice = int.Parse(Console.ReadLine());
                        }
                    }
                    
                    //checking if the position where user want to run is marked(with X or O) or not
                    if (board[choice] != 'X' && board[choice] != 'O')
                    {
                        if (player == 1) //if it is player 1's turn mark O, otherwise mark X  
                        {
                            board[choice] = 'O';
                            flag = CheckWin();
                            Thread.Sleep(500);
                            if (flag == 0)
                            {
                                player = 2;
                            }
                        }
                        else
                        {
                            board[choice] = 'X';
                            flag = CheckWin();
                            Thread.Sleep(500);
                            if (flag == 0)
                            {
                                player = 1;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The position {0} is already marked with {1}\n", choice, board[choice]);
                        Thread.Sleep(1000);
                    }

                } while (flag == 0);

            }

            // two players
            if (single == false)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Player 1: O and Player 2: X");
                    DisplayBoard();

                    if (player == 1)//checking the turn of the player
                    {
                        Console.WriteLine("Player 1's Turn");
                    }
                    else
                    {
                        Console.WriteLine("Player 2's Turn");
                    }
                    Console.WriteLine("Enter a number from 1 - 9:\n");
                    choice = int.Parse(Console.ReadLine());

                    //checking if the position where user want to run is marked(with X or O) or not
                    if (board[choice] != 'X' && board[choice] != 'O')
                    {
                        if (player == 1) //if it is player 1's turn mark O, otherwise mark X  
                        {
                            board[choice] = 'O';
                            flag = CheckWin();
                            Thread.Sleep(500);
                            if (flag == 0)
                            {
                                player = 2;
                            }
                        }
                        else
                        {
                            board[choice] = 'X';
                            flag = CheckWin();
                            Thread.Sleep(500);
                            if (flag == 0)
                            {
                                player = 1;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The position {0} is already marked with {1}\n", choice, board[choice]);
                        Thread.Sleep(1000);
                    }

                } while (flag == 0);
            }


            // game is finished
            Console.Clear();// clearing the console 
            DisplayBoard();// getting filled board again  


            if (flag == 1)// if flag value is 1 then some one has win or means who played marked last time which has win  
            {
                if (single == true)
                {
                    Console.WriteLine("Computer has won", player);  //since Copmuter cannot lose, I did not add a losing statement for the computer
                }
                else
                {
                    Console.WriteLine("Player {0} has won", player);
                }
            }
            else// if flag value is -1 the match will be draw and no one is winner  
            {
                Console.WriteLine("Draw");
            }

        }

        // Board method which creats board
        private static void DisplayBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      ");

        }

        private static int CheckWin()
        {
            // Check if there are 3 matching horizontal symbols
            if (board[1] == board[2] && board[3] == board[1])
            {
                return 1;
            }
            else if (board[4] == board[5] && board[6] == board[4])
            {
                return 1;
            }
            else if (board[7] == board[8] && board[9] == board[7])
            {
                return 1;
            }

            // Check for 3 matching vertical symbols
            if (board[1] == board[4] && board[7] == board[1])
            {
                return 1;
            }
            else if (board[2] == board[5] && board[8] == board[2])
            {
                return 1;
            }
            else if (board[3] == board[6] && board[9] == board[3])
            {
                return 1;
            }

            // Check for 3 matching diagnal symbols
            if (board[1] == board[5] && board[9] == board[1])
            {
                return 1;
            }
            else if (board[3] == board[5] && board[7] == board[3])
            {
                return 1;
            }

            // Check if all positions are filled and there is no winner
            else if (board[1] != '1' && board[2] != '2' && board[3] != '3'
                && board[4] != '4' && board[5] != '5' && board[6] != '6'
                && board[7] != '7' && board[8] != '8' && board[9] != '9') 
            {
                return -1;
            }

            // If no condition is met, continue with game
            return 0;
        }

        private static int ComputerChoice()
        {
            char symbol, opp;

            if (player == 1)
            {
                symbol = 'O';
                opp = 'X';
            }
            else
            {
                symbol = 'X';
                opp = 'O';
            }

            // Victory condition
            //
            // Horizontal victory row 1
            if (board[2] == symbol && board[3] == symbol && board[1] == '1')
            {
                return 1;
            }
            else if (board[1] == symbol && board[3] == symbol && board[2] == '2')
            {
                return 2;
            }
            else if (board[1] == symbol && board[2] == symbol && board[3] == '3')
            {
                return 3;
            }
            // Horizontal victory row 2
            if (board[5] == symbol && board[6] == symbol && board[4] == '4')
            {
                return 4;
            }
            else if (board[4] == symbol && board[6] == symbol && board[5] == '5')
            {
                return 5;
            }
            else if (board[4] == symbol && board[5] == symbol && board[6] == '6')
            {
                return 6;
            }
            // Horizontal victory row 3
            if (board[8] == symbol && board[9] == symbol && board[7] == '7')
            {
                return 7;
            }
            else if (board[7] == symbol && board[9] == symbol && board[8] == '8')
            {
                return 8;
            }
            else if (board[7] == symbol && board[8] == symbol && board[9] == '9')
            {
                return 9;
            }
            // Vertical victory column 1
            if (board[4] == symbol && board[7] == symbol && board[1] == '1')
            {
                return 1;
            }
            else if (board[1] == symbol && board[7] == symbol && board[4] == '4')
            {
                return 4;
            }
            else if (board[4] == symbol && board[4] == symbol && board[7] == '7')
            {
                return 7;
            }
            // Vertical victory column 2
            if (board[5] == symbol && board[8] == symbol && board[2] == '2')
            {
                return 2;
            }
            else if (board[2] == symbol && board[8] == symbol && board[5] == '5')
            {
                return 5;
            }
            else if (board[2] == symbol && board[5] == symbol && board[8] == '8')
            {
                return 8;
            }
            // Vertical victory column 3
            if (board[6] == symbol && board[9] == symbol && board[3] == '3')
            {
                return 3;
            }
            else if (board[3] == symbol && board[9] == symbol && board[6] == '6')
            {
                return 6;
            }
            else if (board[3] == symbol && board[6] == symbol && board[9] == '9')
            {
                return 9;
            }
            // Diagnal victory 1
            if (board[5] == symbol && board[9] == symbol && board[1] == '1')
            {
                return 1;
            }
            else if (board[1] == symbol && board[9] == symbol && board[5] == '5')
            {
                return 5;
            }
            else if (board[1] == symbol && board[5] == symbol && board[9] == '9')
            {
                return 9;
            }
            // Diagnal victory 2
            if (board[5] == symbol && board[7] == symbol && board[3] == '3')
            {
                return 3;
            }
            else if (board[3] == symbol && board[7] == symbol && board[5] == '5')
            {
                return 5;
            }
            else if (board[3] == symbol && board[5] == symbol && board[7] == '7')
            {
                return 7;
            }


            // Loss prevention
            //
            // Horizontal loss prevention row 1
            if (board[2] == opp && board[3] == opp && board[1] == '1')
            {
                return 1;
            }
            else if (board[1] == opp && board[3] == opp && board[2] == '2')
            {
                return 2;
            }
            else if (board[1] == opp && board[2] == opp && board[3] == '3')
            {
                return 3;
            }
            // Horizontal loss prevention row 2
            if (board[5] == opp && board[6] == opp && board[4] == '4')
            {
                return 4;
            }
            else if (board[4] == opp && board[6] == opp && board[5] == '5')
            {
                return 5;
            }
            else if (board[4] == opp && board[5] == opp && board[6] == '6')
            {
                return 6;
            }
            // Horizontal lose prevention row 3
            if (board[8] == opp && board[9] == opp && board[7] == '7')
            {
                return 7;
            }
            else if (board[7] == opp && board[9] == opp && board[8] == '8')
            {
                return 8;
            }
            else if (board[7] == opp && board[8] == opp && board[9] == '9')
            {
                return 9;
            }
            // Vertical lose prevention column 1
            if (board[4] == opp && board[7] == opp && board[1] == '1')
            {
                return 1;
            }
            else if (board[1] == opp && board[7] == opp && board[4] == '4')
            {
                return 4;
            }
            else if (board[1] == opp && board[4] == opp && board[7] == '7')
            {
                return 7;
            }
            // Vertical loss prevention column 2
            if (board[5] == opp && board[8] == opp && board[2] == '2')
            {
                return 2;
            }
            else if (board[2] == opp && board[8] == opp && board[5] == '5')
            {
                return 5;
            }
            else if (board[2] == opp && board[5] == opp && board[8] == '8')
            {
                return 8;
            }
            // Vertical loss prevention column 3
            if (board[6] == opp && board[9] == opp && board[3] == '3')
            {
                return 3;
            }
            else if (board[3] == opp && board[9] == opp && board[6] == '6')
            {
                return 6;
            }
            else if (board[3] == opp && board[6] == opp && board[9] == '9')
            {
                return 9;
            }
            // Diagnal loss prevention 1
            if (board[5] == opp && board[9] == opp && board[1] == '1')
            {
                return 1;
            }
            else if (board[1] == opp && board[9] == opp && board[5] == '5')
            {
                return 5;
            }
            else if (board[1] == opp && board[5] == opp && board[9] == '9')
            {
                return 9;
            }
            // Diagnal loss prevention 2
            if (board[5] == opp && board[7] == opp && board[3] == '3')
            {
                return 3;
            }
            else if (board[3] == opp && board[7] == opp && board[5] == '5')
            {
                return 5;
            }
            else if (board[3] == opp && board[5] == opp && board[7] == '7')
            {
                return 7;
            }

            // the oppenent started first
            if (player%2 == 0)
            {
                // if middle still isn't filled
                if (board[5] == '5')
                {
                    return 5;
                }

                if (board[5] == opp)
                {
                    if (board[1] == '1')
                    {
                        return 1;
                    }
                    else if (board[9] == opp && board[3] == '3')
                    {
                        return 3;
                    }

                }

                // this section is mostly for the end game when the opponent didn't pick the center,
                // but also covers some scenarios where they did. 
                //
                // when no corners have been pick (only possible if opponent didn't pick center going first)
                if (board[1] == '1' && board[3] == '3' && board[7] == '7' && board[9] == '9')
                {
                    return 1;
                }
                // when a tie game is most likely but a win is still possible
                if (board[2] == '2' && board[3] == '3')
                {
                    return 2;
                }
                else if (board[4] == '4' && board[7] == '7')
                {
                    return 4;
                }
            }

            // if computer started first
            if (player%2 == 1)
            {
                if (board[5] == '5')
                {
                    return 5;
                }

                // if opponent picked a corner square
                if (board[1] == opp)
                {
                    if (board[9] == '9')
                    {
                        return 9;
                    }
                    else if (board[6] == opp && board[7] == '7')
                    {
                        return 7;
                    }
                    else if (board[8] == opp && board[3] == '3')
                    {
                        return 3;
                    }
                }
                else if (board[3] == opp)
                {
                    if (board[7] == '7')
                    {
                        return 7;
                    }
                    else if (board[4] == opp && board[9] == '9')
                    {
                        return 9;
                    }
                    else if (board[8] == opp && board[3] == '3')
                    {
                        return 3;
                    }
                }
                else if (board[7] == opp)
                {
                    if (board[3] == '3')
                    {
                        return 3;
                    }
                    else if (board[2] == opp && board[9] == '9')
                    {
                        return 9;
                    }
                    else if (board[6] == opp && board[1] == '1')
                    {
                        return 1;
                    }
                }
                else if (board[9] == opp)
                {
                    if (board[1] == '1')
                    {
                        return 1;
                    }
                    else if (board[4] == opp && board[3] == '3')
                    {
                        return 3;
                    }
                    else if (board[2] == opp && board[7] == '7')
                    {
                        return 7;
                    }
                }

                // If computer selects middle and opponent selects any of the outer middle space
                if (board[2] == opp && board[9] == '9')
                {
                    return 9;
                }
                else if (board[4] == opp && board[3] == '3')
                {
                    return 3;
                }
                else if (board[8] == opp && board[1] == '1')
                {
                    return 1;
                }
                else if (board[6] == opp && board[7] == '7')
                {
                    return 7;
                }

                // after reaching standstill and it is still possible for vomputer to win
                if (board[2] == '2' && board[8] == '8')
                {
                    return 2;
                }
                else if (board[4] == '4' && board[6] == '6')
                {
                    return 4;
                }
            }


            // If there is no way for either side to win or cause a board state that will result in a victory or defeat
            for (int i = 1; i <= board.Length; i++)
            {
                if (board[i] != symbol && board[i] != opp)
                {
                    return i;
                }
            }


            return 0;
        }
    }

}
