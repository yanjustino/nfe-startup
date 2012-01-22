using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using nfebox.domain.entities.values;
using System.Web.Mvc;
using nfebox.domain.entities.contracts;

namespace nfebox.domain.entities
{
    public class Usuario: IEntidade
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Informe o email")]
        [Required(ErrorMessage = "O email é um campo obrigatório")]
        [RegularExpression(EmailRegex.RegexValue, ErrorMessage="Email inválido")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Informe a senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua senha")]
        [Required(ErrorMessage = "A confirmação da senha é obrigatória")]
        [Compare("Senha", ErrorMessage = "A senha de confirmação diferente da informada")]
        public string SenhaConfirmacao { get; set; }

        public Contrato.Tipo TipoContrato { get; set; }
        public string Chave { get; set; }
        public bool Ativado { get; set; }
    }
}
