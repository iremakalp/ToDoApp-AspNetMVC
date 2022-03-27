using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Task:IEntity
    {
        public int Id { get; set; }
        public string TaskContent { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

    }
}