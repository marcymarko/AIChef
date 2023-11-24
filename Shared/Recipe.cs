using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChef.Shared
{
    public class Recipe
    {
        public string? title { get; set; }
        public string[]? ingredients { get; set; }
        public string[]? instructions { get; set; }
        public string? summary { get; set; }
    }
}
