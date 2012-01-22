using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using nfebox.domain.entities.contracts;

namespace nfebox.domain.entities.agreggates
{
    public class Participante: IEntidade
    {
        [Key]
        public int Id { get; set; }

        public string CnpjCpf { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Cidade { get; set; }
        public string CodigoUF { get; set; }
        public string CodigoPais { get; set; }
        public string Pais { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
