using System;
using System.Collections.Generic;

namespace SubItemSummary
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing data set
            var id = 0;
            var items = new List<Item>
            {
                new(++id, "Fruit")
                {
                    new Item(++id, "Citrus")
                    {
                        new(++id, "Orange"),
                        new(++id, "Lemon"),
                        new(++id, "Grapefruit"),
                        new(++id, "Lime"),
                    },
                    new Item(++id, "Berry")
                    {
                        new(++id, "Raspberry"),
                        new(++id, "Strawberry"),
                        new(++id, "Blueberry"),
                    }
                },
                new(++id, "Vegetables")
                {
                    new Item(++id, "Leafy")
                    {
                        new(++id, "Lettuce"),
                        new(++id, "Kale"),
                        new(++id, "Cabbage")
                    },
                    new Item(++id, "Root")
                    {
                        new(++id, "Carrot"),
                        new(++id, "Parsnip"),
                        new(++id, "Radish"),
                    },
                    new Item(++id, "Squash")
                    {
                        new(++id, "Zucchini"),
                        new(++id, "Yellow Squash"),
                        new(++id, "Acorn"),
                    }
                },
            };

            var service = new ItemService(items);

            var summaries = service.GetSubItemSummary("1");
            foreach (var summary in summaries)
                Console.WriteLine($"{summary.Item.Name}: {summary.SubItemNames}");

            Console.WriteLine();

            summaries = service.GetSubItemSummary("11");
            foreach (var summary in summaries)
                Console.WriteLine($"{summary.Item.Name}: {summary.SubItemNames}");

            Console.ReadKey();
        }
    }
}
