using System;
using System.Windows.Forms;

namespace CAFEMANAGER360
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("=== CAFEMANAGER 360 - SISTEMA DA CAFETERIA ===");
            Console.WriteLine("1 - Abrir Modo Terminal (Console)");
            Console.WriteLine("2 - Abrir Modo PDV (Interface Gráfica Windows)");
            Console.Write("\nEscolha como deseja iniciar: ");

            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                ExecutarConsole();
            }
            else if (opcao == "2")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new PDV());
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Opção inválida. Encerrando...");
                Console.ReadKey();
            }
        }

        static void ExecutarConsole()
        {
            Console.Clear(); 
            Console.WriteLine("--- CADASTRO DE PEDIDO ---\n");

            Pedido p = new Pedido();
            
            Console.Write("Nome do Cliente: ");
            p.NomeCliente = Console.ReadLine();

            Console.Write("Valor do Café (ex: 5,50): ");
            p.ValorItem = double.Parse(Console.ReadLine());

            Console.Write("Quantidade: ");
            p.Quantidade = int.Parse(Console.ReadLine());

            double valorBruto = p.ValorItem * p.Quantidade;

            Console.Write("Cliente Fidelidade? (S/N): ");
            p.Fidelidade = Console.ReadLine().ToUpper() == "S";

            double total = p.CalcularValorTotal();

            p.PromoFidelidade();

            Console.WriteLine("\n-------------------------------");
            Console.WriteLine($"PEDIDO PROCESSADO PARA: {p.NomeCliente}");
            Console.WriteLine($"TOTAL A PAGAR: {total:C2}");
            Console.WriteLine("-------------------------------");

            Console.WriteLine("\nPressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}