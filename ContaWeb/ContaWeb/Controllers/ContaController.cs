using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conta.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContaWeb.Controllers
{
    [Route("api/Conta")]
    public class ContaController : Controller
    {
        public IContaRepository ContaRepo { get; set; }
        public IOperacaoRepository OperacaoRepo { get; set; }

        public ContaController(IContaRepository _repo, IOperacaoRepository _repoOp)
        {
            ContaRepo = _repo;
            OperacaoRepo = _repoOp;
        }

        [HttpGet("{id}", Name = "ConsultaConta")]
        public async Task<IActionResult> GetAllByCPF(string cpf)
        {
            var item = await ContaRepo.Find(cpf);
            
            if (item == null)
            {
                return NotFound();
            }

            var operacoes = await OperacaoRepo.Find(item.ID_Conta);
            if (operacoes != null)
            {
                item.Operacoes = operacoes;
            }
            return Ok(item);
        }

        [HttpGet("{id}", Name = "GetConta")]
        public async Task<IActionResult> GetByCPF(string cpf)
        {
            var item = await ContaRepo.Find(cpf);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost(Name = "CriarConta")]
        public async Task<IActionResult> Create([FromBody] Conta.DTO.Conta item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await ContaRepo.Add(item);
            return CreatedAtRoute("GetConta", new { Controller = "Conta", cpf = item.CPF }, item);
        }

        [HttpPost(Name ="Deposito")]
        public async Task<IActionResult> Deposito([FromBody] Conta.DTO.Operacao item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            item.Tipo_Operacao = 'D';
            item.Conta.Valor += item.Valor;
            await OperacaoRepo.Add(item);
            return CreatedAtRoute("AtualizaConta", new { Controller = "Conta", cpf = item.Conta.CPF }, item);
        }

        [HttpPost(Name = "Saque")]
        public async Task<IActionResult> Saque([FromBody] Conta.DTO.Operacao item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            item.Tipo_Operacao = 'S';
            item.Conta.Valor -= item.Valor;
            await OperacaoRepo.Add(item);
            return CreatedAtRoute("AtualizaConta", new { Controller = "Conta", cpf = item.Conta.CPF }, item);
        }

        [HttpPut("{id}", Name ="AtualizaConta")]
        public async Task<IActionResult> Update(string id, [FromBody] Conta.DTO.Conta item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = await ContaRepo.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            await ContaRepo.Update(item);
            return CreatedAtRoute("GetConta", new { Controller = "Conta", cpf = item.CPF }, item);
        }
    }
}
