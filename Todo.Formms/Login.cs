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
using Validadores;

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
            if (txt_user.Text != "" && txt_senha.Text != "")
            {
                Pessoa user = ValidadoresPessoa.GetUser(txt_user.Text);

                if(user != null) 
                { 
                        if (user.Senha == txt_senha.Text)
                        {
                            this.Visible = false;
                            new Usuario(Convert.ToInt32(user.Id)).ShowDialog();                        
                        }
                        else
                        {
                            MessageBox.Show("Senha Incorreta");
                            txt_senha.Text = "";       
                        }
                    
                }
                else
                MessageBox.Show("ESTE UZUARIO NON ECZISTE");
            }
            else
            {
                MessageBox.Show("Você nem digitou um usuário ou senha\n\nAcha que sou palhaço? Aqui não nenem");
            }
        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new CadastroPessoa().ShowDialog();
        }
    }
}
