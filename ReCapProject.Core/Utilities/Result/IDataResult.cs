using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.Utilities.Result
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
