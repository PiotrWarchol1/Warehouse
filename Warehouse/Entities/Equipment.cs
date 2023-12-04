namespace WarehouseApp.Entities
{
    public class Equipment : Shoe
    {
        public string? Type { get; set; }

        public override string ToString() => $"Id: {Id}, Type: {Type}";
    }
}
