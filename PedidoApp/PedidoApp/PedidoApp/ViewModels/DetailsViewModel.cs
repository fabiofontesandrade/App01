using PedidoApp.Models;
using PedidoApp.Services;
using PedidoApp.Validator;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace PedidoApp.ViewModels
{
    public class DetailsViewModel : BasePedidoViewModel
    {
        public ICommand UpdatePedidoCommand { get; private set; }
        public ICommand DeletePedidoCommand { get; private set; }
        public DetailsViewModel(int selectedPedidoID)
        {
            _pedidoValidator = new PedidoValidator();
            _pedido = new Pedido();
            _pedido.Id = selectedPedidoID;
            _pedidoRepository = new PedidoRepository();

            UpdatePedidoCommand = new Command(async () => await UpdatePedido());
            DeletePedidoCommand = new Command(async () => await DeletePedido());

            EncontrarDetalhesDoPedido();
        }
        void EncontrarDetalhesDoPedido()
        {
            _pedido = _pedidoRepository.GetPedido(_pedido.Id);
        }
        async Task UpdatePedido()
        {
            var resultadoValidacao = _pedidoValidator.Validate(_pedido);
            if (resultadoValidacao.IsValid)
            {
                bool isUserAccept = await _messageService.ShowAsyncBool("Detalhes do Pedido",
"Atualiza detalhes do Pedido ?", "OK", "Cancelar");
                if (isUserAccept)
                {
                    _pedidoRepository.UpdatePedido(_pedido);
                    _navigationService.PopAsyncService();
                }
            }
            else
            {
                await _messageService.ShowAsync("Detalhes do Pedido", resultadoValidacao
.Errors[0].ErrorMessage, "OK");
            }
        }
        async Task DeletePedido()
        {
            bool respostaUsuario = await _messageService.ShowAsyncBool("Detalhes do Pedido",
 "Deletar detalhes do pedido", "OK", "Cancelar");
            if (respostaUsuario)
            {
                _pedidoRepository.DeletePedido(_pedido.Id);
                _navigationService.PopAsyncService();
            }
        }
    }
}