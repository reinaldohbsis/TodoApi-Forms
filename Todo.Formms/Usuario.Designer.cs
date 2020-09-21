namespace Todo.Formms
{
    partial class Usuario
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
            this.lst_tarefas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lst_tarefas
            // 
            this.lst_tarefas.FormattingEnabled = true;
            this.lst_tarefas.ItemHeight = 25;
            this.lst_tarefas.Location = new System.Drawing.Point(13, 13);
            this.lst_tarefas.Name = "lst_tarefas";
            this.lst_tarefas.Size = new System.Drawing.Size(453, 429);
            this.lst_tarefas.TabIndex = 0;
            this.lst_tarefas.SelectedIndexChanged += new System.EventHandler(this.lst_tarefas_SelectedIndexChanged);
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 744);
            this.Controls.Add(this.lst_tarefas);
            this.Name = "Usuario";
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.Usuario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_tarefas;
    }
}