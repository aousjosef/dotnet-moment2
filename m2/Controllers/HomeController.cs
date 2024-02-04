using Microsoft.AspNetCore.Mvc;

namespace m2.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }



    [Route("/profile")]
    public IActionResult Profile()
    {

        return View();
    }

    [Route("/contact")]
    public IActionResult Contact()
    {
        return View();
    }


    [Route("/about")]
    public IActionResult About()
    {

        return View();

    }


}

