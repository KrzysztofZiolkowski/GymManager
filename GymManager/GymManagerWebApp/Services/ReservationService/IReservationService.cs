using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.ReservationService
{
    public interface IReservationService
    {
        Task ReserveEventAsync(Customer currentUser, CalendarEvent eventToBook);
        Task<List<Reservation>> GetReservationsByUserAsync(Customer customer);
        Task RemoveReservation(int ReservationId);
    }
}