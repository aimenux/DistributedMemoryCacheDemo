using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Api.Validators;
using Domain.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DummyController : ControllerBase
{
    private readonly IDummyService _service;

    public DummyController(IDummyService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("website")]
    [SwaggerOperation("Get website infos")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public Task<WebSite> GetWebSiteAsync([Required][UrlValidator] string url = "https://abc.com/", CancellationToken cancellationToken = default)
    {
        return _service.GetWebSiteAsync(url, cancellationToken);
    }
}