using ReCapProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CustomerNameSurname { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
