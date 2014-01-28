using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHelper
{
    public class Parser : IParser
    {
        public List<Variable> GetVariables(string memberList)
        {
            return Logic.ParseMemberList(memberList);
        }
    }
}
