using m2.Models;
using Microsoft.AspNetCore.Mvc;

namespace m2.Controllers;

public class HomeController : Controller
{


//Skickar data för att visa den i min partial view
    public IActionResult Index()
    {

        ViewData["date"] = getDate();
        return View();
    }


    // GET
    [HttpGet]
    [Route("/profile")]

    public IActionResult Profile()
    {

        return View();
    }



    //POST, tar emot data från view 
    [HttpPost]
    [Route("/profile")]

    public IActionResult Profile(ProfileModel user, string gender, string education, string[] goalsArray)
    {

        if (ModelState.IsValid)
        {

            var sessionData = HttpContext.Session.GetString("userprofile");

            var listoFUsers = new List<ProfileModel>();

            if (sessionData != null)
            {
                listoFUsers = System.Text.Json.JsonSerializer.Deserialize<List<ProfileModel>>(sessionData);
            }


            listoFUsers.Add(user);
            string jsonList = System.Text.Json.JsonSerializer.Serialize(listoFUsers);
            HttpContext.Session.SetString("userprofile", jsonList);

            ViewBag.gender = gender;
            ViewBag.education = education;
            ViewBag.goalsArray = goalsArray;

            return View(user);


        }

        return View();

    }

    //hämtar data från session för att sedan skicka den med viewbag. Skickar även data till min partial för att hämta datum

    [Route("/users")]
    public IActionResult Users()
    {
        var sessionData = HttpContext.Session.GetString("userprofile");

        if (sessionData != null)
        {
            var listoFUsers = System.Text.Json.JsonSerializer.Deserialize<List<ProfileModel>>(sessionData);

            ViewBag.ProfileListSession = listoFUsers;
        }


        ViewData["date"] = getDate();

        return View();
    }



//Function för att generera dagens datum
    string getDate()
    {

        DateTime today = DateTime.Today;
        string date = today.ToString("d");
        return date;

    }

}



