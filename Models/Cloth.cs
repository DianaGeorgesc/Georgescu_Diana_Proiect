using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Georgescu_Diana_Proiect.Models
{
    public class Cloth
    {
        public int ID { get; set; }
        [Required, StringLength(250, MinimumLength = 5)]

        public string ClothingItem { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }
        public int SizeID { get; set; }
        public Size Size { get; set; }
        public ICollection<ClothCategory> ClothCategories { get; set; }
    }
}
