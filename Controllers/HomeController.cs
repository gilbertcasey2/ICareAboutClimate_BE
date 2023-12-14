using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ICareAboutClimate.Models;
using ICareAboutClimateBE.Models;
using System;
using ICareAboutClimateBE.ViewModels;
using Newtonsoft.Json;

namespace ICareAboutClimate.Controllers;

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
    [Route("api/submit-form")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult SubmitForm([FromBody] IndividualResponse sent_response)
    {
        string sent_questions = sent_response.questions;
        FormResponse? q_responses = JsonConvert.DeserializeObject<FormResponse>(sent_questions);
        return Ok(q_responses);

    }
}

