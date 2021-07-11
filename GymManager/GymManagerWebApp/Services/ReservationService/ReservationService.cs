using GymManagerWebApp.Data;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly GymManagerContext _dbContext;

        public ReservationService(GymManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Reservation>> GetReservationsByUserAsync(Customer customer)
        {
            var reservations = await _dbContext.Reservations
            .Where(x => x.Customer == customer)
            .Include(x=>x.CalendarEvent)
            .Include(x=>x.Customer)
            .ToListAsync();

            return reservations;
        }

        public async Task ReserveEventAsync(Customer currentCustomer, CalendarEvent eventToBook)
        {
            var reservation = new Reservation()
            {
                ActivationDate = DateTime.UtcNow,
                CanBeCanceled = true,
                IsActive = true,
                Customer = currentCustomer,
                CalendarEvent = eventToBook,
            };

            await _dbContext.Reservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveReservation(int ReservationId)
        {
            var reservation = await _dbContext.Reservations.FindAsync(ReservationId);
            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();
        }

    }
}