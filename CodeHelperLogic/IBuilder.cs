using System.Collections.Generic;

namespace CodeHelper
{
    public interface IBuilder
    {
        string BuildMemberList(List<Variable> variables, ushort tabLevel = 0);
        string BuildParameterList(List<Variable> variables);
        string BuildCopyAssignmentList(List<Variable> variables, ushort tabLevel = 0);
        string BuildMemberAssignmentList(List<Variable> variables, ushort tabLevel = 0);
        string BuildHashCodes(List<Variable> variables, ushort tabLevel = 0);
        List<Variable> InferTypes(List<Variable> variables, params List<Variable>[] possibles);
    }
}