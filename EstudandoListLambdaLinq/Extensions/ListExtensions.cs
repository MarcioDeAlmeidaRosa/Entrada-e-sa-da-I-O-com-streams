using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteBankImportacaoExportacao.Extensions
{
    public static class ListExtensions
    {
        public static void AddMany<T>(this IList<T> list , params T[] itens)
        {
            if (itens == null)
                throw new ArgumentException("Não enviado a ista de item", nameof(itens));

            itens.ToList().ForEach(e => list.Add(e));
        }
    }
}
