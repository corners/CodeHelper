using CodeHelper;
using Roslyn.Compilers.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHelperLogicRoslyn
{
    public class RBuilder : IBuilder
    {
        public string BuildClass(string name, IEnumerable<Variable> variables)
        {

            ClassDeclarationSyntax classDef = Syntax.ClassDeclaration(name)
                                                    .WithMembers(CreateProperties(variables))
                                                    .NormalizeWhitespace();

            string text = NodeToString(classDef);
            return text;
        }

        private static string NodeToString(SyntaxNode node)
        {
            string text;
            using (var textWriter = new StringWriter())
            {
                node.GetText()
                        .Write(textWriter);
                text = textWriter.ToString();
            }
            return text;
        }

        private static SyntaxList<MemberDeclarationSyntax> CreateProperties(IEnumerable<Variable> variables)
        {
            var nodes = variables.Select(v => CreateStandardProperty(v));
            var syntaxList = Syntax.List<MemberDeclarationSyntax>(nodes);
            return syntaxList;
        }

        static MemberDeclarationSyntax CreateStandardProperty(Variable variable)
        {
            TypeSyntax ts = Syntax.ParseTypeName(variable.Type);
            SyntaxToken identifier = Syntax.ParseToken(variable.Name);

            SyntaxToken visibility;
            if (!string.IsNullOrWhiteSpace(variable.Access))
                visibility = Syntax.ParseToken(variable.Access);
            else
                visibility = Syntax.Token(SyntaxKind.PublicKeyword);

            var accessors = new[] 
            {
                Syntax.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(Syntax.Token(SyntaxKind.SemicolonToken)),
                Syntax.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(Syntax.Token(SyntaxKind.SemicolonToken)),
            };

            PropertyDeclarationSyntax member = Syntax.PropertyDeclaration(ts, identifier)
                                                     .WithModifiers(visibility)
                                                     .AddAccessorListAccessors(accessors)
                                                     ;
            return member;
        }
    }
}
