namespace WarehouseApp.Entities
{
    public class Shoe : Equipment
    {
        public override string ToString() => $"Id: {Id}, Person: {Person}";
    }
}
