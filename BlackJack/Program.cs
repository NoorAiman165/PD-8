using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.BL;
using static BlackJack.BL.Hand;

namespace BlackJack
{

        class Program
        {
            private static Deck deck;
            private static BlackjackHand playerHand;
            private static BlackjackHand dealerHand;

            static void Main(string[] args)
            {
                InitializeGame();
                  Console.ForegroundColor = ConsoleColor.Green;
                  
                Console.WriteLine("----------------------");
                Console.WriteLine("Welcome to Blackjack!");
                Console.WriteLine("----------------------");
                Console.ForegroundColor= ConsoleColor.Blue;
                DealInitialCards();
                PlayerTurn();
                if (!playerHand.IsBust())
                {
                    DealerTurn();
                }
                DetermineOutcome();
            }
            private static void InitializeGame()
            {
                deck = new Deck();
                playerHand = new BlackjackHand();
                dealerHand = new BlackjackHand();
                deck.shuffle();
            }
            private static void DealInitialCards()
            {
                playerHand.AddCard(deck.dealCard());
                playerHand.AddCard(deck.dealCard());

                dealerHand.AddCard(deck.dealCard());
                dealerHand.AddCard(deck.dealCard());

                Console.WriteLine("Player's Hand: " + playerHand);
                Console.WriteLine("Dealer's Hand: [Hidden] " + dealerHand.GetCard(1));
            }

            
            private static void PlayerTurn()
            {
                Console.WriteLine("\nYour turn!");
                while (true)
                {
                    Console.WriteLine($"Current Hand: {playerHand}");
                    Console.WriteLine($"Hand Value: {playerHand.getCardCount()}");

                    if (playerHand.IsBust())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You busted! Dealer wins.");
                        return;
                    }

                    Console.Write("Do you want to (H)it or (S)tand? ");
                    string choice = Console.ReadLine().Trim().ToUpper();

                    if (choice == "H")
                    {
                        playerHand.AddCard(deck.dealCard());
                    }
                    else if (choice == "S")
                    {
                        Console.WriteLine("You chose to stand.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 'H' to hit or 'S' to stand.");
                    }
                }
            }
            private static void DealerTurn()
            {
                Console.WriteLine("\nDealer's turn!");
                Console.WriteLine($"Dealer's Hand: {dealerHand}");
                Console.WriteLine($"Dealer's Hand Value: {dealerHand.getCardCount()}");

                while (dealerHand.getCardCount() < 17)
                {
                    Console.WriteLine("Dealer hits.");
                    dealerHand.AddCard(deck.dealCard());
                    Console.WriteLine($"Dealer's Hand: {dealerHand}");
                    Console.WriteLine($"Dealer's Hand Value: {dealerHand.getCardCount()}");

                    if (dealerHand.IsBust())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Dealer busted! You win.");
                        return;
                    }
                }

                Console.WriteLine("Dealer stands.");
            }
            private static void DetermineOutcome()
            {
                int playerValue = playerHand.getCardCount();
                int dealerValue = dealerHand.getCardCount();

                Console.WriteLine("\nFinal Results:");
                Console.WriteLine($"Player's Hand: {playerHand} (Value: {playerValue})");
                Console.WriteLine($"Dealer's Hand: {dealerHand} (Value: {dealerValue})");

                if (playerHand.IsBust())
                {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You busted! Dealer wins.");
                }
                else if (dealerHand.IsBust())
                {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Dealer busted! You win.");
                }
                else if (playerValue > dealerValue)
                {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You win!");
                }
                else if (playerValue < dealerValue)
                {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Dealer wins.");
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }
            }
        }
    }
