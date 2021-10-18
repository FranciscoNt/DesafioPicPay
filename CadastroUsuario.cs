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
    public partial class CadastroUsuario : Form
    {
        public CadastroUsuario()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidaSenha()
        {
            if (txtSenha.Text == txtVerificaSenha.Text)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtCPFCNPJ.Text == "" || txtEmail.Text == "" || txtSenha.Text == "" || txtVerificaSenha.Text == "")
            {
                MessageBox.Show("Campo inválido", "Campo vazio!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {

                if (ValidaSenha())
                {
                    Conexao con = new Conexao();

                    try
                    {
                        con.conectar();
                        string sql = "SELECT * FROM Usuarios WHERE email = '" + txtEmail.Text + "' OR CPFCNPJ = '" + txtCPFCNPJ.Text + "'";

                        SQLiteDataAdapter data = new SQLiteDataAdapter(sql, con.conexao);
                        DataTable user = new DataTable();
                        data.Fill(user);

                        if (user.Rows.Count > 0)
                        {

                            MessageBox.Show("Usuário já cadastrado", "Usuário inválido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        else
                        {
                            Usuario usuario = new Usuario();



                            usuario.nome = txtNome.Text;
                            if (rbPesFis.Checked)
                                usuario.TipoPessoa = 0;
                            else
                                usuario.TipoPessoa = 1;
                            usuario.cpfCNPJ = txtCPFCNPJ.Text;
                            usuario.email = txtEmail.Text;
                            usuario.senha = txtSenha.Text;
                            usuario.saldo = 0;


                            string sqlInsert = "INSERT INTO Usuarios (Nome, TipoPessoa, CPFCNPJ, Email, Senha, Saldo) VALUES ('"
                                + usuario.nome + "', "
                                + usuario.TipoPessoa + ", '"
                                + usuario.cpfCNPJ + "', '"
                                + usuario.email + "', '"
                                + usuario.senha + "', "
                                + usuario.saldo + ")";

                            // INSERT
                            using (var comm = new System.Data.SQLite.SQLiteCommand(con.conexao))
                            {
                                comm.CommandText = sqlInsert;

                                try
                                {
                                    comm.ExecuteNonQuery();
                                    MessageBox.Show("USuário inserido com sucesso", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    Close();
                                }
                                catch (Exception Er)
                                {
                                    MessageBox.Show(Er.Message.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }

                        con.desconectar();

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Senhas inválidas!", "As senhas não estão iguais!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
