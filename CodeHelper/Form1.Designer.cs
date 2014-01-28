namespace CodeHelper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.memberListInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.parameterListInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.memberAssignmentInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.classDefinition = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.classNameInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.copyAssignments = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // memberListInput
            // 
            this.memberListInput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberListInput.Location = new System.Drawing.Point(30, 42);
            this.memberListInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.memberListInput.Multiline = true;
            this.memberListInput.Name = "memberListInput";
            this.memberListInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.memberListInput.Size = new System.Drawing.Size(473, 251);
            this.memberListInput.TabIndex = 0;
            this.memberListInput.WordWrap = false;
            this.memberListInput.TextChanged += new System.EventHandler(this.memberInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Member List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 309);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parameter List";
            // 
            // parameterListInput
            // 
            this.parameterListInput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parameterListInput.Location = new System.Drawing.Point(30, 326);
            this.parameterListInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.parameterListInput.Multiline = true;
            this.parameterListInput.Name = "parameterListInput";
            this.parameterListInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.parameterListInput.Size = new System.Drawing.Size(473, 251);
            this.parameterListInput.TabIndex = 2;
            this.parameterListInput.WordWrap = false;
            this.parameterListInput.TextChanged += new System.EventHandler(this.parameterInput_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Member assignments";
            // 
            // memberAssignmentInput
            // 
            this.memberAssignmentInput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberAssignmentInput.Location = new System.Drawing.Point(511, 42);
            this.memberAssignmentInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.memberAssignmentInput.Multiline = true;
            this.memberAssignmentInput.Name = "memberAssignmentInput";
            this.memberAssignmentInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.memberAssignmentInput.Size = new System.Drawing.Size(368, 251);
            this.memberAssignmentInput.TabIndex = 4;
            this.memberAssignmentInput.WordWrap = false;
            this.memberAssignmentInput.TextChanged += new System.EventHandler(this.contructorInput_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 319);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Class";
            // 
            // classDefinition
            // 
            this.classDefinition.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classDefinition.Location = new System.Drawing.Point(511, 366);
            this.classDefinition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.classDefinition.Multiline = true;
            this.classDefinition.Name = "classDefinition";
            this.classDefinition.ReadOnly = true;
            this.classDefinition.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.classDefinition.Size = new System.Drawing.Size(473, 251);
            this.classDefinition.TabIndex = 6;
            this.classDefinition.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Name";
            // 
            // classNameInput
            // 
            this.classNameInput.Location = new System.Drawing.Point(582, 340);
            this.classNameInput.Name = "classNameInput";
            this.classNameInput.Size = new System.Drawing.Size(100, 22);
            this.classNameInput.TabIndex = 9;
            this.classNameInput.Text = "ClassName";
            this.classNameInput.TextChanged += new System.EventHandler(this.classNameInput_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(901, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Copy assignments";
            // 
            // copyAssignments
            // 
            this.copyAssignments.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyAssignments.Location = new System.Drawing.Point(904, 42);
            this.copyAssignments.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.copyAssignments.Multiline = true;
            this.copyAssignments.Name = "copyAssignments";
            this.copyAssignments.ReadOnly = true;
            this.copyAssignments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.copyAssignments.Size = new System.Drawing.Size(368, 251);
            this.copyAssignments.TabIndex = 10;
            this.copyAssignments.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 638);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.copyAssignments);
            this.Controls.Add(this.classNameInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.classDefinition);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.memberAssignmentInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.parameterListInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.memberListInput);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox memberListInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox parameterListInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox memberAssignmentInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox classDefinition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox classNameInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox copyAssignments;
    }
}

