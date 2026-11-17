namespace WarehouseAccounting.Core.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public decimal PriceBase { get; set; }

    public string Barcode { get; set; } = string.Empty;

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
}
