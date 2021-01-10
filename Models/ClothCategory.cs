using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Georgescu_Diana_Proiect.Models
{
    public class ClothCategory
    {
        public int ID { get; set; }
        public int ClothID { get; set; }
        public Cloth Cloth { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
