using System.Collections.Generic;

namespace CodeHelper
{
    public interface IParser
    {
        List<Variable> GetVariables(string memberList);
    }
}