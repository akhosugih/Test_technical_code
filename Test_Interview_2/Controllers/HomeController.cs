using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using Test_Interview_2.Models;

namespace Test_Interview_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        [HttpPost]
        public IActionResult GenerateGanjil(string input)
        {
            try
            {
                long InputDigit = 0;
                if (!long.TryParse(input, out InputDigit))
                    return Json(new
                    {
                        Message = "Invalid Input",
                        Status = 0,
                        Result = new List<string>()
                    });

                var sb = new StringBuilder();

                for (int i = 0; i < InputDigit; i++)
                    if (i % 2 != 0)
                        sb.Append(i.ToString());



                return Json(new
                {
                    Message = "Success",
                    Status = 1,
                    Result = sb.ToString()
                });


            }
            catch (Exception err)
            {
                _logger.LogError(err.Message);

                return Json(new
                {
                    Message = err.Message,
                    Status = 0,
                    Result = string.Empty
                });
            }
        }

        [HttpPost]
        public IActionResult GenerateSegitiga(string input)
        {
            try
            {
                var result = new List<string>();

                long InputDigit = 0;
                if (!long.TryParse(input, out InputDigit))
                    return Json(new
                    {
                        Message = "Invalid Input",
                        Status = 0,
                        Result = new List<string>()
                    });

                var len = input.Length;
                var seed = 2;

                var sb = new StringBuilder();

                for (int i = 0; i < len; i++)
                {
                    sb = new StringBuilder();
                    for (int j = 0; j < seed; j++)
                    {
                        if (j == 0)
                            sb.Append(input[i]);
                        else
                            sb.Append("0");
                    }

                    seed++;

                    result.Add(sb.ToString());
                }



                return Json(new
                {
                    Message = "Success",
                    Status = 1,
                    Result = result
                });

            }
            catch (Exception err)
            {
                _logger.LogError(err.Message);

                return Json(new
                {
                    Message = err.Message,
                    Status = 0,
                    Result = new List<string>()
                });
            }
        }

        [HttpPost]
        public IActionResult GeneratePrima(string input)
        {
            try
            {
                long InputDigit = 0;

                if (!long.TryParse(input, out InputDigit))
                    return Json(new
                    {
                        Message = "Invalid Input",
                        Status = 0,
                        Result = string.Empty
                    });

                if (InputDigit < 0)
                    return Json(new
                    {
                        Message = "Input must be apositive number",
                        Status = 0,
                        Result = string.Empty
                    });

                var control = 0;
                var sb = new StringBuilder();

                for (var i = 0; i <= InputDigit; i++)
                {
                    control = 0;

                    for (var j = 2; j <= i/2; j++)
                    {
                        if (i % j == 0)
                        {
                            control++;
                            break;
                        }

                    }

                    if (control == 0 && i != 1)
                    {
                        sb.Append(i.ToString());
                    }
                }

                return Json(new
                {
                    Message = "Success",
                    Status = 1,
                    Result = sb.ToString()
                });

            }
            catch (Exception err)
            {
                _logger.LogError(err.Message);

                return Json(new
                {
                    Message = err.Message,
                    Status = 0,
                    Result = string.Empty
                });
            }
        }
    }
}