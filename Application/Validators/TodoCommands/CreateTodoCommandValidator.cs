using Application.Features.Todos.Commands;
using Application.Validators.Dtos;
using FluentValidation;

namespace Application.Validators.TodoCommands;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(x => x.Todo)
            .SetValidator(new SubmitTodoRequestValidator());
    }
}