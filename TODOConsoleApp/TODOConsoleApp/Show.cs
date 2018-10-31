using System;
using System.Collections.Generic;

namespace TODOConsoleApp
{
    public static class Show
    {
        private static void ShowTask(List<TaskModel> taskList)
        {

            Console.WriteLine("Twoje zadania:");
            ShowTask("Opis", "Data Rozpoczęcia", "Data Zakończenia", "Zadanie całodniowe", "Ważność zadania");
            Console.WriteLine("".PadLeft(61, '-'));
            foreach (TaskModel taskModel in taskList)
            {
                ShowTask(taskModel.Descryption, taskModel.StartDate.ToString(), taskModel.EndDate.ToString(),
                    taskModel.AllDayTask.ToString(), taskModel.ImportantTask.ToString());
            }
        }

        public static void ShowTask(string opis, string start, string koniec, string zakres, string waga)
        {
            Console.Write(opis.PadLeft(15));
            Console.Write(" |");
            Console.Write(start.PadLeft(30));
            Console.Write(" |");
            Console.Write(koniec.PadLeft(10));
            Console.WriteLine(" |");
            Console.Write(zakres.PadLeft(10));
            Console.WriteLine(" |");
            Console.Write(waga.PadLeft(10));
            Console.WriteLine(" |");
        }
    }
}