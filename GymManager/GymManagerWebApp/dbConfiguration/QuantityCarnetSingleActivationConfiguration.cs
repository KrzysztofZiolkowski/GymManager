using GymManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Data
{
    public class QuantityCarnetSingleActivationConfiguration : IEntityTypeConfiguration<QuantityCarnetSingleActivation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<QuantityCarnetSingleActivation> builder)
        {
            builder
                .HasOne(x => x.Reservation)
                .WithOne(x => x.QuantityCarnetSingleActivation)
                .HasForeignKey<QuantityCarnetSingleActivation>(x => x.ReservationId);
        }
    }



}
