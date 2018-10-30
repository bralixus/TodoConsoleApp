using System;
using System.Security.Cryptography.X509Certificates;

namespace TODOConsoleApp
{
    class TaskModel
    {
        public string Descryption { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AllDayTask { get; set; }
        public string ImportantTask { get; set; }

        public TaskModel(string descryption, string startDate, string endDate, string allDayTask, string importantTask )
        {
            Descryption = descryption;
            StartDate = DateTime.Parse(startDate);
            EndDate = DateTime.Parse(endDate);
            AllDayTask = allDayTask;
            ImportantTask = importantTask;

        }

    }
}