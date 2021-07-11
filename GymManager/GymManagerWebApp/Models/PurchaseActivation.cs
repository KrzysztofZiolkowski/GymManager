using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public abstract class PurchaseActivation
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }
        public bool IsActive { get; set; }
        public bool IsExploited { get; set; }
    }
}
