using System;
using System.Collections.Generic;

namespace TODOConsoleApp
{
    public static class Show
    {
        public static void ShowTask(List<TaskModel> taskList)
        {

            Console.WriteLine("Twoje zadania:");
            ShowTask1("Opis", "Data Rozpoczęcia", "Data Zakończenia", "Zadanie całodniowe", "Ważność zadania");
            Console.WriteLine("".PadLeft(61, '-'));
            foreach (TaskModel taskModel in taskList)
            {
                ShowTask1(taskModel.Descryption, taskModel.StartDate.ToString(), taskModel.EndDate.ToString(),
                    taskModel.AllDayTask.ToString(), taskModel.ImportantTask.ToString());
            }
        }

        public static void ShowTask1(string opis, string start, string koniec, string zakres, string waga)
        {
            Console.Write(opis.PadLeft(15));
            Console.Write(" |");
            Console.Write(start.PadLeft(10));
            Console.Write(" |");
            Console.Write(koniec.PadLeft(10));
            Console.Write(" |");
            Console.Write(zakres.PadLeft(5));
            Console.Write(" |");
            Console.Write(waga.PadLeft(5));
            Console.Write(" |");
            Console.WriteLine();
        }
    }
}