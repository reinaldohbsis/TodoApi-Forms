using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Todo.Forms
{
    public partial class PaginaUsuario : Form
    {
        public PaginaUsuario()
        {
            InitializeComponent();
            var tarefas = new Tarefa(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var httpClient = new HttpClient();
            var URL = "http://localhost:5000/Pokebag/todosPokemonsDaBag";
            var resultRequest = httpClient.GetAsync(URL);
            resultRequest.Wait();

            var result = resultRequest.Result.Content.ReadAsStringAsync();
            result.Wait();

            var data = JsonConvert.DeserializeObject(result.Result);
            var lista = new List<>();

            foreach (var pokemon in data)
            {
                lista.Add(pokemon);
            }

            this.dataGridView1.DataSource = lista;
        }
    }
}
