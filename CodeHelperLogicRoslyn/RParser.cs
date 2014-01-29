using System.Threading;
using CodeHelper;
using Roslyn.Compilers.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHelperLogicRoslyn
{
    public class RParser : IParser
    {
        public List<Variable> GetVariables(string memberList)
        {
            var result = new List<Variable>();

            var tree = SyntaxTree.ParseText(memberList);

            CompilationUnitSyntax root = tree.GetRoot(CancellationToken.None);

            foreach (var m in root.Members.OfType<FieldDeclarationSyntax>())
            {
                var names = m.Declaration.Variables.Select(v => v.Identifier.ValueText);
                var type = m.Declaration.Type.ToString();
                var access = string.Join(" ", m.Modifiers.Select(mod => mod.ValueText));
                result.AddRange(names.Select(n => new Variable(n, type, access)));
            }

            return result;
        }
    }
}
