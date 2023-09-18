using System;
using System.Collections.Generic;
using System.Text;

namespace OpenXRP.AddressCodec.Exceptions
{
    public class DecodeException : Exception
    {
        public DecodeException(string message) : base(message)
        {

        }
    }
}
