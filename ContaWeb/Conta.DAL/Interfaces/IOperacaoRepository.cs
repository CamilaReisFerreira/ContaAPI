using Conta.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conta.DAL.Interfaces
{
    public interface IOperacaoRepository
    {
        Task Add(DTO.Operacao item);
        Task<IList<DTO.Operacao>> Find(long id_conta);

    }
}
