namespace builder;
public class EmployeeReportBuilder : IReportEmployeeBuilder
{
    private string _separator = new string('-', 100);
    private IEnumerable<Employee> _employees;
    private Report _report;
    private bool _withSalary;
    private bool _withHours;
    private bool _withBody;
    private bool _withHeader;
    private bool _withFooter;
    private int _takeCount;
    
    public EmployeeReportBuilder(IEnumerable<Employee> employees)
    {
        _employees = employees;
        _report = new();
        _takeCount = employees.Count();
    }

    public IReportEmployeeBuilder AddHeader(bool isEnabled = true)
    {
        _withHeader = isEnabled;
        return this;
    }

    public IReportEmployeeBuilder AddBody(bool isEnabled = true)
    {
        _withBody = isEnabled;
        return this;
    }

    public IReportEmployeeBuilder AddFooter(bool isEnabled = true)
    {
        _withFooter = isEnabled;
        return this;
    }

    public IReportEmployeeBuilder WithSalary(bool isEnabled = true)
    {
        _withSalary = isEnabled;
        return this;
    }

    public IReportEmployeeBuilder WithHours(bool isEnabled = true)
    {
        _withHours = isEnabled;
        return this;
    }
    public IReportEmployeeBuilder SetSeparator(char separatorSymbol, int countOfSymbols = 100)
    {
        _separator = new string(separatorSymbol, countOfSymbols);
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

    public IReportEmployeeBuilder Take(int countToTake){
        _takeCount = countToTake;
        return this;
    }

    
    private string CreateHeader() =>
                        $"EMPLOYEES REPORT ON DATE: {DateTime.Now}" +
                        $"\n{_separator}\n";

    private string CreateBody() =>
                        string.Join(Environment.NewLine,
                        _employees.Select(e =>
                        $"\nEmployee: {e.LastName} {e.FirstName} {e.MiddleName}" + 
                        (_withHours ? $"\nHours last month: {e.HoursLastMonth}" : String.Empty) +
                        (_withSalary ? $"\nSalary: {e.SalaryLastMonth}" : String.Empty)).Take(_takeCount));
                        
    private string CreateFooter() =>
                        $"\n{_separator}" +
                        $"\nTOTAL EMPLOYEES: {_employees.Count()}, " +
                        (_withSalary ? $"\nTOTAL SALARY LAST MONTH: {_employees.Sum(e => e.SalaryLastMonth)}$" : String.Empty);

}
