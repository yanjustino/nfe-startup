using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;

namespace nfebox.communication
{
    internal class EFDResponseDeserializer
    {
        private string content;

        public EFDResponseDeserializer(string content)
        {
            this.content = content;
        }

        public EFDResponse Deserialize()
        {
            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<Dictionary<string, string>>(this.content);
            return new EFDResponse(dict["Codigo"], dict["Status"]);
        }
    }
}
