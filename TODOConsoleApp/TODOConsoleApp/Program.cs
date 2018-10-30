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
                Console.WriteLine("Jeśli chcesz dodać nowe zadanie, wpisz \"dodaj\"");
                Console.WriteLine("Jeśli chcesz opuścić program, wpisz \"exit\"");
                string task = Console.ReadLine();
                if (task == "dodaj")
                {
                    Console.WriteLine("Wpisz nowe zadanie (opis;data rozpoczęcia;data zakończenia;ważność zadania");
                }


                Console.Write("Podaj opis zadania: ");
                string descryption = Console.ReadLine();
                Console.Write("Podaj datę rozpoczęcia zadania (rrrr.mm.dd): ");
                string startDate = Console.ReadLine();
                if (startDate != null)
                {
                    string[] date1 = startDate.Split('.');
                    if(Date.DateCheck(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2])))
                    {
                        Console.Write("Podaj datę zakończenia zadania zadania (rrrr.mm.dd): ");
                        string endDate = Console.ReadLine();//tu trzeba inaczej
                        if (endDate!=null)
                        {
                            string allDayTask = null;
                            string[] date = startDate.Split('.');
                            if (Date.DateCheck(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])) != false)
                            {
                                //iść dalej
                            }
                            Console.WriteLine("Nieprawidłowy format daty");

                        }
                        else
                        {
                            string allDayTask = "tak";
                            Console.Write("Nie podano daty końcowej. Zostanie dodane zadanie całodniowe.");
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
                    } while (Console.ReadLine() != "exit") ;
                
                    else
                    {
                        Console.WriteLine("Nieprawidłowy format daty");
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy format daty");
                }
                

            


        }
        public static void AddTask(string descryption, string startDate, string endDate, string allDayTask, string importantTask)
        {
            TaskModel taskModel = new TaskModel(descryption, startDate, endDate, allDayTask, importantTask);

            taskList.Add(taskModel);
        }
        
    }
}
