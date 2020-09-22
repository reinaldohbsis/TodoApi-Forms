using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.API.Models;

namespace Todo.Formms
{
    public partial class ExibirTarefa : Form
    {
        public Tarefa _tarefa;
        public ExibirTarefa(Tarefa tarefa)
        {
            _tarefa = tarefa;
            InitializeComponent();
        }

        private void ExibirTarefa_Load(object sender, EventArgs e)
        {
            txt_nome.Text = _tarefa.Nome;
            lst_descricao.Items.Add(_tarefa.Descricao);
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
            this.Close();
        }
    }
}
