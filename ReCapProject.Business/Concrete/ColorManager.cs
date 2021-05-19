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
    public class ColorManager : IColorService
    {
        private IColorDal colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this.colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color color)
        {
            colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAllColors()
        {
            return new SuccessDataResult<List<Color>>(colorDal.GetAll(),Messages.ColorsListed);
        }

        public IDataResult<List<Color>> GetColorByColorName(string colorName)
        {
            return new SuccessDataResult<List<Color>>(colorDal.GetAll(x => x.ColorName == colorName));
        }

        public IDataResult<Color> GetColorById(int id)
        {
          
            return new SuccessDataResult<Color>(colorDal.Get(x => x.ColorId == id));
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
             colorDal.Update(color);
            return new SuccessResult(Messages.ColorModified);
        }
    }
}
