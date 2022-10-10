using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }


        //Formulário de confirmação do Cliente
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        //Processar o Pedido
        [HttpPost]
        public IActionResult Checkout( Pedido pedido)
        {
            return View();
        }
    }
}
