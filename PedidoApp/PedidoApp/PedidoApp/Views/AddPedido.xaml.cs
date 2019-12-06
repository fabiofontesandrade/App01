using PedidoApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PedidoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPedido : ContentPage
    {
        public AddPedido()
        {
            InitializeComponent();
            BindingContext = new AddPedidoViewModel();
        }
    }
}