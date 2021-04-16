using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace SubItemSummary
{
    /// <summary>
    /// And Item in a hierarchical set
    /// </summary>
    [DebuggerDisplay("{Key} {Name}")]
    public class Item : IEnumerable<Item>
    {
        public string Key { get; }
        public string Name { get; }

        private readonly List<Item> _items = new();

        /// <summary>
        /// Initializes a new Item object
        /// </summary>
        /// <param name="key">The item's unique key</param>
        /// <param name="name">This items' name</param>
        public Item(string key, string name)
        {
            Key = key;
            Name = name;
        }
        
        /// <summary>
        /// Initializes a new Item object
        /// </summary>
        /// <param name="key">The item's unique key</param>
        /// <param name="name">This items' name</param>
        public Item(int key, string name)
        {
            Key = key.ToString();
            Name = name;
        }

        /// <summary>
        /// Adds sub-items to the item
        /// </summary>
        /// <param name="item">The sub-item to add</param>
        public void Add(Item item) => _items.Add(item);

        /// <summary>
        /// The count of sub-items
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// Returns an enumerator of sub-items for this item
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Item> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Searches the item hierarchy for an item with the specified key
        /// </summary>
        /// <param name="key">The key to search for</param>
        /// <param name="item">The item, if found</param>
        /// <returns>True if the item was found</returns>
        public bool TryGetItem(string key, [MaybeNullWhen(false)] out Item? item)
        {
            foreach (var item2 in _items)
            {
                if (item2.Key == key)
                {
                    item = item2;
                    return true;
                }

                if (item2.TryGetItem(key, out item))
                    return true;
            }

            item = null;
            return false;
        }
    }
}
