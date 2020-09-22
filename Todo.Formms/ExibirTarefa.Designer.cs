namespace Todo.Formms
{
    partial class ExibirTarefa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lst_descricao = new System.Windows.Forms.ListBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.date_data = new System.Windows.Forms.DateTimePicker();
            this.lbl_situacao = new System.Windows.Forms.Label();
            this.btn_atualizar = new System.Windows.Forms.Button();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_voltar = new System.Windows.Forms.Button();
            this.cb_situacao = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lst_descricao
            // 
            this.lst_descricao.FormattingEnabled = true;
            this.lst_descricao.ItemHeight = 25;
            this.lst_descricao.Location = new System.Drawing.Point(12, 66);
            this.lst_descricao.Name = "lst_descricao";
            this.lst_descricao.Size = new System.Drawing.Size(444, 379);
            this.lst_descricao.TabIndex = 0;
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(13, 13);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(443, 31);
            this.txt_nome.TabIndex = 1;
            // 
            // date_data
            // 
            this.date_data.Location = new System.Drawing.Point(12, 514);
            this.date_data.Name = "date_data";
            this.date_data.Size = new System.Drawing.Size(444, 31);
            this.date_data.TabIndex = 2;
            // 
            // lbl_situacao
            // 
            this.lbl_situacao.AutoSize = true;
            this.lbl_situacao.Location = new System.Drawing.Point(180, 473);
            this.lbl_situacao.Name = "lbl_situacao";
            this.lbl_situacao.Size = new System.Drawing.Size(88, 25);
            this.lbl_situacao.TabIndex = 3;
            this.lbl_situacao.Text = "Situação: ";
            // 
            // btn_atualizar
            // 
            this.btn_atualizar.Location = new System.Drawing.Point(12, 581);
            this.btn_atualizar.Name = "btn_atualizar";
            this.btn_atualizar.Size = new System.Drawing.Size(444, 34);
            this.btn_atualizar.TabIndex = 4;
            this.btn_atualizar.Text = "Atualizar";
            this.btn_atualizar.UseVisualStyleBackColor = true;
            // 
            // btn_excluir
            // 
            this.btn_excluir.Location = new System.Drawing.Point(12, 630);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(444, 34);
            this.btn_excluir.TabIndex = 4;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.UseVisualStyleBackColor = true;
            // 
            // btn_voltar
            // 
            this.btn_voltar.Location = new System.Drawing.Point(12, 698);
            this.btn_voltar.Name = "btn_voltar";
            this.btn_voltar.Size = new System.Drawing.Size(444, 34);
            this.btn_voltar.TabIndex = 4;
            this.btn_voltar.Text = "Voltar";
            this.btn_voltar.UseVisualStyleBackColor = true;
            this.btn_voltar.Click += new System.EventHandler(this.btn_voltar_Click);
            // 
            // cb_situacao
            // 
            this.cb_situacao.FormattingEnabled = true;
            this.cb_situacao.Location = new System.Drawing.Point(274, 465);
            this.cb_situacao.Name = "cb_situacao";
            this.cb_situacao.Size = new System.Drawing.Size(182, 33);
            this.cb_situacao.TabIndex = 5;
            // 
            // ExibirTarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 744);
            this.Controls.Add(this.cb_situacao);
            this.Controls.Add(this.btn_voltar);
            this.Controls.Add(this.btn_excluir);
            this.Controls.Add(this.btn_atualizar);
            this.Controls.Add(this.lbl_situacao);
            this.Controls.Add(this.date_data);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.lst_descricao);
            this.Name = "ExibirTarefa";
            this.Text = "ExibirTarefa";
            this.Load += new System.EventHandler(this.ExibirTarefa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_descricao;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.DateTimePicker date_data;
        private System.Windows.Forms.Label lbl_situacao;
        private System.Windows.Forms.Button btn_atualizar;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Button btn_voltar;
        private System.Windows.Forms.ComboBox cb_situacao;
    }
}