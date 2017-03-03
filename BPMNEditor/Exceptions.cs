using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor
{
    public class IncorrectConverterValueException : Exception
    {
        private readonly object _value;
        private readonly Type _expectedType;

        public object Value => _value;
        public Type ExpectedType => _expectedType;

        public IncorrectConverterValueException(object value, Type expectedType, Exception ex) : base("", ex)
        {
            _value = value;
            _expectedType = expectedType;
        }

        public IncorrectConverterValueException(object value, Type expectedType)
        {
            _value = value;
            _expectedType = expectedType;
        }

        public override string Message
        {
            get
            {
                string provided = _value != null ? _value.GetType().FullName : "null";
                return string.Format("IncorrectConverterValueException. Expected {0}, provided {1}", _expectedType, provided);
            } 
        }
    }
}
