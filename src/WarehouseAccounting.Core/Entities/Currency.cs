namespace WarehouseAccounting.Core.Entities;

public class Currency
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public decimal Rate { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
