using Application.Common.Mappers;
using Application.Dtos.TodoCollections;
using Application.Features.TodoCollections.Commands;
using Application.Features.TodoCollections.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;

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
        var query = new GetCollectionsQuery();
        var collections = await _sender.Send(query, cancellationToken);
        var dtos = collections.Select(c => c.ToDto());
        return Ok(new ApiResponse<IEnumerable<TodoCollectionDto>>(dtos)
        {
            Message = "Successfully retrieved the collections",
            IsSuccess = true
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateCollection(SubmitCollectionRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateCollectionCommand(request);
        var result = await _sender.Send(command, cancellationToken);
        return Ok(new ApiResponse<TodoCollectionDto>(result.ToDto())
        {
            Message = $"{request.Name} was successfully created",
            IsSuccess = true
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditCollection(string id, SubmitCollectionRequest request,
        CancellationToken cancellationToken)
    {
        var command = new EditCollectionCommand(id, request);
        var result = await _sender.Send(command, cancellationToken);
        return Ok(new ApiResponse<TodoCollectionDto>(result.ToDto())
        {
            Message = $"{request.Name} was successfully updated",
            IsSuccess = true
        });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCollection(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteCollectionCommand(id);
        var result = await _sender.Send(command, cancellationToken);
        return Ok(new ApiResponse<bool>(result)
        {
            Message = "Collection was deleted successfully",
            IsSuccess = true
        });
    }

}