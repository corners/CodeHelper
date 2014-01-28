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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool UpdatesEnabled = true;

        void WithoutUpdates(params Action[] actions)
        {
            try
            {
                UpdatesEnabled = false;
                foreach (var action in actions)
                   action();
            }
            finally
            {
                UpdatesEnabled = true;
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

        void UpdateMemberList(List<Variable> variables)
        {
            memberListInput.Text = ResultOrError(() => Logic.BuildMemberList(variables, 0));
        }

        void UpdateParameterList(List<Variable> variables)
        {
            parameterListInput.Text = ResultOrError(() => Logic.BuildParameterList(variables));
        }

        void UpdateMemberAssignment(List<Variable> variables)
        {
            memberAssignmentInput.Text = ResultOrError(() => Logic.BuildMemberAssignmentList(variables, 0));
        }

        void UpdateCooyAssignment(List<Variable> variables)
        {
            copyAssignments.Text = ResultOrError(() => Logic.BuildCopyAssignmentList(variables, 0));
        }

        void UpdateClass(List<Variable> variables)
        {
            classDefinition.Text = ResultOrError(() => Logic.BuildClass(variables, GetClassName()));
        }

        void UpdateUi(params Action<List<Variable>>[] actions)
        {
            if (!UpdatesEnabled)
                return;

            var variables = Logic.ParseMemberList(memberListInput.Text);

            var updates = from action in actions
                          let a = new Action(() => action(variables))
                          select a;

            WithoutUpdates(updates.ToArray());
        }

        private void memberInput_TextChanged(object sender, EventArgs e)
        {
            UpdateUi(UpdateParameterList, UpdateMemberAssignment, UpdateClass, UpdateCooyAssignment);
        }

        private void parameterInput_TextChanged(object sender, EventArgs e)
        {
            UpdateUi(UpdateMemberList, UpdateMemberAssignment, UpdateClass, UpdateCooyAssignment);
        }

        private void contructorInput_TextChanged(object sender, EventArgs e)
        {
            UpdateUi(UpdateMemberList, UpdateMemberAssignment, UpdateClass, UpdateCooyAssignment);
        }

        private void classNameInput_TextChanged(object sender, EventArgs e)
        {
            UpdateUi(UpdateClass);
        }
    }
}
