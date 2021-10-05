using System.Collections.Generic;

namespace Online_Shop
{
    public static class Storage
    {
        public static List<User> Users { get; set; }

        public static User CurrentUser { get; set; }
    }
}
