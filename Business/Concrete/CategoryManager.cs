using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
        }
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
        private IResult CheckIfCategoryExists(string categoryName)
        {
            var result = _categoryDal.GetAll(c => c.CategoryName == categoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckCategoryName);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryCount()
        {
            var result = _categoryDal.GetAll().Count;
            if (result == 5)
            {
                return new ErrorResult(Messages.CheckCategoryCount);
            }
            return new SuccessResult();
        }
    }

   
}
