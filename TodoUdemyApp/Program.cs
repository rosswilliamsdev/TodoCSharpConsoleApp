
class Program
{

    static List<string> todoList = new List<string>();
    static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            string userInput = Menu().ToString().ToUpper();

            switch (userInput)
            {
                case "S":
                    if (todoList.Count == 0)
                    {
                        Console.WriteLine("There are no todos on the list");
                    }
                    else
                    {
                        showList(todoList);
                    }

                    break;
                case "A":
                    Console.WriteLine("Add your todo to the list");
                    string newTodo = Console.ReadLine();

                    if (!string.IsNullOrEmpty(newTodo))
                    {
                        Program.todoList.Add(newTodo);
                    }
                    break;
                case "R":
                    Console.WriteLine("Here is the current list:");
                    showList(todoList);
                    Console.WriteLine("Enter the number of the todo to remove");
                    string todoNumber = Console.ReadLine();


                    if (int.TryParse(todoNumber, out int todoIndex))
                    {
                        if (todoIndex > 0 && todoIndex <= todoList.Count)
                        {
                            // Subtract 1 from todoIndex since lists are 0-indexed
                            todoList.RemoveAt(todoIndex - 1);
                            Console.WriteLine("Todo removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid todo number. No todo removed.");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Invalid input. No todo removed.");
                    }
                    break;
                case "E":
                    Console.WriteLine("\nClosing app...");
                    isRunning = false; // Exit the loop and end the program
                    break;
                default:
                    Console.WriteLine("\nInvalid input");
                    break;
            }
        }
    }

    static void showList(List<string> list)
    {
        Console.WriteLine("Here is your current Todo list:");
        int itemIndex = 1;
        foreach (var item in list)
        {
            Console.WriteLine($"{itemIndex}. {item}");
            itemIndex++;
        }
    }

    /* static void returnToMenu()
    {
        Console.WriteLine("Return to menu?");
        Console.WriteLine("[Y]es");
        Console.WriteLine("[N]o");
        char response = Console.ReadKey().KeyChar;
        if (response == 'N' || response == 'n')
        {
            Console.WriteLine("\nClosing app...");
            Environment.Exit(0);
        }
        else if (!(response == 'Y' || response == 'y'))
        {
            Console.WriteLine("Enter a valid response");
            returnToMenu();
        }
    } */


    static char Menu()
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("[S]ee all TODOs");
        Console.WriteLine("[A]dd a TODO");
        Console.WriteLine("[R]emove a TODO");
        Console.WriteLine("[E]xit");
        return Console.ReadKey().KeyChar;
    }
}




