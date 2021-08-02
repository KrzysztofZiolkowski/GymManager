using GymManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Data
{
    public class QuantityCarnetSingleActivationConfiguration : IEntityTypeConfiguration<QuantityCarnetActivation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<QuantityCarnetActivation> builder)
        {
            builder
                .HasOne(x => x.Reservation)
                .WithOne(x => x.QuantityCarnetSingleActivation)
                .HasForeignKey<QuantityCarnetActivation>(x => x.ReservationId);
        }
    }



}
