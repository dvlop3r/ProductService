using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string  Name{ get; set; }
        public string Description{ get; set; }
        public double Price{ get; set; }
        public int CategoryID { get; set; }
    }
}
