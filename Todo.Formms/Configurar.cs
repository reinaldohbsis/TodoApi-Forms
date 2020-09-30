using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.API.Models;
using Validadores.Exceptions;

namespace Todo.Formms
{
    public partial class Configurar : Form
    {
        public Pessoa _pessoa;
        public Configurar(int id)
        {
            InitializeComponent();
            Pessoa pessoa = Validadores.ValidadoresPessoa.GetUserConfig(id);
            _pessoa = pessoa;
        }

        private void Configurar_Load(object sender, EventArgs e)
        {
            lbl_user.Text = _pessoa.Usuario;
            txt_Nome.Text = _pessoa.Nome;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Deseja atualizar?", "Atualizar", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    var result = Validadores.ValidadoresPessoa.PutUserConfig(txt_Nome.Text, txt_senhanova.Text, lbl_user.Text, _pessoa.Id, txt_senha.Text, txt_confirma.Text, _pessoa.Senha);
                    this.Visible = false;
                    new Usuario(Convert.ToInt32(_pessoa.Id)).ShowDialog();
                }
                catch(SenhaErradaException ex )
                {
                    MessageBox.Show(ex.Message);
                }
                catch (SenhaNaoBateException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (EspaçoEmBrancoException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Usuario(Convert.ToInt32(_pessoa.Id)).ShowDialog();
        }
    }
}
