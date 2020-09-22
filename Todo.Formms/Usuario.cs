using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Todo.API.Models;

namespace Todo.Formms
{
    public partial class Usuario : Form
    {
        public int _id;
        public List<Tarefa> _tarefa;
        public Usuario(int id)
        {
            _id = id;
            _tarefa = new List<Tarefa>();
            InitializeComponent();
        }

        private void lst_tarefas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Usuario_Load(object sender, EventArgs e)
        {
            Get();
            
        }

        private void box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            int idselecionado = Convert.ToInt32(Selecionar());
            //txt_id.Text = Selecionar();
            foreach (var item in _tarefa)
            {
                if (item.Id.ToString() == idselecionado.ToString())
                {
                    var tarefa = _tarefa.Where(x => x.Id == item.Id).FirstOrDefault();
                    this.Visible = false;
                    new ExibirTarefa(tarefa).ShowDialog();
                }
            }
                        
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Login().ShowDialog();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Novo(_id).ShowDialog();
            
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            int idselecao = Convert.ToInt32(Selecionar());

            //var tarefa = new Tarefa()
            //{
            //    Id = idselecao
            //};

            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/TodoItems/" + idselecao;
            var resultClient = httpClient.DeleteAsync(URL);
            resultClient.Wait();

            var result = resultClient.Result.Content.ReadAsStringAsync();
            result.Wait();
            
            Get();

        }

        public string Selecionar()
        {
            string selecao = lst_lista.SelectedItem.ToString().Substring(0, lst_lista.SelectedItem.ToString().IndexOf('|'));
            return selecao;
        }

        public void Get()
        {
            lst_lista.Items.Clear();
            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/Pessoas/" + _id;
            var resultClient = httpClient.GetAsync(URL);
            resultClient.Wait();
            var result = resultClient.Result.Content.ReadAsStringAsync();
            result.Wait();

            var data = JsonConvert.DeserializeObject<List<Tarefa>>(result.Result);


            //lst_lista.Items.Add("ID  | \t NOME |\t STATUS");
            foreach (var item in data)
            {
                _tarefa.Remove(item);
                _tarefa.Add(item);
                string txtt = String.Format("{0,-5} {1,-40} \t {2} \n",item.Id,item.Nome,item.Status);                
               lst_lista.Items.Add(txtt);
            }

        }
    }
}
