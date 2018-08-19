using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta.DTO
{
    public class Operacao
    {
        public long ID_Operacao { get; set; }
        public char Tipo_Operacao { get; set; }
        public Decimal Valor { get; set; }
        public Conta Conta { get; set; }
    }
}
