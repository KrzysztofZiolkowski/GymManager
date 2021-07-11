using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Customer : User
    {
        public virtual IList<Purchase> Purchases { get; set; } = new List<Purchase>();
        public virtual IList<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
