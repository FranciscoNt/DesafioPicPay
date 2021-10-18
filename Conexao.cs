using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DesafioPicPay
{
    class Conexao
    {
        public SQLiteConnection conexao = new SQLiteConnection("Data Source=Desafio.db");

        public void conectar()
        {
            conexao.Open();
        }


        public void desconectar()
        {
            conexao.Close();
        }


        public void inserirUsuario(Usuario user)
        {

        }

    }
}
