﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarBrandDetailDto:IDto
    {
        public int BrandId { get; set; }
        public int CarId { get; set; }
        public int RentalId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
