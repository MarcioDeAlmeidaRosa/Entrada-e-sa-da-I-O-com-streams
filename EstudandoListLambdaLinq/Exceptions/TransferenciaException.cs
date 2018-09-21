using System;

namespace ByteBankImportacaoExportacao.Exceptions
{
    public class TransferenciaException : FinanceiroException
    {
        public TransferenciaException() : this("Erro ao efetuar a transfeência.")
        {
        }

        public TransferenciaException(string msg) : base(msg)
        {
        }

        public TransferenciaException(string msg, Exception innerException) : base(msg, innerException)
        {
        }
    }
}
