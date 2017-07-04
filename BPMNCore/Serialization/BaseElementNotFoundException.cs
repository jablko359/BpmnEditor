using System;
using System.Collections.Generic;

namespace BPMNCore.Serialization
{
    public class BaseElementNotFoundException : Exception
    {

        public BaseElementNotFoundException(KeyNotFoundException exception) : base("BaseElement not found", exception)
        {

        }
    }
}