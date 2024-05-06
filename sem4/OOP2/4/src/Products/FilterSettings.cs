using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.src.Products
{
    public class FilterSettings
    {
        public Sneaker.Brands? Brand { get; set; } = null;
        public string? Color { get; set; } = null;
        public ushort? Size { get; set; } = null;
        public ushort? MaxPrice { get; set; } = null;
        public string? Name { get; set; } = null;
        public FilterSettings() { }
    }
}
