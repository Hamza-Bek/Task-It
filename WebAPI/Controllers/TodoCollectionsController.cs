using Application.Dtos.TodoCollections;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoCollectionsController : ControllerBase
{
    private readonly ISender _sender;

    public TodoCollectionsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetCollections(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCollection(SubmitCollectionRequest request, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditCollection(string id, SubmitCollectionRequest request,
        CancellationToken cancellationToken)
    {
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCollection(string id, CancellationToken cancellationToken)
    {
        return Ok();
    }

}