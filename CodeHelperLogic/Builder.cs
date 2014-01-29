using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHelper
{
    /// <summary>
    /// Facade for Logic class will become interface
    /// </summary>
    public class Builder : IBuilder
    {
        public string BuildClass(string name, IEnumerable<Variable> variables)
        {
            return Logic.BuildClass(variables.ToList(), name);
        }
    }
}
