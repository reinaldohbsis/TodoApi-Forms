using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            //box.Items.Add("JORJE", CheckState.Unchecked);

            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/Pessoas/" + _id;
            var resultClient = httpClient.GetAsync(URL);
            resultClient.Wait();
            var result = resultClient.Result.Content.ReadAsStringAsync();
            result.Wait();

            var data = JsonConvert.DeserializeObject<List<Tarefa>>(result.Result);
            //List<Tarefa> list = new List<Tarefa>();
            //int c = 0;

            foreach (var item in data)
            {
                //list.Add(item);

                _tarefa.Add(item);
                lst_lista.Items.Add($"{item.Id} | {item.Nome} | {item.Status}");
            }

            //lst_tarefas.Text += list;
        }

        private void box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {

            foreach (var item in _tarefa)
            {
                if (item.Id.ToString() == txt_id.Text)
                {
                    new ExibirTarefa(_tarefa[Convert.ToInt32(item.Id) - 1]).ShowDialog();
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
    }
}
