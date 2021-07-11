using GymManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Data
{
    public class TimeCarnetActivationConfiguration : IEntityTypeConfiguration<TimeCarnetActivation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TimeCarnetActivation> builder)
        {
            builder
                .HasMany(x => x.Reservations)
                .WithOne(x => x.TimeCarnetActivation);
        }
    }



}
