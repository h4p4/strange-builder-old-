namespace builder;
public class Product
{
    public string Title { get; set; }
    public decimal PriceForUnit { get; set; }
    public decimal Amount { get; set; }
    public Product(string title, decimal priceForUnit, decimal amount)
    {
        Title = title;
        PriceForUnit = priceForUnit;
        Amount = amount;    
    }
}
