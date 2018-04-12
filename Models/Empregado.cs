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
        public decimal FaixaImposto { get; set; }

        public Empregado() { }

        /*
         *  < 3k = isento
         * 3k - 5k =>  10 % imposto
         * 5k - 7k => 15 % imposto
         * 7k => 25%
         */
        public decimal CalculaSalarioLiquido(decimal salario)
        {
            FaixaImposto = 0;

            if (salario >= 3000 && salario <= 5000)
            {
                FaixaImposto = 0.1m;
                SalarioLiquido = salario - (salario * FaixaImposto);

                return SalarioLiquido;
            }
            else if (salario > 5000 && salario <= 7000)
            {
                FaixaImposto = 0.15m;
                SalarioLiquido = salario - (salario * FaixaImposto);

                return SalarioLiquido;
            }
            else if (salario > 7000)
            {
                FaixaImposto = 0.25m;
                SalarioLiquido = salario - (salario * FaixaImposto);

                return SalarioLiquido;
            }

            return SalarioBruto;

        }

    }
}
