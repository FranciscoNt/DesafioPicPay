using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace DesafioPicPay
{
    public partial class Deposito : Form
    {
        public Deposito()
        {
            InitializeComponent();
            //txtValor.Text = txtValor.ToString("C2", CultureInfo.CurrentCulture));
            /*txtValor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtValor.Properties.Mask.EditMask = "n2";
            txtValor.Properties.Mask.UseMaskAsDisplayFormat = true;*/
        }

        public Usuario _usuarioLogado;

        public Deposito(Usuario usuarioLogado) : this()
        {
            _usuarioLogado = usuarioLogado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao con = new Conexao();
            con.conectar();

            double deposito = Convert.ToDouble(txtValor.Text);
            _usuarioLogado.saldo += deposito;



            string sqlInsert = "Update Usuarios set Saldo = " + _usuarioLogado.saldo + " where Id = " + _usuarioLogado.id;
                                
            // UPDATE
            using (var comm = new System.Data.SQLite.SQLiteCommand(con.conexao))
            {
                comm.CommandText = sqlInsert;

                Form1 princ = new Form1();
                

                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Depósito efetuado com sucesso", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    princ.AtualizarUsuario(_usuarioLogado);
                    Close();
                }
                catch (Exception Er)
                {
                    _usuarioLogado.saldo -= deposito;
                    MessageBox.Show(Er.Message.ToString(), "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    princ.AtualizarUsuario(_usuarioLogado);
                }
            }
        }
    }
}
