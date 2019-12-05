using PedidoApp.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PedidoApp.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAddPedido()
        {
            await PedidoApp.App.Current.MainPage.Navigation.PushAsync(new AddPedido());
        }
        public async Task NavigateToDetailsPage(int id)
        {
            await PedidoApp.App.Current.MainPage.Navigation.PushAsync(new DetailsPage(id));
        }
        public async Task NavigateToPedidosLista()
        {
            await PedidoApp.App.Current.MainPage.Navigation.PushAsync(new PedidoLista());
        }
        public async void PopAsyncService()
        {
            await PedidoApp.App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
