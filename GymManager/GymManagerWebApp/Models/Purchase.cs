using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Purchase
    {
        public Purchase()
        {
        }

        public int Id { get; set; }
        public virtual CarnetOffer Carnet { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PurchaseActivation Activation { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsExpired { get; set; }

    }
}
