using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsXEmployeeManager.Models
{
    public class Empregado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal SalarioLiquido { get; set; }
        public string FaixaImposto { get; set; }

        public Empregado() { }


        /*
         *  < 3k = isento
         * 3k - 5k =>  10 % imposto
         * 5k - 7k => 15 % imposto
         * 7k => 25%
         */
        public decimal CalculaSalarioLiquido()
        {
            if (SalarioBruto >= 3000 && SalarioBruto <= 5000)
            {
                SalarioLiquido = SalarioBruto - (SalarioBruto * 0.1m);
                return SalarioLiquido;
            }
            else if (SalarioBruto > 5000 && SalarioBruto <= 7000)
            {
                SalarioLiquido = SalarioBruto - (SalarioBruto * 0.15m);
                return SalarioLiquido;
            }
            else
            {
                SalarioLiquido = SalarioBruto - (SalarioBruto * 0.25m);
            }

            return SalarioBruto;

        }

    }
}
