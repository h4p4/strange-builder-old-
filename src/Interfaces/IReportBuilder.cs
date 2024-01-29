namespace builder;
public interface IReportBuilder<TBuilder> : IReportBuilder
{
    TBuilder AddHeader(bool isEnabled = true);
    TBuilder AddBody(bool isEnabled = true);
    TBuilder AddFooter(bool isEnabled = true);
    TBuilder SetSeparator(char separatorSymbol, int countOfSymbols = 100);
    TBuilder Take(int countToTake);

}

public interface IReportBuilder
{
    IReport GetReport();
}
