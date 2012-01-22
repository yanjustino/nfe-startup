using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using nfebox.domain.exceptions;
using nfebox.domain.entities;

namespace nfebox.domain.values
{
    public class ValidacaoSchemasXml
    {
        private static string ErroValidadorXML;

        public static void Validar(string arquivoXML, string schemaXML)
        {
            try
            {
                var xmlSettings = new XmlReaderSettings();
                xmlSettings.ValidationType = ValidationType.Schema;
                xmlSettings.Schemas.Add(null, schemaXML);
                xmlSettings.ValidationEventHandler += new ValidationEventHandler(xmlSettingsValidationEventHandler);

                var xml = XmlReader.Create(arquivoXML, xmlSettings);
                ErroValidadorXML = string.Empty;
                while (xml.Read()) { }
                xml.Close();

                if (!string.IsNullOrEmpty(ErroValidadorXML))
                    throw new ServicosException("Erro de schema: " + ErroValidadorXML, 205);
            }
            catch (ServicosException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void xmlSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
                ErroValidadorXML += "Cuidado: \n" + e.Message + "\n";
            else if (e.Severity == XmlSeverityType.Error)
                ErroValidadorXML += "ERRO: \n" + e.Message + "\n";
            else
                ErroValidadorXML += "ERRO: \n" + e.Message + "\n";
        }
    }
}
