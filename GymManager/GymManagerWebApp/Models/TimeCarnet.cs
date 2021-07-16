using GymManagerWebApp.Models;
using System;
using System.Collections.Generic;

namespace GymManagerWebApp
{
    public class TimeCarnet : Carnet
    {
        public int PeriodInDays { get; set; }
        public TimeCarnet(string type, double price, int periodInDays)
        {
            Type = type;
            Price = price;
            PeriodInDays = periodInDays;
        }
    }
}
