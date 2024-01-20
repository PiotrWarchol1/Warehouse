using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApp.Entities;

namespace WarehouseApp1.Entities
{
    public class Helmet : Equipment
    {
        public string? Type { get; set; }
        public string? Color { get; set; }
        public string? Name { get; set; }
        public decimal ListPrice { get; set; }

        public override string ToString() => $"Id: {Id}, Type: {Type}, Name: {Name}, ListPrice: {ListPrice}, Color: {Color}";
    }
}
