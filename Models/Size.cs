using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Georgescu_Diana_Proiect.Models
{
    public class Size
    {
        public int ID { get; set; }
        public string SizeName { get; set; }
        public ICollection<Cloth> Clothes { get; set; }
    }
}
