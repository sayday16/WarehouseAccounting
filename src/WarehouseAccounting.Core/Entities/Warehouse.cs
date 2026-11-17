namespace WarehouseAccounting.Core.Entities;

public class Warehouse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public ICollection<WarehouseProduct> Items { get; set; } = new List<WarehouseProduct>();
}
