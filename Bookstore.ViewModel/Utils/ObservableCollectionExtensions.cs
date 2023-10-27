using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.ViewModel.Utils
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> newItems, bool clearBefore = true)
        {
            if (clearBefore)
                collection.Clear();
            foreach (var item in newItems)
            {
                collection.Add(item);
            }
        }

        public static void RemoveRange<T>(this ObservableCollection<T> collection, Func<T, bool> chooser)
        {
            List<T> itemsToRemove = new List<T>();
            foreach (var item in collection)
            {
                if (chooser(item))
                {
                    itemsToRemove.Add(item);
                }
            }
            foreach (var item in itemsToRemove)
            {
                collection.Remove(item);
            }
        }

        public static bool Contains<T>(this ObservableCollection<T> collection, Func<T, bool> chooser)
        {
            foreach (var item in collection)
            {
                if (chooser(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static int IndexOf<T>(this ObservableCollection<T> collection, Predicate<T> chooser)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (chooser(collection[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public static string CommaList<T>(this ObservableCollection<T> collection, Func<T, string> descriptor)
        {
            string result = string.Empty;
            for (int i = 0; i < collection.Count; i++)
            {
                string currentItem = descriptor(collection[i]);
                if (string.IsNullOrEmpty(currentItem) == false)
                {
                    result += currentItem;
                    if (i < (collection.Count - 1))
                        result += ",";
                }
            }
            return result;
        }
    }

}
