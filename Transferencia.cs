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
    public partial class Transferencia : Form
    {
        public Transferencia()
        {
            InitializeComponent();


        }

        private Usuario _usuarioLogado;

        public Transferencia(Usuario usuarioLogado) : this()
        {
            _usuarioLogado = usuarioLogado;


            Conexao con = new Conexao();
            con.conectar();


            String sql = "SELECT * FROM USUARIOS WHERE ID NOT IN (" + _usuarioLogado.id + ")";

            /*var cmd = new SQLiteCommand(sql, con.conexao);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            DataTable user;
            while (rdr.Read())
            {
                user = new DataTable();
                cbUsuarios.Items.Add(user.Rows[0]["Email"].ToString());
                //Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetInt32(2)}");
            }*/



            SQLiteDataAdapter data = new SQLiteDataAdapter(sql, con.conexao);
            using (SQLiteCommand fmd = con.conexao.CreateCommand())
            {
                fmd.CommandText = sql;
                SQLiteDataReader r = fmd.ExecuteReader();
                int i = 0;
                while (r.Read())
                {

                    DataTable user = new DataTable();
                    data.Fill(user);
                    /*
                    Usuario usuario = new Usuario();
                    usuario.id = (Int32)(Int64)user.Rows[0]["Id"];
                    usuario.nome = user.Rows[0]["Nome"].ToString();
                    usuario.TipoPessoa = (int)user.Rows[0]["TipoPessoa"];
                    usuario.cpfCNPJ = user.Rows[0]["CPFCNPJ"].ToString();
                    usuario.email = user.Rows[0]["Email"].ToString();
                    usuario.senha = user.Rows[0]["Senha"].ToString();
                    usuario.saldo = (double)user.Rows[0]["Saldo"];
                    */

                    cbUsuarios.Items.Add(user.Rows[i]["Email"].ToString());
                    i++;
                }

            }
            con.desconectar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 princ = new Form1();
            princ.AtualizarUsuario(_usuarioLogado);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cbUsuarios.Text == "")
            {
                MessageBox.Show("Selecione uma pessoa a receber!", "Inválido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            double valorTransferir = Convert.ToDouble(txtValor.Text);
            _usuarioLogado.saldo -= valorTransferir;

            if (_usuarioLogado.saldo < 0)
            {
                Form1 princ = new Form1();
                _usuarioLogado.saldo += valorTransferir;
                princ.AtualizarUsuario(_usuarioLogado);
                MessageBox.Show("Você não possui saldo disponível!", "Saldo indisponível!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
                return;
            }


            Conexao con = new Conexao();

            try
            {

                con.conectar();

                string sql = "SELECT saldo FROM USUARIOS WHERE email = '" + cbUsuarios.SelectedText + "'";

                SQLiteDataAdapter data = new SQLiteDataAdapter(sql, con.conexao);
                DataTable user = new DataTable();
                data.Fill(user);

                double saldo = 0;
                if (user.Rows.Count == 1)
                {
                    saldo = (double)user.Rows[0]["Saldo"];
                }
                saldo += valorTransferir;


                SQLiteCommand sqCommand = new SQLiteCommand();
                SQLiteTransaction transaction;


                transaction = con.conexao.BeginTransaction();
                sqCommand.Transaction = transaction;


                Form1 princ = new Form1();

                // UPDATE
                try
                {
                    sqCommand.CommandText = "Update Usuarios set Saldo = " + _usuarioLogado.saldo + " where Id = " + _usuarioLogado.id;
                    sqCommand.ExecuteNonQuery();
                    sqCommand.CommandText = "Update Usuarios set Saldo = " + saldo + " where email = '" + cbUsuarios.Text +"' ";
                    sqCommand.ExecuteNonQuery();
                    transaction.Commit();

                    MessageBox.Show("Transferência realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    princ.AtualizarUsuario(_usuarioLogado);

                }
                catch (Exception E)
                {
                    transaction.Rollback();
                    _usuarioLogado.saldo += valorTransferir;
                    MessageBox.Show(E.Message.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.conexao.Close();
                }

            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
