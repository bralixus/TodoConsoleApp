using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
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
                Console.Write("Podaj opis zadania: ");
                string descryption = Console.ReadLine();
                Console.Write("Podaj datę rozpoczęcia zadania (rrrr.mm.dd): ");
                string startDate = Console.ReadLine();
                if (startDate != null)
                {
                    string[] date = startDate.Split('.');
                    if(Date.DateCheck(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])) == false)
                    {
                        Console.WriteLine("Nieprawidłowy format daty");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy format daty");
                }
                Console.Write("Podaj datę zakończenia zadania zadania (rrrr.mm.dd): ");
                string endDate = Console.ReadLine();
                if (endDate != null)
                {
                    string[] date = startDate.Split('.');
                    if (Date.DateCheck(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])) == false)
                    {
                        Console.WriteLine("Nieprawidłowy format daty");
                    }

                }
                else
                {
                    Console.Write("Podaj, czy jest to zadanie całodniowe (tak/nie): ");
                    string allDayTask = Console.ReadLine();
                }
                
                Console.Write("Jeśli zadanie jest ważne wpisz \"tak\"");
                string importantTask = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Jeśli chcesz dodać kolejne zadanie wciśnij enter.");
                Console.WriteLine("Jeśli chcesz zapisać zadanie wpisz \"add\".");
                if (Console.ReadLine() == "add")
                {
                    AddTask(descryption, startDate, endDate, allDayTask, importantTask);
                }
                Console.WriteLine("Jeśli chcesz zakończyć wpisz \"exit\"");
                Console.ReadLine();
            } while (Console.ReadLine() != "exit");

            


        }
        public static void AddTask(string descryption, string startDate, string endDate, string allDayTask, string importantTask)
        {
            TaskModel taskModel = new TaskModel(descryption, startDate, endDate, allDayTask, importantTask);

            taskList.Add(taskModel);
        }
        
    }
}
