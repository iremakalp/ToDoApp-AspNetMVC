using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Task = Entities.Concrete.Task;

namespace MvcUI.Controllers
{
    public class HomeController : Controller
    {
        ITaskService _taskService;
        TaskViewModel _taskViewModel;
        public HomeController(ITaskService taskService, TaskViewModel taskViewModel)
        {
            _taskService = taskService;
            _taskViewModel = taskViewModel;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var resultTask = _taskService.GetAll();
            _taskViewModel.Tasks = resultTask.Data;
            if (resultTask.Success)
            {
                return View(_taskViewModel);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Add(string taskContent)
        {
            Task task = new Task();
            task.Status = true;
            task.Date=DateTime.Now;
            task.TaskContent = taskContent;
            var result = _taskService.Add(task);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(int taskId)
        {

            var resultTask = _taskService.GetAll().Data.SingleOrDefault(t => t.Id == taskId);
            if (resultTask.Status==true)
            {
                resultTask.Status = false;
                var result = _taskService.Update(resultTask);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
            }
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int taskId)
        {
            
            var resultTask = _taskService.GetAll().Data.SingleOrDefault(t => t.Id == taskId);
            var result = _taskService.Delete(resultTask);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
