using ConsultaCEP.Servico;
using ConsultaCEP.Servico.Modelo;
using System;
using Xamarin.Forms;

namespace ConsultaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BOTAO_Clicked;
        }

        private void BOTAO_Clicked(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();

            if (IsValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                        RESULTADO.Text = string.Format("Endereço: {0}, {1}, {2} - {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    else
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP Informado: " + cep, "OK");
                }
                catch(Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
                
            }
        }

        private bool IsValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
            int novoCEP = 0;
            if (!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO", "O CEP deve ser composto apenas por números.", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
