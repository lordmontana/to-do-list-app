using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace ToDoListApp
{
    class Program
    {
        static List<string> todoList = new List<string>();
        static string password ="";

        static void Main(string[] args)
        {

                 if (File.Exists("todo.txt"))
            {
                todoList.AddRange(File.ReadAllLines("todo.txt"));
            }
            if (File.Exists("password.txt"))
            {
                password = File.ReadAllText("password.txt");
                Console.Write("Enter the password: ");
                if (Console.ReadLine() != password)
                {
                    Console.WriteLine("Invalid password");
                    Console.ReadKey();
                    return;
                }
                ShowMenu();
            }
            else
            {
                ShowMenu();
            }

        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("To-Do List");
            Console.WriteLine("1. Show list");
            Console.WriteLine("2. Add item");
            Console.WriteLine("3. Remove item");
            Console.WriteLine("4. Exit");
            if (File.Exists("password.txt"))
            {
                Console.WriteLine("5. Change password");
            }
            else
            {
                Console.WriteLine("5. Create new password");
            }

            Console.WriteLine("6. Edit item");

            Console.Write("Enter your choice: ");
            switch (Console.ReadLine())
            {
                case "1":
                    ShowList();
                    break;
                case "2":
                    AddItem();
                    break;
                case "3":
                    RemoveItem();
                    break;
                case "4":
                    ExitApplication();
                    break;
                case "5":
                    ChangePassword();
                    break;
                case "6":
                    EditItem();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    ShowMenu();
                    break;
            }
        }

        static void ShowList()
        {
            Console.Clear();
            Console.WriteLine("To-Do List:");
            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {todoList[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
            ShowMenu();
        }

        static void AddItem()
        {
            Console.Clear();
            Console.Write("Enter the new item: ");
            var newItem = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newItem))
            {
                todoList.Add(newItem);
                Console.WriteLine("Item added successfully");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            Console.ReadKey();
            ShowMenu();
        }

        static void RemoveItem()
        {
            Console.Clear();
            Console.Write("Enter the item number to remove: ");
            if (int.TryParse(Console.ReadLine(), out int itemNum) && itemNum > 0 && itemNum <= todoList.Count)
            {
                todoList.RemoveAt(itemNum - 1);
                Console.WriteLine("Item removed successfully");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            Console.ReadKey();
            ShowMenu();
        }


        static void ChangePassword()
    {
    Console.Clear();
            if (File.Exists("password.txt"))
            {
                Console.Write("Enter old password: ");
                if (Console.ReadLine() != password)
                {
                    Console.WriteLine("Invalid password");
                    Console.ReadKey();
                    ShowMenu();
                    return;
                }
            }
    Console.Write("Enter new password: ");
    var newPassword = Console.ReadLine();
    Console.Write("Confirm new password: ");
    if (Console.ReadLine() != newPassword)
    {
        Console.WriteLine("Passwords do not match");
        Console.ReadKey();
        ShowMenu();
        return;
    }
    password = newPassword;
    File.WriteAllText("password.txt", newPassword);

            Console.WriteLine("Password changed successfully");
    Console.ReadKey();
    ShowMenu();
}
        static void EditItem()
        {
            Console.Clear();
            Console.WriteLine("Enter item number: ");
            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {todoList[i]}");
            }
            if (!int.TryParse(Console.ReadLine(), out int itemNum) || itemNum <= 0 || itemNum > todoList.Count)
            {
                Console.WriteLine("Invalid item number");
                Console.ReadKey();
                ShowMenu();
                return;
            }
            Console.WriteLine($"Current value: {todoList[itemNum - 1]}");

            Console.Write("Enter new value: ");
            var newValue = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newValue))
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey();
                ShowMenu();
                return;
            }
            todoList[itemNum - 1] = newValue;
            Console.WriteLine("Item edited successfully");
            Console.ReadKey();
            ShowMenu();
        }
        static void ExitApplication()
        {
            File.WriteAllLines("todo.txt", todoList);
            Environment.Exit(0);
        }
    }
}