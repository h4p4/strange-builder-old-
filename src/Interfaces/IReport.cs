using System.Text;

namespace builder;
public interface IReport
{
    public string Header { get; set; }
    public string Body { get; set; }
    public string Footer { get; set; }
    public string Result();
}
