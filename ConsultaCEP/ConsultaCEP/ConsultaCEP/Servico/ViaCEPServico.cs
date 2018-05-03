using ConsultaCEP.Servico.Modelo;
using Newtonsoft.Json;
using System.Net;

namespace ConsultaCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoURL);

            Endereco oEndereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (oEndereco.cep == null)
                return null;

            return oEndereco;
        }
    }
}
