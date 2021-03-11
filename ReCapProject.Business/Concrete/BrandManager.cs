using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Core.Aspects.Autofac.Validation;
using ReCapProject.Core.Utilities.Result;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            this.brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAllBrands()
        {
            return new SuccessDataResult<List<Brand>>(brandDal.GetAll(),Messages.BrandsListed);
            
        }

        public IDataResult<Brand> GetBrandById(int id)
        {
           
            return new SuccessDataResult<Brand>(brandDal.Get(x => x.BrandId == id));
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            brandDal.Update(brand);
            return new SuccessResult(Messages.BrandModified);
        }
    }
}
