using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }   = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public int Stock { get; set; } 



    }
}
