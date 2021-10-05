using System;
using System.Collections.Generic;

namespace Online_Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Storage.Users = new List<User>();
            LogMenu logMenu = new LogMenu();
            Menu menu = new Menu();
            logMenu.ShowMenu();
            menu.ShowMainMenu();
        }
    }
}
