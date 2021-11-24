using System;
using System.Collections.Generic;

namespace API.Models
{
    public class FormaPagamento
    {
        public FormaPagamento() => CriadoEm = DateTime.Now;
        public int FormaPagamentoId { get; set; }
        public string Descricao { get; set; }
        public int QtdeParc { get; set; }
        public DateTime CriadoEm { get; set; }   
    }
}