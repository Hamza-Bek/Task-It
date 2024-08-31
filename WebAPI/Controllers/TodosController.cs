using Application.Features.Commands;
using Application.Features.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("create/todo")]
        public async Task<Todo> CreateTodo(Todo todo)
        {
            var model = new CreateTodoCommand(todo);

            return await _mediator.Send(model);
        }


        [HttpGet("get/todos/{ownerId}")]
        public async Task<List<Todo>> GetTodos(string ownerId)
        {
            return await _mediator.Send(new GetTodosQuery(ownerId));
        }

    }
}
