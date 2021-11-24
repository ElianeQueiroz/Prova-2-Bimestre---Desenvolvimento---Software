using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Bebidas" },
                }
            );
            _context.FormaPagamentos.AddRange(new FormaPagamento[]
                {
                    new FormaPagamento { FormaPagamentoId = 1, Descricao = "Dinheiro" },
                    new FormaPagamento { FormaPagamentoId = 2, Descricao = "Cartao" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Coca-Cola", Preco = 8, Quantidade = 2, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "Guaraná", Preco = 7, Quantidade = 3, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "Cini", Preco = 5, Quantidade = 6, CategoriaId = 1 },
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}