using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ICareAboutClimate.Models;
using ICareAboutClimateBE.ViewModels;
using ICareAboutClimateBE.Services;
using ICareAboutClimateBE.Models;

namespace ICareAboutClimate.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IFormServices _formService;

    private IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IFormServices formServices, IConfiguration configuration)
    {
        _logger = logger;
        _formService = formServices;
        _configuration = configuration;
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

    private Boolean AuthenticateRequest(string? authHeader) {

        if (authHeader == null || authHeader.Substring(0,6) != "Bearer") {
            return false;
        }
        string token = authHeader.Substring(7);
        var RequestAuthenticationKey = _configuration["RequestAuthenticationKey"];

        if (token != RequestAuthenticationKey) {
            return false;
        }
        return true;
    }

    [HttpGet]
    [Route("api/getclimateresults")]
    public IEnumerable<FormResponse> GetResults()
    {
        var responseList = _formService.GetAllResponses();
        return responseList;    
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
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult SubmitForm([FromBody] IndividualResponseVM sent_response)
    {
        string? authHeader = this.HttpContext.Request.Headers["Authorization"];

        if (!AuthenticateRequest(authHeader)) {
            return StatusCode(403);
        }

        if (sent_response == null) {
            return ValidationProblem("No question sent.");
        }
        try
        {
            _formService.SubmitForm(sent_response);
        } catch(Exception e)
        {
            _logger.LogError("An exception adding a single question. Exception: " + e);
            return StatusCode(500);
        }
        
        return Ok("Successfully indicated submitted a question arrival.");

    }

    [HttpPost]
    [Route("api/form-arrival")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult ArrivedAtPage([FromBody] ArrivedResponseVM arrival_info)
    {
        string? authHeader = this.HttpContext.Request.Headers["Authorization"];
        if (!AuthenticateRequest(authHeader)) {
            return StatusCode(403);
        }
        _logger.LogInformation("User arrived at contribute form. Session ID: {} ", arrival_info.storeageID);

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
        string? authHeader = this.HttpContext.Request.Headers["Authorization"];
        if (!AuthenticateRequest(authHeader)) {
            return StatusCode(403);
        }

        _logger.LogInformation("User submitted a question to the contribute form.");
        if (sent_question == null) {
            return ValidationProblem("No question sent.");
        }

         try
        {
            _formService.SubmitQuestion(sent_question);
        } catch(Exception e)
        {
            _logger.LogError("An exception adding a single question. Exception: " + e);
            return StatusCode(500);
        }
        
        return Ok("Successfully indicated submitted a question arrival.");
    }
}