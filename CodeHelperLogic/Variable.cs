using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHelper
{
    public class Variable
    {
        /// <summary>
        /// Member name
        /// </summary>
        public string Name;
        public string Type;
        public string Access;

        public Variable(string name, string type, string access)
        {
            Name = name;
            Type = type;
            Access = access;
        }
    }
}
