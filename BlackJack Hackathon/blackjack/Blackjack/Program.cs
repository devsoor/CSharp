using System;
using System.Collections.Generic;

namespace hackothon
{

    class Program
    {
        static void Main(string[] args)
        {
            



            Console.WriteLine("Welcome to the game of DojoJack");
            while (true)
            {
                Console.WriteLine("What's your name?");
                string playerName = Console.ReadLine();
                Game game = new Game();
                Deck deck = new Deck();

                // deck.DisplayDeck();
                deck.Shuffle();
                // deck.DisplayDeck();q
            

                Player player = new Player(playerName);
                Dealer dealer = new Dealer();

                Console.WriteLine("player name is " + player.Name);
                Console.WriteLine("dealer name is " + dealer.Name);

                Console.WriteLine("How many chips do you want to bet?");

                while (true)
                {
                    string amount = Console.ReadLine();
                    int chipAmount = Int32.Parse(amount);

                    if (chipAmount > player.Chips)
                    {
                        Console.WriteLine("You can't bet more chips than you have");
                    }
                    else 
                    {
                        player.Chips -= chipAmount;
                        player.ChipsBet += chipAmount;
                        // Send amount to Player.
                        // If Player balance is less than 0, then display message and return to the top.
                        // If amount to bet is okay, exit this loop.
                        break;
                    }
                }

                Console.WriteLine("You are ready to play!");
                Console.WriteLine("d - Deal cards");
                Console.WriteLine("q - Quit");
                while (true)
                {
                    string action = Console.ReadLine();
                    if (action == "q")
                    {
                        Console.WriteLine("Leaving the game");
                        Environment.Exit(0);
                    }
                    else if (action == "d")
                    {
                        Console.WriteLine("Deal a card");
                        //player.Hand.Add(deck.Deal());
                        player.Draw(deck);
                        dealer.Draw(deck);
                        player.Draw(deck);
                        dealer.Draw(deck);
                        break;
                    }
                    // else if (action == "c")
                    // {
                    //     break;
                    // }
                    // if we have two cards, then break.
                }

                Console.WriteLine("Your cards are:");
                player.DisplayPlayerHand();                       

                Console.WriteLine("The dealers card that is showing is:");
                dealer.DisplayDealerHand();

                Console.WriteLine("What next?");
                while (true)
                {
                    Console.WriteLine("h - Hit me!");
                    Console.WriteLine("s - Stand");
                    Console.WriteLine("q - Quit");

                    string action = Console.ReadLine();

                    if (action == "q")
                    {
                        Console.WriteLine("Leaving the game");
                        Environment.Exit(0);
                    }
                    else if (action == "s")
                    {
                        player.IsStanding = true;
                        // Dealer now plays.
                        dealer.DrawCards(deck);
                        Console.WriteLine($"Dealers hand total is {dealer.TotalHandVal}");

                        break;
                    }
                    else if (action == "h")
                    {
                        // Display the players hand with each new card.
                        player.IsStanding = false;
                        player.Draw(deck);
                        player.DisplayPlayerHand();

                        if (player.TotalHandVal > 21)
                        {
                            break;
                        }
                        
                        
                    }
                }

                while (true)
                {
                    // Decide who wins the game and show results
                    if (player.TotalHandVal > 21 ||  player.TotalHandVal == dealer.TotalHandVal || dealer.TotalHandVal > player.TotalHandVal)
                        {
                            Console.WriteLine($"Busted ya' loser! You lost {player.ChipsBet}. Try again");
                        }
                        else if (player.TotalHandVal == 21) 
                        {
                            Console.WriteLine($"DojoJack! Nice job {player.Name}, you won {player.ChipsBet*2}!");
                        }
                        else if (player.TotalHandVal > dealer.TotalHandVal)
                        {
                            Console.WriteLine($"You Win. Nice job! Your chip count is now {player.Chips}");
                        }
                    // Console.WriteLine("Display game results here");
                    break;
                }

                Console.WriteLine("What do you want to do next?");
                Console.WriteLine("p - Play another game");
                Console.WriteLine("q - Quit");

                while (true)
                {
                    string action = Console.ReadLine();

                    if (action == "q")
                    {
                        Console.WriteLine("Leaving the game");
                        Environment.Exit(0);
                    }
                    else if (action == "p")
                    {
                        // play another game
                        Console.WriteLine("Starting a new game");
                        break;
                    }
                }
            }





        }
    }
}
