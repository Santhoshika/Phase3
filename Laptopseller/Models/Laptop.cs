using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptopseller.Models
{
    public class Laptop
    {

        public int LaptopID { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string specifictaions { get; set; }
    }
}
