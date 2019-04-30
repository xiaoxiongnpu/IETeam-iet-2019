using System;
using System.Collections.Generic;
using System.Text;

namespace RDFSharp
{
    class CustomException: Exception
    {
        public CustomException()
        {
           
        }

        public CustomException(string message)
            : base(message)
        {

        }

        public CustomException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
