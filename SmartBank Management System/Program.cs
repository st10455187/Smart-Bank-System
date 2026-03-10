/*
Angel Maile - ST10455187
Program: SmartBank Management System

Reflection Questions:

1. Why is input validation important in console applications?
Input validation prevents crashes and ensures that the program only processes valid data. 
It protects the system from incorrect inputs such as letters where numbers are expected.

2. Why is method separation considered good programming practice?
Method separation makes code easier to read, maintain, and debug. 
Each method performs one task which keeps the program organized and reusable.
*/

using System;
using System.Threading;

namespace SmartBank_Management_System
{
    class Program
    {
        static string accountHolder = "";
        static double balance = 0;
        static bool accountCreated = false;

        static void Main(string[] args)
        {
            int option = 0;

            while (option != 5)
            {
                Console.Clear();
                DisplayHeader();

                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. View Account Details");
                Console.WriteLine("5. Exit");

                Console.Write("\nSelect an option: ");

                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ResetColor();
                    Pause();
                    continue;
                }

                switch (option)
                {
                    case 1:
                        CreateAccount();
                        break;

                    case 2:
                        Deposit();
                        break;

                    case 3:
                        Withdraw();
                        break;

                    case 4:
                        ViewDetails();
                        break;

                    case 5:
                        Console.WriteLine("\nThank you for using SmartBank.");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid menu option.");
                        Console.ResetColor();
                        Pause();
                        break;
                }
            }
        }

        static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("=================================");
            Console.WriteLine("        SMARTBANK SYSTEM");
            Console.WriteLine("=================================");

            Console.ResetColor();
            Console.WriteLine();
        }

        static void CreateAccount()
        {
            Console.Clear();
            DisplayHeader();

            Console.Write("Enter Account Holder Name: ");
            accountHolder = Console.ReadLine();

            double initialDeposit;

            while (true)
            {
                Console.Write("Enter Initial Deposit: ");

                if (!double.TryParse(Console.ReadLine(), out initialDeposit))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid amount.");
                    Console.ResetColor();
                    continue;
                }

                if (initialDeposit < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Deposit cannot be negative.");
                    Console.ResetColor();
                    continue;
                }

                break;
            }

            balance = initialDeposit;
            accountCreated = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAccount created successfully!");
            Console.ResetColor();

            Pause();
        }

        static void Deposit()
        {
            Console.Clear();
            DisplayHeader();

            if (!accountCreated)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No account exists. Create one first.");
                Console.ResetColor();
                Pause();
                return;
            }

            double amount;

            Console.Write("Enter deposit amount: ");

            if (!double.TryParse(Console.ReadLine(), out amount) || amount < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid deposit amount.");
                Console.ResetColor();
                Pause();
                return;
            }

            balance += amount;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Deposit successful! New Balance: R{balance:F2}");
            Console.ResetColor();

            Pause();
        }

        static void Withdraw()
        {
            Console.Clear();
            DisplayHeader();

            if (!accountCreated)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No account exists. Create one first.");
                Console.ResetColor();
                Pause();
                return;
            }

            double amount;

            Console.Write("Enter withdrawal amount: ");

            if (!double.TryParse(Console.ReadLine(), out amount) || amount < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid withdrawal amount.");
                Console.ResetColor();
                Pause();
                return;
            }

            if (amount > balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient funds.");
                Console.ResetColor();
                Pause();
                return;
            }

            balance -= amount;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Withdrawal successful! New Balance: R{balance:F2}");
            Console.ResetColor();

            Pause();
        }

        static void ViewDetails()
        {
            Console.Clear();
            DisplayHeader();

            if (!accountCreated)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No account exists.");
                Console.ResetColor();
                Pause();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Account Holder: {accountHolder}");
            Console.WriteLine($"Current Balance: R{balance:F2}");

            Console.ResetColor();

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}