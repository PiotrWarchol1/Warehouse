using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApp.Entities;

namespace WarehouseApp1.Entities
{
    public class Helmet : EntityBase
    {
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }
        public int? NameLength { get; set; }
        public decimal ListPrice { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new(1024);

            sb.AppendLine($"{Name}  ID: {Id}");
            sb.AppendLine($" Color: {Color}  Type: {(Type ?? "n/a")}");
            sb.AppendLine($" Price: {ListPrice:c}");
            if (NameLength.HasValue)
            {
                sb.AppendLine($"  Name Length: {NameLength}");
            }
            return sb.ToString();
        }
    }
}
