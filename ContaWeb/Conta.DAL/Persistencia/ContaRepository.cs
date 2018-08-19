using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conta.DAL.Context;
using Conta.DAL.Entidades;
using Conta.DAL.Interfaces;
using Conta.DTO;
using Microsoft.EntityFrameworkCore;

namespace Conta.DAL.Persistencia
{
    public class ContaRepository : IContaRepository
    {
        EFContext _context;
        public ContaRepository(EFContext context)
        {
            _context = context;
        }

        public async Task Add(DTO.Conta item)
        {
            var conta = new ContaDAO
            {
                ID_Conta = item.ID_Conta,
                CPF = item.CPF,
                Valor = item.Valor
            };
            await _context.Contas.AddAsync(conta);
            await _context.SaveChangesAsync();
        }

        public async Task<DTO.Conta> Find(string cpf)
        {
            var conta = await _context.Contas
                .Where(e => e.CPF.Equals(cpf))
                .SingleOrDefaultAsync();
            //var operacoes = await _context.Operacoes
            //    .Where(e => e.Conta.CPF.Equals(cpf));

           return new DTO.Conta
            {
                ID_Conta = conta.ID_Conta,
                CPF = conta.CPF,
                Valor = conta.Valor
            };
        }

        public async Task Update(DTO.Conta item)
        {
            var itemToUpdate = await _context.Contas.SingleOrDefaultAsync(r => r.ID_Conta == item.ID_Conta);
            if (itemToUpdate != null)
            {
                itemToUpdate.Valor = item.Valor;
                await _context.SaveChangesAsync();
            }
        }
    }
}
