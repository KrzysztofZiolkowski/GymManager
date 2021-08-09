using GymManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Data
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Purchase> builder)
        {
        }

        public void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Purchase>()
                .Property(x => x.Customer)
                .ValueGeneratedOnAdd();
        }
    }



}
