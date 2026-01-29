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
            Console.WriteLine("\n1. Add password");
            Console.WriteLine("2. View all");
            Console.WriteLine("3. Quit");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Web: ");
                string web = Console.ReadLine();

                Console.Write("Username: ");
                string user = Console.ReadLine();

                Console.Write("Password: ");
                string pass = Console.ReadLine();

                repo.Add(new PasswordEntry
                {
                    WebDomain = web,
                    Username = user,
                    Password = pass
                });

                Console.WriteLine("Saved to MongoDB!");
            }
            else if (choice == "2")
            {
                var entries = repo.GetAll();
                foreach (var e in entries)
                {
                    Console.WriteLine($"{e.WebDomain} | {e.Username} | {e.Password}");
                }
            }
            else if (choice == "3")
            {
                break;
            }
        }
    }
}