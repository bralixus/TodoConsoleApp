using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                string start = Console.ReadLine();
                if (start == "dodaj")
                {
                    Console.WriteLine("Wpisz nowe zadanie (opis;początek(rrrr.mm.dd);koniec(rrrr.mm.dd); wpisz \"tak\" jeżeli zadanie jest ważne ");
                    string element = Console.ReadLine();
                    string afterCheck = CommandCheck.elements(element.Trim(';', ' ', '=', '-', '.'));

                    Console.WriteLine("Aby dodać do listy utworzone zadanie, wpisz \"add\"");
                    //Console.WriteLine("Aby dodać kolejne zadanie, wpisz \"dodaj\"");
                    if (Console.ReadLine() == "add")
                    {
                        AddTask(afterCheck);
                        Console.WriteLine("Zadanie zostało dodane do listy zadań");
                        Console.WriteLine("Jeżeli chcesz wyświetlić listę zadań wpisz\"show\"");
                        if (Console.ReadLine() == "show")
                        {
                            Show.ShowTask(taskList);
                        }
                    }
                }

                if (start == "exit")
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

        
    }
}

                
           

        
