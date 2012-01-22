using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using nfebox.domain.entities.contracts;

namespace nfebox.domain.entities.agreggates
{
    public class ItemNotaFiscal: IEntidade
    {
        [Key]
        public int Id { get; set; }
        public int IdNotaFiscal { get; set; }

        public string Codigo { get; set; }
        public string EAN { get; set; }
        public string NomeProduto { get; set; }
        public string NCM { get; set; }
        public string CFOP { get; set; }
        public string Unidade { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorProduto { get; set; }
        public string UnidadeTributado { get; set; }
        public double QuantidadeTributado { get; set; }
        public double ValorUnitarioTributado { get; set; }
        public double ValorFrete { get; set; }
        public double ValorSeguro { get; set; }
        public double ValorOutro { get; set; }
        public int IndicadorTotalizador { get; set; }

        [ForeignKey("IdNotaFiscal")]
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
