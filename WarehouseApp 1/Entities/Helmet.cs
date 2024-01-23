namespace WarehouseApp.Entities
{
    public class Helmet : Equipment
    {
        public override string ToString() => $"Id: {Id}, Type: {Type}, Name: {Name}, ListPrice: {ListPrice}, Color: {Color}";
    }
}
