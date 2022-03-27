using System;
using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTOs;

namespace MvcUI.Models
{
    public class TaskViewModel
    {
        public List<Task> Tasks { get; set; }
    }
}