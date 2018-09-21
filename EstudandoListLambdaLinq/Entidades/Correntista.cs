namespace ByteBankImportacaoExportacao.Entidades
{
    public class Correntista
    {
        public string Nome { get; }

        public string CPF { get; }

        public Correntista(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
    }
}
