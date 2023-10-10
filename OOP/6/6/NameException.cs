namespace Lab6;
using System.Diagnostics;
public class NameException: Exception
{
    private string ErrorInName { get; set; }
    public string Name { get; private set; }

    public NameException(string message, string name) : base(message)
    {
        Debug.Assert(message == null, "message can't be null");
        Name = name;
    }
}