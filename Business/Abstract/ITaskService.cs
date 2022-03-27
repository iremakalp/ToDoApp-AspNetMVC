using System.Collections.Generic;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ITaskService
    {
        IDataResult<Task> Get();
        IDataResult<List<Task>> GetAll();
        IResult Add(Task task);
        IResult Delete(Task task);
        IResult Update(Task task);
        IDataResult<List<Task>> GetByStatus(bool status);
    }
}