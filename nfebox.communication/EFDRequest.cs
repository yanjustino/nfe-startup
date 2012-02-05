using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace nfebox.communication
{
    public class EFDRequest
    {
        public enum EFDRequestType {NFe, SPEDFiscal, SPEDPisCofins}

        private string Token;
        private const string url = "http://localhost:1076/api/nfe/json/";
        
        /// <summary>
        /// Cria uma nova instância da classe Request.
        /// </summary>
        /// <param name="token">chave de autenticação para comunicar-se com a api</param>
        public EFDRequest(string token)
        {
            this.Token = token;
        }

        /// <summary>
        /// Requisição de envio de Escrituração Fiscal Digital
        /// </summary>
        /// <param name="content">Conteúdo do EFD</param>
        /// <returns>
        /// Instância de EFDResponse com os parâmetros 
        /// 'Codigo' e 'Status' contendo resultado da requisição.
        /// Em caso de exceção será retornado um EFDRequestException
        /// </returns>
        public EFDResponse Send(string content, EFDRequestType EFDType)
        {
            try
            {
                string parameters = PreparePostParameters(content, EFDType);
                return SendPostRequest(parameters);
            }
            catch (Exception ex)
            {                
                throw new EFDRequestException("Erro na requisição de serviço", ex);
            }
        }

        private string PreparePostParameters(string content, EFDRequestType EFDType)
        {
            return string.Format(
                   "key={0}&xml={1}&type={2}", 
                   this.Token, 
                   content,
                   EFDType.ToString());
        }

        private EFDResponse SendPostRequest(string parameters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(parameters);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            Stream newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            return GetResponseAndDeserializeIt(request);
        }

        private EFDResponse GetResponseAndDeserializeIt(HttpWebRequest request)
        {
            HttpWebResponse response = null;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException exception)
            {
                response = exception.Response as HttpWebResponse;
            }

            return new EFDResponseDeserializer(ReadContent(response)).Deserialize();
        }

        private string ReadContent(HttpWebResponse response)
        {
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
