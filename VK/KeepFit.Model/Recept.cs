using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Model
{
    public class Recept
    {
        public string Name { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
