using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Data;
using GymManagerWebApp.Models;
using GymManagerWebApp.ModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GymManagerWebApp.Services.CarnetService
{
    public class CarnetService : ICarnetService
    {
        private readonly GymManagerContext _dbContext;

        public CarnetService(GymManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarnetsOfferViewModel> GetCarnetOfferAsync()
        {
            return new CarnetsOfferViewModel()
            {
                QuantityCarnets = await _dbContext.QuantityCarnets.ToListAsync(),
                TimeCarnets = await _dbContext.TimeCarnets.ToListAsync(),
            };
        }
       public async Task BuyCarnetAsync(int carnetId, string customerId)
        {
            var purchasedCarnet = await _dbContext.Carnets.FindAsync(carnetId);
            var currentCustomer = (Customer) await _dbContext.Users.FindAsync(customerId);
            var purchaseExpireMonthsLimit = 12;

            var purchase = new Purchase()
            {
                Customer = currentCustomer,
                Carnet = purchasedCarnet,
                Date = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddMonths(purchaseExpireMonthsLimit),
                IsExpired = false
            };

            _dbContext.Purchases.Attach(purchase);
            await _dbContext.SaveChangesAsync();
        }
 
        public async Task<PurchasedCarnetsViewModel> GetPurchasedCarnetsAsync(string customerId)
        {
            var timeCarnets = await _dbContext.Purchases
                .Where(x => x.Customer.Id == customerId)
                .OfType<TimeCarnet>()
                .ToListAsync();

            var quantityCarnets = await _dbContext.Purchases
                .Where(x => x.Customer.Id == customerId)
                .OfType<QuantityCarnet>()
                .ToListAsync();

            return new PurchasedCarnetsViewModel()
            {
                TimeCarnets = timeCarnets,
                QuantityCarnets = quantityCarnets,
            };
        }
    }
}

