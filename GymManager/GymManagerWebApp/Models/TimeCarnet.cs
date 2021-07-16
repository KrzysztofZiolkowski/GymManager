using GymManagerWebApp.Models;
using System;
using System.Collections.Generic;

namespace GymManagerWebApp
{
    public class TimeCarnet : Carnet
    {
        public int PeriodInDays { get; set; }
        public TimeCarnet(int id, string type, double price, int periodInDays)
        {
            Id = id;
            Type = type;
            Price = price;
            PeriodInDays = periodInDays;
        }
    }
}
