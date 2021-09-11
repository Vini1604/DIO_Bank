using System;
using System.Collections.Generic;

namespace DIO_Bank
{
    class Program
    {
        static List<Conta> contas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcao = MenuPrincipal();
            while (opcao != "X")
            {
                switch (opcao)
                {   
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        Saque();
                        break;
                    case "3":
                        Deposito();
                        break;
                    case "4":
                        Transferencia();
                        break;
                    case "5":
                        Console.Clear();
                        break;
                    case "6":
                        NovaConta();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcao = MenuPrincipal();
            }
            Console.WriteLine("Obrigado por utilizar nosso banco!!");
            Console.WriteLine();
        }

        private static void ListarContas(){
            if (contas.Count == 0)
            {
                Console.WriteLine("Não há contas a serem listadas!!!");
                return;
            }
            for(int i = 0; i < contas.Count; i++)
            {
                Conta conta = contas[i];
                Console.Write("{0}# - ", i);
                Console.WriteLine(conta);
            }
        } 

        private static void Saque()
        {
            Console.Write("Digite o numero da conta: ");
            int conta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantia a ser sacada: ");
            double valorSaque = double.Parse(Console.ReadLine());
            contas[conta].Saque(valorSaque);
        }

        private static void Deposito()
        {
            Console.Write("Digite o numero da conta: ");
            int conta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantia a ser sacada: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            contas[conta].Deposito(valorDeposito);
        }

        private static void Transferencia()
        {
            Console.Write("Digite o numero da conta origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o numero da conta destino: ");
            int contaDestino = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantia a ser transferida: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            contas[contaOrigem].Transferencia(contas[contaDestino], valorTransferencia);
        }

        private static void NovaConta()
        {
            Console.WriteLine("Digite o nome do titular: ");
            string titularEntrada = Console.ReadLine();
            Console.WriteLine("Digite 1 para pessoa física ou 2 para pessoa jurídica: ");
            int tipoEntrada = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o saldo: ");
            double saldoEntrada = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o crédito: ");
            double creditoEntrada = double.Parse(Console.ReadLine());
            Conta conta = new Conta(tipo:(TipodeConta) tipoEntrada,
                                            titular: titularEntrada,
                                            saldo: saldoEntrada,
                                            credito: creditoEntrada);
            contas.Add(conta);
        }

        private static string MenuPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao DIO Bank!!!");
            Console.WriteLine("Digite aqui sua opção:");
            Console.WriteLine("1 - Verificar contas");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Depósito");
            Console.WriteLine("4 - Transferências");
            Console.WriteLine("5 - Limpar tela");
            Console.WriteLine("6 - Nova conta");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcao = Console.ReadLine().ToUpper();
            return opcao;
        }
    }
}
