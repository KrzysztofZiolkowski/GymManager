using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class PurchasedCarnetsViewModel
    {
        public List<TimeCarnet> TimeCarnets { get; set; }
        public List<QuantityCarnet> QuantityCarnets { get; set; }
    }
}
