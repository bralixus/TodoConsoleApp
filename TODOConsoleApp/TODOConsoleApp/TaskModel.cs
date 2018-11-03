using System;
using System.Security.Cryptography.X509Certificates;

namespace TODOConsoleApp
{
    public class TaskModel
    {
        private string _descryption;
        private DateTime _startDate;
        private DateTime _endDate;
        private bool _allDayTask;
        private bool _importantTask;
        
        public TaskModel(string descryption, string startDate, string endDate, string allDayTask, string importantTask )
        {
            Descryption = descryption;
            StartDate  = DateTime.Parse(startDate);
            if (endDate == "")
            {
                //EndDate = DateTime.Parse(endDate);
                AllDayTask = true;
                if (importantTask == "true")
                {
                    ImportantTask = true;
                }
                else
                {
                    ImportantTask = false;
                }
            }
            else
            {
                EndDate = DateTime.Parse(endDate);
                AllDayTask = false;
                if (importantTask == "true")
                {
                    ImportantTask = true;
                }
                else
                {
                    ImportantTask = false;
                }
            }
            
        }

        public string Descryption { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate {get;set;}

        public bool AllDayTask { get; set; }
        
        public bool ImportantTask { get; set; }
    }
}