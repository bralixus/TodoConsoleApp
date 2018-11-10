using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TODOConsoleApp
{
    class Program
    {
        public static List<TaskModel> taskList = new List<TaskModel>();

        static void Main(string[] args)
        {
            string command = "";
            ConsoleEx.WriteLine("MENEDŻER ZADAŃ TODO", ConsoleColor.Cyan);
            Console.WriteLine();

            do
            {
                Console.WriteLine("Jeśli chcesz dodać nowe zadanie, wpisz \"add\"");
                Console.WriteLine("Jeśli chcesz opuścić program, wpisz \"exit\"");
                command = Console.ReadLine();
                if (command == "add")
                {
                    Console.WriteLine("Wpisz nowe zadanie (opis;początek(rrrr.mm.dd);koniec(rrrr.mm.dd); wpisz \"tak\" jeżeli zadanie jest ważne ");
                    string element = Console.ReadLine();
                    string afterCheck = CommandCheck.elements(element.Trim(';', ' ', '=', '-', '.'));
                    AddTask(afterCheck);
                    ConsoleEx.WriteLine("Zadanie zostało dodane do listy zadań", ConsoleColor.Blue);
                    Console.WriteLine();
                    ConsoleEx.WriteLine("Dostępne komendy: Jeżeli chcesz wyświetlić listę zadań wpisz \"show\"",ConsoleColor.Green);
                    Console.WriteLine("Jeżeli chcesz usunąć zadanie, wpisz \"remove\"");
                    Console.WriteLine("Jeżeli chcesz zapisać zadanie do pliku, wpisz \"save\"");
                }
                else if (command == "remove")
                {
                    RemoveTask();
                    ConsoleEx.WriteLine("Zadanie zostało usunięte", ConsoleColor.Blue);
                }

                else if (command == "show")
                {
                    Show.ShowTask(taskList);
                    
                }

                else if (command == "save")

                {
                    SaveTask();
                    ConsoleEx.WriteLine("Zadanie zostało zapisane", ConsoleColor.Blue);
                    Console.WriteLine("Aby wyświetlić zapisane zadania, wpisz \"load\"");

                }
                else if (command == "load")
                {
                    LoadTask();
                }

                else if (command == "exit")
                {
                    return;
                }

            } while (command != "exit");
        }


        public static void AddTask(string newTask)
        {
            string[] testField = newTask.Split(';');
            List<TaskModel> notImportant = new List<TaskModel>();
            TaskModel taskModel = new TaskModel(testField[0], testField[1], testField[2], testField[3], testField[4]);

            if (testField[4] != null)
            {
                taskList.Add(taskModel);
            }
            else
            {
                notImportant.Add(taskModel);
            }

            foreach (var tas in notImportant)
            {
                taskList.Add(tas);
            }
        }

        public static void RemoveTask()
        {
            int i = 1;
            foreach (var taskModel in taskList)
            {
                Console.WriteLine($"{i}. {taskModel.Descryption} {taskModel.StartDate} {taskModel.EndDate} {taskModel.AllDayTask} {taskModel.ImportantTask}");
                i++;
            }

            ConsoleEx.Write("Wpisz numer zadania do usunięcia:", ConsoleColor.Blue);
            if (int.Parse(Console.ReadLine()) <= taskList.Count)
            {
                taskList.RemoveAt(int.Parse(Console.ReadLine() + 1));
                ConsoleEx.WriteLine("Zadanie zostało usunięte", ConsoleColor.Blue);
            }

            ConsoleEx.WriteLine("Brak zadania o takim numerze", ConsoleColor.Red);
        }
        public static void SaveTask()
        {
            string path = @"data.csv";
            foreach (TaskModel taskmodel in taskList)
            {
                string taskModel = taskmodel.ToString();
                string[] everyElement = taskModel.Split(' ');
                File.WriteAllLines(path, everyElement);

            }
        }

        public static void LoadTask()
        {
            string path = @"data.csv";
            if (File.Exists(path))
            {
                string[] savedTasks = File.ReadAllLines(path);
                foreach (string savedtask in savedTasks)
                {
                    string loadedTask = savedtask.Replace(',', ' ');
                    AddTask(loadedTask);
                }
            }

            ConsoleEx.WriteLine("Brak wskazanego pliku",ConsoleColor.Red);
        }



    }
}





