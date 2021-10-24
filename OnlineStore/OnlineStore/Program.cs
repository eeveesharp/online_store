using OnlineStore.Implementations;
using OnlineStore.Menus;
using OnlineStore.Storages;
using System.Collections.Generic;

namespace OnlineStore.Entities
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Storage.Users = new List<User>();

            AuthMenu logMenu = new AuthMenu();

            Menu menu = new Menu();

            File file = new File();

            file.ReadProduct("products");

            logMenu.ShowMenu();

            menu.Show();
        }
    }
}
