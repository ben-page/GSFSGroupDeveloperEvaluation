using System.Linq;

namespace SubItemSummary
{
    /// <summary>
    /// A summary of the Sub-Items of an Item
    /// </summary>
    public class SubItemSummary
    {
        /// <summary>
        /// The Summarized Item
        /// </summary>
        public Item Item { get; }

        /// <summary>
        /// A comma-separated list of the sub-item's keys
        /// </summary>
        public string SubItemKeys { get; }

        /// <summary>
        /// A comma-separated list of the sub-item's names
        /// </summary>
        public string SubItemNames { get; }

        /// <summary>
        /// Constructs a new summary for the item passed
        /// </summary>
        /// <param name="parentItem">The item to be summarized</param>
        public SubItemSummary(Item parentItem)
        {
            Item = parentItem;
            SubItemKeys = string.Join(",", parentItem.Select(s => s.Key).ToArray());
            SubItemNames = string.Join(",", parentItem.Select(s => s.Name).ToArray());
        }
    }
}