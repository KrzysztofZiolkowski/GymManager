using System;

namespace GymManagerWebApp.Models
{
    public class QuantityCarnetActivation
    {
        public int Id { get; set; }
        public DateTime ActivationDate { get; set; }
        public int PurchaseActivationId {get;set;}
        public virtual QuantityCarnet QuantityCarnet { get; set; }
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }

    }
}