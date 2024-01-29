namespace builder;
public interface IReportEmployeeBuilder : IReportBuilder<IReportEmployeeBuilder> 
{
    IReportEmployeeBuilder WithSalary(bool isEnabled = true);
    IReportEmployeeBuilder WithHours(bool isEnabled = true);
}
