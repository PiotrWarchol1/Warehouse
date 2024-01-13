namespace WarehouseApp.Entities
{
    public class Equipment : EntityBase
    {
        public string? Type { get; set; }

        public override string ToString() => $" Type: {Type}";
    }
}
