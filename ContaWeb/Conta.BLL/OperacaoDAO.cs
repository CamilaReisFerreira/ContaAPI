using Conta.DAL.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.BLL
{
    public class OperacaoDAO
    {
        private OperacaoRepository _serviceOperacao;

        public async void Add(DTO.Operacao operacao)
        {
            await _serviceOperacao.Add(operacao);
        }
    }
}
