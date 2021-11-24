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
                    new Categoria { CategoriaId = 1, Nome = "Periféricos" },
                    new Categoria { CategoriaId = 2, Nome = "Notebook" },
                    new Categoria { CategoriaId = 3, Nome = "Desktop" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Mouse", Preco = 50, Quantidade = 100, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "Notebook DELL", Preco = 3500, Quantidade = 10, CategoriaId = 2 },
                    new Produto { ProdutoId = 3, Nome = "Desktop DELL", Preco = 3000, Quantidade = 5, CategoriaId = 3 },
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}