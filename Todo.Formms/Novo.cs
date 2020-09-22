using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Todo.API.Models;

namespace Todo.Formms
{
    public partial class Novo : Form
    {
        public int _id;
        public Novo(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            var tarefa = new Tarefa()
            {
                Nome = txt_nome.Text,
                IdPessoa = _id,
                Descricao = txt_descricao.Text,
                Data = date_data.Value,
                Status = false
                
            };

            var content = JsonConvert.SerializeObject(tarefa);
            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/TodoItems";
            var resultClient = httpClient.PostAsync(URL, new StringContent(content, Encoding.UTF8, "application/json"));
            resultClient.Wait();
            var result = resultClient.Result.Content.ReadAsStringAsync();
            result.Wait();

            this.Visible = false;
            new Usuario(_id).ShowDialog();
        }
    }
}
