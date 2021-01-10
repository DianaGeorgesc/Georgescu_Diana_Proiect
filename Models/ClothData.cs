using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Georgescu_Diana_Proiect.Models
{
    public class ClothData
    {
        public IEnumerable<Cloth> Clothes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ClothCategory> ClothCategories { get; set; }

    }
}
