using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ActividadFormularios.Models;

namespace ActividadFormularios.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult GuardarInfo(string nombre, int edad, int DNI, bool empleo, string tipoEmpleo, double ingresoMensual, bool deuda, string tipoDeuda, double montoSolicitado, string plazoDevolucion, bool acepto){
        string text1;
        string text2;
        ViewBag.nombre = nombre;
        if(edad<18 || !empleo || ingresoMensual<250000 || montoSolicitado>ingresoMensual/5 || deuda || !acepto){
            ViewBag.text1 = "Lo sentimos,";
            ViewBag.text2 = "no cumple con los requisitos";
        }
        else{
            ViewBag.text1 = "Felicidades,";
            ViewBag.text2 = "! Su préstamo ha sido realizado y le será enviado a la brevedad";
        }
        return View("Request");
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
