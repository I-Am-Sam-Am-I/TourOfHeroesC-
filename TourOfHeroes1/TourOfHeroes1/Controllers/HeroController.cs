using Microsoft.AspNetCore.Mvc;
using TourOfHeroes1.Models;

namespace TourOfHeroes1.Controllers
{
    public class HeroController : Controller
    {

        public IActionResult AllHeroes() 
        {
            Repository.CreateMessage("Now viewing all Heroes.");
            return View("AllHeroes", Repository.AllHeroes);
        
        }

        public IActionResult AllMessages()
        {
            return View("AllHeroes", Repository.AllMessages);

        }

        public IActionResult Create(Hero hero)
        {
            return View();
        }


        public IActionResult Details(Hero hero)
        {
            Repository.CreateMessage("Now viewing Hero Details.");
            return View();
        }

        public ActionResult HeroDetails(string number)
        {
            if (number != null) 
            {
                int id = int.Parse(number);
                Hero hero = Repository.FindHero(id);
                string message = "You're now viewing " + hero.Name + "'s" + " Detail Page";
                Repository.CreateMessage(message);
                return View("Details", hero);
            }

            return View();

        }

        public IActionResult HeroCreated(Hero hero)
        {
            Repository.Create(hero);
            return View("HeroCreated", hero);
        }

        public ActionResult HeroDeleted(string hero)
        {
            if (hero != null)
            {
                int id = int.Parse(hero);
                Repository.Remove(id);
            }
            return View("AllHeroes");
        }

        public ActionResult MessageDeleted(string message)
        {
            Repository.Remove(message);
            return View("Index");
        }

        public ActionResult HeroSearch(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                // Retrieve all customers from the database
                var heros = Repository.AllHeroes.ToList();

                Hero hero = null;


                // Filter customers by name if search query is provided
                if (!string.IsNullOrEmpty(searchString))
                {
                    heros = heros
                        .Where(c => c.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    hero = heros.FirstOrDefault();
                }

                if (hero != null)
                {
                    // Pass the filtered customers to the view
                    string message = "You're now viewing " + hero.Name + "'s" + " Detail Page";
                    Repository.CreateMessage(message);
                    return View("Details", hero);
                }
            }

            return View("Index");

        }

        public ActionResult UpdateHero(string heroName)
        {
            Hero hero = Repository.FindHero(heroName);
            if (!string.IsNullOrEmpty(heroName))
            {

                Repository.UpdateHero(hero);
                return View("Details", hero);
            }
            return View("Details",hero);
        }


        public IActionResult Index()
        {
            Repository.CreateMessage("Now viewing the Top Heroes.");
            return View();
        }



    }
}
