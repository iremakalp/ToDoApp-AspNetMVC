using System.Collections.Generic;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class TaskManager:ITaskService
    { 
        ITaskDal _taskDal;
        public TaskManager(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }

        public IDataResult<Task> Get()
        {
            var result = _taskDal.Get();
            return new SuccessDataResult<Task>(result);
        }

        public IDataResult<List<Task>> GetAll()
        {
           var result= _taskDal.GetAll();
           return new SuccessDataResult<List<Task>>(result);

        }
        [ValidationAspect(typeof(TaskValidator))]
        public IResult Add(Task task)
        {
            _taskDal.Add(task);
            return new SuccessResult();
        }
        public IResult Delete(Task task)
        {
            _taskDal.Delete(task);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(TaskValidator))]
        public IResult Update(Task task)
        {
            _taskDal.Update(task);
            return new SuccessResult();
        }
        public IDataResult<List<Task>> GetByStatus(bool status)
        {
            var result = _taskDal.GetAll(t => t.Status == status);
            return new SuccessDataResult<List<Task>>(result);
        }
    }
}