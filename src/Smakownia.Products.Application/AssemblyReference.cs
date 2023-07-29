using System.Reflection;

namespace Smakownia.Products.Application;

public class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}
