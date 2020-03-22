using System;
using System.Collections.Generic;

namespace Kursova.DAL.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Grade { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public bool IsDone { get; set; }
        public List<TaskChanges> Changes { get; set; }


    }
}
