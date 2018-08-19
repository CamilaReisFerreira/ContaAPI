using System;
using Conta.DTO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conta.DAL.Interfaces
{
    public interface IContaRepository
    {
        Task Add(DTO.Conta item);
        Task Update(DTO.Conta item);
        Task<DTO.Conta> Find(string cpf);
    }
}
