using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class QuantityCarnetActivation : PurchaseActivation
    {
        public virtual IList<QuantityCarnetSingleActivation> QuantityCarnetSingleActivations{ get; set; } = new List<QuantityCarnetSingleActivation>();
        public int EtrancesLeft { get; set; }
    }
}
