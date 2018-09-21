using System;

namespace ByteBankImportacaoExportacao.Exceptions
{
    public class SaldoInsuficienteException : FinanceiroException
    {
        public SaldoInsuficienteException() : this("Saldo insuficiente na conta corrente")
        {
        }

        public SaldoInsuficienteException(string msg) : base(msg)
        {
        }

        public SaldoInsuficienteException(string msg, Exception innerException) : base(msg, innerException)
        {
        }
    }
}
