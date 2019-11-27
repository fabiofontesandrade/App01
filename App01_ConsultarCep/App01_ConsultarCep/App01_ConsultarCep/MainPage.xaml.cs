using App01_ConsultarCep.Servico;
using App01_ConsultarCep.Servico.Modelo;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace App01_ConsultarCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnBuscar.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        { 
            //TODO - lógica do app
            //TODO - validações
            string cep = txtCEP.Text.Trim();
            if (IsValidCep(cep))
            {
                try {
                    Endereco endereco = ViaCepServico.BuscarEnderecoViaCep(cep);

                    if (endereco != null)
                        lblResultado.Text = String.Format("Endereço: {0}, {1}, {2} {3}", endereco.Logradouro, endereco.Bairro, endereco.Localidade, endereco.UF);
                    else
                        DisplayAlert("Erro", String.Format("Endereço não encontrado para o CEP {0}", cep), "ok");
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro crítico", ex.Message, "ok");
                }
            }
        }

        private bool IsValidCep(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                valido = false;
                DisplayAlert("Erro", "CEP inválido. O CEP deve conter 8 caracteres", "Ok");
            }

            int novoCep = 0;
            if (!int.TryParse(cep, out novoCep))
            {
                valido = false;
                DisplayAlert("Erro", "CEP inválido. O CEP deve conter somente números", "Ok");
            }

            return valido;
        }
    }
}
