namespace WarehouseApp.Entities
{
    public class Shoe : EntityBase
    {
        public string? Person { get; set; }

        public override string ToString() => $"Id: {Id}, Person: {Person}";
    }
}
