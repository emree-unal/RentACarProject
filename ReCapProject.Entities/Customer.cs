using ReCapProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Entities
{
    public class Customer:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
