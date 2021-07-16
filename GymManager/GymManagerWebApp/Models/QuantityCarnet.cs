﻿using GymManagerWebApp.Models;
using System;
using System.Collections.Generic;

namespace GymManagerWebApp
{
    public class QuantityCarnet : Carnet
    {
        public int TotalEtrances { get; set; }
        public QuantityCarnet(int id, string type, double price, int totalEtrances)
        {
            Id = id;
            Type = type;
            Price = price;
            TotalEtrances = totalEtrances;
        }
        
    }
}
