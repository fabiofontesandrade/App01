﻿using System.Threading.Tasks;

namespace PedidoApp.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await PedidoApp.App.Current.MainPage.DisplayAlert("Pedidos", message, "Ok");
        }

        public async Task ShowAsync(string title, string message, string text)
        {
            await PedidoApp.App.Current.MainPage.DisplayAlert(title, message, text);
        }

        public async Task ShowAsync(string title, string message, string text1, string text2)
        {
            await PedidoApp.App.Current.MainPage.DisplayAlert(title, message, text1, text2);
        }

        public async Task<bool> ShowAsyncBool(string title, string message, string text1, string text2)
        {
            return await PedidoApp.App.Current.MainPage.DisplayAlert(title, message, text1, text2);
        }
    }
}
