using ReCapProject.Core.DataAccess;
using ReCapProject.Entities;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
       List<RentalDetailDto> GetRentalDetails();
        Rental GetLastRental(int cardId);
    }
}
