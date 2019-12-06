using PedidoApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PedidoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(int pedidoId)
        {
            InitializeComponent();
            this.BindingContext = new DetailsViewModel(pedidoId);
        }
    }
}