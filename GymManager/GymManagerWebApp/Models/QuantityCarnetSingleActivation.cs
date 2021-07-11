using System;

namespace GymManagerWebApp.Models
{
    public class QuantityCarnetSingleActivation
    {
        public int Id { get; set; }
        public DateTime ActivationDate { get; set; }
        public int PurchaseActivationId {get;set;}
        public virtual QuantityCarnetActivation QuantityCarnetActivation { get; set; }
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }

    }
}