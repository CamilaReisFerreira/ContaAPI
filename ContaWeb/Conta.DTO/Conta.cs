using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta.DTO
{
    public class Conta
    {
        public long ID_Conta { get; set; }
        public string CPF { get; set; }
        public Decimal Valor { get; set; }
        public IList<Operacao> Operacoes { get; set; }
    }
}
