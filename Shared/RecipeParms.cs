﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChef.Shared
{
    public class RecipeParms
    {
        public string? Mealtime { get; set; } = "Breakfast";
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public string? SelectedIdea { get; set; }
    }
}
