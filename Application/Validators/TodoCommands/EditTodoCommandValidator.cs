using Application.Features.Todos.Commands;
using Application.Validators.Dtos;
using FluentValidation;

namespace Application.Validators.TodoCommands;

public class EditTodoCommandValidator : AbstractValidator<EditTodoCommand>
{
    public EditTodoCommandValidator()
    {
        RuleFor(x => x.Todo)
            .SetValidator(new SubmitTodoRequestValidator());
        
        RuleFor(x => x.TodoId)
            .NotEmpty().WithMessage("Todo collection id cannot be empty.")
            .NotNull().WithMessage("Todo collection id cannot be null.");
    }
}