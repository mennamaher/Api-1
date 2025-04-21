﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.OrderModule
{
    public record DeliveryMethodDto
    {
        public int Id { get; init; }
        public string ShortName { get; init; }
        public string Description { get; init; }
        public string DeliveryTime { get; init; }
        public decimal Price { get; init; }
    }
}
