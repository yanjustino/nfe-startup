using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace nfebox.domain.entities.factories
{
    public class FabricaNotaFiscalBase
    {
        protected static XNamespace xmlns = "http://www.portalfiscal.inf.br/nfe";

        protected static string ParseToString(XElement element, object defaultValue)
        {
            try
            {
                if (element == null)
                    return defaultValue.ToString();
                return element.Value;
            }
            catch
            {
                return defaultValue.ToString();
            }
        }

        protected static double ParseToDouble(XElement element, object defaultValue)
        {
            try
            {
                if (element == null)
                    return Convert.ToDouble(defaultValue);
                return Convert.ToDouble(element.Value.Replace(".", ","));
            }
            catch
            {
                return Convert.ToDouble(defaultValue);
            }
        }
    }
}
