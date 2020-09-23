using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Todo.API.Models;

namespace Validadores
{
    public class ValidadoresTarefa
    {
        public static bool ValidadorNovaTarefa(string nome, int? idpessoa, string descricao, DateTime data)
        {

            if (nome == "" || descricao == "" || data == null || idpessoa == null)
            {
                return false;
            }

            var tarefa = new Tarefa()
            {
                Nome = nome,
                IdPessoa = Convert.ToInt32(idpessoa),
                Descricao = descricao,
                Data = data,
                Status = false
            };

            var content = JsonConvert.SerializeObject(tarefa);
            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/TodoItems";
            var resultClient = httpClient.PostAsync(URL, new StringContent(content, Encoding.UTF8, "application/json"));
            resultClient.Wait();
            var result = resultClient.Result.Content.ReadAsStringAsync();
            result.Wait();

            return true;
        }
    }
}
