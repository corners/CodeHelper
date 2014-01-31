using CodeHelperLogicRoslyn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
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

        IBuilder _builder;
        IParser _parser;

        private void ClassBuilderForm_Load(object sender, EventArgs e)
        {
            var variablesChanged = Observable.FromEventPattern<EventHandler, EventArgs>
            (
                handler => handler.Invoke,
                h => memberListInput.TextChanged += h,
                h => memberListInput.TextChanged -= h
            );

            var nameChanged = Observable.FromEventPattern<EventHandler, EventArgs>
            (
                handler => handler.Invoke,
                h => classNameInput.TextChanged += h,
                h => classNameInput.TextChanged -= h
            );

            variablesChanged
                .CombineLatest(nameChanged, (ep, s2) => ep)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .ObserveOn(this)
                .Subscribe(x => classDefinition.Text = ResultOrError(() => GenerateClassDefinition(GetClassName(), memberListInput.Text)));
        }


        string GenerateClassDefinition(string name, string text)
        {
            var variables = _parser.GetVariables(text);
            return _builder.BuildClass(name, variables);
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
    }
}
