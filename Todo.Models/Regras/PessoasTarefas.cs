using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Todo.API.Models;

namespace TodoApi.Regras
{
    public class PessoasTarefas
    {
        public static List<Pessoa> GetPessoas()
        {
            var lista = new List<Pessoa>();

            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/Pessoas";
            var resultRequest = httpClient.GetAsync(URL);
            resultRequest.Wait();

            var result = resultRequest.Result.Content.ReadAsStringAsync();
            result.Wait();

            var data = JsonConvert.DeserializeObject<List<Pessoa>>(result.Result);

            foreach(var item in data)
            {
                lista.Add(item);
            }

            return lista;
        }

        public static void CadastrarPessoa(Pessoa pessoa)
        {
            var content = JsonConvert.SerializeObject(pessoa);
            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/Pessoas";
            var resultClient = httpClient.PostAsync(URL, new StringContent(content, Encoding.UTF8, "application/json"));
            resultClient.Wait();
            var result = resultClient.Result.Content.ReadAsStringAsync();
            result.Wait();

        }

        
    }
}
