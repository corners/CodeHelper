using CodeHelperLogicRoslyn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeHelper
{
    public partial class ClassBuilderForm : Form
    {
        public ClassBuilderForm(IBuilder builder, IParser parser)
        {
            InitializeComponent();
            _builder = builder;
            _parser = parser;
        }

        bool _updatesEnabled = true;
        IBuilder _builder;
        IParser _parser;

        void IgnoreUpdates(params Action[] actions)
        {
            try
            {
                _updatesEnabled = false;
                foreach (var action in actions)
                   action();
            }
            finally
            {
                _updatesEnabled = true;
            }
        }

        string GetClassName()
        {
            var name = classNameInput.Text;
            if (string.IsNullOrWhiteSpace(name))
                name = "ClassName";
            return name;
        }

        static string ResultOrError(Func<string> func)
        {
            string result;
            try
            {
                result = func();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }

        void UpdateClassDefinition(List<Variable> variables)
        {
            classDefinition.Text = ResultOrError(() => _builder.BuildClass(GetClassName(), variables));
        }

        void UpdateUiFromMemberList(params Action<List<Variable>>[] actions)
        {
            if (!_updatesEnabled)
                return;

            var variables = _parser.GetVariables(memberListInput.Text);

            var updates = from action in actions
                          let a = new Action(() => action(variables))
                          select a;

            IgnoreUpdates(updates.ToArray());
        }

        private void memberInput_TextChanged(object sender, EventArgs e)
        {
            UpdateUiFromMemberList(UpdateClassDefinition);
        }

        private void classNameInput_TextChanged(object sender, EventArgs e)
        {
            UpdateUiFromMemberList(UpdateClassDefinition);
        }
    }
}
