
namespace DesafioPicPay
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.movimentaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferênciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferênciasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.transferênciasToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimentaçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(264, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // movimentaçõesToolStripMenuItem
            // 
            this.movimentaçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transferênciasToolStripMenuItem,
            this.transferênciasToolStripMenuItem1,
            this.transferênciasToolStripMenuItem2});
            this.movimentaçõesToolStripMenuItem.Name = "movimentaçõesToolStripMenuItem";
            this.movimentaçõesToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.movimentaçõesToolStripMenuItem.Text = "Movimentações";
            // 
            // transferênciasToolStripMenuItem
            // 
            this.transferênciasToolStripMenuItem.Name = "transferênciasToolStripMenuItem";
            this.transferênciasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.transferênciasToolStripMenuItem.Text = "Verificar Saldo";
            this.transferênciasToolStripMenuItem.Click += new System.EventHandler(this.transferênciasToolStripMenuItem_Click);
            // 
            // transferênciasToolStripMenuItem1
            // 
            this.transferênciasToolStripMenuItem1.Name = "transferênciasToolStripMenuItem1";
            this.transferênciasToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.transferênciasToolStripMenuItem1.Text = "Depósitos";
            this.transferênciasToolStripMenuItem1.Click += new System.EventHandler(this.transferênciasToolStripMenuItem1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 238);
            this.button1.MaximumSize = new System.Drawing.Size(110, 45);
            this.button1.MinimumSize = new System.Drawing.Size(110, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sair";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // transferênciasToolStripMenuItem2
            // 
            this.transferênciasToolStripMenuItem2.Name = "transferênciasToolStripMenuItem2";
            this.transferênciasToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.transferênciasToolStripMenuItem2.Text = "Transferências";
            this.transferênciasToolStripMenuItem2.Click += new System.EventHandler(this.transferênciasToolStripMenuItem2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 301);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MaximumSize = new System.Drawing.Size(280, 340);
            this.MinimumSize = new System.Drawing.Size(280, 340);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desafio PicPay";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem movimentaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferênciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferênciasToolStripMenuItem1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem transferênciasToolStripMenuItem2;
    }
}

