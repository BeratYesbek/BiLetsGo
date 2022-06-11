using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Aspects;
using Business.Validation;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(CategoryValidator))]
        [SecuredOperation("Admin,SuperAdmin")]
        public IDataResult<Category> Add(Category category)
        {
            var data = _categoryDal.Add(category);
            if (data is not null)
            {
                return new SuccessDataResult<Category>(data);
            }

            return new ErrorDataResult<Category>(null);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        [SecuredOperation("Admin,SuperAdmin")]
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }

        [SecuredOperation("Admin,SuperAdmin")]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<Category> GetById(int id)
        {
            var data = _categoryDal.Get(t => t.Id == id);
            if (data is not null)
            {
                return new SuccessDataResult<Category>(data);
            }

            return new ErrorDataResult<Category>(null);

        }
        [SecuredOperation("User,Admin,SuperAdmin")]
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
