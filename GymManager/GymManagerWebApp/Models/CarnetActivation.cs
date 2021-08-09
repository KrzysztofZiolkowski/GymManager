using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class CarnetActivation
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Carnet Carnet { get; set; }
        public Purchase Purchase { get; set; }
        public Reservation Reservation { get; set; }

    }
}
