using Application.Features.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }            

        
        [HttpGet("get/todos/{ownerId}")]
        public async Task<List<Todo>> GetTodos(string ownerId)
        {
            return await _mediator.Send(new GetTodosQuery(ownerId));
        }

    }
}
