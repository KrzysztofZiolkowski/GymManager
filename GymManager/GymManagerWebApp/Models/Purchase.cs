using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ActivationDeadline { get; set; }
        public bool WasActivated { get; set; }
        public bool IsActive { get; set; }
        public bool IsExpired { get; set; }
        public int RemainCarnets { get; set; }
        public virtual Carnet Carnet { get; set; }
        public virtual Customer Customer { get; set; }
        public List<CarnetActivation> ActiveCarnets { get; set; }
    }
}
