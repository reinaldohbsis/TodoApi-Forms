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
    public partial class Login : Form
    {
        public Atual user;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            user = new Atual();
            user.User = txt_user.Text;
            user.Senha = txt_user.Text;

            var httpClient = new HttpClient();
            var URL = "https://localhost:44336/api/Pessoas";
            var resultRequest = httpClient.GetAsync(URL);
            resultRequest.Wait();

            var result = resultRequest.Result.Content.ReadAsStringAsync();
            result.Wait();

            var data = JsonConvert.DeserializeObject<List<Pessoa>>(result.Result);
           // var rep = new List<Atual>();

            foreach(var log in data)
            {
                if (log.Usuario == txt_user.Text)
                {
                    if (log.Senha == txt_senha.Text)
                    {
                        
                        
                        this.Visible = false;
                        new Usuario(Convert.ToInt32(log.Id)).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Senha Incorreta");
                        txt_senha.Text = "";
                    }
                }
            }


        }
    }
}
