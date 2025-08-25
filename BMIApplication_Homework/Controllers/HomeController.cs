using System.Diagnostics;
using BMIApplication_Homework.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMIApplication_Homework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(BMIModel model)
        {
            if (model.HeightCm > 0 && model.WeightKg > 0)
            {
                double heightM = model.HeightCm / 100;
                model.BmiResult = model.WeightKg / (heightM * heightM);
                model.Category = GetBmiCategory(model.BmiResult);
            }

            return View(model);
        }

        public string GetBmiCategory(double bmi)
        {
            if (bmi < 18.5) return "underweight";
            else if (bmi < 24.9) return "Normal Weight";
            else if (bmi < 29.9) return "Overweight";
            else return "Obese";
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
}
