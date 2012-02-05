using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nfebox.communication
{
    public class EFDRequestException : Exception
    {
        public EFDRequestException(string message) : base(message) { }
        public EFDRequestException(string message, Exception innerException) : base(message, innerException) { }
    }
}
