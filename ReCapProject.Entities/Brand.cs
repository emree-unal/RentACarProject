using ReCapProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Entities
{
    public class Brand:IEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
