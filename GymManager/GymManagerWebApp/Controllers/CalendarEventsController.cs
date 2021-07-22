using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using GymManagerWebApp.Services;
using GymManagerWebApp.Services.ReservationService;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using GymManagerWebApp.Services.CarnetService;
using GymManagerWebApp.Data;

namespace GymManagerWebApp.Controllers
{
    public class CalendarEventsController : Controller
    {
        private readonly ICalendarEventService _calendarEventService;
        private readonly IReservationService _reservationService;
        private readonly IUserService _userService;
        private readonly ICarnetService _carnetService;
        private readonly GymManagerContext _dbContext;

        public CalendarEventsController(ICalendarEventService calendarEventService, IReservationService reservationService, UserManager<User> userManager, IUserService userService, ICarnetService carnetService, GymManagerContext dbContext)
        {
            _calendarEventService = calendarEventService;
            _reservationService = reservationService;
            _userService = userService;
            _carnetService = carnetService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> AvailableEvents()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await _userService.GetUserByIdAsync(currentUserId);
            var model = new CalendarEventViewModel();

            model.CalendarEvents = await _calendarEventService.GetAllEvents();
            model.Reservations = await _reservationService.GetReservationsByUserAsync(currentUser);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(int eventId)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await _userService.GetUserByIdAsync(currentUserId);
            var selectedEvent = await _calendarEventService.GetEventByIdAsync(eventId);


            return View("Confirmations/BookEventConfirmation");
        }

        [HttpPost]
        public async Task<IActionResult> CancelReservation(int reservationNr)
        {
            var eventId = await _calendarEventService.GetEventIdByReservationIdAsync(reservationNr);

            await _reservationService.RemoveReservation(reservationNr);
            await _calendarEventService.IncreaseAvailableVacanciesAsync(eventId);

            return View("Confirmations/CancelEventConfirmation");
        }

    }
}
