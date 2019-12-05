using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PedidoApp.Services;
using PedidoApp.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PedidoApp
{
    public partial class App : Application
    {
        IPedidoRepository _pedidoRepository;
        public App()
        {
            InitializeComponent();

            //aplica a injeção de dependência nos serviços implementados
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();
            //cria uma instância do repositorio
            _pedidoRepository = new PedidoRepository();
            //invoca o evento 
            OnAppStart();
        }

        private void OnAppStart()
        {
            //obtem todos os dados 
            var getLocalDB = _pedidoRepository.GetAllPedidos();
            //se existir dados então exibe a lista senão inclui dados
            if (getLocalDB.Count > 0)
            {
                MainPage = new NavigationPage(new PedidoLista());
            }
            else
            {
                MainPage = new NavigationPage(new AddPedido());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
