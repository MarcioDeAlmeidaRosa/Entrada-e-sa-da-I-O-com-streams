using ByteBankImportacaoExportacao.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EstudandoListLambdaLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //o byte possui valor de 0 a 255, quando mapeado para caracter temos (256 possibilidades)

            // Convertendo o byte em ASCII, temos 127 todo o alfabeto. Não contempla caracter com acentuação
            // TABELA ASCII - cada byte representa 1 caracter
            // https://upload.wikimedia.org/wikipedia/commons/1/1b/ASCII-Table-wide.svg

            //Quando precisamos de mais de 255 valores códigos para representar outros caracteres, então será necessário no mínimo 2 bytes
            //para conseguir chegar no caracter com acentuação pprecisamos converter a tabela que define o caracter ara a tabela do encode desejado

            //para isso então nasceu a Unicode
            //Organização que define quais são os códigos de cada caracter
            //Os 127 primeiros códigos (Unicode) respeito os mesmo valores na (ASCII) pra manter a compatibilidade

            //Exemplo --> õ representado por 0245 -> não será gravado 0245 no meu byte, este valor é o código do (Unicode)
            //Cada caracter Unicode é um (Code point), esta informação será usada para transformar o (Unicode) - 
            //   Formato de transformação unicode -->  Unicode Transformation Format --> acrônimo de = UTF
            // Exemplos de UTF:
            //  * UTF-7
            //  * UTF-8
            //  * UTF-16
            //  * UTF-32
            // Opções de UTF possíveis --> https://en.wikipedia.org/wiki/UTF

            //Unicode e UTF-8
            //https://www.ime.usp.br/~pf/algoritmos/aulas/unicode.html

            //List of Unicode characters
            //https://en.wikipedia.org/wiki/List_of_Unicode_characters

            //  \n  ---->  quebra de linha


            SalvarContasCorrentesAlteradas(CarregarContas());

            Console.ReadLine();
        }

        static ContaCorrente[] CarregarContas()
        {
            var listaContaCorrente = new List<ContaCorrente>();
            var caminhoArquivo = @"../../../contas.txt";
            using (var arquivo = new FileStream(caminhoArquivo, FileMode.Open))
            using (var balde = new StreamReader(arquivo, Encoding.UTF8))
            {
                while (!balde.EndOfStream)
                {
                    //Console.WriteLine(balde.ReadLine());
                    listaContaCorrente.Add(ConverterStringParaContaCorrente(balde.ReadLine()));
                }
            }
            Console.WriteLine("Carregando arquivo");
            listaContaCorrente.ForEach(c => Console.WriteLine($"Correntista {c.Titular.Nome} portador do CPF {c.Titular.CPF}, da Ag: {c.Agencia} e conta corrente: {c.Numero} com saldo de R$ {c.Saldo}"));
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            return listaContaCorrente.ToArray();
        }

        static void SalvarContasCorrentesAlteradas(ContaCorrente[] contas)
        {
            var caminhoArquivo = @"../../../contas_exportadas.csv";
            using (var fluxoArquivo = new FileStream(caminhoArquivo, FileMode.Create))
            using (var balde = new StreamWriter(fluxoArquivo, Encoding.UTF8))
            {
                foreach (var conta in contas)
                {
                    balde.WriteLine(conta.ToString());
                }
            }
            Console.WriteLine("Gravação terminou!");
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            //Acrônimo -> Comma-separated values -> CSV
            //https://pt.wikipedia.org/wiki/Comma-separated_values
            var dados = linha.Split(',');
            return new ContaCorrente(Convert.ToInt32(dados[1]), Convert.ToInt32(dados[0]), Convert.ToDouble(dados[2].Replace('.', ',')), new Correntista(dados[4], dados[3]));
        }

        static void LidandoComFileStringDiretamento()
        {
            var caminhoArquivo = @"../../../contas.txt";
            //Responsável por ler o arquivo e transformar em array de byte
            using (var fluxoDoArquivo = new FileStream(caminhoArquivo, FileMode.Open))
            {
                //1024 //1 kb
                //Criaando array de byte que servirá como "balde" para armazenar o conteúdo do arquivo que foi lido
                var buffer = new byte[1024]; //1 kb
                var numerosBytesLidos = -1;
                while (numerosBytesLidos != 0)
                {
                    //recebe uma referência para armazenar o array de byte da leitura do arquivo "balde" -> parâmetro "array"
                    //recebe um número do indice que será iniciado a gravação do array de byte do arquivo, você consegue deixar espaços vazio para alguma outra informação -> parâmetro offset
                    //recebe a quantidade de bytes que deverá ser lido do array de byte do arquivo para ser atribuido no "balde" de array
                    numerosBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numerosBytesLidos);
                }
            }
        }

        static void EscreverBuffer(byte[] buffer, int bytesidos)
        {
            var utf8 = new UTF8Encoding();

            var texto = utf8.GetString(buffer, 0, bytesidos);
            Console.Write(texto);

            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }
    }
}
