using Application.Features.Todos.Commands;
using FluentValidation;

namespace Application.Validators.TodoCommands;

public class DeleteTodoCommandValidator : AbstractValidator<DeleteTodoCommand>
{
    public DeleteTodoCommandValidator()
    {
        RuleFor(x => x.TodoId)
            .NotEmpty().WithMessage("Todo id cannot be empty.")
            .NotNull().WithMessage("Todo id cannot be null.");
    }
}