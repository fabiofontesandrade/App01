using System.Threading.Tasks;

namespace PedidoApp.Services
{
    public interface INavigationService
    {
        Task NavigateToAddPedido();
        Task NavigateToDetailsPage(int id);
        Task NavigateToPedidosLista();
        void PopAsyncService();
    }
}
