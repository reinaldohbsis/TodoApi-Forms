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
            
            var dialog = MessageBox.Show("Deseja excluir?", "Excluir", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                
                bool result = ValidadoresTarefa.ExcluirTarefa(idselecao);

                if (result)
                {
                    this.Visible = false;
                    new Usuario(Convert.ToInt32(_tarefa.IdPessoa)).ShowDialog();
                }

                else
                {
                    MessageBox.Show("Hmmm, aparentemente o valor da tarefa é nulo");
                }
            }
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            
            
            var dialog = MessageBox.Show("Deseja atualizar?", "Atualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                bool result = ValidadoresTarefa.ValidadorAtualizar(txt_nome.Text, txtbox_grande.Text, date_data.Value, _tarefa.IdPessoa, _tarefa.Id, cb_situacao.Text);
                if (result)
                {
                    this.Visible = false;
                    new Usuario(Convert.ToInt32(_tarefa.IdPessoa)).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Errar é humano, mas olha...\n\nNão consigo atualizar assim não, sinto muito");
                }
            }

        }
    }
}
