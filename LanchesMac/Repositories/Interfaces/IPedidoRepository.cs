using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        //Assinatura do método
        void CriarPedido(Pedido pedido);
    }
}
