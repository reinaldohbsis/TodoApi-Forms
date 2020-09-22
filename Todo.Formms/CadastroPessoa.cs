using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Todo.API.Models;
using TodoApi.Regras;

namespace Todo.Formms
{
    public partial class CadastroPessoa : Form
    {
        public CadastroPessoa()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            var pessoas = new List<Pessoa>();
            var getpessoas = PessoasTarefas.GetPessoas();
            

            var teste = getpessoas.Where(x => x.Usuario == txt_user.Text).FirstOrDefault();

            //foreach (var item in getpessoas.Where(x => x.Usuario == txt_user.Text))
            //{
            //    pessoas.Add(item);
            //}

            if (teste == null)
            {

                if (txt_senha.Text == txt_senhaconf.Text)
                {
                    var pessoa = new Pessoa()
                    {
                        Nome = txt_nome.Text,
                        Usuario = txt_user.Text,
                        Senha = txt_senha.Text
                    };

                    PessoasTarefas.CadastrarPessoa(pessoa);


                    MessageBox.Show("Usuário cadastrado");

                    this.Visible = false;
                    new Login().ShowDialog();
                }
                else
                {
                    MessageBox.Show("Não sabe digitar senha não?");
                }
            }
            else
            {
                MessageBox.Show("Usuário já existe");
            }
        }
    }
}
