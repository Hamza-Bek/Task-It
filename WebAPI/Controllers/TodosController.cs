using Domain.Models;
using Infrastructure.Features.Queries;
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


        // GET: api/<TodosController>
        [HttpGet]        
        public async Task<List<Todo>> Get()
        {
            return await _mediator.Send(new GetAllTodosQuery());
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public async Task<Todo> GetTodo(string id)
        {
            return await _mediator.Send(new GetTodosQuery(id));
        }
      
    }
}
