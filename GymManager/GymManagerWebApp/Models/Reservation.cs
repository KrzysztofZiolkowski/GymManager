using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Reservation
    {
        public Reservation()
        {
        }

        public Reservation(DateTime activationDate, bool canBeCanceled, bool isActive, Customer customer, CalendarEvent calendarEvent)
        {
            ActivationDate = activationDate;
            CanBeCanceled = canBeCanceled;
            IsActive = isActive;
            Customer = customer;
            CalendarEvent = calendarEvent;
        }

        public int Id { get; set; }
        public DateTime ActivationDate { get; set; }
        public bool CanBeCanceled { get; set; }
        public bool IsActive { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CalendarEvent CalendarEvent { get; set; }
        public virtual TimeCarnetActivation TimeCarnetActivation {get;set;}
        public virtual QuantityCarnetSingleActivation QuantityCarnetSingleActivation { get; set; }

    }
}
