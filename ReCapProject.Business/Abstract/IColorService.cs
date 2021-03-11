using ReCapProject.Core.Utilities.Result;
using ReCapProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAllColors();
        IDataResult<Color> GetColorById(int id);
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
    }
}
