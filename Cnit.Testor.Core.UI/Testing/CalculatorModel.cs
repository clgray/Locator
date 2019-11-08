using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Cnit.Testor.Core.UI.Testing
{
    class CalculatorModel
    {
        private String _result;
        private String _argument;
        private String _operation;

        public CalculatorModel()
        {
            init();
        }

		public String evaluate()
		{
			if (_operation == null)
			{
				_result = _argument;
			}
			else
			{
				double res = 0;
				double arg = 0;
				if (!Double.TryParse(_result, NumberStyles.Any, new CultureInfo("en-US"), out res) ||
					!Double.TryParse(_argument, NumberStyles.Any, new CultureInfo("en-US"), out arg))
				{
					init();
					return _result;
				}
				if (CalculatorForm.PLUS.Equals(_operation))
				{
					res += arg;
				}
				else if (CalculatorForm.MINUS.Equals(_operation))
				{
					res -= arg;
				}
				else if (CalculatorForm.MULTIPLY.Equals(_operation))
				{
					res *= arg;
				}
				else if (CalculatorForm.DIVIDE.Equals(_operation))
				{
					res /= arg;
				}
				_result = System.Convert.ToString(res, new CultureInfo("en-US"));
				if (_result.EndsWith(".0"))
				{
					_result = _result.Substring(0, _result.Length - 2);
				}
			}
			return _result;
		}

        public String getResult() { return this._result; }
        public void init()
        {
            _result = "0";
            _argument = "0";
            _operation = null;
        }
        public void setArgument(String number) { this._argument = number; }
        public void setOperation(String operation) { this._operation = operation; }
    }
}
