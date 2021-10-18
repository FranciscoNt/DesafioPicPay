using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPicPay
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int TipoPessoa { get; set; }
        public string cpfCNPJ { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public double saldo { get; set; }
    }
}
