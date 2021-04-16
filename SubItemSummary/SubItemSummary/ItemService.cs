using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SubItemSummary
{
    /// <summary>
    /// A service used to create SubItemSummary objects from a hierarchy of items.
    /// </summary>
    public class ItemService
    {
        private readonly List<Item> _items;

        /// <summary>
        /// Constructs the service
        /// </summary>
        /// <param name="items">The top level items in the hierarchy</param>
        public ItemService(List<Item> items)
        {
            _items = items;
        }

        /// <summary>
        /// Gets a sub-item summary for a given item number.
        /// </summary>
        /// <param name="key">The item keu of the item to get the sub-item summary of.</param>
        public SubItemSummary[] GetSubItemSummary(string key)
        {
            if (!TryGetItem(key, out var item))
                throw new ArgumentException($"Item '{key}' does not exist in the collection");
            
            List<SubItemSummary> summaries = new();

            CreateSummaries(item, summaries);

            return summaries.ToArray();
        }

        /// <summary>
        /// Searches the item hierarchy for an item with the specified key
        /// </summary>
        /// <param name="key">The key to search for</param>
        /// <param name="item">The item, if found</param>
        /// <returns>True if the item was found</returns>
        private bool TryGetItem(string key, [MaybeNullWhen(false)] out Item? item)
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

        /// <summary>
        /// Recursively creates the SubItemSummary objects for an Item and it's sub-items
        /// </summary>
        /// <param name="item">The item to summaries</param>
        /// <param name="summaries">The list that collects the summaries. The list is created externally to avoid a bunch of List.AddRange() calls.</param>
        private static void CreateSummaries(Item item, List<SubItemSummary> summaries)
        {
            summaries.Add(new SubItemSummary(item));
            foreach (var subItem in item)
            {
                if (subItem.Count > 0)
                    CreateSummaries(subItem, summaries);
            }
        }
    }
}