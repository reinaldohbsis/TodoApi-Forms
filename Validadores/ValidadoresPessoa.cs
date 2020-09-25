using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Todo.API.Models;

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

    }
}
