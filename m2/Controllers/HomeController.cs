using m2.Models;
using Microsoft.AspNetCore.Mvc;

namespace m2.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }


    // Tar emot get
    [Route("/profile")]

    public IActionResult Profile()
    {

        return View();
    }

    //Tar emot post, skickar model data om 
    [HttpPost]
    [Route("/profile")]

    public IActionResult Profile(ProfileModel user)
    {

        if (ModelState.IsValid)
        {

            HttpContext.Session.SetString("username", user.Name);


            return View(user);

        }


        return View();



    }




    [Route("/contact")]
    public IActionResult Contact()
    {
        var sessionData = HttpContext.Session.GetString("username");
      
  if (sessionData != null)
        {
            ViewBag.UserNameFromSession = sessionData;
        }

        return View();
    }


    [Route("/about")]
    public IActionResult About()
    {

        return View();

    }


}

