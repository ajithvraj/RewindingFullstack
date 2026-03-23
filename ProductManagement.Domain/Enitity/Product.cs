using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Enitity
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 

        public decimal Price { get; set; } 

        public int Stock {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedAt { get; set; }
    }
}
