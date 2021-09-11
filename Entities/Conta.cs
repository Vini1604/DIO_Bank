using System;

namespace DIO_Bank
{
    public class Conta
    {
        private TipodeConta Tipo { get; set; }
        private string Titular { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta(TipodeConta tipo, string titular, double saldo, double credito) 
        {
            this.Tipo = tipo;
            this.Titular = titular;
            this.Saldo = saldo;
            this.Credito = credito;
               
        }

        public bool Saque (double valorSaque)
        {
            if (this.Saldo - valorSaque < this.Credito * (-1))
            {
                Console.WriteLine("Você não possui saldo suficiente para realizar essa ação!!!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("O Saldo atual da conta de {0} é {1}",this.Titular, this.Saldo);
            return true;
        }

        public void Deposito(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("O saldo atual da conta de {0} é {1}",this.Titular, this.Saldo);
        }

        public void Transferencia(Conta contaDestino, double valorTransferencia)
        {
            if (this.Saque(valorTransferencia))
            {
                contaDestino.Deposito(valorTransferencia);
            }
        }

        public override string ToString(){
            string conta = "";
            conta += "Tipo Conta: " + this.Tipo + " | ";
            conta += "Titular: " + this.Titular + " | ";
            conta += "Saldo: " + this.Saldo + " | ";
            conta += "Credito: " + this.Credito;
            return conta;
        }
    }
}