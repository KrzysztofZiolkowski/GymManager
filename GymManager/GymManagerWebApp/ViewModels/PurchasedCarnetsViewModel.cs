using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class PurchasedCarnetsViewModel
    {
        public virtual IList<TimeCarnet> QuantityCarnets { get; set; } = new List<TimeCarnet>();
        public virtual IList<QuantityCarnet> TimeCarnets { get; set; } = new List<QuantityCarnet>();
    }
}
