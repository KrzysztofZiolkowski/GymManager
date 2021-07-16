﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Room
    {
        public Room(int id, int number, int maxCustomersCapacity)
        {
            Id = id;
            Number = number;
            MaxCustomersCapacity = maxCustomersCapacity;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public int MaxCustomersCapacity { get; set; }
        public virtual IList<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
