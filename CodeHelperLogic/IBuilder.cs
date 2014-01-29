using System.Collections.Generic;

namespace CodeHelper
{
    public interface IBuilder
    {
        string BuildClass(string name, IEnumerable<Variable> variables);
    }
}