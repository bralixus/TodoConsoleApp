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
            Console.WriteLine("MENEDŻER ZADAŃ TODO");
            Console.WriteLine();
            do
            {
                Console.WriteLine("Jeśli chcesz dodać nowe zadanie, wpisz \"dodaj\"");
                Console.WriteLine("Jeśli chcesz opuścić program, wpisz \"exit\"");
                
                if (Console.ReadLine() == "dodaj")
                {
                    Console.WriteLine("Wpisz nowe zadanie (opis;początek(rrrr.mm.dd);koniec(rrrr.mm.dd); wpisz \"tak\" jeżeli zadanie jest ważne ");
                    string element = Console.ReadLine();
                    string afterCheck = CommandCheck.elements(element.Trim(';', ' ', '=', '-', '.'));

                    Console.WriteLine("Aby dodać do listy utworzone zadanie, wpisz \"add\"");
                    
                    if (Console.ReadLine() == "add")
                    {
                        AddTask(afterCheck);
                        Console.WriteLine("Zadanie zostało dodane do listy zadań");
                        Console.WriteLine();
                        Console.WriteLine("Aby dodać kolejne zadanie, wpisz \"dodaj\"");
                        Console.WriteLine("Jeżeli chcesz usunąć zadanie, wpisz \"remove\"");
                        if (Console.ReadLine() == "dodaj")
                        {
                            return;//jak wrócić do dodawania zadań
                        }
                        if (Console.ReadLine() == "remove")
                        {
                            RemoveTask();
                        }
                        Console.WriteLine("Jeżeli chcesz wyświetlić listę zadań wpisz\"show\"");
                        if (Console.ReadLine() == "show")
                        {
                            int i = 1;
                            foreach (var taskModel in taskList)
                            {
                                Console.WriteLine($"{i}. {taskModel}");
                                i++;
                            }
                            
                            Console.WriteLine();
                            Console.WriteLine("Aby zapisać zadanie wpisz\"save\"");
                            if (Console.ReadLine() == "save")
                            {
                                SaveTask();
                                Console.WriteLine("Aby wyświetlić zapisane zadania, wpisz\"load\"");
                                if (Console.ReadLine() == "load")
                                {
                                    LoadTask();
                                }

                                return;
                            }
                            
                        }

                    }
                    Console.WriteLine("Błędna komenda");
                }

                if (Console.ReadLine() == "exit")
                {
                    return;
                }


            } while (true);
        }


        public static void AddTask(string newTask)
        {
                string[] testField = newTask.Split(';');

                TaskModel taskModel = new TaskModel(testField[0], testField[1], testField[2], testField[3], testField[4]);

                taskList.Add(taskModel);

        }

        public static void RemoveTask()
        {
            int i = 1;
            foreach (var taksModel in taskList)
            {
                Console.WriteLine($"{i}. {taksModel}");
                i++;
            }

            Console.Write("Wpisz numer zadania do usunięcia:");
            if (int.Parse(Console.ReadLine()) <= taskList.Count)
            {
                taskList.RemoveAt(int.Parse(Console.ReadLine() +1));
                Console.WriteLine("Zadanie zostało usunięte");
            }

            Console.WriteLine("Brak zadania o takim numerze");
        }
        public static void SaveTask()
        {
            string path = @"data.csv";
            foreach (TaskModel taskmodel in taskList)
            {
                string taskModel = taskmodel.ToString();
                string[] everyElement = taskModel.Split(';');
                File.WriteAllLines(path, everyElement);

            }
        }

        public static void LoadTask()
        {
            string path = @"data.csv";
            bool exist = File.Exists(path);
            if (exist == true)
            {
                string[] savedTasks = File.ReadAllLines(path);
                foreach (var savedtask in savedTasks)
                {
                    savedtask.Replace(",", ";");
                    //taskList.Add(savedtask);//Co wpisać, aby dodało się do listy
                }
            }

            Console.WriteLine("Brak wskazanego pliku");
        }


        
    }
}

                
           

        
