using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CodeHelper
{
    /* TODO 
     * proper indenting
     * copy constructor
     * correctly handle access modifiers
     * static constructor for static fields
     * ignore constants
     * 
    */ 

/*
    class Modifiers
    {
        public string Access;
        public string ReadOnly;
        public string Static;

        public Modifiers(string Access, string ReadOnly, string Static)
        {
            
        }
    }
*/
    public static class Logic
    {
        static string Pattern = "[?\\t ]*(?:(?<modifiers>public|private|public|protected|readonly|static|const) )?(?<type>[a-z" +
      "A-Z0-9<>\\?\\,]*) (?<name>[_a-zA-Z0-9]*);";

        static Regex regex = new Regex(Pattern,
            RegexOptions.Multiline
            | RegexOptions.CultureInvariant
            | RegexOptions.Compiled
            );

        internal static List<Variable> ParseMemberList(string text)
        {
            var result = new List<Variable>();

            MatchCollection ms = regex.Matches(text);
            foreach (Match m in ms)
            {

                var access = m.Groups["modifiers"].Value;
                var name = m.Groups["name"].Value;
                var type = m.Groups["type"].Value;
                result.Add(new Variable(name, type, access));
            }
            return result;
        }

        public static List<Variable> ParseParameterList(string text)
        {
            return new List<Variable>(); // todo
        }

        static string LowerCaseFirstChar(string name)
        {
            return Char.ToLowerInvariant(name[0]) + name.Substring(1);
        }

        static string UpperCaseFirstChar(string name)
        {
            return Char.ToUpperInvariant(name[0]) + name.Substring(1);
        }

        static string RootNameFromMember(string name)
        {
            return name.TrimStart('_');
        }

        static bool IsPublic(string name)
        {
            return Char.IsUpper(name[0]);
        }

        internal static string ParameterName(string name)
        {
            return LowerCaseFirstChar(RootNameFromMember(name));
        }

        internal static string MemberName(string name)
        {
            return name;
        }

        public static string Indent(ushort level, string format, params object[] args)
        {
            var sb = new StringBuilder();
            sb.Append(new string(' ', (int)(level * 4)));
            sb.AppendFormat(format, args);
            return sb.ToString();
        }

        public static string BuildMemberList(List<Variable> variables, ushort tabLevel = 0)
        {
            var list = variables.Select(v => Indent(tabLevel, "{0} {1} {2}", v.Access, v.Type, MemberName(v.Name)));
            return string.Join(";" + Environment.NewLine, list);
        }

        public static string BuildParameterList(List<Variable> variables)
        {
            var list = variables.Select(v => string.Format("{0} {1}", v.Type, ParameterName(v.Name)));
            return string.Join(", ", list);
        }

        public static string BuildCopyAssignmentList(List<Variable> variables, ushort tabLevel = 0)
        {
            var tabs = new string('\t', (int)tabLevel);
            var list = variables.Select(v => Indent(tabLevel, "this.{0} = other.{0}", MemberName(v.Name)));
            return string.Join(";" + Environment.NewLine, list);
        }


        public static string BuildMemberAssignmentList(List<Variable> variables, ushort tabLevel = 0)
        {
            var tabs = new string('\t', (int)tabLevel);
            var list = variables.Select(v => Indent(tabLevel, "this.{0} = {1}", MemberName(v.Name), ParameterName(v.Name)));
            return string.Join(";" + Environment.NewLine, list);
        }

        public static string BuildHashCodes(List<Variable> variables, ushort tabLevel = 0)
        {
            var tabs = new string('\t', (int)tabLevel);
            var list = variables.Select(v => Indent(tabLevel, "hash = hash * 23 + HashOrDefault({0});", MemberName(v.Name)));
            return string.Join(Environment.NewLine, list);
        }

        public static List<Variable> InferTypes(List<Variable> variables, params List<Variable>[] possibles)
        {
            var lookup = (from list in possibles
                          from variable in list
                          where !string.IsNullOrWhiteSpace(variable.Type)
                          group variable by variable.Name 
                          into grp
                          select grp
                         ).ToDictionary(g => g.Key, g => g.Select(v => v.Type).ToArray(), StringComparer.InvariantCultureIgnoreCase);

            return variables.Select(v => new Variable(v.Name, PickType(lookup.ValueOrDefault(v.Name, new string[] { })), "public")).ToList();
        }

        public static string PickType(IEnumerable<string> options)
        {
            if (options.Any())
                return options.First();
            else
                return "string";
        }


        const string ClassFormat =
@"public class {0}
{{
{1}

    public {0}({2})
    {{
{3}
    }}

    /// Copy constructor
    public {0}({0} other)
    {{
{4}
    }}

    public override int GetHashCode()
    {{
		Func<object, int, int> hashOrDefault = (obj, defaultValue) => (obj == null) ?  defaultValue : obj.GetHashCode();
		Func<object, int> HashOrDefault = (obj) => hashOrDefault(obj, 0);

		unchecked // Overflow is fine, just wrap
		{{
			int hash = 17;
{5}        
			return hash;
        }}
    }}
}}
";


        public static string BuildClass(List<Variable> variables, string name)
        {
            var sb = new StringBuilder();

            var members = BuildMemberList(variables, 1);
            var parameters = BuildParameterList(variables);
            var assignments = BuildMemberAssignmentList(variables, 2);
            var copyCtor = BuildCopyAssignmentList(variables, 2);
            var hashCodes = BuildHashCodes(variables, 4);

            sb.AppendFormat(ClassFormat, name, members, parameters, assignments, copyCtor, hashCodes);

            return sb.ToString();
        }
    }
}
