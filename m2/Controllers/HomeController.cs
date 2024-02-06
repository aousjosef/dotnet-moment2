using m2.Models;
using Microsoft.AspNetCore.Mvc;

namespace m2.Controllers;

public class HomeController : Controller
{



    public IActionResult Index()
    {
        return View();
    }


    // GET
    [Route("/profile")]

    public IActionResult Profile()
    {

        return View();
    }



    //POST, tar emot data från view 
    [HttpPost]
    [Route("/profile")]

    public IActionResult Profile(ProfileModel user)
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


            return View(user);

        }

        return View();

    }


    [Route("/users")]
    public IActionResult Users()
    {
        var sessionData = HttpContext.Session.GetString("userprofile");

        if (sessionData != null)
        {
            var listoFUsers = System.Text.Json.JsonSerializer.Deserialize<List<ProfileModel>>(sessionData);

            ViewBag.ProfileListSession = listoFUsers;
        }



        return View();
    }


    [Route("/about")]

    public IActionResult About()
    {

        DateTime today = DateTime.Today;
        string date = today.ToString("d");
        ViewData["date"] = date;

        return View();

    }

}



