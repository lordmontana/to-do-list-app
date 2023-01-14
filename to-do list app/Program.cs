using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoListApp
{
    class Program
    {
        static List<string> todoList = new List<string>();

        static void Main(string[] args)
        {
            //Read the to-do list from a text file
            if (File.Exists("todo.txt"))
            {
                todoList.AddRange(File.ReadAllLines("todo.txt"));
            }
            //Show the main menu
            ShowMenu();
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("To-Do List");
            Console.WriteLine("1. Show list");
            Console.WriteLine("2. Add item");
            Console.WriteLine("3. Remove item");
            Console.WriteLine("4. Exit");
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
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    ShowMenu();
                    break;
            }
        }

        static void ShowList()
        {
            //Show the current to-do list
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
            //Add a new item to the to-do list
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
            //Remove an item from the to-do list
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

        static void ExitApplication()
        {
            //Save the to-do list to a text file
            File.WriteAllLines("todo.txt", todoList);
            //Exit the application
            Environment.Exit(0);
        }
    }
}