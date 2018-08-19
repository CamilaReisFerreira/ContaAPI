using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Conta.DAL.Context;
using Conta.DAL.Entidades;
using Conta.DAL.Interfaces;
using Conta.DTO;

namespace Conta.DAL.Persistencia
{
    public class OperacaoRepository : IOperacaoRepository
    {
        EFContext _context;
        public OperacaoRepository(EFContext context)
        {
            _context = context;
        }

        public async Task Add(Operacao item)
        {
            var operacao = new OperacaoDAO {
                ID_Operacao = item.ID_Operacao,
                Tipo_Operacao = item.Tipo_Operacao.ToString(),
                Valor = item.Valor,
                Conta = new ContaDAO {
                    ID_Conta = item.Conta.ID_Conta}
            };
            await _context.Operacoes.AddAsync(operacao);
            await _context.SaveChangesAsync();
        }
        public async Task<IList<DTO.Operacao>> Find(long id_conta)
        {
            var operacoes = await _context.Operacoes
                .Where(e => e.Conta.ID_Conta.Equals(id_conta)).ToListAsync();

            IList<Operacao> lista = new List<Operacao>();

            foreach (var item in operacoes)
            {
                lista.Add(new Operacao
                {
                    ID_Operacao = item.ID_Operacao,
                    Tipo_Operacao = Convert.ToChar(item.Tipo_Operacao),
                    Valor = item.Valor
                });
            }

            return lista;
        }

    }
}
