using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAFEMANAGER360
{
    public partial class PDV : Form
    {
        public PDV()
        {
            InitializeComponent();
        }

        //botão finalizar pedido
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                Pedido p = new Pedido();

                p.NomeCliente = txtNome.Text;
                p.ValorItem = double.Parse(txtValor.Text);
                p.Quantidade = (int)numQtd.Value;
                p.Fidelidade = chkFidelidade.Checked;

                double total = p.CalcularValorTotal();
                double bruto = p.ValorItem * p.Quantidade;

                string mensagemBonus = "";
                if (bruto >= 10)
                {
                    mensagemBonus = "\n🎁 PARABÉNS: Você ganhou um carimbo fidelidade!";
                }

                MessageBox.Show($"Cliente: {p.NomeCliente}\n" +
                                $"Total a Pagar: {total:C2}" +
                                mensagemBonus,
                                "Resumo do Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro: Verifique se os valores foram digitados corretamente.", "Erro de Entrada");
            }
        }
        //botão fechar x
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
