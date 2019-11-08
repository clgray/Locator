using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;

namespace Cnit.Testor.Core.UI.Testing
{
    public partial class CalculatorForm : Form
    {
        private CalculatorModel model = null;
        private Boolean resetText = false;
        private Boolean textChanged = false;
        private String previousInput = "";
		public const String BACKSPACE = "Backspace";
        public const String CLEAR_ALL = "AC";
        public const String CLEAR_ENTRY = "CE";
        public const String DECIMAL_POINT = ".";
        public const String NEGATE = "\u00b1"; // u00b1
        public const String SQRT = "sqrt";
        public const String DIVX = "1\\/x";
        public const String DIVX2 = "1/x";
        public const String PI = "pi";
        public const String RE_EDIT = "\\d" + "|" + BACKSPACE
          + "|" + CLEAR_ALL + "|" + CLEAR_ENTRY
          + "|\\" + DECIMAL_POINT + "|" + NEGATE + "|" + SQRT
          + "|" + DIVX + "|" + PI;
        public const String EVALUATE = "=";
        public const String PLUS = "+";
        public const String MINUS = "-";
        public const String MULTIPLY = "\u00d7";
        public const String DIVIDE = "\u00f7";
        public const String RE_EVALUATE = EVALUATE + "|\\" + PLUS + "|" + MINUS
          + "|" + MULTIPLY + "|" + DIVIDE + "|" + DIVIDE;
        public const String RE_OPERATOR = "\\" + PLUS + "|" + MINUS
          + "|" + MULTIPLY + "|" + DIVIDE;

        public CalculatorForm()
        {
            InitializeComponent();
            model = new CalculatorModel();

            this.textBoxNumber.Text = "0";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool isReEval;

        private void doClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            String input = b.Text;
            String buffer = this.textBoxNumber.Text;

            if (Regex.IsMatch(input, RE_EDIT))
            {
                buffer = doEdit(buffer, input);
            }
            else if (Regex.IsMatch(input, RE_EVALUATE))
            {
                buffer = doEvaluate(buffer, input);
            }
            previousInput = input;
            this.textBoxNumber.Text = buffer;
        }

        private String doEdit(String buffer, String input)
        {
            if (resetText && Regex.IsMatch(input, "[\\d.]"))
            {
                buffer = "0";
                resetText = false;
            }
            if (input.Equals(DIVX2))
            {
                double buf = 0;
                if (double.TryParse(buffer,NumberStyles.Any, new CultureInfo("en-US"), out buf))
                {
                    double newValue = 1 / buf;
                    if (!double.IsNaN(newValue))
                        buffer = newValue.ToString(new CultureInfo("en-US"));
                    else
                        buffer = "0";
                }
                isReEval = true;
            }
            else if (Regex.IsMatch(input, "\\d"))
            {
                if ("0".Equals(buffer) || isReEval)
                {
                    buffer = "";
                    if (isReEval)
                        model.setOperation(null);
                    isReEval = false;
                }
                else if ("-0".Equals(buffer))
                {
                    buffer = "-";
                }
                buffer += input;
            }
            else if (DECIMAL_POINT.Equals(input) && !buffer.Contains(DECIMAL_POINT))
            {
                buffer += input;
            }
            else if (input.Equals(NEGATE))
            {
                if (buffer.StartsWith("-"))
                {
                    buffer = buffer.Substring(1);
                }
                else
                {
                    buffer = '-' + buffer;
                }
            }
            else if (input.Equals(BACKSPACE))
            {
                buffer = buffer.Substring(0, buffer.Length - 1);
                if (buffer.Equals("-") || buffer.Length == 0)
                {
                    buffer = "0";
                }
            }
            else if (CLEAR_ENTRY.Equals(input))
            {
                buffer = "0";
                model.setOperation(null);
            }
            else if (CLEAR_ALL.Equals(input))
            {
                buffer = "0";
                model.init();
            }
            else if(input.Equals(SQRT))
            {
                double buf=0;
                if (double.TryParse(buffer,NumberStyles.Any, new CultureInfo("en-US"), out buf))
                {
                    double newValue = Math.Sqrt(buf);
                    if (!double.IsNaN(newValue))
                        buffer = newValue.ToString(new CultureInfo("en-US"));
                    else
                        buffer = "0";
                }
                isReEval = true;
            }
            else if (input.Equals(PI))
            {
                buffer = "3.1415";
            }
            textChanged = true;
            return buffer;
        }

        public String doEvaluate(String buffer, String input)
        {
            if (textChanged)
            {
                model.setArgument(buffer);
                textChanged = false;
            }
            if (EVALUATE.Equals(input) || (!EVALUATE.Equals(input) && !EVALUATE.Equals(previousInput)))
            {
                buffer = model.evaluate();
            }
            if (EVALUATE.Equals(input))
            {
                isReEval = true;
            }
            if (Regex.IsMatch(input, RE_OPERATOR))
            {
                model.setOperation(input);
                resetText = true;
                isReEval = false;
            }
            else if (EVALUATE.Equals(input))
            { }
            return buffer;
        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            Button btn = new Button();
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '+'
            || e.KeyChar == '-')
                btn.Text = e.KeyChar.ToString();
            else if (e.KeyChar == '\b')
				btn.Text = "Backspace";
            else if (e.KeyChar == '\r')
                btn.Text = "=";
            else if (e.KeyChar == '*')
                btn.Text = "×";
            else if (e.KeyChar == '/')
                btn.Text = "÷";
            else if (e.KeyChar == '.' || e.KeyChar == ',')
                btn.Text = ".";
            else
                return;
            doClick(btn, new EventArgs());
        }

        private void buttonClearEntry_Enter(object sender, EventArgs e)
        {
            buttonEvaluate.Focus();
        }
    }
}
