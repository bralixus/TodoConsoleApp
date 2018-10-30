using System.Security.Cryptography.X509Certificates;

namespace TODOConsoleApp
{
    class TaskModel
    {
        
        public TaskModel(string descryption, string startDate, string endDate, string allDayTask, string importantTask )
        {
            Descryption = descryption;
            StartDate = startDate;
            EndDate = endDate;
            AllDayTask = allDayTask;
            ImportantTask = importantTask;

        }

        public string Descryption { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string AllDayTask { get; set; }
        public string ImportantTask { get; set; }
        

    }
}