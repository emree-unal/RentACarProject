using ReCapProject.Core.DataAccess;

using ReCapProject.Entities;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> expression=null);
        CarDetailDto GetCarDetailsById(Expression<Func<CarDetailDto, bool>> expression = null);
        //List<CarDetailDto> GetCarsDetailsByBrandId(int barndId);

    }
}
