using GymManagerWebApp.Models;
using GymManagerWebApp.ModelViews;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.CarnetService
{
    public interface ICarnetService
    {
        Task BuyCarnetAsync(int carnetId, string customerId);
        Task<CarnetsOfferViewModel> GetCarnetOfferAsync();
        Task<PurchasedCarnetsViewModel> GetPurchasedCarnetsAsync(string customerId);
    }
}
