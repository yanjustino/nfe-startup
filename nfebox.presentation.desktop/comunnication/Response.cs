using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nfebox.presentation.desktop.comunnication
{
    public class Response
    {
        public static string Status { get; private set; }
        public static string Motivo { get; private set; }

        public static void SetResponse(string response)
        {
            Status = "";
            Motivo = "";
        }
    }
}
