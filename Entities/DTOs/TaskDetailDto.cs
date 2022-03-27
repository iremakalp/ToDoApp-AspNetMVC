using System;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class TaskDetailDto:IDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string TaskContent { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}