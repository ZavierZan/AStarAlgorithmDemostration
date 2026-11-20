using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectAStar
{
    public class PriorityQueue<T>
    {
        private List<(T Item, float Priority)> element = new List<(T, float)>();

        public int Count => element.Count;
        public IEnumerable<(T Item, float Priority)> UnorderedItems => element;

        public void Enqueue(T item, float priority)
        {
            element.Add((item, priority));
            element.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }

        public T Dequeue()
        {
            var bestItem = element[0].Item;
            element.RemoveAt(0);
            return bestItem;
        }
    }
}
