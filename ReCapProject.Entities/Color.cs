using ReCapProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Entities
{
    public class Color:IEntity
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
