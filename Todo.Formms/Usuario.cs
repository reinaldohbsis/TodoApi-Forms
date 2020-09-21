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
    public partial class Usuario : Form
    {
        public int _id;
        public Usuario(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private void lst_tarefas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            //box.Items.Add("JORJE", CheckState.Unchecked);


            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/Pessoas/" + _id;
            var resultClient = httpClient.GetAsync(URL);
            resultClient.Wait();

            var result = resultClient.Result.Content.ReadAsStringAsync();
            result.Wait();

            var data = JsonConvert.DeserializeObject<List<Tarefa>>(result.Result);
            List<Tarefa> list = new List<Tarefa>();

            foreach (var item in data)
            {
                list.Add(item);
                box.Items.Add(item.Nome, CheckState.Unchecked);
            }

            //lst_tarefas.Text += list;
        }

        private void box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
