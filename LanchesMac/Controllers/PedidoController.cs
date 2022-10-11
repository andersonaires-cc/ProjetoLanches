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
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            // obter os itens do carrinho de compra do cliente
            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItems();
            _carrinhoCompra.CarrinhoCompraItems = items;

            //verifica se existem itens de pedidos
            if (_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState.AddModelError("", "seu carrinho esta vazio que tal incluir um lanche...");
            }
            // calcular o total de itens e o total do pedido
            foreach(var item in items)
            {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Lanche.Preco * item.Quantidade);
            }
            // atribuir os valores ao pedido
            pedido.TotalItensPedido = totalItensPedido;
            pedido.PedidoTotal = precoTotalPedido;
            //validar os dados do pedido
            if (ModelState.IsValid)
            {
                // criar o pedido e os detalhes
                _pedidoRepository.CriarPedido(pedido);

                // define mensagens ao cliente
                ViewBag.CheckoutCompletoMensagem = "obrigado pelo seu pedido :)";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                //limpar o carrinho do cliente
                _carrinhoCompra.LimparCarrinho();

                //exibir a view com dados do cliente e do pedido
                return View("~/Views/Pedido/CheckoutCompleto.cshtml",pedido);

            }
            return View(pedido);
        }
    }
}
