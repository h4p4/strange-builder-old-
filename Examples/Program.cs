namespace builder;
class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new(){
            new Employee(){ FirstName = "Lexa", MiddleName = "Nikolaevich", LastName = "Alexeev", SalaryLastMonth = 30, HoursLastMonth =  100},
            new Employee(){ FirstName = "absdf", MiddleName = "asdfsa", LastName = "sdafas", SalaryLastMonth = 300, HoursLastMonth =  120},
            new Employee(){ FirstName = "asdf", MiddleName = "sadfsad", LastName = "sadf", SalaryLastMonth = 30, HoursLastMonth =  130},
            new Employee(){ FirstName = "asdf", MiddleName = "dfdd", LastName = "dfdf", SalaryLastMonth = 50, HoursLastMonth =  115},
            new Employee(){ FirstName = "sfgh", MiddleName = "fghfgh", LastName = "fghfgh", SalaryLastMonth = 150, HoursLastMonth =  110},
        };
        var products = new List<Product>(){
            new Product("Apelsin", 10, 150),
            new Product("Yabloko", 15, 250),
            new Product("Limon", 10, 350),
            new Product("Pomelo(chto takoe pomelo)", 10, 450),
        };
        var productsReport = new ProductReportBuilder(products);
        var report = new EmployeeReportBuilder(employees)
                                                    .WithHours()
                                                    .WithSalary()
                                                    .AddBody()
                                                    .AddFooter()
                                                    .AddHeader();


        // PrintReportAndWait(report);
        // report.SetSeparator('*', 55).WithHours(false).Take(3);
        // PrintReportAndWait(report);

        // report.AddHeader(false);
        // report.WithHours(false);
        // PrintReportAndWait(report);
        // report.AddFooter(false);
        // report.AddHeader();
        // PrintReportAndWait(report);
        // report.SetSeparator('_', 50);
        // report.AddFooter();
        // PrintReportAndWait(report);


        productsReport.AddBody().AddFooter().SetSeparator('_', 50).AddHeader();
        PrintReportAndWait(productsReport);
        productsReport.Skip(1).AddFooter(false);
        PrintReportAndWait(productsReport);
    }

    static void PrintReportAndWait(IReportBuilder reportBuilder)
    {
        Console.Clear();
        System.Console.WriteLine(reportBuilder.GetReport().Result());
        Console.ReadKey();
    }
}
