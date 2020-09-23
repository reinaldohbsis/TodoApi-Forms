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
    public partial class Novo : Form
    {
        public int _id;
        public Novo(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {           
            bool resultado = ValidadoresTarefa.ValidadorNovaTarefa(txt_nome.Text, _id, txt_descricao.Text, date_data.Value);
            if (resultado)
            {
                MessageBox.Show("Nova tarefa cadastrada");
                this.Visible = false;
                new Usuario(_id).ShowDialog();
            }
            else
            {
                MessageBox.Show("Parece que tem algo faltando por ai");
            }
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Usuario(_id).ShowDialog();
        }
    }
}
