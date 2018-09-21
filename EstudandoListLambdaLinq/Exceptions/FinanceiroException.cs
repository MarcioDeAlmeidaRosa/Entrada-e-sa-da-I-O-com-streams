using System;

namespace ByteBankImportacaoExportacao.Exceptions
{
    public class FinanceiroException : Exception
    {
        public FinanceiroException() : this("Erro na conta corrente")
        {
        }

        public FinanceiroException(string msg) : base(msg)
        {
        }

        public FinanceiroException(string msg, Exception innerException) : base(msg, innerException)
        {
        }
    }
}
