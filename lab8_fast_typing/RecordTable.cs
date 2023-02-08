using System;
using Newtonsoft.Json;
using System.IO;
using Speedtext;

namespace Speedtext
{
    static public class RecordTable
    {
        static private string filePath = "../../../Records.json";
        static public void Show()
        {
            string text = File.ReadAllText(filePath);
            List<User> list = new List<User>();
            list = JsonConvert.DeserializeObject<List<User>>(text);
            foreach (var user in list)
            {
                var pr = $"{user.Name} {user.Minyt} {user.Sekynd}";
                Console.WriteLine(pr);
            }

        }

        static public void Add(User user)
        {
            string text = File.ReadAllText(filePath);
            List<User> list = new List<User>();
            list = JsonConvert.DeserializeObject<List<User>>(text);
            bool found = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == user.Name)
                {
                    found = true;
                    if (list[i].Sekynd < user.Sekynd)
                    {
                        list[i].Minyt = user.Minyt;
                        list[i].Sekynd = user.Sekynd;
                    }
                }
            }

            if (!found)
            {
                list.Add(user);
            }

            string json = JsonConvert.SerializeObject(list);

            File.WriteAllText($"{filePath}", json);
        }



    }
}

