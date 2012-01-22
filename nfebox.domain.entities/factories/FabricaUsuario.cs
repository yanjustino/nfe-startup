using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.entities.values;
using System.Security.Cryptography;
using System.Data;

namespace nfebox.domain.entities.factories
{
    public class FabricaUsuario
    {
        public static Usuario Criar()
        {
            var usuario = new Usuario();
            usuario.Id = 0;
            usuario.TipoContrato = Contrato.Tipo.Free;
            usuario.Chave = "";
            usuario.Ativado = false;
            usuario.Email = "";
            usuario.Senha = "";
            usuario.SenhaConfirmacao = "";
            return usuario;
        }

        public static Usuario Criar(DataRowCollection table)
        {
            Usuario usuario = null;
            if (table.Count > 0)
            {
                usuario = new Usuario();
                usuario.Id = (int)table[0]["id"];
                usuario.Email = table[0]["email"].ToString();
                usuario.Ativado = (bool)table[0]["ativado"];
                usuario.Chave = table[0]["chave"].ToString();
                usuario.Senha = table[0]["senha"].ToString();
                usuario.SenhaConfirmacao = table[0]["senha_confirmacao"].ToString();

                switch (table[0]["tipo_contrato"].ToString())
                {
                    case "F": usuario.TipoContrato = Contrato.Tipo.Free; break;
                    case "S": usuario.TipoContrato = Contrato.Tipo.Standart; break;
                    case "P": usuario.TipoContrato = Contrato.Tipo.Premium; break;
                    default: usuario.TipoContrato = Contrato.Tipo.Free; break;
                }
            }
            return usuario;
        }

        public static string GerarChaveUsuario(Usuario usuario)
        {
            var random = new Random();
            var codigo1 = usuario.Email;
            int codigo2 = random.Next(3000, 3999);
            int codigo3 = random.Next(2000, 2999);
            int codigo4 = random.Next(1000, 1999);


            var content = codigo1.ToString() +
                          GerarCodeHash(codigo2.ToString()) +
                          GerarCodeHash(codigo3.ToString()) +
                          GerarCodeHash(codigo4.ToString());

            return content;
        }

        private static string GerarCodeHash(string content)
        {
            var encoding = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = encoding.GetBytes(content);
            var SHhash = new SHA1Managed();
            var strHex = "";

            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
                strHex += String.Format("{0:x2}", b);

            return strHex;
        }

    }
}
