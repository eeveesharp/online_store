using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace ConsoleApp2
{
    public class File
    {
        User user;
        public void WriteFile()
        {
            List<User> userList = new List<User>();
            userList.Add(user);

            for (int i = 0; i < userList.Count; i++)
            {
                System.IO.File.AppendAllText("input.json", JsonConvert.SerializeObject(userList[i]));
            }
        }

        public void ReadFile()
        {
            JsonTextReader reader = new JsonTextReader(new StreamReader("input.json"));
            reader.SupportMultipleContent = true;

            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }
            }
        }
    }
}

