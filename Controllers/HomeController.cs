using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ICareAboutClimate.Models;
using ICareAboutClimateBE.Models;
using System;
using ICareAboutClimateBE.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICareAboutClimateBE.Services;

namespace ICareAboutClimate.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IFormServices _formService;

    public HomeController(ILogger<HomeController> logger, IFormServices formServices)
    {
        _logger = logger;
        _formService = formServices;
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

    [HttpGet]
    [Route("ok")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult HealthCheck()
    {
        return Ok("All is well!");

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

        for (int i = 0; i < q_responses?.responses?.Count; i++)
        {
            q_responses.responses[i].isFinalResponse = true;
        }
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
        try
        {
            _formService.ResponseArrival(arrival_info);
        } catch(Exception e)
        {
            _logger.LogError("An exception adding a user. Exception: " + e);
            return StatusCode(500);
        }
        
        return Ok("Successfully indicated user's arrival.");

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
        new_response.isFinalResponse = false;

        // add response to DB using Guid 

        return Ok(new_response);

    }
}

