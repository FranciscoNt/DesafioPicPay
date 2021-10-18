using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioPicPay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Usuario _usuarioLogado;

        public Form1(Usuario usuarioLogado) : this()
        {
            _usuarioLogado = usuarioLogado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void AtualizarUsuario(Usuario usuarioLogado)
        {
            _usuarioLogado = null;
            _usuarioLogado = usuarioLogado;
        }

        private void transferênciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seu saldo é de R$ " + _usuarioLogado.saldo + " reais", "Saldo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void transferênciasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Deposito deposito = new Deposito(_usuarioLogado);
            deposito.Show();
        }

        private void transferênciasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (_usuarioLogado.TipoPessoa == 1)
            {
                MessageBox.Show("Movimentação permitida apenas para pessoa física!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Transferencia transferencia = new Transferencia(_usuarioLogado);
            transferencia.ShowDialog();

        }
    }
}
