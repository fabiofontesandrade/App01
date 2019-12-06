using PedidoApp.Models;
using PedidoApp.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PedidoApp.ViewModels
{
    public class PedidoListaViewModel : BasePedidoViewModel
    {
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllPedidosCommand { get; private set; }

        public PedidoListaViewModel()
        {
            _pedidoRepository = new PedidoRepository();

            AddCommand = new Command(async () => await ExibirAddPedido());
            DeleteAllPedidosCommand = new Command(async () => await DeleteAllPedidos());

            EncontrarPedidos();
        }

        void EncontrarPedidos()
        {
            PedidoLista = _pedidoRepository.GetAllPedidos();
        }

        async Task ExibirAddPedido()
        {
            await _navigationService.NavigateToAddPedido();
        }

        async Task DeleteAllPedidos()
        {
            bool respostaUsuario = await _messageService.ShowAsyncBool("Lista de Pedidos", "Deletar todos os detalhes de pedidos?", "OK", "Cancelar");
            if (respostaUsuario)
            {
                _pedidoRepository.DeleteAllPedidos();
                await _navigationService.NavigateToAddPedido();
            }
        }

        async void ExibirPedidoDetails(int selectedPedidoID)
        {
            await _navigationService.NavigateToDetailsPage(selectedPedidoID);
        }

        Pedido _selectedPedidoItem;
        public Pedido SelectedPedidoItem
        {
            get => _selectedPedidoItem;
            set
            {
                if (value != null)
                {
                    _selectedPedidoItem = value;
                    NotifyPropertyChanged("SelectedPedidoItem");
                    ExibirPedidoDetails(value.Id);
                }
            }
        }
    }
}
