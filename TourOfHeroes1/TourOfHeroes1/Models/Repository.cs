using System.Xml.Linq;

namespace TourOfHeroes1.Models
{
    public class Repository
    {
        private static List<Hero>? allHeroes;

        private static List<string> allMessages = new();

        public static IEnumerable<Hero> AllHeroes
        {
            get
            {
                if (allHeroes == null)
                {
                    allHeroes = new List<Hero>
                    {
                        new Hero { Id = 1, Name = "Hans Gruber" },
                        new Hero { Id = 2, Name = "Kingpin" },
                        new Hero { Id = 3, Name = "Norman Osborn" },
                        new Hero { Id = 4, Name = "Anton Chigurh" },
                        new Hero { Id = 5, Name = "Jack Torrance" },
                        new Hero { Id = 6, Name = "Agent Smith" }
                    };
                }

                return allHeroes; } }


        public static void Create(Hero hero)
        {
            string message = hero.Name + " has been added to the Hero List.";
            int highestId = (int)allHeroes.Last().Id;
            int id = highestId + 1;
            hero.Id = id;
            if (hero.Name != null)
            {
                allHeroes.Add(hero);
                allMessages.Add(message);
            }
            

        }

        public static void CreateMessage( string message)
        {
            if (message != null)
            {
                allMessages.Add(message);
            }
        }

        public static Hero FindHero(int id)
        {
            Hero hero = allHeroes.Find(h => h.Id == id);
            return hero;
        }


        public static Hero FindHero(string heroName)
        {
            Hero hero = allHeroes.Find(h => h.Name == heroName);
            return hero;
        }

        public static void UpdateHero(Hero hero)
        {
            string name = hero.Name;
            allHeroes.Find(u => hero.Name == name);
        }



        public static void Remove(int id)
        {
            Hero hero = allHeroes.Find(h => h.Id == id);

            allHeroes.RemoveAll(p => p.Id == id);

            string name = hero.Name;
            string message = name + " has been removed from the Hero List.";
            allMessages.Add(message);
        }


        public static IEnumerable<string> AllMessages
        {
            get
            {
                return allMessages;
            }
        }


        public static void Create(string message)
        {
            allMessages.Add(message);
        }


        public static void Remove(string message)
        {
            allMessages.Clear();
        }


    }
}
