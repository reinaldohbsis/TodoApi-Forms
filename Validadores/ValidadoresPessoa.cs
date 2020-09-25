using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Todo.API.Models;
using Validadores.Exceptions;

namespace Validadores
{
    public class ValidadoresPessoa
    {
        public static Pessoa GetUser(string user)
        {
            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/Pessoas";
            var resultRequest = httpClient.GetAsync(URL);
            resultRequest.Wait();

            var result = resultRequest.Result.Content.ReadAsStringAsync();
            result.Wait();

            var data = JsonConvert.DeserializeObject<List<Pessoa>>(result.Result);
            var pessoa = data.Where(x => x.Usuario == user).FirstOrDefault();

            return pessoa;

        }

        public static Pessoa GetUserConfig(long id)
        {
            var httpClient = new HttpClient();
            string URL = "https://localhost:44336/api/Pessoas/Config/" + id;
            var resultRequest = httpClient.GetAsync(URL);
            resultRequest.Wait();

            var result = resultRequest.Result.Content.ReadAsStringAsync();
            result.Wait();

            var data = JsonConvert.DeserializeObject<List<Pessoa>>(result.Result);
            var pessoa = data.Where(x => x.Id == id).FirstOrDefault();

            return pessoa;
        }

        public static bool PutUserConfig(string nome, string senha, string user, long id, string senhaantiga, string confirma)
        {
            if (nome == "" || senha == "")
            {
                throw new EspaçoEmBrancoException();
            }

            var pessoa = new Pessoa()
            {
                Nome = nome,
                Senha = senha,
                Usuario = user,
                Id = id
            };

            var content = JsonConvert.SerializeObject(pessoa);
            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/Pessoas/" + id;
            var resultClient = httpClient.PutAsync(URL, new StringContent(content, Encoding.UTF8, "application/json"));
            resultClient.Wait();

            var result = resultClient.Result.Content.ReadAsStringAsync();
            result.Wait();

            

            return true;
        }
    }
}
