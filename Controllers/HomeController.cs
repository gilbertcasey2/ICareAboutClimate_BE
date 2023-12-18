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
    public ActionResult SubmitForm([FromBody] IndividualResponseVM sent_response)
    {
        string sent_questions = sent_response.questions;
        FormResponse? q_responses = JsonConvert.DeserializeObject<FormResponse>(sent_questions);
        return Ok(q_responses);

    }

    [HttpPost]
    [Route("api/form-arrival")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult ArrivedAtPage([FromBody] ArrivedResponseVM arrival_info)
    {
        if (arrival_info == null) {
            return ValidationProblem("No arrival information sent.");
        }
        Guid new_storeageID = arrival_info.storeageID;
        FormResponse new_responses = new() {
            storeageID = new_storeageID,
            formIndex = arrival_info.formIndex
        };
        return Ok(new_responses);

    }

    [HttpPost]
    [Route("api/submit-question")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult SubmitQuestion([FromBody] SubmitQuestionVM sent_question)
    {

        if (sent_question == null) {
            return ValidationProblem("No question sent.");
        }
        
        DateTime currentTime = DateTime.Now;
        FormQuestionResponse new_response = new(sent_question.questionIndex, sent_question.answerIndex, currentTime);

        // add response to DB using Guid 

        return Ok(new_response);

    }
}

