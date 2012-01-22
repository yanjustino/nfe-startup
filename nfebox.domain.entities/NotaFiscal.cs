using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nfebox.domain.entities.agreggates;
using System.ComponentModel.DataAnnotations;
using nfebox.domain.entities.contracts;

namespace nfebox.domain.entities
{
    [Table("NotasFiscais")]
    public class NotaFiscal: IEntidade
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public string CodigoUF { get; set; }
        public string Codigo { get; set; }
        public string Numero { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string TipoNF { get; set; }
        public string Ambiente { get; set; }
        public string ChaveAcesso { get; set; }
        public string Operacao { get; set; }
        public string Pagamento { get; set; }
        public string TipoEmissao { get; set; }
        public string Finalidade { get; set; }
        public string Processo { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataEntradaSaida { get; set; }
        public string HoraEntradaSaida { get; set; }
        public string VersaoProcesso { get; set; }
        public string Digito { get; set; }
        public string CnpjCpfEmitente { get; set; }
        public string CnpjCpfDestinatario { get; set; }
        public string CaminhoXml { get; set; }
        public double ValorNotaFiscal { get; set; }

        public virtual List<ItemNotaFiscal> Itens { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }
}
