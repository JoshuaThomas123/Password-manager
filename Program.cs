using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var entries = new List<(string Web, string User, string Pass)>();

        while (true)
        {
            Console.WriteLine("\n--- Password Manager ---");
            Console.WriteLine("1. Add password");
            Console.WriteLine("2. View all");
            Console.WriteLine("3. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Web domain: ");
                string web = Console.ReadLine();

                Console.Write("Username: ");
                string user = Console.ReadLine();

                Console.Write("Password: ");
                string pass = Console.ReadLine();

                entries.Add((web, user, pass));
                Console.WriteLine("Saved!");
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n--- Saved Passwords ---");

                if (entries.Count == 0)
                {
                    Console.WriteLine("No entries yet.");
                }
                else
                {
                    for (int i = 0; i < entries.Count; i++)
                    {
                        Console.WriteLine(
                            $"{i + 1}. {entries[i].Web} | {entries[i].User} | {entries[i].Pass}"
                        );
                    }
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Goodbye!");
                break; // exit while loop
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}

