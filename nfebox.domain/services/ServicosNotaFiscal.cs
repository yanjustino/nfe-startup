using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.contracts;
using nfebox.domain.exceptions;
using nfebox.domain.entities;
using nfebox.domain.entities.factories;
using System.Xml.Linq;
using nfebox.domain.values;
using System.IO;

namespace nfebox.domain.services
{
    public class ServicosNotaFiscal : IServicoNotaFiscal
    {
        IRepositorioNotaFiscal RepositorioNota;
        IRepositorioUsuario RepositorioUsuario;
        IRepositorioParticipante RepositorioParticipante;

        public ServicosNotaFiscal(
            IRepositorioNotaFiscal repositorioNota,
            IRepositorioUsuario repositorioUsuario,
            IRepositorioParticipante repositorioParticipante)
        {
            RepositorioNota = repositorioNota;
            RepositorioUsuario = repositorioUsuario;
            RepositorioParticipante = repositorioParticipante;
        }

        public ResponseServicosNotaFiscal GravarNotaFiscalNoBancoDeDados(XElement xml, string chaveUsuario)
        {
            ResponseServicosNotaFiscal response;
            try
            {
                var usuario = RepositorioUsuario.BuscarUsuarioPorChave(chaveUsuario);
                ValidarUsuario(usuario);

                ValidarXmlDaNota(xml, usuario);

                var nota = FabricaNotaFiscal.Criar(xml, usuario);
                ValidarNotaFiscal(nota);
                SalvarXmlNaPastaDoEmitente(nota, xml);
                RepositorioNota.Incluir(nota);

                var emitente = FabricaParticipante.CriarEmitente(xml);
                RepositorioParticipante.Incluir(emitente);

                var destinatario = FabricaParticipante.CriarDestinatario(xml);
                if (RepositorioParticipante.SelecionarPorCnpjCpf(destinatario.CnpjCpf) == null)
                    RepositorioParticipante.Incluir(destinatario);

                response = new ResponseServicosNotaFiscal(100, "Nota recebida com sucesso");
                return response;
            }
            catch (ServicosException ex)
            {
                return ex.Response;
            }
            catch (Exception ex)
            {
                return response = new ResponseServicosNotaFiscal(501, "erro no servidor " + ex.Message);
            }
        }

        private void SalvarXmlNaPastaDoEmitente(NotaFiscal nota, XElement xml)
        {
            try
            {
                if (!Directory.Exists("nfes"))
                    Directory.CreateDirectory("nfes");

                if (!Directory.Exists(nota.CnpjCpfEmitente))
                    Directory.CreateDirectory(nota.CnpjCpfEmitente);

                var arquivo = string.Format("nfes//{0}//{1}.xml", nota.CnpjCpfEmitente, nota.ChaveAcesso);
                nota.CaminhoXml = arquivo;
                xml.Save(arquivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidarXmlDaNota(XElement xml, Usuario usuario)
        {
            var arquivo = "temp\\" + usuario.Id.ToString().PadLeft(10, '0') + "_" +
                          DateTime.Now.ToString("ddMMyyyyhhmmsszz") + "_" +
                          usuario.Chave.Substring(0, 10) +
                          ".xml";
            try
            {
                if (!Directory.Exists("temp"))
                    Directory.CreateDirectory("temp");

                xml.Save(arquivo);
                ValidacaoSchemasXml.Validar(arquivo, "Resources\\nfe_v2.00.xsd");
            }
            catch (ServicosException ex)
            {
                throw ex;
            }
            finally
            {
                if (File.Exists(arquivo))
                    File.Delete(arquivo);
            }
        }

        private void ValidarNotaFiscal(NotaFiscal nota)
        {
            if (RepositorioNota.BuscarPorChaveAcesso(nota.ChaveAcesso) != null)
                throw new ServicosException("Nota já cadastrada", 200);
        }

        private void ValidarUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ServicosException("Usuario não localizado", 201);

            if (usuario.Ativado == false)
                throw new ServicosException("Sua conta não econtra-se ativa. acesse seu email e ative sua conta", 202);
        }
    }
}
