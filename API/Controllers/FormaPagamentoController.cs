using System;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/formapagamento")]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly DataContext _context;
        public FormaPagamentoController(DataContext context)
        {
            _context = context;
        }

        //POST: api/formapagamento/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] FormaPagamento formapagamento)
        {
            _context.FormaPagamentos.Add(formapagamento);
            _context.SaveChanges();
            return Created("", formapagamento);
        }

        //GET: api/formapagamento/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.FormaPagamentos.ToList());

        //GET: api/formapagamento/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            FormaPagamento formapagamento = _context.FormaPagamentos.Find(id);
            if (formapagamento == null)
            {
                return NotFound();
            }
            return Ok(formapagamento);
        }

        //DELETE: /api/formapagamento/delete/bolacha
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete([FromRoute] string descricao)
        {
            //Expressão lambda
            //Buscar um objeto na tabela de produtos com base no nome
            FormaPagamento formapagamento = _context.FormaPagamentos.FirstOrDefault(formapagamento => formapagamento.Descricao == descricao);

            if (formapagamento == null)
            {
                return NotFound();
            }
            _context.FormaPagamentos.Remove(formapagamento);
            _context.SaveChanges();
            return Ok(_context.FormaPagamentos.ToList());
        }


        //PUT: api/formapagamento/update
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] FormaPagamento formapagamento)
        {
            _context.FormaPagamentos.Update(formapagamento);
            _context.SaveChanges();
            return Ok(formapagamento);
        }
    }    
}