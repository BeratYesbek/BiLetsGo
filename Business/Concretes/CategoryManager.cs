using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entity.Concretes;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<Category> Add(Category category)
        {
            var data = _categoryDal.Add(category);
            if (data is not null)
            {
                return new SuccessDataResult<Category>(data);
            }

            return new ErrorDataResult<Category>(null);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
        }

        public IDataResult<Category> GetById(int id)
        {
            var data = _categoryDal.Get(t => t.Id == id);
            if (data is not null)
            {
                return new SuccessDataResult<Category>(data);
            }

            return new ErrorDataResult<Category>(null);

        }

        public IDataResult<List<Category>> GetAll()
        {
            var data = _categoryDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<Category>>(data);
            }

            return new ErrorDataResult<List<Category>>(null);
        }
    }
}
