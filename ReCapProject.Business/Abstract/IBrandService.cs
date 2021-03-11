using ReCapProject.Core.Utilities.Result;
using ReCapProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAllBrands();
        IDataResult<Brand> GetBrandById(int id);
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
    }
}
