using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> ListContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Tranferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.Readline();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Bank ao seu dispor!");
            Console.WriteLine("Informe a transação:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Tranferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.Readline().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta.");

            Console.WriteLine("1 - PF | 2 - PJ");
            int entradaTipoConta = int.Parse(Console.Readline());

            Console.WriteLine("Nome");
            string entradaNome = Console.Readline();

            Console.WriteLine("Saldo");
            double entradaSaldo = double.Parse(Console.Readline());

            Console.WriteLine("Crédito");
            double entradaCredito = double.Parse(Console.Readline());

            Conta novaConta = new Conta
            (
                tipoConta: (TipoConta)entradaTipoConta,
                saldo: entradaSaldo,
                credito: entradaCredito,
                nome: entradaNome
            );

            ListContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if(ListContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for(int x = 0; x < ListContas.Count; x++)
            {
                Conta conta = ListContas[x];
                Console.WriteLine("#{0} - ", x);
                Console.WriteLine(conta);
            }
        }

        private static void Sacar()
        {
            Console.WriteLine("Informe a conta");
            int indiceConta = int.Parse(Console.Readline());

            Console.WriteLine("Informe o valor");
            double valorSaque = double.Parse(Console.Readline());

            ListContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("Informe a conta");
            int indiceConta = int.Parse(Console.Readline());

            Console.WriteLine("Informe o valor");
            double valorDeposito = double.Parse(Console.Readline());

            ListContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Tranferir()
        {
            Console.WriteLine("Informe a conta origem");
            int indiceConta = int.Parse(Console.Readline());

            Console.WriteLine("Informe a conta destino");
            int contaDestino = int.Parse(Console.Readline());            

            Console.WriteLine("Informe o valor");
            double valorTransferencia = double.Parse(Console.Readline());

            ListContas[indiceConta].Transferir(valorTransferencia, contaDestino);
        }
    }
}
