﻿using GymManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp
{
 public abstract class Carnet
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

    }
}