using PedidoApp.Models;
using System.Collections.Generic;

namespace PedidoApp.Services
{
    public interface IPedidoRepository
    {
        List<Pedido> GetAllPedidos();

        //Obtem um pedido pelo id
        Pedido GetPedido(int pedidoId);

        //Deleta todos os pedidos
        void DeleteAllPedidos();

        //Delete um pedido
        void DeletePedido(int pedidoId);

        //Insere um novo pedido
        void InsertPedido(Pedido pedido);

        //Atualiza um pedido
        void UpdatePedido(Pedido pedido);
    }
}
