using PedidoApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PedidoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidoLista : ContentPage
    {
        public PedidoLista()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new PedidoListaViewModel();
        }
    }
}