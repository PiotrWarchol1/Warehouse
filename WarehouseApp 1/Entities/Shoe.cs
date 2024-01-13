namespace WarehouseApp.Entities
{
    public class Shoe : Equipment
    {
        public string? Person { get; set; }

        public override string ToString() => $"Id: {Id}, Person: {Person}";
    }
}
