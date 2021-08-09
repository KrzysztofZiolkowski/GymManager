using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.ModelViews
{
    public class CarnetsOfferViewModel
    {
        public virtual IList<Carnet> QuantityCarnets { get; set; } = new List<Carnet>();
    }
}
