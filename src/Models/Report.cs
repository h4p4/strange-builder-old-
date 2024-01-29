using System.Text;

namespace builder;
public class Report : IReport
{
    public string Header { get; set; }

    public string Body { get; set; }

    public string Footer { get; set; }

    public string Result() => new StringBuilder()
                                        .Append(Header)
                                        .Append(Body)
                                        .Append(Footer)
                                        .ToString();
}
