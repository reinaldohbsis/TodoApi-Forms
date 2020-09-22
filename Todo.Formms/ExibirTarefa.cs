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
    public partial class ExibirTarefa : Form
    {
        public Tarefa _tarefa;
        public int idselecao;
        public ExibirTarefa(Tarefa tarefa)
        {      
            _tarefa = tarefa;
            idselecao = Convert.ToInt32(_tarefa.Id);
            InitializeComponent();
        }

        private void ExibirTarefa_Load(object sender, EventArgs e)
        {
            txt_nome.Text = _tarefa.Nome;
            txtbox_grande.Text = _tarefa.Descricao;
            if (_tarefa.Status)
            {
                
                cb_situacao.Items.Add("Finalizado");
                cb_situacao.Items.Add("Aberto");
                cb_situacao.SelectedItem = "Finalizado";
            }
            else
            {
                cb_situacao.Items.Add("Aberto");
                cb_situacao.Items.Add("Finalizado");
                cb_situacao.SelectedItem = "Aberto";
            }
            date_data.Value = _tarefa.Data;


        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Usuario(Convert.ToInt32(_tarefa.IdPessoa)).ShowDialog();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            
            var tarefa = new Tarefa()
            {
                Id = idselecao
            };

            var dialog = MessageBox.Show("Deseja excluir?", "Excluir", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                var httpClient = new HttpClient();
                var URL = "https://localhost:44336/api/TodoItems/" + idselecao;
                var resultClient = httpClient.DeleteAsync(URL);
                resultClient.Wait();

                var result = resultClient.Result.Content.ReadAsStringAsync();
                result.Wait();

                this.Visible = false;
                new Usuario(Convert.ToInt32(_tarefa.IdPessoa)).ShowDialog();
            }


        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            var tarefa = new Tarefa()
            {
                Nome = txt_nome.Text,
                Descricao = txtbox_grande.Text,
                Data = date_data.Value,
                Status = (cb_situacao.Text == "Aberto") ? false : true,
                Id = _tarefa.Id,
                IdPessoa = _tarefa.IdPessoa
            };
            
            var dialog = MessageBox.Show("Deseja atualizar?", "Atualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                var content = JsonConvert.SerializeObject(tarefa);
                var httpClient = new HttpClient();
                var URL = "https://localhost:44336/api/TodoItems/" + idselecao;
                var resultClient = httpClient.PutAsync(URL, new StringContent(content, Encoding.UTF8, "application/json"));
                resultClient.Wait();

                var result = resultClient.Result.Content.ReadAsStringAsync();
                result.Wait();

                this.Visible = false;
                new Usuario(Convert.ToInt32(_tarefa.IdPessoa)).ShowDialog();
            }

        }
    }
}
