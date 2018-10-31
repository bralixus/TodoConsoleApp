using System;
using System.Security.Cryptography.X509Certificates;

namespace TODOConsoleApp
{
    class TaskModel
    {
        private string _descryption;
        private DateTime _startDate;
        private DateTime _endDate;
        private bool _allDayTask;
        private bool _importantTask;
        
        public TaskModel(string descryption, string startDate, string endDate, string allDayTask, string importantTask )
        {
            Descryption = descryption;
            StartDate = DateTime.Parse(startDate);
            EndDate = DateTime.Parse(endDate);
            AllDayTask = bool.Parse(allDayTask);
            ImportantTask = bool.Parse(importantTask);

        }

        public string Descryption { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public bool AllDayTask
        {
            get { return _allDayTask;}
            set
            {
                if (_endDate == null)
                {
                    _allDayTask = true;
                }
                
            }
        }
        
        public bool ImportantTask { get; set; }
    }
}