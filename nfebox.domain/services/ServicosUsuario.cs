using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.contracts;
using nfebox.domain.entities;
using System.Security.Cryptography;
using nfebox.domain.entities.factories;
using nfebox.domain.exceptions;

namespace nfebox.domain.services
{
    public class ServicosUsuario : IServicosUsuario
    {
        IRepositorioUsuario Repositorio;

        public ServicosUsuario(IRepositorioUsuario repositorio)
        {
            Repositorio = repositorio;
        }

        public bool Logon(string login, string senha)
        {
            try
            {
                var usuario = Repositorio
                     .Buscar(u => u.Email == login && u.Senha == senha)
                     .FirstOrDefault();

                var usuario_validado = (usuario != null);

                if (usuario_validado)
                    ServicosSessao.Iniciar(usuario);

                return usuario_validado;

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

        public void Logout()
        {
            if (ServicosSessao.UsuarioSessao != null)
                ServicosSessao.Encerrar();
        }

        public Usuario UsuarioDaSessao()
        {
            return ServicosSessao.UsuarioSessao;
        }

        public void CriarNovoUsuario(Usuario usuario)
        {
            try
            {
                if (Repositorio.EmailExisteNoCadastro(usuario.Email))
                    throw new ServicosException("Email inválido");

                usuario.Chave = FabricaUsuario.GerarChaveUsuario(usuario);
                Repositorio.Incluir(usuario);
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

        public void AtivarUsuario(string chave, string email)
        {
            try
            {
                var usuario = Repositorio
                              .Buscar(u => u.Chave == chave &&
                              u.Email == email).FirstOrDefault();

                if (usuario == null)
                    throw new ServicosException("A chave informada não foi localizada ou atribuida a " + email);

                if (!usuario.Ativado)
                {
                    usuario.Ativado = true;
                    Repositorio.Atualizar(usuario);
                }
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
    }
}
