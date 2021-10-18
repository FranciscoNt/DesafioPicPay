using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace DesafioPicPay
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtEmail.Text = "franciscoc.nt@gmail.com";
            txtSenha.Text = "123456";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtEmail.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Email ou senha vazio!", "Forneça os dados para acesso!", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtSenha.Clear();
                txtEmail.Focus();
            }
            else
            {
                Conexao con = new Conexao();

                try
                {
                    con.conectar();
                    string sql = "SELECT * FROM Usuarios WHERE email = '" + txtEmail.Text + "' AND senha = '" + txtSenha.Text + "'";

                    SQLiteDataAdapter data = new SQLiteDataAdapter(sql, con.conexao);
                    DataTable user = new DataTable();
                    data.Fill(user);

                    if (user.Rows.Count < 0)
                    {
                        MessageBox.Show("Usuário inválido", "Usuário não encontrado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSenha.Clear();
                        txtEmail.Focus();
                    }
                    else if (user.Rows.Count == 1)
                    {
                        Usuario usuarioLogado = new Usuario();


                        //object x = user.Rows[0]["Saldo"];
                        //MessageBox.Show(x.GetType().Name);

                        usuarioLogado.id = (Int32)(Int64)user.Rows[0]["Id"];
                        usuarioLogado.nome = user.Rows[0]["Nome"].ToString();
                        usuarioLogado.TipoPessoa = (int)user.Rows[0]["TipoPessoa"];
                        usuarioLogado.cpfCNPJ = user.Rows[0]["CPFCNPJ"].ToString();
                        usuarioLogado.email = user.Rows[0]["Email"].ToString();
                        usuarioLogado.senha = user.Rows[0]["Senha"].ToString();
                        usuarioLogado.saldo = (double)user.Rows[0]["Saldo"];

                        Form1 form = new Form1(usuarioLogado);
                        form.ShowDialog();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuário inválido", "Usuário não encontrado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSenha.Clear();
                        txtEmail.Focus();
                    }
                    con.desconectar();


                }
                catch(Exception E)
                {
                    MessageBox.Show(E.Message.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                



            }


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroUsuario cad = new CadastroUsuario();
            cad.ShowDialog();
        }
    }
}
