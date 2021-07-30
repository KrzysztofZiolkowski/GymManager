using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.ModelViews
{
    public class CarnetsOfferViewModel
    {
        public virtual IList<TimeCarnet> TimeCarnets { get; set; } = new List<TimeCarnet>();
        public virtual IList<QuantityCarnet> QuantityCarnets { get; set; } = new List<QuantityCarnet>();
    }
}
