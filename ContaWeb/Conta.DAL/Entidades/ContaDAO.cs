using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta.DAL.Entidades
{
    [Table("Conta")]
    public class ContaDAO
    {
        [Key]
        public long ID_Conta { get; set; }
        public string CPF { get; set; }
        public Decimal Valor { get; set; }
    }
}
