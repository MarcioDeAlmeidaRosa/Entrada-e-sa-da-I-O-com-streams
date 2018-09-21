using System;
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

            var caminhoArquivo = @"../../../contas.txt";
            using (var arquivo = new FileStream(caminhoArquivo, FileMode.Open))
            using (var balde = new StreamReader(arquivo))
            {
                while (!balde.EndOfStream)
                {
                    Console.WriteLine(balde.ReadLine());
                }
            }

            Console.ReadLine();
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
