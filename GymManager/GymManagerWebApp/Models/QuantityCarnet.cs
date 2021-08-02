using GymManagerWebApp.Models;
using System;
using System.Collections.Generic;

namespace GymManagerWebApp
{
    public class QuantityCarnet : CarnetOffer
    {
        public int TotalEtrances { get; set; }
        public virtual IList<QuantityCarnetActivation> QuantityCarnetActivations { get; set; } = new List<QuantityCarnetActivation>();
        public QuantityCarnet(string categoryName, double price, int totalEtrances)
        {
            CategoryName = categoryName;
            Price = price;
            TotalEtrances = totalEtrances;
        }
        
    }
}
