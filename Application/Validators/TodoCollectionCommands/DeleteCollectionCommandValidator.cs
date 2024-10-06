using Application.Features.TodoCollections.Commands;
using FluentValidation;

namespace Application.Validators.TodoCollectionCommands;

public class DeleteCollectionCommandValidator : AbstractValidator<DeleteCollectionCommand>
{
    public DeleteCollectionCommandValidator()
    {
        RuleFor(x => x.CollectionId)
            .NotEmpty().WithMessage("Todo collection id cannot be empty.")
            .NotNull().WithMessage("Todo collection id cannot be null.");
    }
}