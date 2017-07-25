using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TestLeechi.Models;

namespace TestLeechi.Data
{
    public static class Repository
    {
        private static List<Mobilier> _mobiliers = new List<Mobilier>();

        /// <summary>
        /// Récupère la liste des mobiliers à partir d'un fichier json
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Mobilier> Get()
        {
            if (File.Exists("list.json"))
            {
                _mobiliers = JsonConvert.DeserializeObject<List<Mobilier>>(File.ReadAllText("list.json"), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                });
            }

            return _mobiliers;
        }

        /// <summary>
        /// Sauvegarde le nouveau mobilier dans le fichier json
        /// </summary>
        /// <param name="item"></param>
        public static void AddItem(Mobilier item)
        {
            _mobiliers.Add(item);

            using (StreamWriter file = File.CreateText("list.json"))
            {
                JsonSerializer serializer = new JsonSerializer
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                serializer.Serialize(file, _mobiliers);
            }
        }
    }
}
