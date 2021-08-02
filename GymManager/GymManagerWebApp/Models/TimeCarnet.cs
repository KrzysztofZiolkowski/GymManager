using GymManagerWebApp.Models;
using System;
using System.Collections.Generic;

namespace GymManagerWebApp
{
    public class TimeCarnet : CarnetOffer
    {
        public int PeriodInDays { get; set; }
        public TimeCarnetActivation TimeCarnetActivation {get;set;}
        public TimeCarnet(string categoryName, double price, int periodInDays)
        {
            CategoryName = categoryName;
            Price = price;
            PeriodInDays = periodInDays;
        }
    }
}
