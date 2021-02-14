﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.FrontEnd.Menu
{
    class MenuExercisesWithFiltering : MenuCommonLibrary
    {
        public MenuExercisesWithFiltering()
        {
            _positions.Add(1, "Dostępne zajęcia na silowni, filtrowane po dacie i godzinie");
            _positions.Add(2, "Dostępne zajęcia na silowni, filtrowane po typie zajęć");
            _positions.Add(3, "Dostępne zajęcia na silowni, filtrowane wg prowadzącego");
            _positions.Add(4, "Wyjście do menu głównego");
        }
    }
}