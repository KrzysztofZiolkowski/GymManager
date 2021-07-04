﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Coach> Coaches { get; set; } = new List<Coach>();
        public virtual IList<Room> Rooms { get; set; } = new List<Room>();
    }
}