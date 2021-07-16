using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Data
{
    public class GymManagerContext : IdentityDbContext<User>
    {
        public GymManagerContext(DbContextOptions<GymManagerContext> options): base(options){}
        public GymManagerContext(){ }

        public override DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TimeCarnet> TimeCarnets { get; set; }
        public DbSet<QuantityCarnet> QuantityCarnets { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Carnet> Carnets { get; set; }
        public DbSet<PurchaseActivation> PurchaseActivations { get; set; }
        public DbSet<TimeCarnetActivation> TimeCarnetActivations { get; set; }
        public DbSet<QuantityCarnetActivation> QuantityCarnetAcitvations { get; set; }
        public DbSet<QuantityCarnetSingleActivation> QuantityCarnetSingleActivations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=GymManager;Integrated Security=true;");
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        }
    }
}
