using System;
using PasswordManager.Data;
using PasswordManager.Models;

class Program
{
    static void Main()
    {
        var repo = new PasswordRepository();

        while (true)
        {
            Console.WriteLine("\n--- PASSWORD MANAGER ---");
            Console.WriteLine("1. Add password");
            Console.WriteLine("2. View all");
            Console.WriteLine("3. Delete password");
            Console.WriteLine("4. Quit");
            Console.Write("Choice: ");

            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Web domain: ");
                string web = Console.ReadLine() ?? "";

                Console.Write("Username: ");
                string user = Console.ReadLine() ?? "";

                Console.Write("Password: ");
                string pass = Console.ReadLine() ?? "";

                repo.Add(new PasswordEntry
                {
                    WebDomain = web,
                    Username = user,
                    Password = pass
                });
            }
            else if (choice == "2")
            {
                var entries = repo.GetAll();

                Console.WriteLine("\nID | WEBSITE | USERNAME | PASSWORD");
                Console.WriteLine("-----------------------------------");

                foreach (var e in entries)
                {
                    Console.WriteLine($"{e.Id} | {e.WebDomain} | {e.Username} | {e.Password}");
                }
            }
            else if (choice == "3")
            {
                Console.Write("Enter ID to delete: ");
                string id = Console.ReadLine() ?? "";

                repo.DeleteById(id);
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine(" Invalid choice");
            }
        }
    }
}
