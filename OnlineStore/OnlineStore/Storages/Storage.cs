using OnlineStore.Entities;
using System.Collections.Generic;

namespace OnlineStore.Storages
{
    public static class Storage
    {
        public static List<User> Users { get; set; }

        public static User CurrentUser { get; set; }

        public static List<Product> Products { get; set; } = new List<Product>();

        public static List<Product> Basket { get; set; }

        public static List<Product> HistoryBuy { get; set; }
    }
}
