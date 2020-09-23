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

        public static bool ValidadorAtualizar(string nome, string descricao, DateTime data, long? idpessoa, long? idtarefa, string status)
        {
            if (nome == "" || descricao == "" || data == null || idpessoa == null || idtarefa == null || status == null)
            {
                return false;
            }

            var tarefa = new Tarefa()
            {
                Nome = nome,
                Descricao = descricao,
                Data = data,
                Status = (status == "Aberto") ? false : true,
                Id = Convert.ToInt32(idtarefa),
                IdPessoa = Convert.ToInt32(idpessoa)
            };

            var content = JsonConvert.SerializeObject(tarefa);
            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/TodoItems/" + idtarefa;
            var resultClient = httpClient.PutAsync(URL, new StringContent(content, Encoding.UTF8, "application/json"));
            resultClient.Wait();

            var result = resultClient.Result.Content.ReadAsStringAsync();
            result.Wait();



            return true;
        }

        public static bool ExcluirTarefa(long? idselecao)
        {
            if(idselecao == null)
            {
                return false;
            }

            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/TodoItems/" + idselecao;
            var resultClient = httpClient.DeleteAsync(URL);
            resultClient.Wait();

            var result = resultClient.Result.Content.ReadAsStringAsync();
            result.Wait();

            return true;
            
        }
    }
}
