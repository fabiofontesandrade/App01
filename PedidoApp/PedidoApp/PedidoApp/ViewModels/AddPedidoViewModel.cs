
using PedidoApp.Models;
using PedidoApp.Services;
using PedidoApp.Validator;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PedidoApp.ViewModels
{
    public class AddPedidoViewModel : BasePedidoViewModel
    {
        public ICommand AddPedidoCommand { get; private set; }
        public ICommand ViewAllPedidosCommand { get; private set; }

        public AddPedidoViewModel()
        {
            _pedidoValidator = new PedidoValidator();
            _pedido = new Pedido();
            _pedidoRepository = new PedidoRepository();

            AddPedidoCommand = new Command(async () => await AddPedido());
            ViewAllPedidosCommand = new Command(async () => await ExibirPedidoLista());
        }

        async Task AddPedido()
        {
            var resultadoValidacao = _pedidoValidator.Validate(_pedido);
            if (resultadoValidacao.IsValid)
            {
                bool respostaUsuario = await _messageService.ShowAsyncBool("Adicionar Pedido", "Deseja salvar os detalhes do pedido?", "OK", "Cancela");
                if (respostaUsuario)
                {
                    _pedidoRepository.InsertPedido(_pedido);
                    await _navigationService.NavigateToPedidosLista();
                }
            }
            else
            {
                await _messageService.ShowAsync("Adicionar Pedido", resultadoValidacao
.Errors[0].ErrorMessage, "OK");
            }
        }
        async Task ExibirPedidoLista()
        {
            await _navigationService.NavigateToPedidosLista();
        }
        public bool IsViewAll => _pedidoRepository.GetAllPedidos().Count > 0 ? true : false;
    }
}
