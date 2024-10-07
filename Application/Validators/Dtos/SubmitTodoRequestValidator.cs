using System.Data;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Validators.Dtos;

public class SubmitTodoRequestValidator : AbstractValidator<Application.Dtos.Todo.SubmitTodoRequest>
{
    public SubmitTodoRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .NotNull().WithMessage("Title cannot be null.")
            .Length(1, 150).WithMessage("Title must be between 3 and 50 characters.");

        RuleFor(x => x.Content)
            .Length(1, 1000).WithMessage("Content cannot be between 1 and 1000 characters.");

        RuleFor(x => x.DueDate)
            .GreaterThan(DateTime.UtcNow);

    }
}