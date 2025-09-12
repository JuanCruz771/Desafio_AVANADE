using Desafio_e_commerce_AVANADE_Vendas.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Desafio_e_commerce_AVANADE_Vendas.Services
{
    public class Venda_Service
    {
        private readonly HttpClient _httpClient;

        public Venda_Service(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API_Estoque");

            
            
            
        }

        public async Task<Produtos?> Buscar_Produto_Id(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"/Estoque/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Produtos>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
