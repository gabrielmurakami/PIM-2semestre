using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMANAGER360
{
    public class Pedido
    {
        public string NomeCliente { get; set; }
        public double ValorItem { get; set; }
        public int Quantidade { get; set; }
        public bool Fidelidade { get; set; }

        public double ValorBruto
        {
            get { return ValorItem * Quantidade; }
        }

        public double CalcularValorTotal()
        {
            double total = ValorItem * Quantidade;
            if (Fidelidade)
            {
                total *= 0.9; // aplica um desconto de 10% para clientes fidelidade
            }
            return total;
        }

        public void PromoFidelidade()
        {
            if (ValorBruto >= 10)
            {
                Console.WriteLine("\n\nBÔNUS: Este pedido ganhou um carimbo no cartão fidelidade!\n\n");
            }
        }
    }
}