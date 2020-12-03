using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        //{
        //    var loginContent = ObterConteudo(usuarioLogin);

        //    var response = await _httpClient.PostAsync("/api/identidade/autenticar", loginContent);

        //    if (!TratarErrosResponse(response))
        //    {
        //        return new UsuarioRespostaLogin
        //        {
        //            ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
        //        };
        //    }

        //    return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        //}

        //public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        //{
        //    var registroContent = ObterConteudo(usuarioRegistro);

        //    var response = await _httpClient.PostAsync("/api/identidade/nova-conta", registroContent);

        //    if (!TratarErrosResponse(response))
        //    {
        //        return new UsuarioRespostaLogin
        //        {
        //            ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
        //        };
        //    }

        //    return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        //}
        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(usuarioLogin),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44379/api/identidade/autenticar", loginContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = new StringContent(
                JsonSerializer.Serialize(usuarioRegistro),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44379/api/identidade/nova-conta", registroContent);

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync());
        }
    }
}