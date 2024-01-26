using System.Text;

namespace WarehouseApp.Entities
{
    public class Equipment : EntityBase
    {

        public string? Name { get; set; }
        public string? Person { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }
        public int? NameLength { get; set; }
        public decimal ListPrice { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new(1024);

            sb.AppendLine($" Name: {Name}  ID: {Id}");
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
