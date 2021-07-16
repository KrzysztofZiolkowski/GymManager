using GymManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Data
{
    public class QuantityCarnetActivationConfiguration : IEntityTypeConfiguration<QuantityCarnetActivation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<QuantityCarnetActivation> builder)
        {
            builder
                .HasMany(x => x.QuantityCarnetSingleActivations)
                .WithOne(x => x.QuantityCarnetActivation)
                .HasForeignKey(x => x.PurchaseActivationId);
        }
    }



}
