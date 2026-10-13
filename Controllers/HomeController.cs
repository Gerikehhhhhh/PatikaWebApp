using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PatikaWebApp.Models;
using PatikaWebApp.Services;

namespace PatikaWebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Gyogyszerek()
    {
        List<Gyogyszer> gyogyszerek = new GyogyszerService().GetAllGyogyszer();
        return View(gyogyszerek);
    }

    public IActionResult Gyogyszer(int id)
    {
        Gyogyszer kivalasztott = new GyogyszerService().GetById(id);
        return View(kivalasztott);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}