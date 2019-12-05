using FluentValidation;
using PedidoApp.Models;
using PedidoApp.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace PedidoApp.ViewModels
{
    public class BasePedidoViewModel : INotifyPropertyChanged
    {
        public Pedido _pedido;
        public IValidator _pedidoValidator;
        public IPedidoRepository _pedidoRepository;

        protected IMessageService _messageService;
        protected INavigationService _navigationService;

        public BasePedidoViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        public string Titulo
        {
            get => _pedido.Titulo;
            set
            {
                _pedido.Titulo = value;
                NotifyPropertyChanged(nameof(Titulo));
            }
        }

        public string Link
        {
            get => _pedido.Link;
            set
            {
                _pedido.Link = value;
                NotifyPropertyChanged(nameof(Link));
            }
        }
        public decimal Preco
        {
            get => _pedido.Preco;
            set
            {
                _pedido.Preco = value;
                NotifyPropertyChanged(nameof(Preco));
            }
        }
        public string Descricao
        {
            get => _pedido.Descricao;
            set
            {
                _pedido.Descricao = value;
                NotifyPropertyChanged(nameof(Descricao));
            }
        }
        List<Pedido> _pedidoLista;
        public List<Pedido> PedidoLista
        {
            get => _pedidoLista;
            set
            {
                _pedidoLista = value;
                NotifyPropertyChanged(nameof(PedidoLista));
            }
        }

        #region INotifyPropertyChanged      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
