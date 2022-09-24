using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context
{
    //Herdando de DbContext (carregando informações do DbContext
    public class AppDbContext: DbContext
    {
        //Construtor referenciando AppDbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        //Propriedades DbSet quais classes  Mapear para criar as tabelas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        //Mapeando a classe pedidos para a tabela Pedido
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
