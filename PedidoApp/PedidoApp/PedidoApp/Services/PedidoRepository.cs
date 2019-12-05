using PedidoApp.Helpers;
using PedidoApp.Models;
using System.Collections.Generic;

namespace PedidoApp.Services
{
    public class PedidoRepository : IPedidoRepository
    {
        DatabaseHelper _databaseHelper;

        public PedidoRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public List<Pedido> GetAllPedidos()
        {
            return _databaseHelper.GetAllPedidos();
        }

        public Pedido GetPedido(int pedidoId)
        {
            return _databaseHelper.GetPedido(pedidoId);
        }

        public void DeleteAllPedidos()
        {
            _databaseHelper.DeleteAllPedidos();
        }

        public void DeletePedido(int pedidoId)
        {
            _databaseHelper.DeletePedido(pedidoId);
        }

        public void InsertPedido(Pedido pedido)
        {
            _databaseHelper.InsertPedido(pedido);
        }

        public void UpdatePedido(Pedido pedido)
        {
            _databaseHelper.UpdatePedido(pedido);
        }
    }
}
