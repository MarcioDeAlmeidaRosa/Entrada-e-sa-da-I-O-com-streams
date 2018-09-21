using System;
using System.Linq;
using System.Collections.Generic;
using ByteBankImportacaoExportacao.Entidades;
using ByteBankImportacaoExportacao.Extensions;

namespace EstudandoListLambdaLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //var lista = new Lista<ContaCorrente>();
            //lista.AdicionarItem(new ContaCorrente(12345, 589632, new Correntista("Marcio de Almeida Rosa", "525.965.852-85")));
            //lista.AdicionarItem(new ContaCorrente(58965, 745892, new Correntista("Renato Alvez dos Santos", "584.528.657-54")));
            //lista.AdicionarItem(new ContaCorrente(85236, 576325, new Correntista("Romologlosvaldo Pafunço Filho", "753.396.149-52")));
            //lista.AdicionarItem(new ContaCorrente(85236, 576325, new Correntista("Clara Maria Aparecida", "745.568.756-85")));
            //lista.AdicionarItem(new ContaCorrente(12345, 589632, new Correntista("Caroline de Almeida Rosa", "854.225.856.88")));
            //lista.AdicionarItem(
            //    new ContaCorrente(47586, 852369, new Correntista("Rosicleide da Silva Santos", "745.654.852-95")),
            //    new ContaCorrente(47586, 852369, new Correntista("Fernando da Silva Saulo", "758.365.854-65")),
            //    new ContaCorrente(47586, 852369, new Correntista("Renato Aragão", "745.325.865-99"))
            //);
            //for (int i = 0; i < lista.TotalItem; i++)
            //{
            //    var contaCorrente = lista[i] as ContaCorrente;
            //    if (contaCorrente != null)
            //        Console.WriteLine($"Conta corrente do {lista[i].Correntista.Nome}, Agência: {lista[i].Agencia}, Conta corrente: {lista[i].Numero}");
            //}

            //var listaNumerica = new List<int>();
            //listaNumerica.AddMany(1, 2, 3, 45, 9, 4, 5, 100, 8, 7,-1,0);
            //listaNumerica.Sort();
            //listaNumerica.ForEach(e => Console.WriteLine(e));

            //Console.ReadLine();

            //var listaNomes = new List<string>();
            //listaNomes.AddMany("Mrcio", "Andre", "Renato");
            //listaNomes.Sort();
            //listaNomes.ForEach(e => Console.WriteLine(e));

            //Console.ReadLine();

            var lista = new List<ContaCorrente>();
            lista.Add(new ContaCorrente(11111, 999999, new Correntista("Marcio de Almeida Rosa", "525.965.852-85")));
            lista.Add(new ContaCorrente(22222, 888888, new Correntista("Renato Alvez dos Santos", "584.528.657-54")));
            lista.Add(new ContaCorrente(33333, 777777, new Correntista("Romologlosvaldo Pafunço Filho", "753.396.149-52")));
            lista.Add(new ContaCorrente(44444, 777777, new Correntista("Clara Maria Aparecida", "745.568.756-85")));
            lista.Add(new ContaCorrente(55555, 666666, new Correntista("Caroline de Almeida Rosa", "854.225.856.88")));
            lista.AddMany(
                new ContaCorrente(66666, 555555, new Correntista("Rosicleide da Silva Santos", "745.654.852-95")),
                new ContaCorrente(77777, 444444, new Correntista("Fernando da Silva Saulo", "758.365.854-65")),
                new ContaCorrente(88888, 333333, new Correntista("Renato Aragão", "745.325.865-99")),
                new ContaCorrente(1, 852369, new Correntista("Douglas Magrão", "753.951.852-51"))
            );

            lista.Sort(new ComparadorContaCorrentePorAgencia());

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] is ContaCorrente contaCorrente)
                    Console.WriteLine($"Conta corrente do {lista[i].Correntista.Nome}, Conta corrente: {lista[i].Numero} , Agência: {lista[i].Agencia}");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");


            var listaOrdenada = lista.OrderBy(l => l.Numero);
            foreach (var item in listaOrdenada)
            {
                Console.WriteLine($"Conta corrente do {item.Correntista.Nome}, Conta corrente: {item.Numero} , Agência: {item.Agencia}");
            }

            Console.ReadLine();
        }
    }
}
