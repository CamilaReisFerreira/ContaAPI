using Conta.DAL.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conta.BLL
{
    public class ContaBO
    {
        private ContaRepository _serviceConta;

        public async void Add(DTO.Conta conta)
        {
            await _serviceConta.Add(conta);
        }

        public async Task<DTO.Conta> Find(string cpf)
        {
            return await _serviceConta.Find(cpf);
        }
    }
}
