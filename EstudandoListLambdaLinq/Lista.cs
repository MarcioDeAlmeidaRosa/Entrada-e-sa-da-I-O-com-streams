using System.Linq;

namespace ByteBankImportacaoExportacao
{
    public class Lista<T>
    {
        private T[] _list = null;
        public int TotalItem { get { return _list.Length; } }
        private int _proximoItem = 0;

        public Lista(int tamanhoLista = 5)
        {
            _list = new T[tamanhoLista];
        }

        public void AdicionarItem(params T[] itens)
        {
            itens.ToList().ForEach(e => AdicionarItem(e));
        }

        public void AdicionarItem(T item)
        {
            if (_proximoItem >= _list.Length)
            {
                RedimencionarList(5);
            }
            _list[_proximoItem++] = item;
        }

        private void RedimencionarList(int totalNovosEspacos = 5)
        {
            var _listOld = _list;
            _list = new T[_proximoItem + totalNovosEspacos];
            _proximoItem = 0;
            _listOld.ToList().ForEach(e => AdicionarItem(e));
            _listOld = null;
        }

        public T this[int index]
        {
            get => _list[index];
            set => AdicionarItem(value);
        }
    }
}
