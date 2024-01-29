using System.Text;

namespace builder;
public class ProductReportBuilder : IReportBuilder<ProductReportBuilder>
{
    private string _separator;
    private IReport _report;
    private IEnumerable<Product> _products;
    private bool _withHeader;
    private bool _withBody;
    private bool _withFooter;
    private int _countToSkip = 0;

    public ProductReportBuilder(IEnumerable<Product> products)
    {
        _products = products;

    }

    public ProductReportBuilder AddBody(bool isEnabled = true)
    {
        _withBody = isEnabled;
        return this;
    }

    public ProductReportBuilder AddFooter(bool isEnabled = true)
    {
        _withFooter = isEnabled;
        return this;
    }

    public ProductReportBuilder AddHeader(bool isEnabled = true)
    {
        _withHeader = isEnabled;
        return this;
    }

    public IReport GetReport()
    {
        _report = new Report();
        _report.Header = _withHeader ? CreateHeader() : String.Empty;
        _report.Body = _withBody ? CreateBody() : String.Empty;
        _report.Footer = _withFooter ? CreateFooter() : String.Empty;
        return this._report;
    }

    private string CreateHeader() =>
                        $"PRODUCTS REPORT ON DATE: {DateTime.Now}" +
                        $"\n{_separator}\n";

    private string CreateBody() =>
                        string.Join(Environment.NewLine,
                        _products.Select(e =>
                        $"\nProduct: {e.Title} \tLeft: {e.Amount} units \tPrice: {e.PriceForUnit}$").Skip(_countToSkip));
                        
    private string CreateFooter() =>
                        $"\n{_separator}" +
                        $"\nTOTAL PRODUCTS TYPES: {_products.Count()}\n" +
                        $"\nTOTAL PRODUCTS COUNT: {_products.Sum(x => x.Amount)} units\n" +
                        $"\nAVG PRICE: {_products.Average(p => p.PriceForUnit)}$";

    public ProductReportBuilder SetSeparator(char separatorSymbol, int countOfSymbols = 100)
    {
        _separator = new string(separatorSymbol, countOfSymbols);
        return this;
    }

    ProductReportBuilder IReportBuilder<ProductReportBuilder>.Take(int countToTake)
    {
        throw new NotImplementedException();
    }
    
    public ProductReportBuilder Skip(int countToSkip)
    {
        _countToSkip = countToSkip;
        return this;
    }
}
