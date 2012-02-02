using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace nfebox.infrastructure.data.Context
{
    public class ConnectionStringAppHarbor
    {
        public static string CriarStringConexao(string sqlserverUri)
        {
            if (string.IsNullOrEmpty(sqlserverUri))
                return "";

            var uriString = sqlserverUri;
            var uri = new Uri(uriString);
            return new SqlConnectionStringBuilder
            {
                DataSource = uri.Host,
                InitialCatalog = uri.AbsolutePath.Trim('/'),
                UserID = uri.UserInfo.Split(':').First(),
                Password = uri.UserInfo.Split(':').Last(),
                MultipleActiveResultSets = true,
            }.ConnectionString;
        }
    }
}
