using GymManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp
{
    public class Carnet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalEtrances { get; set; }
        public double Price {get; set;}

        public Carnet(string name, double price, int totalEtrances)
        {
            Name = name;
            Price = price;
            TotalEtrances = totalEtrances;
        }

    }
}
