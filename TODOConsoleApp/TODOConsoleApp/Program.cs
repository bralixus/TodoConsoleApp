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
                string start = Console.ReadLine();
                if (start == "dodaj")
                {
                    Console.WriteLine("Wpisz nowe zadanie (opis;początek(rrrr.mm.dd);koniec(rrrr.mm.dd); wpisz \"tak\" jeżeli zadanie jest ważne ");
                    string element = Console.ReadLine();
                    string[] everyElement = element.Split(';');
                    string[] date = everyElement[1].Split('.');
                    if (Date.DateCheck(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])) == true)
                    {
                        if (everyElement[2] != null)
                        {
                            string[] dateEnd = everyElement[2].Split('.');
                            if (Date.DateCheck(int.Parse(dateEnd[0]), int.Parse(dateEnd[1]), int.Parse(dateEnd[2])) == true)
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("Błędny format daty zakończenia");
                        }
                        else
                        {
                            //TODO dodać co zrobić z pustym polem daty zakończenia
                        }
                    }

                    Console.WriteLine("Błędny format daty rozpoczęcia");
                }

                if (start == "exit")
                {
                    Console.ReadKey();
                }
                
            }while(true);


            //Console.Write("Podaj opis zadania: ");
            //string descryption = Console.ReadLine();
            //Console.Write("Podaj datę rozpoczęcia zadania (rrrr.mm.dd): ");
            //string startDate = Console.ReadLine();
            //if (startDate != null)
            //{
            //    string[] date1 = startDate.Split('.');
            //    if(Date.DateCheck(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2])))
            //    {
            //        Console.Write("Podaj datę zakończenia zadania zadania (rrrr.mm.dd): ");
            //        string endDate = Console.ReadLine();//tu trzeba inaczej
            //        if (endDate!=null)
            //        {
            //            string allDayTask = null;
            //            string[] date = startDate.Split('.');
            //            if (Date.DateCheck(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])) != false)
            //            {
            //                //iść dalej
            //            }
            //            Console.WriteLine("Nieprawidłowy format daty");

            //        }
            //        else
            //        {
            //            string allDayTask = "tak";
            //            Console.Write("Nie podano daty końcowej. Zostanie dodane zadanie całodniowe.");
            //        }

            //        Console.Write("Jeśli zadanie jest ważne wpisz \"tak\"");
            //        string importantTask = Console.ReadLine();
            //        Console.WriteLine();
            //        Console.WriteLine("Jeśli chcesz dodać kolejne zadanie wciśnij enter.");
            //        Console.WriteLine("Jeśli chcesz zapisać zadanie wpisz \"add\".");
            //        if (Console.ReadLine() == "add")
            //        {
            //            AddTask(descryption, startDate, endDate, allDayTask, importantTask);
            //        }
            //        Console.WriteLine("Jeśli chcesz zakończyć wpisz \"exit\"");
            //        Console.ReadLine();
            //    } while (Console.ReadLine() != "exit") ;

            //    else
            //    {
            //        Console.WriteLine("Nieprawidłowy format daty");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Nieprawidłowy format daty");
            //}





        }
        public static void AddTask(string newTask)
        {
            string[] testGap = newTask.Split(';');

            TaskModel taskModel = new TaskModel(testGap[0], testGap[1], testGap[2], testGap[3], testGap[4]);

            taskList.Add(taskModel);
        }
        private static void Row(List<TaskModel> taskList)
        {

            Console.WriteLine("Twoje zadanie:");
            PrintRow("Opis", "Data Rozpoczęcia", "Data Zakończenia", "Zadanie całodniowe", "Ważność zadania");
            Console.WriteLine("".PadLeft(61, '-'));
            foreach (TaskModel in taskModel in expenses)
            {
                PrintRow(expense.Category, expense.Description, expense.Cost.ToString());
            }

            public static void ShowTask(string showTask)
        {
            Console.Write(category.PadLeft(15));
            Console.Write(" |");
            Console.Write(description.PadLeft(30));
            Console.Write(" |");
            Console.Write(cost.PadLeft(10));
            Console.WriteLine(" |");
        }
        
    }
}
