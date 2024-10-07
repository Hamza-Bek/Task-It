using Application.Common;
using Application.Dtos.Todo;
using Application.Features.Todos.Commands;
using Application.Features.Todos.Queries;
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

        [HttpPost("create/todo/{collectionId}")]
        public async Task<Todo> CreateTodo(string collectionId, SubmitTodoRequest todo)
        {
            var model = new CreateTodoCommand(collectionId, todo);

            return await _mediator.Send(model);
        }

        [HttpPut("edit/todo/{todoId}")]
        public async Task<Todo> EditTodo(string todoId , SubmitTodoRequest todo)
        {
            var model = new EditTodoCommand(todoId, todo);

            return await _mediator.Send(model);
        }

        [HttpDelete("delete/todo/{todoId}")]
        public async Task<bool> DeleteTodo(string todoId)
        {
            var result = new DeleteTodoCommand(todoId);
            return await _mediator.Send(result);
        }

        [HttpGet("get/todos/{collectionId}")]
        public async Task<List<Todo>> GetTodos([FromQuery] PageRequest pageRequest , [FromQuery] string collectionId)
        {
            return await _mediator.Send(new GetTodosQuery(pageRequest , collectionId));
        }

    }
}
