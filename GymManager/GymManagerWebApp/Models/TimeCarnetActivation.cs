using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class TimeCarnetActivation : PurchaseActivation
    {
        public DateTime ActiveUntil { get; set; }
        public DateTime ActivationDate { get; set; }
        public virtual IList<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
