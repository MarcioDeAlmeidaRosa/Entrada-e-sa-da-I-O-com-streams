using System;
using System.Collections.Generic;
using ByteBankImportacaoExportacao.Exceptions;

namespace ByteBankImportacaoExportacao.Entidades
{
    public class ContaCorrente : IComparable
    {
        public int Numero { get; }

        public int Agencia { get; }

        public double Saldo { get; private set; }

        public Correntista Titular { get; }

        public ContaCorrente(int numero, int agencia, double saldo, Correntista correntista)
        {
            Numero = numero;
            Agencia = agencia;
            Titular = correntista;
            Saldo = saldo;
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor do depósito não é válido", nameof(valor));
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor do sac não é válido", nameof(valor));

            if (Saldo < valor)
                throw new SaldoInsuficienteException("Não existe saldo na conta para executar o saque");

            Saldo -= valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (contaDestino == null)
                throw new ArgumentException("Valor do sac não é válido", nameof(valor));
            try
            {
                Sacar(valor);
                contaDestino.Depositar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                throw new TransferenciaException("Não foi possível efetuar a transferência", ex);
            }
        }

        public override bool Equals(object obj)
        {
            var contaCorrente = obj as ContaCorrente;
            if (contaCorrente == null) return false;
            return Numero == contaCorrente.Numero && Agencia == contaCorrente.Agencia;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is ContaCorrente uotraConta))
                return -1;
            return (Numero < uotraConta.Numero) ? -1 : Numero == uotraConta.Numero ? 0 : 1;
        }
    }

    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            if (x == y) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            //Comparações de números inteiros é equivalente o que já existe
            //no tipo INT
            //return ( < y.Agencia) ? -1 : (x.Agencia == y.Agencia) ? 0 : 1;
            return x.Agencia.CompareTo(y.Agencia);
        }
    }
}
