using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nfebox.domain.entities.values
{
    public class EmailRegex
    {
        public const string RegexValue =
            @"^(([^<>()[\]\\.,;:\s@\""]+"
            + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
            + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
            + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
            + @"[a-zA-Z]{2,}))$";
    }
}
