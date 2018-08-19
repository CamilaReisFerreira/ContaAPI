using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta.DAL.Entidades
{
    [Table("Operacao")]
    public class OperacaoDAO
    {
        [Key]
        public long ID_Operacao { get; set; }
        public char Tipo_Operacao { get; set; }
        public Decimal Valor { get; set; }
        public ContaDAO Conta { get; set; }
    }
}
