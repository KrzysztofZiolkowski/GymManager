using GymManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp
{
    public class TimeCarnet : Carnet
    {
        public DateTime ActiveUntil { get; set; }
    }

    public class QuantityCarnet : Carnet
    {
        public int Etrances { get; set; }
        public int RemainEtrances { get; set; }
        public DateTime ActivationDates { get; set; }    
    }

    public class Carnet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime PurchasedAt { get; set; }
        public DateTime? ActivatedOn { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public bool Activated { get; set; }
        public virtual User User { get; set; }
        public Carnet()
        {
        }
    }
}
