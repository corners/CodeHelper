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
    public class Builder
    {
        public List<Variable> ParseMemberList(string input)
        {
            return Logic.ParseMemberList(input);
        }

        public string BuildMemberList(List<Variable> variables, ushort tabLevel = 0)
        {
            return Logic.BuildMemberList(variables, tabLevel);
        }

        public string BuildParameterList(List<Variable> variables)
        {
            return Logic.BuildParameterList(variables);
        }

        public string BuildCopyAssignmentList(List<Variable> variables, ushort tabLevel = 0)
        {
            return Logic.BuildCopyAssignmentList(variables, tabLevel);
        }


        public string BuildMemberAssignmentList(List<Variable> variables, ushort tabLevel = 0)
        {
            return Logic.BuildMemberAssignmentList(variables, tabLevel);
        }

        public string BuildHashCodes(List<Variable> variables, ushort tabLevel = 0)
        {
            return Logic.BuildHashCodes(variables, tabLevel);
        }

        public List<Variable> InferTypes(List<Variable> variables, params List<Variable>[] possibles)
        {
            return Logic.InferTypes(variables, possibles);            
        }
    }
}
